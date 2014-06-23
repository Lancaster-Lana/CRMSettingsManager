using System;
using System.ComponentModel;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Business;

namespace LanaSoft.SettingsTool.Controls
{
    public partial class ServiceType : UserControl, ISettingsData//, IToolItem
    {
        #region Properties 

        public BusinessType OldData { get; set; }

        public int ID
        {
            get { return (OldData != null) ? OldData.ID : -1; }
        }

        public string ServiceTypeName
        {
            get { return serviceTypeNameTextBox.Text; }
            set { serviceTypeNameTextBox.Text = value; }
        }

        #endregion

        #region Methods

        public ServiceType()
        {
            InitializeComponent();
        }

        public void Show(Panel panel)
        {
            panel.Controls.Add(this);
        }

        public void InitDefaultSettingsData()
        {
            ClearSettingsData();
        }

        public void ClearSettingsData()
        {
            OldData = null;
            ServiceTypeName = string.Empty;
        }        

        public void LoadSettingsData(BusinessType bObject)
        {
            //Save Old Data
            OldData = bObject;
            //Load data to controls
            var data = (ConfigDatabase.Business.ServiceType)bObject;
            ServiceTypeName = data.TypeName;
            //ID = data.ID;
        }

        public BusinessType GetSettingsData()
        {
            var data = new ConfigDatabase.Business.ServiceType();
            data.TypeName = ServiceTypeName;
            return data;
        }

        public bool ValidateData()
        {
            if (!string.IsNullOrEmpty(ServiceTypeName))
                return true;
            return false;           
        }

        #endregion

        private void ServiceType_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void ServiceType_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void serviceTypeNameTextBox_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
