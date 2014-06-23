 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetERPCommunicationComponents')
	BEGIN
		DROP  Procedure  GetERPCommunicationComponents
	END
GO

CREATE Procedure GetERPCommunicationComponents
AS
	SELECT
	    Name	varchar(100),
	    ErpHost	varchar(50),		
		ErpPort	int,		
		InactivityTimeOut int
	FROM
		ERPCommunicationComponent

GO  