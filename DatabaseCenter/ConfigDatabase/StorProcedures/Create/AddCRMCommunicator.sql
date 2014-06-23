IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AddCRMCommunicator')
	BEGIN
		DROP  Procedure  AddCRMCommunicator
	END
GO

CREATE Procedure AddCRMCommunicator
	@CRMHost	varchar(100),
	@CRMPort	int	
AS
	INSERT INTO CRMCommunicator
	(
		CRMHost,
		CRMPort	
	)
	VALUES
	(
		@CRMHost,
		@CRMPort		
	) 

GO 