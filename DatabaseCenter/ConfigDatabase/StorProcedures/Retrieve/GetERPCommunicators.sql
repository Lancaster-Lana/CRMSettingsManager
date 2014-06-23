 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetERPCommunicators')
	BEGIN
		DROP  Procedure  GetERPCommunicators
	END
GO

CREATE Procedure GetERPCommunicators
AS
	SELECT
		CRMHost,
		CRMPort
	FROM
		ERPCommunicator

GO  