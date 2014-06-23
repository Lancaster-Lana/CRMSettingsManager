using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LanaSoft.SettingsTool.Controls
{
    public partial class ERPCommunicator : UserControl, ISettingsData//, IToolItem
    {
        ConfigDatabase.Business.BusinessType _oldData;
        int _id;

        #region Properties

        public int ID
        {
            get { return (OldData != null) ? OldData.ID : -1; }
        }

        public int ERPCommunicationComponentID
        {
            get
            {
                try
                {
                    return Convert.ToInt32(erpCommunicationComponentComboBox.SelectedValue);
                }
                catch
                {
                    return -1;
                }

            }
            set
            {
                erpCommunicationComponentComboBox.SelectedValue = value;
            }
        }

        #endregion

        #region ERPCommunicator properties

        public ConfigDatabase.Business.BusinessType OldData
        {
            get { return _oldData; }
            set { _oldData = value; }
        }


        public int ERPClientTypeID
        {
            get { return (typeComboBox.SelectedValue is int) ? Convert.ToInt32(typeComboBox.SelectedValue) : -1; }
            set { typeComboBox.SelectedValue = value; }
        }

        public string AnswerHost
        {
            get { return answerHostTextBox.Text; }
            set { answerHostTextBox.Text = value; }
        }

        public int AnswerPort
        {
            get { return Convert.ToInt32(answerPortUpDown.Value); }
            set { answerPortUpDown.Value = value; }
        }

        public int OpenTimeOut
        {
            get { return Convert.ToInt32(openTimeOutUpDown.Value); }
            set { openTimeOutUpDown.Value = value; }
        }

        public int CloseTimeOut
        {
            get { return Convert.ToInt32(closeTimeOutUpDown.Value); }
            set { closeTimeOutUpDown.Value = value; }
        }

        public int SendTimeOut
        {
            get { return Convert.ToInt32(sendTimeOutUpDown.Value); }
            set { sendTimeOutUpDown.Value = value; }
        }

        public int ReceiveTimeOut
        {
            get { return Convert.ToInt32(receiveTimeOutUpDown.Value); }
            set { receiveTimeOutUpDown.Value = value; }
        }

        public int InactivetimeOut
        {
            get { return Convert.ToInt32(inactivetimeOutUpDown.Value); }
            set { inactivetimeOutUpDown.Value = value; }
        }

        #endregion

        #region Methods

        public ERPCommunicator()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            try
            {
                //Init ERPCommunicationComponents 
                DataTable dtECC = SettingsManager.GetERPCommunicationComponents();
                erpCommunicationComponentComboBox.DataSource = dtECC;
                erpCommunicationComponentComboBox.ValueMember = ConfigDatabase.Dal.ERPCommunicationComponent.IDColumnName; //"ID";
                erpCommunicationComponentComboBox.DisplayMember = ConfigDatabase.Dal.ERPCommunicationComponent.ColumnName; //"Name";
                erpCommunicationComponentComboBox.Update();

                DataTable dtERPClientType = SettingsManager.GetERPClientTypes();
                typeComboBox.DataSource = dtERPClientType;
                typeComboBox.ValueMember = ConfigDatabase.Dal.ERPClientType.IDColumnName;//"ID";
                typeComboBox.DisplayMember = ConfigDatabase.Dal.ERPClientType.ColumnServiceType;//"ClientName";
                typeComboBox.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Show(Panel panel)
        {
            panel.Controls.Add(this);
        }

        public void InitDefaultSettingsData()
        {
            ClearSettingsData();
            var bActiveECC = SettingsManager.GetActiveERPCommunicationComponent();
            ERPCommunicationComponentID = (bActiveECC != null) ? bActiveECC.ID : -1;
        }

        public void ClearSettingsData()
        {
            OldData = null;

            //
            ERPCommunicationComponentID = -1;
            ERPClientTypeID = -1;

            AnswerHost = string.Empty;
            AnswerPort = 0;

            OpenTimeOut = 0;
            CloseTimeOut = 0;
            SendTimeOut = 0;
            ReceiveTimeOut = 0;
        }

        public void LoadSettingsData(ConfigDatabase.Business.BusinessType bObject)
        {
            if (bObject != null)
            {
                var data = (ConfigDatabase.Business.ERPCommunicationComponent)bObject;
                ERPCommunicationComponentID = data.ID;

                /*
                ConfigDatabase.business.ERPCommunicator data = (ConfigDatabase.business.ERPCommunicator)bObject;

                if (data != null)
                {
                    ERPCommunicationComponentID = (data.ERPCommunicationComponent != null)? data.ERPCommunicationComponent.ID: -1;
                    ERPClientTypeID = (data.ERPClientType != null) ? data.ERPClientType.ID : -1;

                    AnswerHost = data.AnswerHost;
                    AnswerPort = data.AnswerPort;

                    OpenTimeOut = data.OpenTimeOut;
                    CloseTimeOut = data.CloseTimeOut;
                    SendTimeOut = data.SendTimeOut;
                    ReceiveTimeOut = data.ReceiveTimeOut;
                    InactivetimeOut = data.InactiveTimeOut;
                }*/
            }
        }


        public ConfigDatabase.Business.BusinessType GetSettingsData()
        {
            var data = new ConfigDatabase.Business.ERPCommunicator();
            data.AnswerHost = AnswerHost;
            data.AnswerPort = AnswerPort;
            data.OpenTimeOut = OpenTimeOut;
            data.CloseTimeOut = CloseTimeOut;
            data.ReceiveTimeOut = ReceiveTimeOut;
            data.SendTimeOut = SendTimeOut;
            data.InactiveTimeOut = InactivetimeOut;
            if (data.ERPClientType != null)
                data.ERPClientType.ID = ERPClientTypeID;
            //data.ERPCommunicationComponentServices = ERPCommunicationComponentServices;
            return data;
        }

        public bool ValidateData()
        {
            if (ERPCommunicationComponentID > -1)
                return true;
            return false;
        }


        private void LoadERPClientData(int erpClientTypeID)
        {
            var erpClients = SettingsManager.GetERPCommunicatorsByECC_ID(ERPCommunicationComponentID);

            foreach (ConfigDatabase.Business.ERPCommunicator bObject in erpClients)
            {
                if (erpClientTypeID == bObject.ERPClientType.ID)
                {
                    LoadERPClientData(bObject);
                    break;
                }
            }
        }

        private void LoadERPClientData(ConfigDatabase.Business.ERPCommunicator data)
        {
            //Save old data;
            OldData = data;

            //Load data to view
            ((DetailedControl)this.Parent.Parent).CurrentID = data.ID;

            if (data != null)
            {
                ERPCommunicationComponentID = (data.ERPCommunicationComponent != null) ? data.ERPCommunicationComponent.ID : -1;
                ERPClientTypeID = (data.ERPClientType != null) ? data.ERPClientType.ID : -1;

                AnswerHost = data.AnswerHost;
                AnswerPort = data.AnswerPort;

                OpenTimeOut = data.OpenTimeOut;
                CloseTimeOut = data.CloseTimeOut;
                SendTimeOut = data.SendTimeOut;
                ReceiveTimeOut = data.ReceiveTimeOut;
                InactivetimeOut = data.InactiveTimeOut;
            }
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadERPClientData(ERPClientTypeID);
        }

        #endregion

    }
}
