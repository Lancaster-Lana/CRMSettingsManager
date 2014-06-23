  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ClearERPCommunicators')
	BEGIN
		DROP  Procedure  ClearERPCommunicators
	END

GO

CREATE Procedure ClearERPCommunicators
AS
	DELETE
	FROM ERPCommunicator

GO