using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Business;

namespace LanaSoft.SettingsTool.Controls
{
    public partial class DetailedControl : UserControl
    {
        #region Local Variables

        UserControl _settingsDetailedControl = null;
        SettingsType _settingsType = SettingsType.CrmCommunicator;
        DataSet _dataSet = new DataSet();
        DataTable _dataTable;

        int _id = -1;
        bool isNewRecord = false;

        #endregion

        #region Properties

        /// <summary>
        /// ID selected (edited, added ) bussines object
        /// </summary>
        public int CurrentID
        {
            get { return _id; }
            set { _id = value; }
        }

        [Browsable(true)]
        [Category("Custom")]
        public string Title
        {
            get { return tileLabel.Text; }
            set { tileLabel.Text = value; }
        }

        public DetailedControl()
        {
            InitializeComponent();
            mainSettingsToolBar.CausesValidation = true;
        }

        public DetailedControl(SettingsType settType)
            : this()
        {
            _settingsType = settType;
            //var datailedPanel = new DetailedControl();
            switch (settType)
            {
                case SettingsType.ErpCommunicationComponent:
                    _settingsDetailedControl = new ERPCommunicationComponent();
                    break;

                case SettingsType.ErpCommunicator:
                    _settingsDetailedControl = new ERPCommunicator();
                    break;

                case SettingsType.CrmCommunicator:
                    _settingsDetailedControl = new CRMCommunicator();
                    break;

                case SettingsType.ServiceType:
                    _settingsDetailedControl = new ServiceType();
                    break;
            }

            if (_settingsDetailedControl != null)
            {
                // _settingsDetailedControl.LostFocus += new EventHandler(ValidateCtrlData);

                _settingsDetailedControl.Dock = DockStyle.Fill;
                this.infoPanel.Controls.Add(_settingsDetailedControl);

                LoadSettingsDataToView();
            }
        }

        #endregion

        #region  Methods

        public enum EventType { preCreateRecord = 0, postCreateRecord = 1, postRecordDelete = 2, preRecordUpdate = 3, postRecordUpdate = 4, postRecordSelected = 5 }

        /// <summary>
        /// Refresh form after changes in DB
        /// </summary>
        public void RefreshDataView(EventType refreshType, int bOjectID)
        {
            //Refresh ToolStrip
            switch (refreshType)
            {
                case EventType.postCreateRecord:
                case EventType.postRecordUpdate:
                    CurrentID = bOjectID;
                    //((ISettingsData)_settingsDetailedControl).LoadSettingsData(ActiveObj);
                    //LoadSelectedItemData(ActiveObj);
                    LoadSettingsDataToView();
                    break;

                case EventType.postRecordDelete:
                    CurrentID = -1;
                    choiseItemsToolStripButton.DropDownItems.RemoveByKey(bOjectID.ToString());
                    ((ISettingsData)_settingsDetailedControl).ClearSettingsData();
                    break;

                case EventType.postRecordSelected:
                    CurrentID = bOjectID;
                    isNewRecord = false;
                    break;
            }
            SetControlsStates(refreshType);
        }

        private void SetControlsStates(EventType action)
        {
            switch (action)
            {
                case EventType.preCreateRecord:
                    isNewRecord = true;
                    newButton.Enabled = false;
                    deleteButton.Enabled = false;
                    ((ISettingsData)_settingsDetailedControl).InitDefaultSettingsData();
                    break;

                case EventType.postCreateRecord:
                    isNewRecord = false;
                    newButton.Enabled = true;
                    //saveButton.Enabled = false;
                    deleteButton.Enabled = true;
                    break;

                case EventType.preRecordUpdate:
                    newButton.Enabled = false;
                    saveButton.Enabled = true;
                    deleteButton.Enabled = true;
                    break;

                case EventType.postRecordUpdate:
                    //isNewRecors = false;
                    newButton.Enabled = true;
                    deleteButton.Enabled = true;
                    break;

                case EventType.postRecordDelete:
                    if (_settingsDetailedControl != null)
                        ((ISettingsData)_settingsDetailedControl).ClearSettingsData();
                    break;

                case EventType.postRecordSelected:
                    newButton.Enabled = true;
                    deleteButton.Enabled = true;
                    //saveButton.Enabled = false;
                    break;
            }
        }

        public BusinessType ActiveObj { get; private set; }

