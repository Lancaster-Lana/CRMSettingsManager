  IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ClearServiceTypes')
	BEGIN
		DROP  Procedure  ClearServiceTypes
	END

GO

CREATE Procedure ClearServiceTypes
AS
	DELETE
	FROM ServiceType

GO 