USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[select_sellers_as_strings]    Script Date: 10/28/2023 11:23:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[select_sellers_as_strings] ******/

-- =============================================
-- Author:		Keith Frantz
-- Create date: 1 July 2023
-- Description:	Given optional id, first_nname, and last_name filter parameters,
--              return the qualifying records from the seller table, id and
--              id, salutation, first_name, middle_name, last_name, and suffix in a
--              single string, sname (which will be used to choose a particular seller)
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_sellers_as_strings] 
	-- Add the parameters for the stored procedure here
	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT id, CAST(id AS nvarchar) + ' - ' + 
		IIF(LEN(salutation) > 0, salutation + ' ', '') + --LEN(NULL) is NULL and NULL > 0 is false
		-- trims below added in case row delimiter when importing is {LF} instead of {CR}{LF} as it should be,
		-- and thus the first name (or the last name, whichever ends the row) has a carriage return appended to it
		trim(char(13) FROM first_name) + ' ' + -- first_name is guaranteed not to be null/blank
		IIF(LEN(middle_name) > 0, middle_name + ' ', '') +
		trim(char(13) FROM last_name) + ' ' + -- last_name is guaranteed not to be null/blank
		IIF(LEN(suffix) > 0, ' ' + suffix + ' ', '') as sname
		FROM seller
		WHERE (id = @id or @id IS NULL)
			AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
			AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
END
