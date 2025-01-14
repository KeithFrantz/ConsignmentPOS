USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[insert_sale]    Script Date: 7/26/2023 2:33:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Inserts a new sale into the sale table and its associated
--              sale_items information (which is a string of trios of numbers -
--              item_id1,quantity1,amount1,item_id2,quantity2,amount2,...,
--              item_idN,quantityN,amountN) into the sale_item table.  This is all 
--              done in a transaction so it all succeeds or fails.  It outputs the
--              sale's id in @id if successful, or 0 if unsuccessful.  Note that
--              superseded is false for both tables and superseding_id is null 
--              for the sale table since it's a new sale, not a change to an 
--              existing one.  When_sold is filled in by this SP.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[insert_sale]
	@tendered decimal(7,2),
	@change decimal(7,2),
	@sale_items nvarchar(1000), -- way longer than it'd ever practically be
	@id int OUT
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	SELECT @now = DATETIMEFROMPARTS (DATEPART(year, @now), 
	                                 DATEPART(month, @now), 
	                                 DATEPART(day, @now), 
	                                 DATEPART(hour, @now), 
	                                 DATEPART(minute, @now),
	                                 0,0) -- Truncate seconds and milliseconds as Change Sale doesn't allow them to be entered
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO sale (tendered, [change], when_sold, superseded, last_edit_at) 
			VALUES (@tendered, @change, @now, 0, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN @error
		END
	END CATCH
	-- Parse @sale_items and create a record for each number trio
	SELECT @id = @@IDENTITY
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	IF @next_comma < 2 SELECT @done = 1 -- if the @sale_items parameter is malformed (has no commas or starts with one) don't try to create sale_item records
	WHILE @done = 0 BEGIN
		SELECT @item_id = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed so quit writing to sale_item
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
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
				SELECT @id = 0
				RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value 
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) -- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		BEGIN TRY
			INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@id, @item_id, @quantity, @amount, 0, @now)
			SELECT @num_sale_item_rows = @num_sale_item_rows + 1
		END TRY
		BEGIN CATCH
			SELECT @error = @@ERROR
			IF @error <> 0 BEGIN
				ROLLBACK TRAN
				SELECT @id - 0
				RETURN @error
			END
		END CATCH 
	END
	IF @num_sale_item_rows = 0 BEGIN -- If no rows were inserted into the sale_item table, this is not allowed - every sale must have at least one item
		ROLLBACK TRAN
		SELECT @id = 0
		RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
