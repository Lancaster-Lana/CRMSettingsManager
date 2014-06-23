 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetCRMCommunicatorById')
	BEGIN
		DROP  Procedure  GetCRMCommunicatorById
	END

GO

CREATE Procedure GetCRMCommunicatorById
	@ID	int
AS
	SELECT
		CRMHost,
		CRMPort
	FROM
		CRMCommunicator
	WHERE
		ID = @ID

GO