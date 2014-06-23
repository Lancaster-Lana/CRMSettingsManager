IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ConfigDB')
	DROP DATABASE [ConfigDB]
GO
--TODO
CREATE DATABASE [ConfigDB]  ON (NAME = N'ConfigDB_Data', FILENAME = N'C:\ConfigDB_Data.MDF' , SIZE = 2, FILEGROWTH = 10%) LOG ON (NAME = N'ConfigDB_Log', FILENAME = N'D:\ConfigDB_Log.LDF' , SIZE = 1, FILEGROWTH = 10%)
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'ConfigDB', N'autoclose', N'false'
GO

exec sp_dboption N'ConfigDB', N'bulkcopy', N'false'
GO

exec sp_dboption N'ConfigDB', N'trunc. log', N'false'
GO

exec sp_dboption N'ConfigDB', N'torn page detection', N'true'
GO

exec sp_dboption N'ConfigDB', N'read only', N'false'
GO

exec sp_dboption N'ConfigDB', N'dbo use', N'false'
GO

exec sp_dboption N'ConfigDB', N'single', N'false'
GO

exec sp_dboption N'ConfigDB', N'autoshrink', N'false'
GO

exec sp_dboption N'ConfigDB', N'ANSI null default', N'false'
GO

exec sp_dboption N'ConfigDB', N'recursive triggers', N'false'
GO

exec sp_dboption N'ConfigDB', N'ANSI nulls', N'false'
GO

exec sp_dboption N'ConfigDB', N'concat null yields null', N'false'
GO

exec sp_dboption N'ConfigDB', N'cursor close on commit', N'false'
GO

exec sp_dboption N'ConfigDB', N'default to local cursor', N'false'
GO

exec sp_dboption N'ConfigDB', N'quoted identifier', N'false'
GO

exec sp_dboption N'ConfigDB', N'ANSI warnings', N'false'
GO

exec sp_dboption N'ConfigDB', N'auto create statistics', N'true'
GO

exec sp_dboption N'ConfigDB', N'auto update statistics', N'true'
GO

if( (@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 724) )
	exec sp_dboption N'ConfigDB', N'db chaining', N'false'
GO

use [ConfigDB]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ERPCommunicator_ERPClientType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ERPCommunicator] DROP CONSTRAINT FK_ERPCommunicator_ERPClientType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ERPCommunicator_ERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ERPCommunicator] DROP CONSTRAINT FK_ERPCommunicator_ERPCommunicationComponent
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Service_ERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Service] DROP CONSTRAINT FK_Service_ERPCommunicationComponent
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Service_To_EndPoit_EndPoint]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Service_To_EndPoint] DROP CONSTRAINT FK_Service_To_EndPoit_EndPoint
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Service_ServiceType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Service] DROP CONSTRAINT FK_Service_ServiceType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Service_To_EndPoit_Service]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Service_To_EndPoint] DROP CONSTRAINT FK_Service_To_EndPoit_Service
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddECC_Service_To_EndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddECC_Service_To_EndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddEndPointToECCService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddEndPointToECCService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ChangeECCServiceEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ChangeECCServiceEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteECCService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteECCService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteERPCommunicationComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteLinkToEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteLinkToEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetECCServiceEndPoints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetECCServiceEndPoints]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetECCServices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetECCServices]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetECCServicesRelatedWithEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetECCServicesRelatedWithEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RemoveEndPointFromECCService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[RemoveEndPointFromECCService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateECCServiceEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateECCServiceEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddECCService]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddECCService]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddERPCommunicationComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddERPCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddERPCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicationComponentServices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicationComponentServices]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicatorsByECC_ID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicatorsByECC_ID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateECCServiceInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateECCServiceInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateERPCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateERPCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddCRMCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddCRMCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddEndPoint]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddEndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddServiceType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddServiceType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearServiceTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearServiceTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteServiceType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteServiceType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetActiveCRMCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetActiveCRMCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetActiveERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetActiveERPCommunicationComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCRMCommunicatorById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCRMCommunicatorById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCRMCommunicators]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCRMCommunicators]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPClientTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPClientTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicationComponents]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicationComponents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEndPoints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEndPoints]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetServiceType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetServiceType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetServiceTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetServiceTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateCRMCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateCRMCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateERPCommunicationComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateServiceType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateServiceType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddERPClientType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddERPClientType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearCRMCommunicators]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearCRMCommunicators]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearERPClientTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearERPClientTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearERPCommunicationComponents]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearERPCommunicationComponents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearERPCommunicators]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearERPCommunicators]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteCRMCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteCRMCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteERPClientType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteERPClientType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DeleteERPCommunicator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[DeleteERPCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPClientType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPClientType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicationComponentById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicationComponentById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicationComponentByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicationComponentByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicatorById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicatorById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetERPCommunicators]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetERPCommunicators]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateERPClientType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateERPClientType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Service_To_EndPoint]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Service_To_EndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ERPCommunicator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ERPCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Service]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Service]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CRMCommunicator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CRMCommunicator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ERPClientType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ERPClientType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ERPCommunicationComponent]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ERPCommunicationComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EndPoint]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EndPoint]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ServiceType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ServiceType]
GO

