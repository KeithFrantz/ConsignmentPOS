USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_actual_sellers_as_strings]    Script Date: 8/15/2023 5:10:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 15 August 2023
-- Description:	Return the id and id, salutation, first_name, middle_name,
--              last_name, and suffix in a single string, sname, for all
--              actual sellers (sellers having an item referencing them)
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_actual_sellers_as_strings] 
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.id, CAST(s.id AS nvarchar) + ' - ' + 
		IIF(LEN(salutation) > 0, salutation + ' ', '') + --LEN(NULL) is NULL and NULL > 0 is false
		first_name + ' ' +-- first_name is guaranteed not to be null/blank
		IIF(LEN(middle_name) > 0, middle_name + ' ', '') +
		last_name + -- last_name is guaranteed not to be null/blank
		IIF(LEN(suffix) > 0, ' ' + suffix + ' ', '') as sname
		FROM seller s JOIN item i on s.id = i.seller_id
	UNION
	SELECT 0 AS id, '' AS sname
	ORDER BY id
END