        public void LoadSettingsDataToView()
        {
            //1. Retrive info about items from DB
            if (_settingsDetailedControl != null)
            {
                //int activeID = -1;
                var choiseButtonItems = new List<BusinessType>();

                switch (_settingsType)
                {
                    case SettingsType.CrmCommunicator:
                        //__Toolstrip items
                        List<ConfigDatabase.Business.CRMCommunicator> crmCommList = ConfigDatabase.Dal.CRMCommunicator.GetCRMCommunicators();
                        foreach (ConfigDatabase.Business.CRMCommunicator bObj in crmCommList)
                        {
                            if (bObj.Active) ActiveObj = bObj;
                            choiseButtonItems.Add(bObj);
                        }
                        //if (ActiveObj == null)
                        //    ActiveObj = SettingsManager.GetActiveCRMCommunicator();
                        break;

                    case SettingsType.ErpCommunicationComponent:
                        List<ConfigDatabase.Business.ERPCommunicationComponent> eccList = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponents();
                        foreach (ConfigDatabase.Business.ERPCommunicationComponent bObj in eccList)
                        {
                            if (bObj.Active) ActiveObj = bObj;
                            choiseButtonItems.Add(bObj);
                        }
                        break;

                    case SettingsType.ErpCommunicator:
                        List<ConfigDatabase.Business.ERPCommunicationComponent> ecList = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponents();
                        foreach (ConfigDatabase.Business.ERPCommunicationComponent bObj in ecList)
                        {
                            if (bObj.Active) ActiveObj = bObj;
                            choiseButtonItems.Add(bObj);
                        }
                        break;

                    case SettingsType.ServiceType:
                        List<ConfigDatabase.Business.ServiceType> srvTypesList = ConfigDatabase.Dal.ServiceType.GetServiceTypes();
                        foreach (ConfigDatabase.Business.ServiceType bObj in srvTypesList)
                            choiseButtonItems.Add(bObj);
                        if (srvTypesList.Count > 0)
                            ActiveObj = srvTypesList[0];
                        break;
                }

                if (choiseButtonItems.Count > 0)
                {
                    //2. Load ToolStrip Items
                    LoadToolStrips(choiseButtonItems);

                    //3. Check active item
                    CheckActiveItem(ActiveObj);

                    //4. Select active item if there no selected items
                    if (CurrentID == -1)
                        LoadSelectedItemData(ActiveObj);//Select active item data
                }
                else
                    MessageBox.Show("There no data !", "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Load Detailed View after select TollStripItem


        private void LoadToolStrips(IEnumerable<BusinessType> choiseButtonItems)
        {
            choiseItemsToolStripButton.DropDownItems.Clear();

            foreach (var bObj in choiseButtonItems)
            {
                AddItemToToolStripButton(bObj);
            }
            choiseItemsToolStripButton.DropDownDirection = ToolStripDropDownDirection.Right;

        }

        private void CheckActiveItem(BusinessType activeObj)
        {
            if (activeObj != null)
                CheckActiveItem(activeObj.ID);
        }

        private void CheckActiveItem(int ID)
        {
            foreach (ToolStripMenuItem item in choiseItemsToolStripButton.DropDownItems)
            {
                if (((BusinessType)(item.Tag)).ID == ID)
                    item.CheckState = CheckState.Checked;
            }
        }

        private void AddItemToToolStripButton(BusinessType bObject)
        {
            var item = new ToolStripMenuItem();
            item.Tag = bObject;
            item.Name = bObject.ID.ToString(CultureInfo.InvariantCulture);//KEY 
            item.Text = bObject.Description;
            //item.CheckState = CheckState.Unchecked;           
            item.Click += new EventHandler(SelectSettingItem);

            choiseItemsToolStripButton.DropDownItems.Add(item);
        }

        private void SelectSettingItem(object sender, EventArgs args)
        {
            // Retrive data from selected item
            var selItem = sender as ToolStripMenuItem;   //int ID = (int)item.Tag;         
            if (selItem != null)
            {
                SetBoldSelectedItem(selItem);

                var bObject = (BusinessType)selItem.Tag;
                LoadSelectedItemData(bObject);
            }
        }

        private void SetBoldSelectedItem(ToolStripMenuItem selItem)
        {
            //Normalize all items font
            foreach (ToolStripMenuItem item in choiseItemsToolStripButton.DropDownItems)
                item.Font = new Font(item.Font, FontStyle.Regular);

            selItem.Font = new Font(selItem.Font, FontStyle.Bold);
        }

        private void LoadSelectedItemData(BusinessType bObject)
        {
            if (_settingsDetailedControl != null)
                ((ISettingsData)_settingsDetailedControl).LoadSettingsData(bObject);

            if (bObject != null)
                RefreshDataView(EventType.postRecordSelected, bObject.ID);
        }

        #endregion

        private void CreateNewRecord()
        {
            int? addedID = -1;

            try
            {
                if (((ISettingsData)_settingsDetailedControl).ValidateData())
                {
                    switch (_settingsType)
                    {
                        case SettingsType.CrmCommunicator:
                            // Get current detailed control and its data
                            var crmCommunicatorCtrl = (CRMCommunicator)_settingsDetailedControl;
                            addedID = SettingsManager.AddCRMCommunicator(crmCommunicatorCtrl.CRMHost, crmCommunicatorCtrl.CRMPort);
                            break;

                        case SettingsType.ErpCommunicationComponent:
                            // Get cusrrent detailed control and its data
                            var crmCommCmpntCtrl = (ERPCommunicationComponent)_settingsDetailedControl;
                            addedID = SettingsManager.AddERPCommunicationComponent(
                                                            crmCommCmpntCtrl.Name,
                                                            crmCommCmpntCtrl.ERPHost, crmCommCmpntCtrl.ERPPort,
                                                            crmCommCmpntCtrl.InactivityTimeOut,
                                                            crmCommCmpntCtrl.IsActive);
                            break;
                        case SettingsType.ErpCommunicator:

                            // Get current detailed control and its data
                            var erpCommunicatorCtrl = (ERPCommunicator)_settingsDetailedControl;
                            addedID = SettingsManager.AddERPCommunicator(
                                                                erpCommunicatorCtrl.ERPClientTypeID,
                                                                erpCommunicatorCtrl.AnswerHost,
                                                                erpCommunicatorCtrl.AnswerPort,
                                                                erpCommunicatorCtrl.OpenTimeOut,
                                                                erpCommunicatorCtrl.CloseTimeOut,
                                                                erpCommunicatorCtrl.SendTimeOut,
                                                                erpCommunicatorCtrl.ReceiveTimeOut,
                                                                erpCommunicatorCtrl.InactivetimeOut);
                            break;
                        case SettingsType.ServiceType:
                            // Get current detailed control and its data
                            var serviceCtrl = (ServiceType)_settingsDetailedControl;
                            addedID = SettingsManager.AddServiceType(serviceCtrl.ServiceTypeName);
                            break;
                    }


                    //3. Refresh data view
                    if ((addedID > -1) && (addedID != null))
                    {
                        MessageBox.Show("New record is created !");
                        RefreshDataView(EventType.postCreateRecord, (int)addedID);
                    }
                    else
                        MessageBox.Show("Record is not saved !");
                }
                else
                {
                    MessageBox.Show("Check all data! ");
                }
            }
            catch (SettingsToolException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateRecord(int ID)
        {
            int isUpdated = -1;

            switch (_settingsType)
            {
                case SettingsType.CrmCommunicator:
                    var crmCommunicatorCtrl = (CRMCommunicator)_settingsDetailedControl;
                    isUpdated = SettingsManager.UpdateCRMCommunicator(ID, crmCommunicatorCtrl.CRMHost, crmCommunicatorCtrl.CRMPort, crmCommunicatorCtrl.Active);
                    break;

                case SettingsType.ErpCommunicationComponent:
                    var erpCommunicationComponentCtrl = (ERPCommunicationComponent)_settingsDetailedControl;
                    isUpdated = SettingsManager.UpdateERPCommunicationComponent(ID,
                                                erpCommunicationComponentCtrl.Name,
                                                erpCommunicationComponentCtrl.ERPHost,
                                                erpCommunicationComponentCtrl.ERPPort,
                                                erpCommunicationComponentCtrl.InactivityTimeOut,
                                                erpCommunicationComponentCtrl.IsActive);
                    break;

                case SettingsType.ErpCommunicator:
                    var erpCommunicatorCtrl = (ERPCommunicator)_settingsDetailedControl;
                    isUpdated = SettingsManager.UpdateERPCommunicator(ID, erpCommunicatorCtrl.ERPClientTypeID, erpCommunicatorCtrl.ERPCommunicationComponentID,
                                                erpCommunicatorCtrl.AnswerHost,
                                                erpCommunicatorCtrl.AnswerPort,
                                                erpCommunicatorCtrl.OpenTimeOut,
                                                erpCommunicatorCtrl.CloseTimeOut,
                                                erpCommunicatorCtrl.SendTimeOut,
                                                erpCommunicatorCtrl.ReceiveTimeOut,
                                                erpCommunicatorCtrl.InactivetimeOut
                                                );
                    break;

                case SettingsType.ServiceType:
                    var serviceCtrl = (ServiceType)_settingsDetailedControl;
                    isUpdated = SettingsManager.UpdateServiceType(ID,
                                                 serviceCtrl.ServiceTypeName);
                    break;
            }

            //2.Refresh Grid Data
            if (isUpdated > -1)
                RefreshDataView(EventType.postRecordUpdate, ID);
            else
                MessageBox.Show("Record is not saved");
        }

        private void DeleteRecord(int ID)
        {
            if (MessageBox.Show("Are you sure to delete current recors ?", "Delete record", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                switch (_settingsType)
                {
                    case SettingsType.CrmCommunicator:
                        SettingsManager.DeleteCRMCommunicator(ID);
                        break;

                    case SettingsType.ErpCommunicationComponent:
                        SettingsManager.DeleteERPCommunicationComponent(ID);
                        break;

                    case SettingsType.ErpCommunicator:
                        SettingsManager.DeleteERPCommunicator(ID);
                        break;

                    case SettingsType.ServiceType:
                        SettingsManager.DeleteServiceType(ID);
                        break;
                }
            }
            RefreshDataView(EventType.postRecordDelete, ID);
        }


        private void ApplySettingsChanges()
        {
            SettingsManager.AcceptChanges();
        }

        private void CancelSettingsChanges()
        {
            SettingsManager.RejectChanges();
        }

        #endregion

        #region Presenter Handlers

        private void newButton_Click(object sender, EventArgs e)
        {
            if (_settingsDetailedControl != null)
                SetControlsStates(EventType.preCreateRecord);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCurrentRecord();
        }

        private void SaveCurrentRecord()
        {
            try
            {
                if (isNewRecord)
                {
                    CreateNewRecord();
                }
                else
                {
                    UpdateRecord(CurrentID);
                }

                MessageBox.Show("Your changes are saved !", "Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                //update UI view data
                ((ISettingsData) _settingsDetailedControl).OldData = ((ISettingsData) _settingsDetailedControl).GetSettingsData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteRecord(CurrentID);
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (this.Parent is Panel)
                SettingsManager.LoadCommonView(this.Parent as Panel);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettingsChanges();
            if (this.Parent is Panel) SettingsManager.LoadCommonView(this.Parent as Panel);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelSettingsChanges();
            if (this.Parent is Panel) SettingsManager.LoadCommonView(this.Parent as Panel);
        }

        private void mainSettingsToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _settingsDetailedControl.Validate();

            if (isNewRecord
                || AreChanges && (e.ClickedItem.Tag == null
                || ((e.ClickedItem.Tag != null) && (!(e.ClickedItem.Tag.Equals("save")
                || (e.ClickedItem.Tag.Equals("delete")))))))
            {
                if (MessageBox.Show("Save your changes ?", "Saving record changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    //save to DB
                    SaveCurrentRecord();

                    //update UI view data
                    ((ISettingsData)_settingsDetailedControl).OldData = ((ISettingsData)_settingsDetailedControl).GetSettingsData();

                }
                else
                    RefuseCurrentChanges();
            }
        }

        private bool AreChanges
        {
            get
            {
                var oldObj = ((ISettingsData)_settingsDetailedControl).OldData;//GetCurrectObjectOldData();
                if (oldObj != null)
                {
                    var currBObj = ((ISettingsData)_settingsDetailedControl).GetSettingsData();//get CurrentID                
                    return !currBObj.Equals(oldObj);
                }
                return false;
            }
        }

        private void RefuseCurrentChanges()
        {
            //reject creating new record
            if (isNewRecord)
            {
                isNewRecord = false;
                // LoadSelectedItemData(acti)
            }
            else
            {
                //Load old data to view
                var oldObj = ((ISettingsData)_settingsDetailedControl).OldData;//GetCurrectObjectOldData();
                ((ISettingsData)_settingsDetailedControl).LoadSettingsData(oldObj);
            }
        }

        #endregion
    }
}
