USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[insert_item]    Script Date: 8/7/2023 10:40:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Inserts a new item into the item table and its associated
--              pricing information (which is a string of pairs of numbers -
--              quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN) into the price table.  This is all done
--              in a transaction so it all succeeds or fails.  It outputs the
--              item's id in @id if successful, or 0 if unsuccessful.  Note that
--              quantity_returned, amount_paid, and commission are all null
--              (not 0) for a new item.  These are only entered upon
--              settlement with the seller.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[insert_item]
	@seller_id int,
	@short_description nvarchar(40),
	@long_description nvarchar(1000),
	@location_id int,
	@quantity_at_start int,
	@pricing nvarchar(1000), -- way longer than it'd ever practically be
	@id int OUT
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_price_rows int = 0, 
		@quantity_break int, @price decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO item (seller_id, short_description, long_description, location_id, quantity_at_start, last_edit_at) 
			VALUES (@seller_id, @short_description, @long_description, @location_id, @quantity_at_start, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN @error
		END
	END CATCH
	-- Parse @pricing and create a record for each number pair
	SELECT @id = @@IDENTITY
	SELECT @next_comma = CHARINDEX(',', @pricing, @start)
	IF @next_comma < 2 SELECT @done = 1 -- @if the @pricing parameter is malformed (has no commas or starts with one) don't try to create price records
	WHILE @done = 0 BEGIN
		--SELECT @length = @next_comma - @start
		SELECT @quantity_break = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @pricing, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @price = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next quantity_break value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @pricing, @start)
			IF @next_comma < 1 SELECT @done = 1 -- If there's no comma following the next quantity_break in @pricing stop here
		END
		ELSE BEGIN -- At the end of @pricing, handling the last price value 
			SELECT @price = CAST(SUBSTRING(@pricing, @start, LEN(@pricing) + 1 - @start) AS decimal(7,2)) -- LEN(@pricing) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		BEGIN TRY
			INSERT INTO price (item_id, quantity_break, price, last_edit_at) VALUES (@id, @quantity_break, @price, @now)
		END TRY
		BEGIN CATCH
			SELECT @error = @@ERROR
			IF @error <> 0 BEGIN
				ROLLBACK TRAN
				SELECT @id - 0
				RETURN @error
			END
		END CATCH
		SELECT @num_price_rows = @num_price_rows + 1
	END
	IF @num_price_rows = 0 BEGIN -- If no rows were inserted into the price table, this is not allowed - every item must have at least one price
		ROLLBACK TRAN
		SELECT @id = 0
		RETURN 0 -- There was no error but neither was a new item inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
