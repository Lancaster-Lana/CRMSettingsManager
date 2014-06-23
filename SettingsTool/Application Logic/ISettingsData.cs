using LanaSoft.ConfigDatabase.Business;

namespace LanaSoft.SettingsTool
{
    interface ISettingsData
    {
        BusinessType OldData { get; set; }
        void LoadSettingsData(BusinessType data);
        BusinessType GetSettingsData();
        void InitDefaultSettingsData();
        void ClearSettingsData();
        bool ValidateData();
    }
}
