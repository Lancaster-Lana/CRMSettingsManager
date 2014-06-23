using System;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    public class ERPClientType
    {
        #region DataTableAdapter DAL Methods

        #region Properties


        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.ERPClientTypeDataTable()).IDColumn.ColumnName; }
        }

        public static string ColumnServiceType
        {
            get { return (new ConfigSettingsDS.ERPClientTypeDataTable()).ClientNameColumn.ColumnName; }
        }

        #endregion

        #region Methods

        public static int AddERPClientType(string clientTypeName)
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                object ID = Convert.ToInt32(adapt.AddERPClientType(clientTypeName));
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        public static ConfigSettingsDS.ERPClientTypeDataTable GetERPClientTypes()
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                return adapt.GetERPClientTypes();
            }
        }

        public static ConfigSettingsDS.ERPClientTypeRow GetERPClientType(int clientTypeId)
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                var tbl = adapt.GetERPClientType(clientTypeId);
                return (tbl.Count > 0) ? tbl[0] : null;
            }
        }

        public static int DeleteERPClientType(int clientTypeId)
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                return adapt.DeleteERPClientType(clientTypeId);
            }
        }

        public static int UpdateERPClientType(int id, string newTypeName)
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                return adapt.UpdateERPClientType(id, newTypeName);
            }
        }

        public static int ClearERPClientTypes()
        {
            using (var adapt = new ERPClientTypeTableAdapter())
            {
                return adapt.ClearERPClientTypes();
            }
        }

        #endregion

        #endregion
    }
}
