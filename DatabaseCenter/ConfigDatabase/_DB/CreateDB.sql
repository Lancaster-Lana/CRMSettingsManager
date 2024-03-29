USE [G:\MY PROJECTS\! GOLD PROJECTS - GITHUB\CRMSETTINGSMANAGER\DATABASECENTER\CONFIG.DAL\APP_DATA\CONFIGDB.MDF]
GO
/****** Object:  Table [dbo].[CRMCommunicator]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CRMCommunicator](
	[CRMHost] [varchar](100) NOT NULL,
	[CRMPort] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_CRMCommunicator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ERPCommunicationComponent]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ERPCommunicationComponent](
	[ERPPort] [int] NOT NULL,
	[ERPHost] [varchar](100) NULL,
	[Name] [varchar](100) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InactivityTimeOut] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ErpCommunicationComponent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ERPClientType]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ERPClientType](
	[ID] [int] NOT NULL,
	[ClientName] [nchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EndPoint]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EndPoint](
	[ListenHost] [varchar](100) NOT NULL,
	[ListenPort] [int] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerHost] [varchar](100) NULL,
	[AnswerPort] [int] NULL,
 CONSTRAINT [PK_EndPoint] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_EndPoint] UNIQUE NONCLUSTERED 
(
	[ListenHost] ASC,
	[ListenPort] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedDataType [dbo].[ServiceType]    Script Date: 05/14/2014 16:59:50 ******/
