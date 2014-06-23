IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AddServiceType')
	BEGIN
		DROP  Procedure  AddServiceType
	END
GO

CREATE Procedure AddServiceType
	@ServiceName	varchar(100)
AS
	INSERT INTO ServiceType
	(
		ServiceName	
	)
	VALUES
	(
		@ServiceName			
	) 

GO  