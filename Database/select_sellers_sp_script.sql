USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_sellers]    Script Date: 8/23/2023 11:06:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 1 July 2023
-- Description:	Given optional id, first_name, and last_name filter parameters,
--              and a logical field specifying whether to exclude potential sellers,
--              return the qualifying records from the seller table as distinct fields
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_sellers]
	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL, @actual_sellers bit = 0
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @actual_sellers = 0
		SELECT salutation, first_name, middle_name, last_name, suffix, address_1, address_2, post_office, [state], postal_code, country, phone_1, phone_2, email, member_id, id
			FROM seller
			WHERE (id = @id or @id IS NULL)
				AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
				AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
	ELSE
		WITH distinct_seller_ids AS (SELECT DISTINCT seller_id FROM item)
		SELECT salutation, first_name, middle_name, last_name, suffix, address_1, address_2, post_office, [state], postal_code, country, phone_1, phone_2, email, member_id, id
			FROM seller JOIN distinct_seller_ids on id = seller_id
			WHERE (id = @id or @id IS NULL)
				AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
				AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
END
