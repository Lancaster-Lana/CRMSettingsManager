using System;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;
using LanaSoft.ConfigDatabase.Dal.Properties;

//using LanaSoft.ConfigDatabase.Dal.Properties;

namespace LanaSoft.ConfigDatabase.Dal
{
    /// <summary>
    /// Class to make changes to CRMCommunicator table of ConfigSettingsDS by use CRMCommunicatorTableAdapter class
    /// </summary>
    public class CRMCommunicator
    {
        #region Business CRMCommunicator Object Methods

        public static int AddCRMCommunicator(Business.CRMCommunicator bCrmCommunicator)
        {
            return AddCRMCommunicator(bCrmCommunicator.CRMHost, bCrmCommunicator.CRMPort, bCrmCommunicator.Active);
        }

        /// <summary>
        /// Update CRMCommunicator  data by ID
        /// </summary>
        /// <param name="newCrmCommunicatorData"></param>
        /// <returns>status of updating</returns>
        public static int UpdateCRMCommunicator(Business.CRMCommunicator newCrmCommunicatorData)
        {
            return UpdateCRMCommunicator(newCrmCommunicatorData.ID, newCrmCommunicatorData.CRMHost, newCrmCommunicatorData.CRMPort, newCrmCommunicatorData.Active);
        }

        #endregion

        #region DataTableAdapter DAL Methods

        #region Properties

        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.CRMCommunicatorDataTable()).ColumnIdName; }
        }

        public static string ColumnCRMHost
        {
            get { return (new ConfigSettingsDS.CRMCommunicatorDataTable()).CRMHostColumn.ColumnName; }
        }

        public static string ColumnCRMPort
        {
            get { return (new ConfigSettingsDS.CRMCommunicatorDataTable()).CRMPortColumn.ColumnName; }
        }

        public static string ColumnListenHost
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).ListenHostColumn.ColumnName; }
        }

        #endregion

        #region Methods

        public static int AddCRMCommunicator(string host, int? port)
        {
            return AddCRMCommunicator(host, port, true);
        }

        public static int AddCRMCommunicator(string host, int? port, bool? isActive)
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                var ID = adapt.AddCRMCommunicator(host, port, isActive);
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        public static ConfigSettingsDS.CRMCommunicatorDataTable GetCRMCommunicators()
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                return adapt.GetCRMCommunicators();
            }
        }

        public static ConfigSettingsDS.CRMCommunicatorRow GetActiveCRMCommunicator()
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                var activeCRMComm = adapt.GetActiveCRMCommunicator();
                return (activeCRMComm.Count > 0) ? activeCRMComm[0] : null;
            }
        }

        public static ConfigSettingsDS.CRMCommunicatorRow GetCRMCommunicator(int crmCommunicatorId)
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                return adapt.GetCRMCommunicator(crmCommunicatorId)[0];
            }
        }

        public static int DeleteCRMCommunicator(int crmCommunicatorId)
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                return adapt.DeleteCRMCommunicator(crmCommunicatorId);
            }
        }

        public static int ClearCRMCommunicators()
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                return adapt.ClearCRMCommunicators();
            }
        }

        public static int UpdateCRMCommunicator(int id, string host, int? port, bool? isActive)
        {
            using (var adapt = new CRMCommunicatorTableAdapter())
            {
                return adapt.UpdateCRMCommunicator(id, host, port, isActive);
            }
        }

        #endregion

        #endregion
    }
}
