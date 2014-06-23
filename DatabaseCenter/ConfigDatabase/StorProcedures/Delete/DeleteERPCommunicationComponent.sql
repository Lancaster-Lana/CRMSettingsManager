 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteERPCommunicationComponent')
	BEGIN
		DROP  Procedure DeleteERPCommunicationComponent
	END

GO

CREATE Procedure DeleteERPCommunicationComponent
	@ID	int
AS
	DELETE
	FROM ERPCommunicationComponent
WHERE
		ID = @ID
GO  