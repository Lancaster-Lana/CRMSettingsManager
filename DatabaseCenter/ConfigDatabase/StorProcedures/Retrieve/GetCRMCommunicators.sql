 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCRMCommunicators')
	BEGIN
		DROP  Procedure  GetCRMCommunicators
	END

GO

CREATE Procedure GetCRMCommunicators
AS
	SELECT
		CRMHost,
		CRMPort
	FROM
		CRMCommunicator


GO 