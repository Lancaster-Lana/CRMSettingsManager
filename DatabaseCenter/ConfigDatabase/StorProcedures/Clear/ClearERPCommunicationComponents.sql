  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ClearERPCommunicationComponents')
	BEGIN
		DROP  Procedure  ClearERPCommunicationComponents
	END

GO

CREATE Procedure ClearERPCommunicationComponents
AS
	DELETE
	FROM ERPCommunicationComponent

GO 