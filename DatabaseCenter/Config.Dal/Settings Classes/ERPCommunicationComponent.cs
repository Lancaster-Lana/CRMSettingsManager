using System;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    /// <summary>
    /// Class to make changes to ERPCommunicationComponent table Config DB by use of ConfigSettingsDS (typed DataSet) Adapter class
    /// </summary>
    public class ERPCommunicationComponent
    {

        #region DataTableAdapter DAL Methods

        #region Properties

        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).ColumnIdName; }
        }

        public static string ColumnName
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).NameColumn.ColumnName; }
        }

        public static string ColumnERPHost
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).ERPHostColumn.ColumnName; }
        }

        public static string ColumnERPPort
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).ERPPortColumn.ColumnName; }
        }

        public static string ColumnInactivityTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).InactivityTimeOutColumn.ColumnName; }
        }

        public static string ColumnActive
        {
            get { return (new ConfigSettingsDS.ERPCommunicationComponentDataTable()).ActiveColumn.ColumnName; }
        }


        #region Properties from Collected information for ECC Services (results of GetECCServices procedure execution)

        /// <summary>
        /// !!! From GetECCServices procedure columns
        /// </summary>
        public static string ServiceTypeID
        {
            get { return "ServiceType_ID"; }
        }

        /// <summary>
        /// From GetECCServices procedure columns
        /// </summary>
        public static string EndPointID
        {
            get { return "EndPoint_ID"; }
        }

        public static string ECCServiceID
        {
            get { return "Service_ID"; }
        }

        #endregion

        #endregion

        /// <summary>
        /// Return ID of added ECC or null - if it is not added.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="erpHost"></param>
        /// <param name="erpPort"></param>
        /// <param name="inactivityTimeout"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public static int AddERPCommunicationComponent(string name, string erpHost, int? erpPort, int? inactivityTimeout, bool isActive)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                object ID = adapt.AddERPCommunicationComponent(name, erpHost, erpPort, inactivityTimeout, isActive);
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        /// <summary>
        /// Add ERP Service (Data, Metadata, Action) for ERP Communication Component
        /// </summary>
        /// <param name="ecc_ID"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static int AddECCService(int ecc_ID, int serviceType_ID)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                object ID = adapt.AddECCService(ecc_ID, serviceType_ID);
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        /// <summary>
        /// Returns -1 if EndPoint is not added
        /// </summary>
        /// <param name="ecc_ID"></param>
        /// <param name="eccService_ID"></param>
        /// <param name="endPoint_ID"></param>
        /// <returns></returns>
        public static int AddEndPointToECCService(int ecc_ID, int eccService_ID, int endPoint_ID)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.AddEndPointToECCService(ecc_ID, eccService_ID, endPoint_ID);
            }
        }

        public static ConfigSettingsDS.ERPCommunicationComponentDataTable GetERPCommunicationComponents()
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.GetERPCommunicationComponents();
            }
        }

        public static ConfigSettingsDS.ERPCommunicationComponentRow GetERPCommunicationComponent(int erpCommunicationComponentId)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                var tbl = adapt.GetERPCommunicationComponent(erpCommunicationComponentId);
                return (tbl.Count > 0) ? tbl[0] : null;
            }
        }

        public static ConfigSettingsDS.ERPCommunicationComponentRow GetActiveCommunicationComponent()
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                var tbl = adapt.GetActiveERPCommunicationComponent();
                return (tbl.Count > 0) ? tbl[0] : null;
            }
        }

        public static int DeleteERPCommunicationComponent(int? erpCommunicationComponentsId)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.DeleteERPCommunicationComponent(erpCommunicationComponentsId);
            }
        }

        public static int ClearERPCommunicationComponents()
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.ClearERPCommunicationComponents();
            }
        }

        public static int UpdateERPCommunicationComponent(int id, string name, string erpHost, int? erpPort, int? inactivityTimeout, bool? isActive)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.UpdateERPCommunicationComponent(id, name, erpHost, erpPort, inactivityTimeout, isActive);
            }
        }

        /// <summary>
        /// Update serviceType for ERP Communication Component
        /// </summary>
        /// <param name="ecc_Id"></param>
        /// <param name="oldServiceType"></param>
        /// <param name="newServiceType"></param>
        /// <returns></returns>
        public static int UpdateECCService(int ecc_Id, string oldServiceType, string newServiceType)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.UpdateECCService(ecc_Id, oldServiceType, newServiceType);
            }
        }

        public static int UpdateECCServiceEndPoint(int ecc_Id, int serviceType_ID, string listenHost, int listenPort, string answerHost, int answerPort)
        {
            using (var adapt = new ERPCommunicationComponentTableAdapter())
            {
                return adapt.UpdateECCServiceEndPoint(ecc_Id, serviceType_ID, listenHost, listenPort, answerHost, answerPort);
            }
        }

        #endregion
    }
}