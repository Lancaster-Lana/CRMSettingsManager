using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Dal;

namespace SettingsTool
{
    public partial class EditECCServiceDialog : Form
    {
        public int EndPointID
        {
            get { return Convert.ToInt32(endPointComboBox.SelectedValue); }
            set { endPointComboBox.SelectedValue = value; }
        }

        public int ServiceTypeID
        {
            get
            {
                return Convert.ToInt32(serviceTypeComboBox.SelectedValue);
            }
            set { serviceTypeComboBox.SelectedValue = value; }
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

        public void Init()
        {
            try
            {
                DataTable dtServiseTypes = ServiceType.GetServiceTypes();
                serviceTypeComboBox.DataSource = dtServiseTypes;
                serviceTypeComboBox.ValueMember = "ID";
                serviceTypeComboBox.DisplayMember = "Name";
                serviceTypeComboBox.Update();

                //
                DataTable dtEndPoints = EndPoint.GetEndPoints();
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
                ServiceTypeID = Convert.ToInt32(data[/*ConfigDatabase.Dal.ServiceType.ColumnServiceType*/ "ServiceTypeID"]);
                ListenHost = data[EndPoint.ColumnListenHost].ToString();
                ListenPort = (data[EndPoint.ColumnListenPort] is System.DBNull) ? 0 : Convert.ToInt32(data[EndPoint.ColumnListenPort]);
                AnswerHost = data[EndPoint.ColumnAnswerHost].ToString();
                AnswerPort = (data[EndPoint.ColumnAnswerPort] is System.DBNull) ? 0 : Convert.ToInt32(data[EndPoint.ColumnAnswerPort]);

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
            var epParams = (ConfigSettingsDS.EndPointRow)((DataRowView)(endPointComboBox.SelectedItem)).Row;
            ListenHost = (epParams.ListenHost is System.DBNull) ? string.Empty : epParams.ListenHost;
            ListenPort = (epParams.ListenPort is System.DBNull) ? 0 : epParams.ListenPort;
            AnswerHost = (epParams.AnswerHost is System.DBNull) ? string.Empty : epParams.AnswerHost;
            AnswerPort = (epParams.AnswerPort is System.DBNull) ? 0 : epParams.AnswerPort;// (data[EndPoint.ColumnAnswerPort] is System.DBNull) ? 0 : Convert.ToInt32(data[EndPoint.ColumnAnswerPort]);            
        }
    }
}