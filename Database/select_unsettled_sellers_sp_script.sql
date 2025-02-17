USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_unsettled_sellers]    Script Date: 8/5/2023 9:45:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 5 August 2023
-- Description:	Given optional id, first_name, and last_name filter parameters,
--              return the qualifying records from the seller table for which
--              there are items for which quantity_returned is null
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_unsettled_sellers]
	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT DISTINCT s.id, salutation, TRIM(char(13) FROM first_name) AS first_name, middle_name, TRIM(char(13) FROM last_name) AS last_name, suffix
		FROM seller s JOIN item i ON s.id = i.seller_id -- inner join prevents returning potential sellers
		WHERE (s.id = @id or @id IS NULL)
			AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
			AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
			AND quantity_returned IS NULL
		ORDER BY s.id
END
