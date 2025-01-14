USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_unsettled_items]    Script Date: 8/5/2023 9:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 7 August 2023
-- Description:	Given the ID of a seller, find all the items for which have 
--              a null value in the quantity_returned column. These
--              are the items which yet require settlement.  The returned
--              fields are the item_id, short_description, (location)
--              description, quantity_at_start, (total) num_sold (sum of
--              sale_item.quantity), (total) sales_amount (sum of sale_item.
--              amount), and a pricing field consisting of comma-separated
--              pairs of comma-separated price and quantity values.  These are
--              from the sale_item table, not the price table, meaning they are
--              actual values representing the pricing that was in effect at 
--              the time of the sale, unless there were no sales.  If so the 
--              highest price entry in the price table for that item is used
--              to get the unit price.  Otherwise the price is amount divided 
--              by quantity.   They are aggregated by price, and the quantity 
--              portion is the sum of the quantity fields for a given price.  
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_unsettled_items]
	@id int 
AS 
BEGIN
	DECLARE @result TABLE (item_id int NOT NULL,
	                       short_description nvarchar(40),
	                       [description] nvarchar(20),
	                       quantity_at_start int,
	                       num_sold int,
	                       sales_amount decimal(7,2),
	                       pricing nvarchar(1000))
	DECLARE @item_id int, @pricing nvarchar(1000), @price decimal(7,2), @num_sold int, @num_sold_at_price int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Fill @result with everything but the pricing column
	INSERT INTO @result 
		SELECT i.id AS item_id,
		       i.short_description,
		       l.[description],
		       quantity_at_start,
		       COALESCE(SUM(quantity),0) AS num_sold,
		       COALESCE(SUM(amount),0) AS sales_amount,
		       '' AS pricing  
		FROM item i
			JOIN seller s ON i.seller_id = s.id
			LEFT JOIN sale_item si on i.id = si.item_id
			LEFT JOIN location l on i.location_id = l.id
		WHERE (superseded = 0 OR superseded IS NULL)
			AND seller_id = @id
			AND quantity_returned IS NULL
		GROUP BY i.id,
		       i.short_description,
			   l.[description],
			   quantity_at_start
		ORDER BY i.id
	-- Then go through the table and create the pricing string for each item
	DECLARE item_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT item_id, num_sold, pricing FROM @result FOR UPDATE OF pricing
	OPEN item_cur
	FETCH NEXT FROM item_cur INTO @item_id, @num_sold, @pricing
	WHILE @@FETCH_STATUS = 0 BEGIN
		IF @num_sold = 0 BEGIN
			SELECT TOP 1 @price = price FROM price WHERE item_id = @item_id ORDER BY quantity_break
			SELECT @pricing = CAST(@price AS nvarchar) + ',0'
		END
		ELSE BEGIN
			DECLARE price_cur CURSOR LOCAL FAST_FORWARD FOR
				SELECT amount/quantity AS price, SUM(quantity) AS num_sold_at_price 
					FROM sale_item si JOIN item i on si.item_id = i.id
					WHERE superseded = 0 AND item_id = @item_id
					GROUP BY amount/quantity
					ORDER BY amount/quantity DESC
			OPEN price_cur
			FETCH NEXT FROM price_cur INTO @price, @num_sold_at_price
			WHILE @@FETCH_STATUS = 0 BEGIN
				SELECT @pricing = @pricing + CAST(@price AS nvarchar) + ',' + CAST(@num_sold_at_price AS nvarchar) + ','
				FETCH NEXT FROM price_cur INTO @price, @num_sold_at_price
			END
			CLOSE price_cur
			DEALLOCATE price_cur
			-- Remove final comma
			SELECT @pricing = LEFT(@pricing, LEN(@pricing) - 1)
		END
		UPDATE @result SET pricing = @pricing WHERE CURRENT OF item_cur
		FETCH NEXT FROM item_cur INTO @item_id, @num_sold, @pricing
	END
	CLOSE item_cur
	DEALLOCATE item_cur
	SELECT * FROM @result -- Return the @result table's contents to the caller
END
