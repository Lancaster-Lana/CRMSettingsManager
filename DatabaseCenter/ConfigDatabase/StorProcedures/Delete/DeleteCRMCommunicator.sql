 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteCRMCommunicator')
	BEGIN
		DROP  Procedure  DeleteCRMCommunicator
	END

GO

CREATE Procedure DeleteCRMCommunicator
	@ID	int
AS
	DELETE
	FROM CRMCommunicator
WHERE
		ID = @ID
GO 