CREATE TYPE [dbo].[ServiceType] FROM [varchar](8000) NOT NULL
GO
/****** Object:  Table [dbo].[ServiceType]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ServiceType_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ServiceTypeName] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[UpdateERPCommunicationComponent]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateERPCommunicationComponent]
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
	if (@Active = 1)
	BEGIN	
		UPDATE
			ERPCommunicationComponent
		SET
			Active = 0
	END

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
/****** Object:  StoredProcedure [dbo].[UpdateCRMCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateCRMCommunicator]
    @ID		int,
	@CRMHost	varchar(100),
	@CRMPort	int,
	@Active bit
AS
	UPDATE
		CRMCommunicator
	SET
		CRMHost=@CRMHost,
		CRMPort=@CRMPort,
		Active = @Active
	WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateServiceType]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateServiceType]
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
/****** Object:  StoredProcedure [dbo].[GetCRMCommunicators]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetCRMCommunicators]
AS
	SELECT
		CRMHost,
		CRMPort
	FROM
		CRMCommunicator
GO
/****** Object:  StoredProcedure [dbo].[GetCRMCommunicatorById]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetCRMCommunicatorById]
	@ID	int
AS
	SELECT
		CRMHost,
		CRMPort
	FROM
		CRMCommunicator
	WHERE
		ID = @ID
GO
/****** Object:  Table [dbo].[ERPCommunicator]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ERPCommunicator](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CloseTimeOut] [int] NULL,
	[OpenTimeOut] [int] NULL,
	[ReceiveTimeOut] [int] NULL,
	[SendTimeOut] [int] NULL,
	[InactiveTimeOut] [int] NULL,
	[ERPCommunicationComponent_ID] [int] NULL,
 CONSTRAINT [PK_ERPCommunicator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ERPCommunicationComponentView]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ERPCommunicationComponentView]
AS
SELECT     Name, ERPHost, ERPPort, InactivityTimeOut, Active
FROM         dbo.ERPCommunicationComponent
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ERPCommunicationComponent"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 197
               Right = 265
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ERPCommunicationComponentView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ERPCommunicationComponentView'
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicationComponents]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPCommunicationComponents]
AS
	SELECT
	    Name, ERPHost, ERPPort, InactivityTimeOut, Active
	FROM
		ERPCommunicationComponent
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicationComponentByName]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPCommunicationComponentByName]
	@Name	varchar(100)
AS
	SELECT
	        *
	FROM
		ERPCommunicationComponent
	WHERE
		Name = @Name
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicationComponentById]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPCommunicationComponentById]
	@ID	int
AS
	SELECT
	   *
	FROM
		ERPCommunicationComponent
	WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetERPClientTypes]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPClientTypes]
	@ID	int
AS
	SELECT
		*
	FROM
		ERPClientType
GO
/****** Object:  StoredProcedure [dbo].[GetERPClientType]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPClientType]
	@ID	int
AS
	SELECT
		*
	FROM
		ERPClientType
	WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetEndPoints]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEndPoints]
AS
SELECT 
	ID, ListenHost, ListenPort, AnswerHost, AnswerPort,
	 ListenHost +':'+ Str(ListenPort) + '              '+ AnswerHost +':'+Str(AnswerPort) as 'Description'
	  FROM  EndPoint
GO
/****** Object:  Table [dbo].[Service]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ERPCommunicationComponent_ID] [int] NULL,
	[ServiceType_ID] [int] NULL,
 CONSTRAINT [PK_ServiceType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCRMCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteCRMCommunicator]
	@ID	int
AS
	DELETE
	FROM CRMCommunicator
WHERE
	ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[AddCRMCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddCRMCommunicator]
	@CRMHost	varchar(100),
	@CRMPort	int	
AS
	INSERT INTO CRMCommunicator
	(
		CRMHost,
		CRMPort	
	)
	VALUES
	(
		@CRMHost,
		@CRMPort		
	) 

select max(ID) from CRMCommunicator
GO
/****** Object:  StoredProcedure [dbo].[DeleteERPCommunicationComponent]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteERPCommunicationComponent]
	@ID	int
AS
	DELETE
	FROM ERPCommunicationComponent
WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[GetServiceTypes]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetServiceTypes]
AS
	SELECT
	    *
	FROM
		ServiceType
GO
/****** Object:  StoredProcedure [dbo].[GetServiceType]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetServiceType]
	@ID	int
AS
	SELECT
	    *
	FROM
		ServiceType
	WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteServiceType]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteServiceType]
	@ID	int
AS
DELETE
	FROM ServiceType
WHERE
	ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[ClearERPCommunicationComponents]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ClearERPCommunicationComponents]
AS
	DELETE
	FROM ERPCommunicationComponent
GO
/****** Object:  StoredProcedure [dbo].[ClearCRMCommunicators]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ClearCRMCommunicators]
AS
	DELETE
	FROM CRMCommunicator
GO
/****** Object:  StoredProcedure [dbo].[AddEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEndPoint]
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
               
END               
select  ID from EndPoint where  (ListenHost = @ListenHost)and (ListenPort=@ListenPort)
GO
/****** Object:  StoredProcedure [dbo].[AddServiceType]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddServiceType]
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

select ID from ServiceType Where Name = @Name
GO
/****** Object:  StoredProcedure [dbo].[ClearServiceTypes]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[ClearServiceTypes]
AS
	DELETE
	FROM ServiceType
GO
/****** Object:  StoredProcedure [dbo].[ClearERPCommunicators]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[ClearERPCommunicators]
AS
	DELETE
	FROM ERPCommunicator
GO
/****** Object:  StoredProcedure [dbo].[AddERPCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddERPCommunicator]
	@CloseTimeOut 	int,
	@OpenTimeOut		int,
	@ReceiveTimeOut	int,
	@SendTimeOut		int,
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

declare @id int 
select  @id = scope_identity()
return @id
GO
/****** Object:  StoredProcedure [dbo].[AddERPCommunicationComponent]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddERPCommunicationComponent]
	@Name		varchar(100),
    @ErpHost	varchar(50),
	@ErpPort	int,
	@InactivityTimeOut int,
	@Active bit
AS

if(NOT EXISTS(SELECT * FROM ERPCommunicationComponent WHERE Name = @Name))
	
BEGIN
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
select  @id = scope_identity()

INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'1')
INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'2')
INSERT INTO Service( ERPCommunicationComponent_ID,ServiceType_ID) VALUES(@id,'3')
	
return @id
END
GO
/****** Object:  StoredProcedure [dbo].[AddECCService]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[AddECCService]
	@ERPCommunicationComponent_ID	int,
	@ServiceType_ID	int
AS
declare @existServiceID int
select  @existServiceID = ID from Service where  (ServiceType_ID = @ServiceType_ID)and (ERPCommunicationComponent_ID=@ERPCommunicationComponent_ID)

if (@existServiceID is NULL)
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
	/*select max(ID) from Service*/
END

