 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteERPCommunicator')
	BEGIN
		DROP  Procedure DeleteERPCommunicator
	END

GO

CREATE Procedure DeleteERPCommunicator
	@ID	int
AS
	DELETE
	FROM ERPCommunicator
WHERE
		ID = @ID
GO  