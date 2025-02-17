USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_item_price]    Script Date: 9/3/2023 11:46:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[select_item_price] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 5 July 2023
-- Description:	Given the item_id and quantity proposed for a sale,
--              return the quantity of that item that should remain
--              and the price appropriate for that quantity.  It is
--              up to the caller how to respond if the remaining
--              quantity is less than the quantity proposed for sale.
--              This SP does not try to handle the case of an invalid
--              item_id because the program calling it has already
--              validated the item_id, and won't let this SP be called
--              with an invalid value.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_item_price]
	@item_id int, @quantity int
AS 
BEGIN
	DECLARE @qty_left int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT @qty_left = MAX(quantity_at_start) - SUM(COALESCE(si.quantity,0)) -- Need to use COALESCE because there might not yet be any sale_item records for this item
		FROM item i LEFT JOIN sale_item si ON i.id = si.item_id AND (si.superseded = 0 OR si.superseded IS NULL)
		WHERE i.id = @item_id 
	SELECT TOP 1 price, @qty_left AS qty_left FROM price WHERE item_id = @item_id AND quantity_break <= @quantity ORDER BY quantity_break DESC
END
