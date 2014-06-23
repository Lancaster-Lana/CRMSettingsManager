 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateERPCommunicationComponent')
	BEGIN
		DROP  Procedure  UpdateERPCommunicationComponent
	END

GO

CREATE Procedure UpdateERPCommunicationComponent
		@ID	int,
		@Name	varchar(100),
		@ErpHost	varchar(50),
		@ErpPort	int,
		@InactivityTimeOut int
AS
	UPDATE
		ERPCommunicationComponent
	SET
		Name = @Name,
		ErpHost = @ErpHost,
		ErpPort = @ErpPort,
		InactivityTimeOut = @InactivityTimeOut
	WHERE
		ID = @ID

GO