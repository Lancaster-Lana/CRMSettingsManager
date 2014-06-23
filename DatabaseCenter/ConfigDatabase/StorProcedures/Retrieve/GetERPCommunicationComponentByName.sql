 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetERPCommunicationComponentByName')
	BEGIN
		DROP  Procedure  GetERPCommunicationComponentByName
	END
GO

CREATE Procedure GetERPCommunicationComponentByName
	@Name	varchar(100)
AS
	SELECT
	    Name	varchar(100),
	    ErpHost	varchar(50),		
		ErpPort	int,		
		InactivityTimeOut int
	FROM
		ERPCommunicationComponent
	WHERE
		Name = @Name

GO 