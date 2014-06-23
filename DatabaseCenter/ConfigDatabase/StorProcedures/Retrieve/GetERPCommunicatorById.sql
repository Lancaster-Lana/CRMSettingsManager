 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetERPCommunicatorById')
	BEGIN
		DROP  Procedure  GetERPCommunicatorById
	END
GO

CREATE Procedure GetERPCommunicatorById
	@ID	int
AS
	SELECT
		CloseTimeOut,
		ReceiveTimeOut,
		ReceiveTimeOut,
		SendTimeOut,
	    InactivetimeOut
	FROM
		ERPCommunicator
	WHERE
		ID = @ID

GO 