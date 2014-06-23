using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Business;
using LanaSoft.ConfigDatabase.Dal;
using Service = LanaSoft.ConfigDatabase.Business.Service;

namespace LanaSoft.SettingsTool.Controls
{
    public partial class ERPCommunicationComponent : UserControl, ISettingsData
    {
        #region Properties

        public BusinessType OldData { get; set; }

        public int ID
        {
            get { return (OldData != null) ? OldData.ID : -1; }
            // set { _eccId = value; }
        }
        public new string Name
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public string ERPHost
        {
            get { return hostTextBox.Text; }
            set { hostTextBox.Text = value; }
        }

        public int ERPPort
        {
            get { return Convert.ToInt32(portTextBox.Text); }
            set { portTextBox.Text = value.ToString(); }
        }

        public int InactivityTimeOut
        {
            get { return Convert.ToInt32(inactivityTimeOutUpDown.Value); }
            set { inactivityTimeOutUpDown.Value = value; }
        }

        public bool IsActive
        {
            get { return activeCheckBox.Checked; }
            set { activeCheckBox.Checked = value; }
        }

        ConfigSettingsDS.ServiceDataTable _eccServicesDataTable;
        List<Service> ERPCommunicationComponentServices { get; set; }

        #endregion

        #region Handlers

        public ERPCommunicationComponent()
        {
            InitializeComponent();
        }

        public void InitDefaultSettingsData()
        {
            ClearSettingsData();
        }

        public void ClearSettingsData()
        {
            OldData = null;
            //
            Name = string.Empty;
            ERPHost = string.Empty;
            ERPPort = 0;
            InactivityTimeOut = 0;
            IsActive = false;

            ClearERPServices();
        }

        private void ClearERPServices()
        {
            ERPCommunicationComponentServices = new List<Service>();
            _eccServicesDataTable = new ConfigSettingsDS.ServiceDataTable();
            servicesDataGridView.DataSource = _eccServicesDataTable;
            servicesDataGridView.Update();
        }


        public void LoadSettingsData(BusinessType bObject)
        {
            //Save old data
            OldData = bObject;

            //Load data to view
            if (bObject != null)
            {
                var data = (ConfigDatabase.Business.ERPCommunicationComponent)bObject;

                Name = data.Name;
                ERPHost = data.ERPHost;
                ERPPort = data.ERPPort;
                InactivityTimeOut = data.InactivityTimeOut;
                IsActive = data.Active;

                //Load ecc services
                LoadERPServices();
            }
        }

        public void LoadERPServices()
        {
            _eccServicesDataTable = SettingsManager.GetERPCommunicationComponentServices(ID);
            ERPCommunicationComponentServices = _eccServicesDataTable;// SettingsManager.GetERPCommunicationComponentServices(ID);

            servicesDataGridView.DataSource = _eccServicesDataTable;
            servicesDataGridView.Update();

            foreach (DataGridViewColumn col in servicesDataGridView.Columns)
            {
                if (!SettingsManager.ECCServicesVisibleColumns.Contains(col.Name))
                    col.Visible = false;
            }
        }

        public BusinessType GetSettingsData()
        {
            var data = new ConfigDatabase.Business.ERPCommunicationComponent();
            data.Active = IsActive;
            data.Name = Name;
            data.ERPHost = ERPHost;
            data.ERPPort = ERPPort;
            data.InactivityTimeOut = InactivityTimeOut;
            data.ERPCommunicationComponentServices = ERPCommunicationComponentServices;
            return data;
        }

