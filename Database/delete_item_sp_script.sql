USE [CoStore]
GO
/****** Object:  StoredProcedure [dbo].[delete_item]    Script Date: 8/19/2023 11:36:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Keith Frantz
-- Create date: 19 August 2023
-- Description:	Deletes an item from the item table and its associated
--              price records.  Returns 0 if successful, or the error
--              code if there was an error.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[delete_item]
	@id int 
AS
BEGIN
	DECLARE @error int
	BEGIN TRAN
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
	BEGIN TRY
		DELETE FROM item WHERE id  = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	COMMIT TRAN
	RETURN 0
END