select ID from Service where  (ServiceType_ID = @ServiceType_ID)and (ERPCommunicationComponent_ID=@ERPCommunicationComponent_ID)
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicators]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPCommunicators]
AS
	SELECT
		*
	FROM
		ERPCommunicator
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicatorById]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetERPCommunicatorById]
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
/****** Object:  Table [dbo].[Service_To_EndPoint]    Script Date: 05/14/2014 16:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service_To_EndPoint](
	[Service_ID] [int] NOT NULL,
	[EndPoint_ID] [int] NOT NULL,
 CONSTRAINT [PK_Service_To_EndPoit] PRIMARY KEY NONCLUSTERED 
(
	[Service_ID] ASC,
	[EndPoint_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Service_To_EndPoit] UNIQUE NONCLUSTERED 
(
	[Service_ID] ASC,
	[EndPoint_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateERPCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[UpdateERPCommunicator]
		@ID			int,
		@CloseTimeOut 	int,
		@OpenTimeOut		int,
		@ReceiveTimeOut	int,
		@SendTimeOut		int,
		@InactivetimeOut	int,
		
		@ERPCommunicationComponent_ID int
AS
	UPDATE
		ERPCommunicator
	SET
		CloseTimeOut = @CloseTimeOut,
		OpenTimeOut = @OpenTimeOut,
		ReceiveTimeOut = @ReceiveTimeOut,
		SendTimeOut = @SendTimeOut,
		InactivetimeOut = @InactivetimeOut,
		ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID
	WHERE
		ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[DeleteERPCommunicator]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteERPCommunicator]
	@ID	int
AS
	DELETE
	FROM ERPCommunicator
WHERE
	ID = @ID
GO
/****** Object:  StoredProcedure [dbo].[UpdateECCServiceInfo]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateECCServiceInfo]	
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
/****** Object:  StoredProcedure [dbo].[UpdateECCServiceEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateECCServiceEndPoint]
(
    @ERPCommunicationComponent_ID int,
	@ServiceType varchar(100),
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
                      (Select EndPoint_ID  
                         From  Service_To_EndPoint
                                   Inner Join Service ON  Service_To_EndPoint.Service_ID=Service.ID
                         Where 
                                    (Service.ServiceType = @ServiceType) and 
                                     (Service.ERPCommunicationComponent_ID =@ERPCommunicationComponent_ID)
                       )
GO
/****** Object:  StoredProcedure [dbo].[RemoveEndPointFromECCService]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[RemoveEndPointFromECCService]
(
			@EndPoint_ID int,
			@Service_ID int				
)		  
AS
	

Delete from Service_To_EndPoint
where   (  Service_ID = @Service_ID) and  (EndPoint_ID   = @EndPoint_ID)
GO
/****** Object:  StoredProcedure [dbo].[GetERPCommunicationComponentServices]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetERPCommunicationComponentServices]
(
	  @ERPCommunicationComponent_ID int
)	
AS
	SELECT Service.ERPCommunicationComponent_ID,  Service.ServiceType_ID, EndPoint.ListenHost, EndPoint.ListenPort, EndPoint.AnswerHost, EndPoint.AnswerPort
    FROM Service FULL JOIN  Service_To_EndPoint
    ON  Service.ID =Service_To_EndPoint.Service_ID
    INNER JOIN EndPoint
    ON  EndPoint.ID = Service_To_EndPoint.EndPoint_ID
    WHERE     (Service.ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID)
GO
/****** Object:  StoredProcedure [dbo].[DeleteEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteEndPoint]
	@EndPoint_ID	int
AS

if(NOT EXISTS(select * from Service_To_EndPoint Where (EndPoint_ID = @EndPoint_ID)))

Delete From EndPoint
 Where (ID = @EndPoint_ID)
GO
/****** Object:  StoredProcedure [dbo].[DeleteECCService]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[DeleteECCService]	
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
/****** Object:  StoredProcedure [dbo].[GetECCServicesRelatedWithEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetECCServicesRelatedWithEndPoint]
(
			@Service_ID int,
			@EndPoint_ID int						
)		  
AS
	
select * from Service
		 inner join Service_To_EndPoint on Service.ID = Service_To_EndPoint.Service_ID
where  Service_To_EndPoint.EndPoint_ID=@EndPoint_ID
GO
/****** Object:  StoredProcedure [dbo].[GetECCServices]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetECCServices] 	
	(
		@ERPCommunicationComponent_ID int	
	)
	
AS
	SELECT    
                      Service.ERPCommunicationComponent_ID/* as ECC_ID*/, 
                      Service.ID as Service_ID,
                      
                      Service.ServiceType_ID as ServiceType_ID,                      
                      ServiceType.Name as ServiceType,
                      
                      EndPoint.ID as EndPoint_ID,
                      EndPoint.ListenHost, EndPoint.ListenPort, EndPoint.AnswerHost, EndPoint.AnswerPort
