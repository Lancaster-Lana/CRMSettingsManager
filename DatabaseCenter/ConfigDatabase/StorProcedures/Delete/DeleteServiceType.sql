 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DeleteServiceType')
	BEGIN
		DROP  Procedure  DeleteServiceType
	END

GO

CREATE Procedure DeleteServiceType
	@ID	int
AS
DELETE
	FROM ServiceType
WHERE
		ID = @ID
GO  