CREATE TABLE [dbo].[CRMCommunicator] (
	[CRMHost] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CRMPort] [int] NULL ,
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Active] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ERPClientType] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClientName] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ERPCommunicationComponent] (
	[ERPPort] [int] NOT NULL ,
	[ERPHost] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[InactivityTimeOut] [int] NULL ,
	[Active] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[EndPoint] (
	[ListenHost] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ListenPort] [int] NULL ,
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AnswerHost] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AnswerPort] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ServiceType] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ERPCommunicator] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[CloseTimeOut] [int] NULL ,
	[OpenTimeOut] [int] NULL ,
	[ReceiveTimeOut] [int] NULL ,
	[SendTimeOut] [int] NULL ,
	[InactiveTimeOut] [int] NULL ,
	[ERPCommunicationComponent_ID] [int] NULL ,
	[AnswerHost] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AnswerPort] [int] NULL ,
	[ERPClientType_ID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Service] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[ERPCommunicationComponent_ID] [int] NULL ,
	[ServiceType_ID] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Service_To_EndPoint] (
	[Service_ID] [int] NOT NULL ,
	[EndPoint_ID] [int] NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CRMCommunicator] WITH NOCHECK ADD 
	CONSTRAINT [PK_CRMCommunicator] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPClientType] WITH NOCHECK ADD 
	CONSTRAINT [PK_ERPClientType] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPCommunicationComponent] WITH NOCHECK ADD 
	CONSTRAINT [PK_ErpCommunicationComponent] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[EndPoint] WITH NOCHECK ADD 
	CONSTRAINT [PK_EndPoint] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ServiceType] WITH NOCHECK ADD 
	CONSTRAINT [PK_ServiceType_1] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPCommunicator] WITH NOCHECK ADD 
	CONSTRAINT [PK_ERPCommunicator] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Service] WITH NOCHECK ADD 
	CONSTRAINT [PK_ServiceType] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPCommunicationComponent] ADD 
	CONSTRAINT [DF_ERPCommunicationComponent_Active] DEFAULT (0) FOR [Active]
GO