        public bool ValidateData()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(ERPHost))
                return true;
            return false;
        }

        #region ECC Services Methods

        private void newEndPointButton_Click(object sender, EventArgs e)
        {
            try
            {
                var editdlg = new EditECCServiceDialog();

                if (editdlg.ShowDialog() == DialogResult.OK)
                {
                    //Add Service for ECC if it is not exists 
                    int eccService_ID = SettingsManager.AddECCService(
                                                         ID,
                                                         editdlg.ServiceTypeID);

                    //Add EndPoint if it is not exists
                    int endPoint_ID = SettingsManager.AddEndPoint(
                                                         editdlg.ListenHost, editdlg.ListenPort,
                                                         editdlg.AnswerHost, editdlg.AnswerPort);
                    //ECC_ID,
                    //editdlg.ServiceTypeID);                    

                    int isAdded = SettingsManager.AddEndPointToECCService(ID, eccService_ID, endPoint_ID);

                    if (isAdded == -1)
                        MessageBox.Show("This endPoint already belongs to another Service Type,  please choose differ EndPoint", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        LoadERPServices();//ID);            
                    //Reload ECC Services                        
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateEndPointButton_Click(object sender, EventArgs e)
        {
            if (servicesDataGridView.SelectedRows.Count == 1)
            {
                int eccServiceID;
                int endPointID;

                var currRow = _eccServicesDataTable.Rows[servicesDataGridView.SelectedRows[0].Index];//Source Row
                SettingsManager.RetrieveECCServiceEndPointInfo(currRow, out eccServiceID, out endPointID);

                var editdlg = new EditECCServiceDialog(ID, currRow);
                //int oldECCServiceType_ID = editdlg.ServiceTypeID;
                int oldEndPoint_ID = endPointID;

                if (editdlg.ShowDialog() == DialogResult.OK)
                {
                    //Add EndPoint if it is not exists
                    int endPoint_ID = SettingsManager.AddEndPoint(editdlg.ListenHost, editdlg.ListenPort, editdlg.AnswerHost, editdlg.AnswerPort);

                    //Update endPoint, related with Service and then service of ECC
                    int isChanged = SettingsManager.ChangeECCServiceEndPoint(ID, eccServiceID, oldEndPoint_ID, endPoint_ID);

                    //Reload data from DB
                    if (isChanged == -1)
                        MessageBox.Show("This endPoint already belongs to another Service Type,  please choose differ EndPoint", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        LoadERPServices();//ID);
                }
            }
        }

        //Delete ECC Service endpoint
        private void removeEndPointButton_Click(object sender, EventArgs e)
        {
            int serviceID;
            int endPointID;

            if (servicesDataGridView.SelectedRows.Count > 0)
            {
                var currRow = _eccServicesDataTable.Rows[servicesDataGridView.SelectedRows[0].Index];
                SettingsManager.RetrieveECCServiceEndPointInfo(currRow, out serviceID, out endPointID);

                var deleteDlg = new RemoveEndPointFromECCServiceDialog(endPointID, serviceID);
                if (deleteDlg.ShowDialog() == DialogResult.OK)
                {
                    switch (deleteDlg.DeletionMode)
                    {
                        case ServiceDeletionMode.endPointLinkOnly:
                            SettingsManager.DeleteEndPoint(serviceID, endPointID, false);
                            break;

                        case ServiceDeletionMode.endPointLinkAndEndPoint:
                            SettingsManager.DeleteEndPoint(serviceID, endPointID, true);
                            break;

                        case ServiceDeletionMode.eccServiceOnly:
                            SettingsManager.DeleteECCService(serviceID, false);
                            break;

                        case ServiceDeletionMode.eccServiceAndRelatedEndPoint:
                            SettingsManager.DeleteECCService(serviceID, true);
                            break;

                    }
                    LoadERPServices();//ID);
                }
            }
        }

        #endregion

        #region Free Ports Handlers

        System.Net.IPAddress[] addrs;

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
        }

        private void hostTextBox_Validating(object sender, CancelEventArgs e)
        {
            addrs = SettingsManager.GetIPsByHostName(ERPHost);
            /*if ((addrs == null) || (addrs.Length == 0))
            {
                MessageBox.Show("Check full host name!");
                e.Cancel = true;
            }*/
        }

        private void portTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (addrs != null)
            {
                if ((System.Net.IPEndPoint.MinPort > ERPPort) || (System.Net.IPEndPoint.MaxPort < ERPPort))
                {
                    MessageBox.Show("Port must be >" + System.Net.IPEndPoint.MinPort.ToString() + " and <" + System.Net.IPEndPoint.MaxPort.ToString());
                    e.Cancel = true;
                }
                else if (!SettingsManager.IsPortFree(ERPHost, ERPPort))
                {
                    MessageBox.Show("Port " + ERPPort.ToString() + " is busy!");

                    e.Cancel = true;
                }
            }
        }

        #endregion

        #endregion
    }
}
