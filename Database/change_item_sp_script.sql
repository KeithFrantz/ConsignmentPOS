USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[change_item]    Script Date: 8/22/2023 8:44:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Updates an existing item in the item table and its associated
--              pricing information (which is passed as a string of pairs of 
--              numbers - quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN) in the price table.  This is all done
--              in a transaction so it all succeeds or fails.  It returns 0
--              if successful, 3 if no new price records were created, or an
--              error code if there was an error (there is no error code 3).
--              quantity_returned, amount_paid, and commission are not updated
--              by this SP as the Change Existing Items screen, that is the only 
--              screen wherein this is called, doesn't allow changes to items 
--              for which settlement has been made.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_item]
	@id int,
	@seller_id int,
	@short_description nvarchar(40),
	@long_description nvarchar(1000),
	@location_id int,
	@quantity_at_start int,
	@pricing nvarchar(1000) -- way longer than it'd ever practically be
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_price_rows int = 0, 
		@quantity_break int, @price decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	BEGIN TRAN
	BEGIN TRY
		IF @location_id = 0 -- The null location is coded as 0 in the location dropdown but there's no entry o in the location table
			UPDATE item SET 
				seller_id = @seller_id, 
				short_description = @short_description, 
				long_description = @long_description, 
				location_id = NULL, 
				quantity_at_start = @quantity_at_start,
				last_edit_at = @now
				WHERE id = @id
		ELSE
			UPDATE item SET 
				seller_id = @seller_id, 
				short_description = @short_description, 
				long_description = @long_description, 
				location_id = @location_id, 
				quantity_at_start = @quantity_at_start,
				last_edit_at = @now
				WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	BEGIN TRY
		DELETE FROM price WHERE item_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	-- Parse @pricing and create a record for each number pair
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
			IF @error <> 0  BEGIN
				ROLLBACK TRAN
				RETURN @error
			END
		END CATCH
		SELECT @num_price_rows = @num_price_rows + 1
	END
	IF @num_price_rows = 0 BEGIN -- If no rows were inserted into the price table, this is not allowed - every item must have at least one price
		ROLLBACK TRAN
		RETURN 3 -- There was no error but neither was a new item inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
