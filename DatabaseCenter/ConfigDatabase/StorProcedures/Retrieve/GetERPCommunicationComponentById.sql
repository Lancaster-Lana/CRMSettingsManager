 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetERPCommunicationComponentById')
	BEGIN
		DROP  Procedure  GetERPCommunicationComponentById
	END
GO

CREATE Procedure GetERPCommunicationComponentById
	@ID	int
AS
	SELECT
	    Name	varchar(100),
	    ErpHost	varchar(50),		
		ErpPort	int,		
		InactivityTimeOut int
	FROM
		ERPCommunicationComponent
	WHERE
		ID = @ID

GO  