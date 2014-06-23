 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ClearCRMCommunicators')
	BEGIN
		DROP  Procedure  ClearCRMCommunicators
	END

GO

CREATE Procedure ClearCRMCommunicators
AS
	DELETE
	FROM CRMCommunicator

GO