ALTER TABLE [dbo].[EndPoint] ADD 
	CONSTRAINT [IX_EndPoint] UNIQUE  NONCLUSTERED 
	(
		[ListenHost],
		[ListenPort]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ServiceType] ADD 
	CONSTRAINT [IX_ServiceTypeName] UNIQUE  NONCLUSTERED 
	(
		[Name]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPCommunicator] ADD 
	CONSTRAINT [IX_ERPCommunicator] UNIQUE  NONCLUSTERED 
	(
		[AnswerHost],
		[AnswerPort]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Service_To_EndPoint] ADD 
	CONSTRAINT [PK_Service_To_EndPoit] PRIMARY KEY  NONCLUSTERED 
	(
		[Service_ID],
		[EndPoint_ID]
	)  ON [PRIMARY] ,
	CONSTRAINT [IX_Service_To_EndPoit] UNIQUE  NONCLUSTERED 
	(
		[Service_ID],
		[EndPoint_ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ERPCommunicator] ADD 
	CONSTRAINT [FK_ERPCommunicator_ERPClientType] FOREIGN KEY 
	(
		[ERPClientType_ID]
	) REFERENCES [dbo].[ERPClientType] (
		[ID]
	),
	CONSTRAINT [FK_ERPCommunicator_ERPCommunicationComponent] FOREIGN KEY 
	(
		[ERPCommunicationComponent_ID]
	) REFERENCES [dbo].[ERPCommunicationComponent] (
		[ID]
	)
GO

ALTER TABLE [dbo].[Service] ADD 
	CONSTRAINT [FK_Service_ERPCommunicationComponent] FOREIGN KEY 
	(
		[ERPCommunicationComponent_ID]
	) REFERENCES [dbo].[ERPCommunicationComponent] (
		[ID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_Service_ServiceType] FOREIGN KEY 
	(
		[ServiceType_ID]
	) REFERENCES [dbo].[ServiceType] (
		[ID]
	)
GO

ALTER TABLE [dbo].[Service_To_EndPoint] ADD 
	CONSTRAINT [FK_Service_To_EndPoit_EndPoint] FOREIGN KEY 
	(
		[EndPoint_ID]
	) REFERENCES [dbo].[EndPoint] (
		[ID]
	),
	CONSTRAINT [FK_Service_To_EndPoit_Service] FOREIGN KEY 
	(
		[Service_ID]
	) REFERENCES [dbo].[Service] (
		[ID]
	)
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure AddERPClientType
	@ClientName	varchar(100)
AS
if(NOT EXISTS (select * from ERPClientType Where ClientName = @ClientName))

	INSERT INTO ERPClientType
	(
		ClientName
	)
	VALUES
	(		
		@ClientName
	)

select  @@identity



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure ClearCRMCommunicators
AS
	DELETE
	FROM CRMCommunicator


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure ClearERPClientTypes
AS
DELETE
	FROM ERPClientType

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure ClearERPCommunicationComponents
AS
	DELETE
	FROM ERPCommunicationComponent


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure ClearERPCommunicators
AS
	DELETE
	FROM ERPCommunicator


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure DeleteCRMCommunicator
	@ID	int
AS
	DELETE
	FROM CRMCommunicator
WHERE
	ID = @ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure DeleteERPClientType
	@ID	int
AS
DELETE
	FROM ERPClientType
WHERE
	ID = @ID
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure DeleteERPCommunicator
	@ID	int
AS
	DELETE
	FROM ERPCommunicator
WHERE
	ID = @ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure GetERPClientType
	@ID	int
AS
	SELECT
	    *
	FROM
		ERPClientType
	WHERE
		ID = @ID
		

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetERPCommunicationComponentById
	@ID	int
AS
	SELECT
	   *
	FROM
		ERPCommunicationComponent
	WHERE
		ID = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetERPCommunicationComponentByName
	@Name	varchar(100)
AS
	SELECT
	        *
	FROM
		ERPCommunicationComponent
	WHERE
		Name = @Name


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetERPCommunicatorById
	@ID	int
AS
	SELECT
		*
	FROM
		ERPCommunicator
	WHERE
		ID = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetERPCommunicators
AS
	SELECT
		*
	FROM
		ERPCommunicator


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure UpdateERPClientType
		@ID		int,		
		@ClientName	varchar(100)
AS
	UPDATE
		ERPClientType
	SET	
		ClientName = @ClientName
	WHERE
		ID = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure AddCRMCommunicator
	@CRMHost	varchar(100),
	@CRMPort	int,
	@Active		bit	
AS
if (@Active = 1)	
	UPDATE CRMCommunicator SET Active = 0
	
 if (NOT EXISTS(select * from  CRMCommunicator where (CRMHost = @CRMHost) AND (CRMPort=@CRMPort)))
 BEGIN
	INSERT INTO CRMCommunicator
	(
		CRMHost,
		CRMPort,
		Active
	)
	VALUES
	(
		@CRMHost,
		@CRMPort,
		@Active		
	) 

select  @@identity
/*select ID from  CRMCommunicator where (CRMHost = @CRMHost) AND (CRMPort=@CRMPort)*/
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.AddEndPoint
(			
			@ListenHost varchar(100),
			@ListenPort int,
			@AnswerHost varchar(100),
 			@AnswerPort int			
	)		  
AS


declare @existEndPointID int
select  @existEndPointID = count(*) from EndPoint where  (ListenHost = @ListenHost)and (ListenPort=@ListenPort)

if (@existEndPointID = 0)
BEGIN

	 INSERT INTO  EndPoint
                (
							ListenHost,
							ListenPort,
							AnswerHost,
							AnswerPort              	
                )
               VALUES
               (
						   @ListenHost, 
	                       @ListenPort,
	                       @AnswerHost, 
	                       @AnswerPort
               )
               
    select  @@identity
END 

ELSE              
	select  ID from EndPoint where  (ListenHost = @ListenHost)and (ListenPort=@ListenPort)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure AddServiceType
	@Name	varchar(100)
AS
if(NOT EXISTS (select * from ServiceType Where Name = @Name))

	INSERT INTO ServiceType
	(
		Name
	)
	VALUES
	(		
		@Name
	)

select  @@identity
/*select ID from ServiceType Where Name = @Name */

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create Procedure ClearServiceTypes
AS
	DELETE
	FROM ServiceType



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure DeleteServiceType
	@ID	int
AS
DELETE
	FROM ServiceType
WHERE
	ID = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure GetActiveCRMCommunicator
AS
	SELECT
	   *
	FROM
		CRMCommunicator
	WHERE
		Active =  1
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetActiveERPCommunicationComponent	
AS
	SELECT
	   *
	FROM
		ERPCommunicationComponent
	WHERE
		Active =  1
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetCRMCommunicatorById
	@ID	int
AS
	SELECT
		*
	FROM
		CRMCommunicator
	WHERE
		ID = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure GetCRMCommunicators
AS
	SELECT
		*
	FROM
		CRMCommunicator



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  Procedure GetERPClientTypes
AS
	SELECT
	    *
	FROM
		ERPClientType

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  Procedure GetERPCommunicationComponents
AS
	SELECT
		*	
	FROM
		ERPCommunicationComponent



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.GetEndPoints
AS
SELECT 
	ID, ListenHost, ListenPort, AnswerHost, AnswerPort,
	 ListenHost +':'+ Str(ListenPort) + '              '+ AnswerHost +':'+Str(AnswerPort) as 'Description'
	  FROM  EndPoint
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure GetServiceType
	@ID	int
AS
	SELECT
	    *
	FROM
		ServiceType
	WHERE
		ID = @ID
		
		
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE Procedure GetServiceTypes
AS
	SELECT
	    *
	FROM
		ServiceType
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure UpdateCRMCommunicator
    @ID		int,
	@CRMHost	varchar(100),
	@CRMPort	int,
	@Active		bit	
AS
if (@Active = 1)	
	UPDATE CRMCommunicator SET Active = 0
	
	UPDATE
		CRMCommunicator
	SET
		CRMHost=@CRMHost,
		CRMPort=@CRMPort,
		Active=@Active
		
	WHERE
		ID = @ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure UpdateERPCommunicationComponent
		@ID	int,
		@Name	varchar(100),
		@ErpHost	varchar(50),
		@ErpPort	int,
		@InactivityTimeOut int,
		@Active  bit
AS

/* Clear all active UpdateERPCommunicationComponent*/
if(NOT EXISTS(SELECT * FROM ERPCommunicationComponent WHERE (Name = @Name) AND (ID != @ID)))
BEGIN	

	if (@Active = 1) UPDATE ERPCommunicationComponent SET Active = 0

	UPDATE
		ERPCommunicationComponent
	SET
		Name = @Name,
		ErpHost = @ErpHost,
		ErpPort = @ErpPort,
		InactivityTimeOut = @InactivityTimeOut,
		Active = @Active
	WHERE
		ID = @ID
		
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure UpdateServiceType
		@ID		int,		
		@Name	varchar(100)
AS
	UPDATE
		ServiceType
	SET	
		Name = @Name
	WHERE
		ID = @ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure AddECCService
	@ERPCommunicationComponent_ID	int,
	@ServiceType_ID	int
AS
declare @existServiceID int
select  @existServiceID = ID from Service where  (ServiceType_ID = @ServiceType_ID)and (ERPCommunicationComponent_ID=@ERPCommunicationComponent_ID)

if (@existServiceID is null)
BEGIN
	INSERT INTO Service
	(
		ServiceType_ID,
		ERPCommunicationComponent_ID
	)
	VALUES
	(		
		@ServiceType_ID, 
		@ERPCommunicationComponent_ID	
	)
	
	 select  @@identity
END

ELSE
	select ID from Service where  (ServiceType_ID = @ServiceType_ID)and (ERPCommunicationComponent_ID=@ERPCommunicationComponent_ID)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure AddERPCommunicationComponent
	@Name		varchar(100),
    @ErpHost	varchar(50),
	@ErpPort	int,
	@InactivityTimeOut int,
	@Active bit
AS

if(NOT EXISTS(SELECT * FROM ERPCommunicationComponent WHERE Name = @Name))
BEGIN
	if (@Active = 1)
		UPDATE ERPCommunicationComponent
		SET Active = 0

		INSERT INTO ERPCommunicationComponent
		(
			Name,
			ErpHost,
			ErpPort,
			InactivityTimeOut,
			Active 
		)
		VALUES
		(
			@Name,
			@ErpHost,
			@ErpPort,
			@InactivityTimeOut,
			@Active
		)

declare @id int
select @id = @@identity/*ID from ERPCommunicationComponent where Name=@Name*/

INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'1')
INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'2')
INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'3')


