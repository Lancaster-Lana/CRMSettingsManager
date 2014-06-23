IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateERPCommunicator')
	BEGIN
		DROP  Procedure  UpdateERPCommunicator
	END

GO

CREATE Procedure UpdateERPCommunicator
		@ID	int,
		@CloseTimeOut int,
		@OpenTimeOut	int,
		@ReceiveTimeOut	int,
		@SendTimeOut	int,
		@InactivetimeOut	int
AS
	UPDATE
		ERPCommunicator
	SET
		CloseTimeOut = @CloseTimeOut,
		OpenTimeOut = @OpenTimeOut,
		ReceiveTimeOut = @ReceiveTimeOut,
		SendTimeOut = @SendTimeOut,
		InactivetimeOut = @InactivetimeOut
	WHERE
		ID = @ID

GO
  