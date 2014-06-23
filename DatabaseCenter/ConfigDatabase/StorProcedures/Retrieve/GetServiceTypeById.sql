 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetServiceTypeById')
	BEGIN
		DROP  Procedure  GetServiceTypeById
	END
GO

CREATE Procedure GetServiceTypeById
	@ID	int
AS
	SELECT
	    Name	varchar(100)
	FROM
		ServiceType
	WHERE
		ID = @ID

GO  