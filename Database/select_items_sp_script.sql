USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_items]    Script Date: 9/3/2023 2:00:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[select_items] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 15 August 2023
-- Description:	Given optional id, short_description, and seller_id filter 
--              parameters, return the qualifying records from the item table 
--              as distinct fields, including (from the sale_item table) the 
--              number sold, and (from the price table) the pricing as a series
--              of comma-separated quantity break and price values, i.e. 
--              quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_items]
	@id int = NULL, @short_description nvarchar(40) = NULL, @seller_id int = NULL
AS 
BEGIN
	DECLARE @result TABLE (id int NOT NULL,
	                       seller_id int NOT NULL,
	                       short_description nvarchar(40)NOT NULL,
	                       long_description nvarchar(1000) NULL,
	                       location_id int NULL,
	                       [description] nvarchar(20) NULL, -- This is the location description since the location_id is meaningless to a user
	                       quantity_at_start int NOT NULL,
	                       num_sold int NOT NULL,
	                       quantity_returned int NULL,
	                       pricing nvarchar(1000))
	DECLARE @item_id int, @pricing nvarchar(1000), @price decimal(7,2), @quantity int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Fill @result with everything but the pricing column
	INSERT INTO @result 
		SELECT i.id AS item_id,
		       i.seller_id,
		       i.short_description,
		       i.long_description,
		       COALESCE(i.location_id, 0),
		       l.[description],
		       quantity_at_start,
		       COALESCE(SUM(quantity),0) AS num_sold,
		       quantity_returned,
		       '' AS pricing  
		FROM item i
			LEFT JOIN sale_item si on i.id = si.item_id AND (superseded = 0 OR superseded IS NULL)
			LEFT JOIN location l on i.location_id = l.id
		WHERE (i.id = @id OR @id IS NULL)
			AND (short_description LIKE '%' + @short_description + '%' OR @short_description IS NULL)
			AND (seller_id = @seller_id OR @seller_id IS NULL)
		GROUP BY i.id,
		         i.seller_id,
		         i.short_description,
		         i.long_description,
		         i.location_id,
		         l.[description],
		         quantity_at_start,
		         quantity_returned
		ORDER BY i.id
	-- Then go through the table and create the pricing string for each item
	DECLARE item_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT id, pricing FROM @result FOR UPDATE OF pricing
	OPEN item_cur
	FETCH NEXT FROM item_cur INTO @item_id, @pricing
	WHILE @@FETCH_STATUS = 0 BEGIN
		DECLARE price_cur CURSOR LOCAL FAST_FORWARD FOR
			SELECT quantity_break, price FROM price WHERE item_id = @item_id ORDER BY quantity_break
		OPEN price_cur
		FETCH NEXT FROM price_cur INTO @quantity, @price
		WHILE @@FETCH_STATUS = 0 BEGIN
			SELECT @pricing = @pricing + CAST(@quantity AS nvarchar) + ','+ CAST(@price AS nvarchar) + ',' 
			FETCH NEXT FROM price_cur INTO @quantity, @price
		END
		CLOSE price_cur
		DEALLOCATE price_cur
		-- Remove final comma
		SELECT @pricing = LEFT(@pricing, LEN(@pricing) - 1)
		UPDATE @result SET pricing = @pricing WHERE CURRENT OF item_cur
		FETCH NEXT FROM item_cur INTO @item_id, @pricing
	END
	CLOSE item_cur
	DEALLOCATE item_cur
	SELECT * FROM @result ORDER BY id -- Return the @result table's contents to the caller
END