INSERT INTO ERPCommunicator(ERPCommunicationComponent_ID, ERPClientType_ID, AnswerHost, AnswerPort, OpenTimeOut, CloseTimeOut, SendTimeOut, ReceiveTimeOut, InactivetimeOut) 
			VALUES(@id,'1','local_1', @id,  0, 0, 0, 0, 0)
INSERT INTO ERPCommunicator(ERPCommunicationComponent_ID, ERPClientType_ID, AnswerHost, AnswerPort, OpenTimeOut, CloseTimeOut, SendTimeOut, ReceiveTimeOut, InactivetimeOut )
		    VALUES(@id,'2','local_2', @id,  0, 0, 0, 0, 0)
INSERT INTO ERPCommunicator(ERPCommunicationComponent_ID, ERPClientType_ID, AnswerHost, AnswerPort, OpenTimeOut, CloseTimeOut, SendTimeOut, ReceiveTimeOut, InactivetimeOut )
		    VALUES(@id,'3','local_3', @id,  0, 0, 0, 0, 0)
INSERT INTO ERPCommunicator(ERPCommunicationComponent_ID, ERPClientType_ID, AnswerHost, AnswerPort, OpenTimeOut, CloseTimeOut, SendTimeOut, ReceiveTimeOut, InactivetimeOut )
		    VALUES(@id,'4','local_4', @id,  0, 0, 0, 0, 0)

