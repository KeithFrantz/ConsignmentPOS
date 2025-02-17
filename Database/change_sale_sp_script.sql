USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[change_sale]    Script Date: 9/3/2023 11:01:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[change_sale] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 26 July 2023
-- Description:	Creates a new sale with the modified information, and  
--              supersedes the old sale and all its items.  Sets superseding_id  
--              for the old sale to the id of the new sale.  It does this in a  
--              transaction so all succeed or fail.  Returns (via a final 
--              SELECT) 0 if successful, 5 if no sale items were inserted, 6 if
--              @sale_items is malformed, or @@ERROR number for other errors.
--              (5 and 6 are not used for any internal errors in SQL Server
--              2019 or 2022.)  If unsuccessful for any reason @new_id is 
--              returned as 0, which is not a valid sale id, as that identity 
--              is 1-based.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_sale]
	@id int, -- The id of the sale to be superseded
	@when_sold datetime,
	@tendered decimal(7,2),
	@change decimal(7,2),
	@sale_items nvarchar(1000), -- way longer than it'd ever practically be
	@new_id int OUT
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), 
		@start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0,
		@action_and_item nvarchar(20), -- Item_id possibly preceded by I:, C:, or D:
		@delete_item bit
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO sale (tendered, [change], when_sold, superseded, last_edit_at) 
			VALUES (@tendered, @change, @when_sold, 0, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	SELECT @new_id = @@IDENTITY
	BEGIN TRY
		UPDATE sale SET superseded = 1, superseding_id = @new_id, last_edit_at = @now WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	BEGIN TRY
		UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	-- Parse @sale_items and create a record for each number trio
	-- Note that unlike in insert_sale, there may be a letter and a colon before
	-- the item_id value, and if it's D, don't insert tthis item
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	-- if the @sale_items parameter is malformed (has no commas or starts with one) abort
	IF @next_comma < 2 BEGIN
		ROLLBACK TRAN
		SELECT @new_id = 0
		SELECT 6
		RETURN
	END
	WHILE @done = 0 BEGIN
		SELECT @delete_item = 0 -- Assume the item isn't being deleted
		SELECT @action_and_item = SUBSTRING(@sale_items, @start, @next_comma - @start)
		IF CHARINDEX (':' , @action_and_item) != 0 BEGIN
			IF LEFT(@action_and_item, 1) =  'D' SELECT @delete_item = 1 -- unless it is
			SELECT @item_id = CAST(SUBSTRING(@action_and_item, 3, LEN(@action_and_item) - 1) AS int)
			END
		ELSE SELECT @item_id = CAST(@action_and_item AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed 
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT 6
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
			IF @next_comma < 1 BEGIN -- If there's no comma following the next item_id in @@sale_items abort
				ROLLBACK TRAN
				SELECT @new_id = 0
				SELECT 6
				RETURN
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value 
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) -- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		IF @delete_item = 0 BEGIN
			BEGIN TRY
				INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@new_id, @item_id, @quantity, @amount, 0, @now)
				SELECT @num_sale_item_rows = @num_sale_item_rows + 1
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @new_id = 0
					SELECT @error
					RETURN
				END
			END CATCH
		END
	END
	IF @num_sale_item_rows = 0 BEGIN -- If all the items were deleted from a sale, that's not allowed
		ROLLBACK TRAN
		SELECT @new_id = 0
		SELECT 5
		RETURN
	END
	COMMIT TRAN
	SELECT 0
	RETURN
END
