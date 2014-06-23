IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'AddERPCommunicator')
	BEGIN
		DROP  Procedure  AddERPCommunicator
	END
GO

CREATE Procedure AddERPCommunicator
	@CloseTimeOut int,
	@OpenTimeOut	int,
	@ReceiveTimeOut	int,
	@SendTimeOut	int,
	@InactivetimeOut	int
AS
	INSERT INTO ERPCommunicator
	(
		CloseTimeOut,
		OpenTimeOut,
		ReceiveTimeOut,
		SendTimeOut,
		InactivetimeOut
	)
	VALUES
	(
		@CloseTimeOut,
		@OpenTimeOut,
		@ReceiveTimeOut,
		@SendTimeOut,
		@InactivetimeOut
	) 

GO  