/*exec AddERPCommunicator @ERPClientType_ID =1, @AnswerHost = 'l_47890ocal', @AnswerPort = 0, @OpenTimeOut = 0, @CloseTimeOut = 0, @SendTimeOut = 0, @ReceiveTimeOut	= 0, @InactivetimeOut =0
exec AddERPCommunicator @ERPClientType_ID =2, @AnswerHost = 'local', @AnswerPort = 0, @OpenTimeOut = 0, @CloseTimeOut = 0, @SendTimeOut = 0, @ReceiveTimeOut	= 0, @InactivetimeOut =0
exec AddERPCommunicator @ERPClientType_ID =3, @AnswerHost = 'local', @AnswerPort = 0, @OpenTimeOut = 0, @CloseTimeOut = 0, @SendTimeOut = 0, @ReceiveTimeOut	= 0, @InactivetimeOut =0
exec AddERPCommunicator @ERPClientType_ID =0, @AnswerHost = 'local', @AnswerPort = 0, @OpenTimeOut = 0, @CloseTimeOut = 0, @SendTimeOut = 0, @ReceiveTimeOut	= 0, @InactivetimeOut =0
*/

select @id

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure AddERPCommunicator
	@ERPClientType_ID     int,

	@AnswerHost                varchar(100),
	@AnswerPort                  int,

	@OpenTimeOut		int,
	@CloseTimeOut 	int,
	@SendTimeOut		int,
	@ReceiveTimeOut	int,
	@InactivetimeOut	int
