 
  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateServiceType')
	BEGIN
		DROP  Procedure  UpdateServiceType
	END

GO

CREATE Procedure UpdateServiceType
		@ID	int,
		@ServiceName	varchar(100)
AS
	UPDATE
		ServiceType
	SET
		ServiceName = @ServiceName
	WHERE
		ID = @ID

GO
 