USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_sales]    Script Date: 7/14/2023 10:59:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 14 July 2023
-- Description:	Given when_sold, number of items, and total sale amount (min and max for all these)
--              and sale ID optional filter parameters, return the qualifying records from the sale
--              table plus the calculated number of items in the sale and the total sale amount,
--              and the information about each item (item_id, quantity, and amount) as trios of
--              comma-separated numbers.  The item short descriptions are not included since they
--              could contain commas (or any other delimiter character that might alternatively
--              be used instead of a comma).  Instead the descriptions will be gotten from the 
--              item table as required by the calling program.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_sales]
	@when_sold_min datetime = NULL,
	@when_sold_max datetime = NULL,
	@no_items_min int = NULL,
	@no_items_max int = NULL,
	@sale_amount_min decimal = NULL,
	@sale_amount_max decimal = NULL,
	@id int = NULL
AS 
BEGIN
	DECLARE @result TABLE (id int NOT NULL, 
	                       when_sold datetime,
	                       num_items int,
	                       sale_amount decimal(7,2),
	                       tendered decimal(7,2),
	                       items nvarchar(max)) 
	DECLARE @sale_id int, @items nvarchar(max), @item_id int, @quantity int, @amount decimal
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Start by inserting all the fields to be returned except items in a table variable
	WITH no_items_cte (id, num_items)
	AS 
	(
		SELECT sale_id, COUNT(item_id) AS num_items FROM sale_item GROUP BY sale_id
	)
	INSERT INTO @result SELECT s.id, s.when_sold, num_items, (s.tendered - s.[change]) AS sale_amount, s.tendered, '' AS items
		FROM sale s JOIN no_items_cte nic ON s.id = nic.id
		WHERE (s.id = @id or @id IS NULL)
			AND (when_sold >= @when_sold_min OR @when_sold_min IS NULL)
			AND (when_sold <= @when_sold_max OR @when_sold_max IS NULL)
			AND (num_items >= @no_items_min OR @no_items_min IS NULL)
			AND (num_items <= @no_items_max OR @no_items_max IS NULL)
			AND ((s.tendered - s.[change]) >= @sale_amount_min OR @sale_amount_min IS NULL)
			AND ((s.tendered - s.[change]) <= @sale_amount_max OR @sale_amount_max IS NULL)
			AND s.superseded = 0 -- Exclude superseded sales
		ORDER BY s.id
	-- Then go through the table and create the items string for each sale
	DECLARE sale_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT id, items FROM @result FOR UPDATE OF items
	OPEN sale_cur
	FETCH NEXT FROM sale_cur INTO @sale_id, @items
	WHILE @@FETCH_STATUS = 0 BEGIN

		DECLARE sale_item_cur CURSOR LOCAL FAST_FORWARD FOR
			SELECT item_id, quantity, amount FROM sale_item WHERE sale_id = @sale_id AND superseded = 0 ORDER BY id
		OPEN sale_item_cur
		FETCH NEXT FROM sale_item_cur INTO @item_id, @quantity, @amount
		WHILE @@FETCH_STATUS = 0 BEGIN
			SELECT @items = @items + CAST(@item_id AS nvarchar) + ',' + CAST(@quantity AS nvarchar) + ',' + CAST(@amount AS nvarchar) + ','
			FETCH NEXT FROM sale_item_cur INTO @item_id, @quantity, @amount
		END
		CLOSE sale_item_cur
		DEALLOCATE sale_item_cur
		-- Remove final comma
		SELECT @items = LEFT(@items, LEN(@items) - 1)
		UPDATE @result SET items = @items WHERE CURRENT OF sale_cur
		FETCH NEXT FROM sale_cur INTO @sale_id, @items
	END
	CLOSE sale_cur
	DEALLOCATE sale_cur
	SELECT * FROM @result -- Return the @result table's contents to the caller
END
