IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AddERPCommunicationComponent')
	BEGIN
		DROP  Procedure  AddERPCommunicationComponent
	END
GO

CREATE Procedure AddERPCommunicationComponent
	@Name	varchar(100),
    @ErpHost	varchar(50),
	@ErpPort	int,
	@InactivityTimeOut int
AS
	INSERT INTO ERPCommunicationComponent
	(
			Name,
			ErpHost,
			ErpPort,
			InactivityTimeOut 
	)
	VALUES
	(
		@Name,
		@ErpHost,
		@ErpPort,
		@InactivityTimeOut
	) 

GO   