AS

declare @activeECC_ID int 
select @activeECC_ID = ID FROM ERPCommunicationComponent WHERE Active =  1

if(@activeECC_ID is NOT NULL)
BEGIN
	INSERT INTO ERPCommunicator
	(
				ERPClientType_ID,
				ERPCommunicationComponent_ID,

              	AnswerHost,
              	AnswerPort,

				OpenTimeOut,
				CloseTimeOut,
				SendTimeOut,
				ReceiveTimeOut,
				InactivetimeOut
	)
	VALUES
	(
				@ERPClientType_ID,
				@activeECC_ID,

              	@AnswerHost,
              	@AnswerPort,

				@OpenTimeOut,
				@CloseTimeOut,
				@SendTimeOut,
				@ReceiveTimeOut,
				@InactivetimeOut

	)
	select  @@identity

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

Create PROCEDURE GetERPCommunicationComponentServices 	
	(
		@ERPCommunicationComponent_ID int	
	)	
AS

SELECT    
		*
FROM  
        Service          
                       
WHERE     (Service.ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetERPCommunicatorsByECC_ID
	@ECC_ID	int
AS
	SELECT
	   *
	FROM
		ERPCommunicator
	WHERE
		ERPCommunicationComponent_ID = @ECC_ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UpdateECCServiceInfo	
	(
	    @ERPCommunicationComponent_ID int,
	    @ServiceType_ID varchar(100),
	    @NewServiceType_ID varchar(100)
	)

AS
	UPDATE  Service
              SET  Service.ServiceType_ID = @NewServiceType_ID
              WHERE (Service.ServiceType_ID = @ServiceType_ID) and 
                                            (Service.ERPCommunicationComponent_ID =@ERPCommunicationComponent_ID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure [dbo].[UpdateERPCommunicator]
		@ID					int,
		@ERPClientType_ID	int,
		@ERPCommunicationComponent_ID int,
		
		@AnswerHost 		varchar(100),
		@AnswerPort 		int,
		
		@CloseTimeOut 		int,
		@OpenTimeOut		int,
		@ReceiveTimeOut		int,
		@SendTimeOut		int,
		@InactivetimeOut	int
				
AS
	UPDATE
		ERPCommunicator
	SET
		ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID,
		ERPClientType_ID = @ERPClientType_ID,
		
		AnswerHost = @AnswerHost,
		AnswerPort = @AnswerPort,		
	
		CloseTimeOut = @CloseTimeOut,
		OpenTimeOut = @OpenTimeOut,
		ReceiveTimeOut = @ReceiveTimeOut,
		SendTimeOut = @SendTimeOut,
		InactivetimeOut = @InactivetimeOut		
	WHERE
		ID = @ID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE  Procedure AddECC_Service_To_EndPoint
	@Service_ID	 int,
	@EndPoint_ID int
AS
	INSERT INTO Service_To_EndPoint
	(
		Service_ID,
		EndPoint_ID
	)
	VALUES
	(		
		@Service_ID, 
		@EndPoint_ID	
	)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.AddEndPointToECCService
(
			@ERPCommunicationComponent_ID int,
			@Service_ID int,
			@EndPoint_ID int						
)		  
AS

declare @existsEndPointLinkInECCService int
		
select @existsEndPointLinkInECCService = count(*) from Service_To_EndPoint
where 
 (EndPoint_ID = @EndPoint_ID) AND 

  Service_ID IN (select Service.ID from Service		
	   inner join Service_To_EndPoint on Service.ID = Service_To_EndPoint.Service_ID	
	   where  (Service.ERPCommunicationComponent_ID =  @ERPCommunicationComponent_ID))	   

 if(@existsEndPointLinkInECCService=0)                          
	INSERT INTO  Service_To_EndPoint
                (
						Service_ID,
						EndPoint_ID            	
                )
               VALUES               
               (                     
						@Service_ID,
						@EndPoint_ID                 
               )               
             
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.ChangeECCServiceEndPoint
(
			@ERPCommunicationComponent_ID int,
			@Service_ID int,
			@FromEndPoint_ID int,
			@ToEndPoint_ID int		
)		  
AS

declare @existsEndPointLinkInECCService int
		
select @existsEndPointLinkInECCService = count(*) from Service_To_EndPoint
where 
 (EndPoint_ID = @ToEndPoint_ID) AND 

  Service_ID IN (select Service.ID from Service		
	   inner join Service_To_EndPoint on Service.ID = Service_To_EndPoint.Service_ID	
	   where  (Service.ERPCommunicationComponent_ID =  @ERPCommunicationComponent_ID))	   

if(@existsEndPointLinkInECCService = 0)
BEGIN 
	DELETE FROM Service_To_EndPoint
	WHERE  (Service_ID = @Service_ID) and (EndPoint_ID = @FromEndPoint_ID )	


	INSERT INTO  Service_To_EndPoint(Service_ID,EndPoint_ID)
    VALUES(@Service_ID, @ToEndPoint_ID)
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE Procedure DeleteECCService	
	@Service_ID	int,
	@DeleteRelatedEndPoints	bit
	/*
	@ERPCommunicationComponent_ID	int,
	*/
AS

if (@DeleteRelatedEndPoints=1)

Delete From EndPoint
Where ID in (select EndPoint.ID 
				  From EndPoint Inner Join Service_To_EndPoint on EndPoint.ID = Service_To_EndPoint.EndPoint_ID
				  Where Service_To_EndPoint.Service_ID = @Service_ID )
	      	

Delete From Service_To_EndPoint
		Where (Service_ID = @Service_ID)
		
Delete From Service
		Where (ID = @Service_ID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE Procedure DeleteERPCommunicationComponent
	@ID	int
AS

/*
if (@DeleteRelatedEndPoints=1)

Delete From EndPoint
Where ID in (select EndPoint.ID 
				  From EndPoint Inner Join Service_To_EndPoint on EndPoint.ID = Service_To_EndPoint.EndPoint_ID
				  Where Service_To_EndPoint.Service_ID = @Service_ID )
	      			
*/		

Delete From Service_To_EndPoint
		Where Service_To_EndPoint.Service_ID in
			(Select Service.ID from Service Where ERPCommunicationComponent_ID = @ID)
		
Delete From Service
		Where (ERPCommunicationComponent_ID = @ID)


/*Delete related ERPCommunicators*/
Delete From ERPCommunicator
		Where (ERPCommunicationComponent_ID = @ID)
		

DELETE FROM ERPCommunicationComponent
WHERE ID = @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteEndPoint
	@EndPoint_ID	int
AS

if(NOT EXISTS(select * from Service_To_EndPoint Where (EndPoint_ID = @EndPoint_ID)))

Delete From EndPoint
 Where (ID = @EndPoint_ID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.DeleteLinkToEndPoint 
	@EndPoint_ID	int,
	@Service_ID	int
AS

Delete From Service_To_EndPoint
 Where (EndPoint_ID = @EndPoint_ID)and(Service_ID = @Service_ID)
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetECCServiceEndPoints
(
	@ECCService_ID int						
)		  
AS
	
select * 
from EndPoint 
		inner join Service_To_EndPoint on Service_To_EndPoint.EndPoint_ID = EndPoint.ID
where  Service_To_EndPoint.Service_ID=@ECCService_ID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetECCServices 	
	(
		@ERPCommunicationComponent_ID int	
	)
	
AS
	SELECT    
					  Service.ID as ID,
                      Service.ERPCommunicationComponent_ID, 
                      Service.ID as Service_ID,
                      
                      Service.ServiceType_ID as ServiceType_ID,                      
                      ServiceType.Name,
                      
                      EndPoint.ID as EndPoint_ID,
                      EndPoint.ListenHost, EndPoint.ListenPort, EndPoint.AnswerHost, EndPoint.AnswerPort
                      
FROM  
        Service INNER JOIN ServiceType ON  ServiceType.ID = Service.ServiceType_ID                         
                        FULL OUTER JOIN Service_To_EndPoint 
                                ON  Service.ID =Service_To_EndPoint.Service_ID
                                 
                            FULL OUTER  JOIN EndPoint 
                                            ON  EndPoint.ID = Service_To_EndPoint.EndPoint_ID                             
                              

WHERE     (Service.ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID)
ORDER BY ServiceType.Name

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE GetECCServicesRelatedWithEndPoint
(
			@Service_ID int,
			@EndPoint_ID int						
)		  
AS
	
select * from Service
		 inner join Service_To_EndPoint on Service.ID = Service_To_EndPoint.Service_ID
where  Service_To_EndPoint.EndPoint_ID=@EndPoint_ID
 
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE dbo.RemoveEndPointFromECCService
(
			@EndPoint_ID int,
			@Service_ID int				
)		  
AS
	

Delete from Service_To_EndPoint
where   (  Service_ID = @Service_ID) and  (EndPoint_ID   = @EndPoint_ID)         
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE dbo.UpdateECCServiceEndPoint
(
    @ERPCommunicationComponent_ID int,
	@ServiceType_ID int,
	@ListenHost varchar(100),
	@ListenPort int,
	@AnswerHost varchar(100),
	@AnswerPort int
)
AS
	SET NOCOUNT OFF;


UPDATE  EndPoint
              SET  EndPoint.ListenHost = @ListenHost, 
                      EndPoint.ListenPort = @ListenPort,
                      EndPoint.AnswerHost = @AnswerHost, 
                      EndPoint.AnswerPort = @AnswerPort

WHERE  EndPoint.ID IN                 
              (Select EndPoint_ID  From  Service_To_EndPoint
               Inner Join Service ON  Service_To_EndPoint.Service_ID=Service.ID
               Where 
                        (Service.ServiceType_ID = @ServiceType_ID) and 
                        (Service.ERPCommunicationComponent_ID =@ERPCommunicationComponent_ID)
                       )
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

