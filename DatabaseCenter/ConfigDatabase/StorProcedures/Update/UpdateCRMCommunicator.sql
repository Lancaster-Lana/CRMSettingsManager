IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateCRMCommunicator')
	BEGIN
		DROP  Procedure  UpdateCRMCommunicator
	END

GO

CREATE Procedure UpdateCRMCommunicator
    @ID	int,
	@CRMHost	varchar(100),
	@CRMPort	int	
AS
	UPDATE
		CRMCommunicator
	SET
		CRMHost=@CRMHost,
		CRMPort=@CRMPort
	WHERE
		ID = @ID

GO
 