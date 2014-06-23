 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'GetServiceTypes')
	BEGIN
		DROP  Procedure  GetServiceTypes
	END
GO

CREATE Procedure GetServiceTypes
AS
	SELECT
	    Name	varchar(100)
	FROM
		ServiceType


GO  