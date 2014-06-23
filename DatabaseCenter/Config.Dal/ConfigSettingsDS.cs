using System.Collections.Generic;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    /// <summary>
    /// Custom class to add/delete/update rows in ConfigSettingsDS, related with efficient DB
    /// </summary>
    partial class ConfigSettingsDS
    {
        #region Server

        partial class ERPCommunicationComponentDataTable
        {
            public string ColumnIdName
            {
                get { return this.columnID.ColumnName; }
            }

            public static implicit operator List<Business.ERPCommunicationComponent>(ERPCommunicationComponentDataTable fromECCTable)
            {
                var bERPCommunicationComponents = new List<Business.ERPCommunicationComponent>();
                foreach (ERPCommunicationComponentRow eccRow in fromECCTable)
                    bERPCommunicationComponents.Add(eccRow);

                return bERPCommunicationComponents;
            }
        }

        partial class ERPCommunicationComponentRow
        {
            public static implicit operator Business.ERPCommunicationComponent(ERPCommunicationComponentRow fromECCRow)
            {
                if (fromECCRow != null)
                {
                    var bERPCommunicationComponent = new Business.ERPCommunicationComponent();
                    bERPCommunicationComponent.ID = fromECCRow.ID;
                    bERPCommunicationComponent.Name = fromECCRow.Name;
                    bERPCommunicationComponent.ERPHost = fromECCRow.ERPHost;
                    bERPCommunicationComponent.ERPPort = fromECCRow.ERPPort;
                    bERPCommunicationComponent.InactivityTimeOut = fromECCRow.InactivityTimeOut;
                    bERPCommunicationComponent.Active = fromECCRow.Active;
                    bERPCommunicationComponent.ERPCommunicationComponentServices = GetERPCommunicationComponentServices(fromECCRow.ID);
                    return bERPCommunicationComponent;
                }
                return null;
                //   throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }

            public static ServiceDataTable GetERPCommunicationComponentServices(int? erpCommunicationComponentId)
            {
                using (var adapt = new ServiceTableAdapter())
                {
                    return adapt.GetECCServices(erpCommunicationComponentId);
                    //return adapt.GetERPCommunicationComponentServices(erpCommunicationComponentId);
                }
            }
        }

        partial class EndPointDataTable
        {
            public string ColumnIdName
            {
                get { return this.columnID.ColumnName; }
            }

            public static implicit operator List<LanaSoft.ConfigDatabase.Business.EndPoint>(EndPointDataTable fromEndPointTable)
            {
                if (fromEndPointTable != null)
                {
                    var bEndPoints = new List<LanaSoft.ConfigDatabase.Business.EndPoint>();
                    foreach (EndPointRow fromEndPointRow in fromEndPointTable)
                        bEndPoints.Add(fromEndPointRow);
                    return bEndPoints;
                }
                return null;
            }
        }

        partial class EndPointRow
        {
            public static implicit operator Business.EndPoint(EndPointRow fromEndPointRow)
            {
                if (fromEndPointRow != null)
                {
                    var bEndPoint = new Business.EndPoint();
                    bEndPoint.ID = fromEndPointRow.ID;
                    bEndPoint.ListenHost = fromEndPointRow.ListenHost;
                    bEndPoint.ListenPort = fromEndPointRow.ListenPort;
                    bEndPoint.AnswerHost = fromEndPointRow.AnswerHost;
                    bEndPoint.AnswerPort = fromEndPointRow.AnswerPort;
                    return bEndPoint;
                }
                return null;// throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }
        }


        partial class ServiceDataTable
        {
            public string ColumnIdName
            {
                get { return this.columnID.ColumnName; }
            }

            public static implicit operator List<Business.Service>(ServiceDataTable fromECCServices)
            {
                if (fromECCServices != null)
                {
                    var bECCServices = new List<Business.Service>();
                    foreach (ServiceRow fromServiceRow in fromECCServices)
                        bECCServices.Add(fromServiceRow);//Auto convert to Business.Service, because of implicit operator

                    return bECCServices;
                }
                return null;
            }
        }

        partial class ServiceRow
        {
            public static implicit operator Business.Service(ServiceRow fromServiceRow)
            {
                if (fromServiceRow != null)
                {
                    var bECCService = new Business.Service();
                    bECCService.ID = fromServiceRow.ID;
                    bECCService.ServiceType = GetServiceTypeNameByID(fromServiceRow.ServiceType_ID);//fromServiceRow.ServiceTypeRow; // there is implicit
                    bECCService.ERPCommunicationComponentID = fromServiceRow.ERPCommunicationComponent_ID;
                    //bECCService.ERPCommunicationComponent = ERPCommunicationComponentById(fromServiceRow.ERPCommunicationComponent_ID);
                    //GetERPCommunicationComponent(fromServiceRow.ERPCommunicationComponent_ID);
                    //fromServiceRow.ERPCommunicationComponentRow;
                    //TODO:
                    //bECCService.EndPoints = GetECCServiceEndPoints(fromServiceRow.ID);

                    return bECCService;
                }
                return null;//  throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }

            private static Business.ServiceType GetServiceTypeNameByID(int serviceType_ID)
            {
                using (var adapt = new ServiceTypeTableAdapter())
                {
                    return adapt.GetServiceType(serviceType_ID)[0];
                }
            }

            /// <summary>
            /// ServiceDataTable class has implicit convert to List<EndPoint>
            /// </summary>
            /// <param name="serviceID"></param>
            /// <returns></returns>
            public static EndPointDataTable GetECCServiceEndPoints(int? eccServiceID)
            {
                using (var adapt = new EndPointTableAdapter())
                {
                    return adapt.GetECCServiceEndPoints(eccServiceID);
                }
            }
        }

        public partial class ServiceTypeDataTable
        {
            public static implicit operator List<Business.ServiceType>(ServiceTypeDataTable fromServiceTypeTable)
            {
                if (fromServiceTypeTable != null)
                {
                    var bServiceTypes = new List<Business.ServiceType>();
                    foreach (ServiceTypeRow fromServiceTypeRow in fromServiceTypeTable)
                        bServiceTypes.Add(fromServiceTypeRow);

                    return bServiceTypes;
                }
                return null;
            }
        }

        public partial class ServiceTypeRow
        {
            public static implicit operator Business.ServiceType(ServiceTypeRow fromServiceTypeRow)
            {
                if (fromServiceTypeRow != null)
                {
                    var bServiceType = new Business.ServiceType();
                    bServiceType.ID = fromServiceTypeRow.ID;
                    bServiceType.TypeName = fromServiceTypeRow.Name;
                    return bServiceType;
                }
                return null;// throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }
        }

        #endregion

        #region Client

        partial class ERPClientTypeDataTable
        {
            public static implicit operator List<Business.ERPClientType>(ERPClientTypeDataTable fromERPClientTypeTable)
            {
                if (fromERPClientTypeTable != null)
                {
                    var bERPClientTypes = new List<Business.ERPClientType>();
                    foreach (ERPClientTypeRow fromERPClientTypeRow in fromERPClientTypeTable)
                        bERPClientTypes.Add(fromERPClientTypeRow);

                    return bERPClientTypes;
                }
                return null;
            }
        }

        partial class ERPClientTypeRow
        {
            public static implicit operator Business.ERPClientType(ERPClientTypeRow fromERPClientTypeRow)
            {
                if (fromERPClientTypeRow != null)
                {
                    var bERPClientType = new Business.ERPClientType();
                    bERPClientType.ID = fromERPClientTypeRow.ID;
                    bERPClientType.ClientName = fromERPClientTypeRow.ClientName;
                    return bERPClientType;
                }
                return null;
            }
        }


        partial class ERPCommunicatorDataTable
        {
            public string ColumnIdName
            {
                get { return this.columnID.ColumnName; }
            }

            public static implicit operator List<Business.ERPCommunicator>(ERPCommunicatorDataTable fromERPCommunicatorDataTable)
            {
                var bERPCommunicators = new List<Business.ERPCommunicator>();
                foreach (ERPCommunicatorRow erpCommunicatorRow in fromERPCommunicatorDataTable)
                    bERPCommunicators.Add(erpCommunicatorRow);

                return bERPCommunicators;
            }
        }

        partial class ERPCommunicatorRow
        {
            public static implicit operator Business.ERPCommunicator(ERPCommunicatorRow fromERPCommunicatorRow)
            {
                if (fromERPCommunicatorRow != null)
                {
                    var bERPCommunicator = new Business.ERPCommunicator();
                    bERPCommunicator.ID = fromERPCommunicatorRow.ID;

                    bERPCommunicator.AnswerHost = fromERPCommunicatorRow.AnswerHost;
                    bERPCommunicator.AnswerPort = fromERPCommunicatorRow.AnswerPort;

                    bERPCommunicator.OpenTimeOut = fromERPCommunicatorRow.OpenTimeOut;
                    bERPCommunicator.CloseTimeOut = fromERPCommunicatorRow.CloseTimeOut;
                    bERPCommunicator.SendTimeOut = fromERPCommunicatorRow.SendTimeOut;
                    bERPCommunicator.ReceiveTimeOut = fromERPCommunicatorRow.ReceiveTimeOut;

                    bERPCommunicator.ERPCommunicationComponent = GetERPCommunicationComponentById(fromERPCommunicatorRow.ERPCommunicationComponent_ID);//Stub !!!
                    bERPCommunicator.ERPClientType = GetERPClientTypeById(fromERPCommunicatorRow.ERPClientType_ID);//Stub !!!
                    //fromERPCommunicatorRow.ERPCommunicationComponentRow;
                    return bERPCommunicator;
                }
                return null;//throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }

            public static ERPCommunicationComponentRow GetERPCommunicationComponentById(int eccID)
            {
                using (var adapt = new ERPCommunicationComponentTableAdapter())
                {
                    var tbl = adapt.GetERPCommunicationComponent(eccID);
                    if (tbl.Count > 0) return tbl[0];
                }
                return null;
            }

            public static ERPClientTypeRow GetERPClientTypeById(int erpClientTypeID)
            {
                using (var adapt = new ERPClientTypeTableAdapter())
                {
                    var tbl = adapt.GetERPClientType(erpClientTypeID);
                    if (tbl.Count > 0) return tbl[0];
                }
                return null;
            }
        }

        partial class CRMCommunicatorDataTable
        {
            public string ColumnIdName
            {
                get { return this.columnID.ColumnName; }
            }

            public static implicit operator List<Business.CRMCommunicator>(CRMCommunicatorDataTable fromCRMCommunicatorTable)
            {
                if (fromCRMCommunicatorTable != null)
                {
                    var bCRMCommunicators = new List<Business.CRMCommunicator>();
                    foreach (CRMCommunicatorRow crmCommunicatorRow in fromCRMCommunicatorTable)
                    {
                        bCRMCommunicators.Add(crmCommunicatorRow);
                    }

                    return bCRMCommunicators;
                }
                return null;
            }
        }

        partial class CRMCommunicatorRow
        {
            public static implicit operator Business.CRMCommunicator(CRMCommunicatorRow fromCRMCommunicatorRow)
            {
                if (fromCRMCommunicatorRow != null)
                {
                    var bCRMCommunicator = new Business.CRMCommunicator();
                    bCRMCommunicator.ID = fromCRMCommunicatorRow.ID;
                    bCRMCommunicator.CRMHost = fromCRMCommunicatorRow.CRMHost;
                    bCRMCommunicator.CRMPort = fromCRMCommunicatorRow.CRMPort;
                    bCRMCommunicator.Active = fromCRMCommunicatorRow.Active;

                    return bCRMCommunicator;
                }
                return null;//  throw new ConfigDatabaseException(ConfigDatabaseExceptionType.emptyRow);
            }
        }
        #endregion
    }
}

namespace LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters
{
    partial class CRMCommunicatorTableAdapter
    {
        public CRMCommunicatorTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class ERPCommunicationComponentTableAdapter
    {
        public ERPCommunicationComponentTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class ServiceTableAdapter
    {
        public ServiceTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class Service_To_EndPointTableAdapter
    {
        public Service_To_EndPointTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class ServiceTypeTableAdapter
    {
        public ServiceTypeTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class EndPointTableAdapter
    {
        public EndPointTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class ERPCommunicatorTableAdapter
    {
        public ERPCommunicatorTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }

    partial class ERPClientTypeTableAdapter
    {
        public ERPClientTypeTableAdapter(string connection)
        {
            this.Connection.ConnectionString = connection;
        }
    }
}
