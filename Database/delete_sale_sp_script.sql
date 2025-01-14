USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[delete_sale]    Script Date: 7/26/2023 10:31:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 26 July 2023
-- Description:	Marks a sale and all its items as superseded but with no 
--              superseding_id for the sale.  Also updates all the last_edit_at 
--              fields of the affected rows.  It does this in a transaction so 
--              all succeed or fail.  Returns via a final SELECT 0 if  
--              successful, or @@ERROR number if there's an  error.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[delete_sale]
	@id int
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), @row_count int = 0
	BEGIN TRAN
	BEGIN TRY
		UPDATE sale SET superseded = 1, last_edit_at = @now WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @error
			RETURN 
		END
	END CATCH
	BEGIN TRY
		UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @error
			RETURN 
		END
	END CATCH
	COMMIT TRAN
	SELECT 0
	RETURN
END
