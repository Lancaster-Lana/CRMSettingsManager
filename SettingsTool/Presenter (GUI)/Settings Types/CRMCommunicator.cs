using System;
using System.ComponentModel;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Business;

namespace LanaSoft.SettingsTool.Controls
{
    public partial class CRMCommunicator : UserControl, ISettingsData
    {
        #region Properties

        public BusinessType OldData { get; set; }

        public int ID
        {
            get { return (OldData != null) ? OldData.ID : -1; }
        }

        public string CRMHost
        {
            get { return hostTextBox.Text; }
            set { hostTextBox.Text = value; }
        }

        public int CRMPort
        {
            get { return Convert.ToInt32(portTextBox.Text); }
            set { portTextBox.Text = value.ToString(); }
        }

        public bool Active
        {
            get { return activeCheckBox.Checked; }
            set { activeCheckBox.Checked = value; }
        }

        #endregion

        #region Methods

        public void InitDefaultSettingsData()
        {
            ClearSettingsData();
        }

        public void ClearSettingsData()
        {
            OldData = null;
            CRMHost = string.Empty;
            CRMPort = 0;
        }

        public void LoadSettingsData(BusinessType bObject)
        {
            OldData = bObject;

            if (bObject != null)
            {
                var data = (ConfigDatabase.Business.CRMCommunicator)bObject;
                CRMHost = data.CRMHost;
                CRMPort = data.CRMPort;
                Active = data.Active;
                //ID = data.ID; saved in old data
            }
        }

        public BusinessType GetSettingsData()
        {
            var data = new ConfigDatabase.Business.CRMCommunicator();
            data.Active = Active;
            data.CRMHost = CRMHost;
            data.CRMPort = CRMPort;
            return data;
        }

        public bool ValidateData()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(CRMHost))
                return true;
            return false;
        }

        public CRMCommunicator()
        {
            InitializeComponent();
        }

        #endregion

        #region Handlers

        private void CRMCommunicator_Validating(object sender, CancelEventArgs e)
        {

        }

        private void portTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void hostTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        #endregion
    }
}