FROM  
        Service          
                         FULL OUTER JOIN Service_To_EndPoint 
                                 ON  Service.ID =Service_To_EndPoint.Service_ID
                              FULL OUTER JOIN EndPoint 
                                            ON  EndPoint.ID = Service_To_EndPoint.EndPoint_ID                             
                              RIGHT OUTER  JOIN ServiceType
                                            ON  ServiceType.ID = Service.ServiceType_ID

WHERE     (Service.ERPCommunicationComponent_ID = @ERPCommunicationComponent_ID)
ORDER BY ServiceType
GO
/****** Object:  StoredProcedure [dbo].[DeleteLinkToEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLinkToEndPoint] 
	@EndPoint_ID	int,
	@Service_ID	int
AS

Delete From Service_To_EndPoint
 Where (EndPoint_ID = @EndPoint_ID)and(Service_ID = @Service_ID)
GO
/****** Object:  StoredProcedure [dbo].[ChangeECCServiceEndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangeECCServiceEndPoint]
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
/****** Object:  StoredProcedure [dbo].[AddECC_Service_To_EndPoint]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure [dbo].[AddECC_Service_To_EndPoint]
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


declare @id int 
select  @id = scope_identity()
return @id
GO
/****** Object:  StoredProcedure [dbo].[AddEndPointToECCService]    Script Date: 05/14/2014 16:59:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEndPointToECCService]
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
BEGIN                           
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

END
GO
/****** Object:  Default [DF_ERPCommunicationComponent_Active]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[ERPCommunicationComponent] ADD  CONSTRAINT [DF_ERPCommunicationComponent_Active]  DEFAULT (0) FOR [Active]
GO
/****** Object:  ForeignKey [FK_ERPCommunicator_ERPCommunicationComponent]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[ERPCommunicator]  WITH NOCHECK ADD  CONSTRAINT [FK_ERPCommunicator_ERPCommunicationComponent] FOREIGN KEY([ERPCommunicationComponent_ID])
REFERENCES [dbo].[ERPCommunicationComponent] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ERPCommunicator] CHECK CONSTRAINT [FK_ERPCommunicator_ERPCommunicationComponent]
GO
/****** Object:  ForeignKey [FK_Service_ERPCommunicationComponent]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_ERPCommunicationComponent] FOREIGN KEY([ERPCommunicationComponent_ID])
REFERENCES [dbo].[ERPCommunicationComponent] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_ERPCommunicationComponent]
GO
/****** Object:  ForeignKey [FK_Service_ServiceType]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_ServiceType] FOREIGN KEY([ServiceType_ID])
REFERENCES [dbo].[ServiceType] ([ID])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_ServiceType]
GO
/****** Object:  ForeignKey [FK_Service_To_EndPoit_EndPoint]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[Service_To_EndPoint]  WITH NOCHECK ADD  CONSTRAINT [FK_Service_To_EndPoit_EndPoint] FOREIGN KEY([EndPoint_ID])
REFERENCES [dbo].[EndPoint] ([ID])
GO
ALTER TABLE [dbo].[Service_To_EndPoint] CHECK CONSTRAINT [FK_Service_To_EndPoit_EndPoint]
GO
/****** Object:  ForeignKey [FK_Service_To_EndPoit_Service]    Script Date: 05/14/2014 16:59:50 ******/
ALTER TABLE [dbo].[Service_To_EndPoint]  WITH NOCHECK ADD  CONSTRAINT [FK_Service_To_EndPoit_Service] FOREIGN KEY([Service_ID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[Service_To_EndPoint] CHECK CONSTRAINT [FK_Service_To_EndPoit_Service]
GO
