using System;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    public class ServiceType
    {
        #region  Business ServiceType Object Methods

        public static int UpdateServiceType(Business.ServiceType serviceTypeData)
        {
            return UpdateServiceType(serviceTypeData.ID, serviceTypeData.TypeName);
        }

        #endregion

        #region DataTableAdapter DAL Methods

        #region Properties

        public static string ColumnServiceType
        {
            get { return (new ConfigSettingsDS.ServiceTypeDataTable()).NameColumn.ColumnName; }
        }

        #endregion

        #region Methods

        public static int AddServiceType(string serviceTypeName)
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                var ID = Convert.ToInt32(adapt.AddServiceType(serviceTypeName));
                return Convert.ToInt32(ID);
            }
        }

        public static ConfigSettingsDS.ServiceTypeDataTable GetServiceTypes()
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                return adapt.GetServiceTypes();
            }
        }

        public static ConfigSettingsDS.ServiceTypeRow GetServiceType(int serviceTypeId)
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                var tbl = adapt.GetServiceType(serviceTypeId);
                return (tbl.Count > 0) ? tbl[0] : null;
            }
        }

        public static int DeleteServiceType(int serviceTypeId)
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                return adapt.DeleteServiceType(serviceTypeId);
            }
        }

        public static int UpdateServiceType(int id, string newTypeName)
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                return adapt.UpdateServiceType(id, newTypeName);
            }
        }

        public static int ClearServices()
        {
            using (var adapt = new ServiceTypeTableAdapter())
            {
                return adapt.ClearServiceTypes();
            }
        }

        #endregion

        #endregion
    }
}
