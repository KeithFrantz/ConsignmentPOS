USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[change_sale_items]    Script Date: 7/27/2023 4:26:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 27 July 2023
-- Description:	Handles changes to the items ina sale that don't result in a 
--              change to the sale itself.  Supersedes deleted and changed 
--              items, and creates new sale_item records for changed items
--              with the new information as well as for inserted items.  It  
--              does this in a transaction so all succeed or fail.  Returns 
--              (via a final SELECT) 0 if successful, 1 if the @sale_items 
--              string was malformed, or @@ERROR number for other errors.
--              (1 is not used for any internal errors in SQL Server 2019 
--              or 2022)
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_sale_items]
	@id int, -- The id of the sale whose items are to be altered
	@sale_items nvarchar(1000) -- way longer than it'd ever practically be
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), @row_count int = 0, 
		@start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0,
		@action_and_item nvarchar(20), -- item_id possibly preceded by I:, C:, or D:
		@action nvarchar(1) -- D = delete, C = change, I = insert, empty = no action
	BEGIN TRAN
	-- Parse @sale_items and do the appropriate action for each number trio 
	-- preceded by D:, C:, or I:
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	-- if the @sale_items parameter is malformed (has no commas or starts with one)
	-- don't try to modify sale_item records
	IF @next_comma < 2 BEGIN
		ROLLBACK TRAN -- Nothing to roll back yet but shouldn't leave transaction open
		SELECT 1
		RETURN
	END
	WHILE @done = 0 BEGIN
		-- Assume no action for each item unless a letter and a colon prefix the trio
		SELECT @action = ''
		SELECT @action_and_item = SUBSTRING(@sale_items, @start, @next_comma - @start)
		IF CHARINDEX (':' , @action_and_item) != 0 BEGIN
			SELECT @action = LEFT(@action_and_item, 1)
			SELECT @item_id = CAST(SUBSTRING(@action_and_item, 3, LEN(@action_and_item) - 1) AS int)
		END
		ELSE SELECT @item_id = CAST(@action_and_item AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed 
			ROLLBACK TRAN
			SELECT 1
			RETURN
		END
		SELECT @quantity = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next item_id value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
			IF @next_comma < 1 BEGIN -- If there's no comma following the next item_id in @sale_items is malformed
				ROLLBACK TRAN
				SELECT 1 
				RETURN
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value
			-- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) 
			SELECT @done = 1
		END
		IF @action = 'D' OR @action = 'C' BEGIN -- "Delete" the existing item (mark it as superseded)
			BEGIN TRY
				UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id AND item_id = @item_id AND superseded = 0
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @error
					RETURN
				END
			END CATCH
		END
		IF @action = 'I' OR @action = 'C' BEGIN -- Create a new sale_item record
			BEGIN TRY
				INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@id, @item_id, @quantity, @amount, 0, @now)
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @error
					RETURN
				END 
			END CATCH
		END
	END
	COMMIT TRAN
	SELECT 0
	RETURN 
END