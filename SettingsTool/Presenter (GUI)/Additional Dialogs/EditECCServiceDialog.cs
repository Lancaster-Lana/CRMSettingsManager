using System;
using System.Data;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Dal;

namespace LanaSoft.SettingsTool
{
    public partial class EditECCServiceDialog : Form
    {
        #region Peoperties

        public int EndPointID
        {
            get
            {
                return (endPointComboBox.SelectedValue is Nullable) ? -1 : Convert.ToInt32(endPointComboBox.SelectedValue);
            }
            set
            {
                endPointComboBox.SelectedValue = value;
            }
        }

        public int ServiceTypeID
        {
            get
            {
                return (serviceTypeComboBox.SelectedValue is Nullable) ? -1 : Convert.ToInt32(serviceTypeComboBox.SelectedValue);
            }
            set
            {
                serviceTypeComboBox.SelectedValue = value;
            }
        }

        public string ListenHost
        {
            get { return listenHostTextBox.Text; }
            set { listenHostTextBox.Text = value; }
        }

        public int ListenPort
        {
            get
            {
                if (!string.IsNullOrEmpty(listenPortTextBox.Text))
                {
                    return Convert.ToInt32(listenPortTextBox.Text);
                }
                return 0;
            }
            set { listenPortTextBox.Text = value.ToString(); }
        }

        public string AnswerHost
        {
            get { return answerHostTextBox.Text; }
            set { answerHostTextBox.Text = value; }
        }

        public int AnswerPort
        {
            get
            {
                if (!string.IsNullOrEmpty(answerPortTextBox.Text))
                {
                    return Convert.ToInt32(answerPortTextBox.Text);
                }
                return 0;
            }
            set { answerPortTextBox.Text = value.ToString(); }
        }

        public EditECCServiceDialog()
        {
            InitializeComponent();
            Init();
        }

        #endregion

        #region Methods

        public void Init()
        {
            try
            {
                DataTable dtServiseTypes = SettingsManager.GetServiceTypes();
                serviceTypeComboBox.DataSource = dtServiseTypes;
                serviceTypeComboBox.ValueMember = "ID";
                serviceTypeComboBox.DisplayMember = "Name";
                serviceTypeComboBox.Update();

                DataTable dtEndPoints = SettingsManager.GetEndPoints();
                endPointComboBox.DataSource = dtEndPoints;
                endPointComboBox.ValueMember = "ID";
                endPointComboBox.DisplayMember = "Description";
                endPointComboBox.Update();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        public EditECCServiceDialog(int eccId, DataRow data)
            : this()
        {
            serviceTypeComboBox.Enabled = false;
            LoadDataToEdit(data);
        }

        public void LoadDataToEdit(/*int eccId,*/ DataRow data)
        {
            try
            {
                ServiceTypeID = Convert.ToInt32(data[ConfigDatabase.Dal.ERPCommunicationComponent.ServiceTypeID]);

                //Changing the EndPoint - auto loads (ListenHost, ListenPort, AnswerHost, AnswerPort)
                EndPointID = (data[ConfigDatabase.Dal.ERPCommunicationComponent.EndPointID] is System.DBNull) ? -1 : Convert.ToInt32(data[ConfigDatabase.Dal.ERPCommunicationComponent.EndPointID]);

                /*
                ListenHost = data[ConfigDatabase.Dal.EndPoint.ColumnListenHost].ToString();
                ListenPort = (data[ConfigDatabase.Dal.EndPoint.ColumnListenPort] is System.DBNull) ? 0 : Convert.ToInt32(data[ConfigDatabase.Dal.EndPoint.ColumnListenPort]);
                AnswerHost = data[ConfigDatabase.Dal.EndPoint.ColumnAnswerHost].ToString();
                AnswerPort = (data[ConfigDatabase.Dal.EndPoint.ColumnAnswerPort] is System.DBNull) ? 0 : Convert.ToInt32(data[ConfigDatabase.Dal.EndPoint.ColumnAnswerPort]);
                */
                // ConfigDatabase.Dal.ConfigSettingsDS.ServiceRow eccServiceRow =
                //        (ConfigDatabase.Dal.ConfigSettingsDS.ServiceRow)data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int serviceTypeId = Convert.ToInt32(serviceTypeComboBox.SelectedValue);
        }

        private void serviceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int serviceTypeId = ServiceTypeID;
        }

        private void EditECCServiceDialog_Load(object sender, EventArgs e)
        {

        }

        private void endPointComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (endPointComboBox.SelectedItem != null)
            {
                var epParams = (ConfigSettingsDS.EndPointRow)((System.Data.DataRowView)(endPointComboBox.SelectedItem)).Row;

                ListenHost = epParams.ListenHost;
                ListenPort = epParams.ListenPort;
                AnswerHost = epParams.AnswerHost;
                AnswerPort = epParams.AnswerPort;
            }

        }

        #endregion
    }
}