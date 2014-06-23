using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    /// <summary>
    /// Class to make changes to ServiceType table by use of ConfigSettingsDS (typed DataSet) ServiceTypeTableAdapter
    /// </summary>
    public class Service
    {
        #region DataTableAdapter DAL Methods

        #region Properties

        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.ServiceDataTable()).ColumnIdName; }
        }

        public static string ColumnERPCommunicationComponentID
        {
            get { return (new ConfigSettingsDS.ServiceDataTable()).ERPCommunicationComponent_IDColumn.ColumnName; }
        }

        #endregion

        #region Methods

        public static ConfigSettingsDS.ServiceDataTable GetECCServices(int erpCommunicationComponentId)
        {
            using (var adapt = new ServiceTableAdapter())
            {
                return adapt.GetECCServices(erpCommunicationComponentId);
            }
        }

        public static int ChangeECCServiceEndPoint(int ecc_ID, int eccService_ID, int? fromEndPoint_ID, int? toEndPoint_ID)
        {
            using (var adapt = new ServiceTableAdapter())
            {
                return adapt.ChangeECCServiceEndPoint(ecc_ID, eccService_ID, fromEndPoint_ID, toEndPoint_ID);
            }
        }

        public static int DeleteECCService(int eccService_ID, bool deleteRelatedEndPoints)
        {
            using (var adapt = new ServiceTableAdapter())
            {
                return adapt.DeleteECCService(eccService_ID, deleteRelatedEndPoints);
            }
        }

        #endregion

        #endregion
    }
}
