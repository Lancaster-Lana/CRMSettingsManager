using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LanaSoft.ConfigDatabase.Dal;
using LanaSoft.SettingsTool.Controls;
using LanaSoft.SettingsTool.Properties;
using System.Net;
using System.Net.Sockets;
using LanaSoft.UserControls.MultiPanel;

namespace LanaSoft.SettingsTool
{
    public enum SettingsType { ErpCommunicationComponent = 0, ErpCommunicator = 1, CrmCommunicator = 2, ServiceType = 3 }

    public interface IToolItem
    {
        void Show(Panel viewArea);
    }

    internal class SettingsManager : IToolItem
    {
        #region Views (GUI working)

        public static Panel _presenterPanel;

        public static void LoadDetailedView(Panel parentPanel, SettingsType settType, string title)
        {
            if (parentPanel != null)
            {
                var datailedPanel = new DetailedControl(settType);
                datailedPanel.Title = title;
                datailedPanel.Dock = DockStyle.Fill;

                parentPanel.Controls.Clear();
                parentPanel.Controls.Add(datailedPanel);
            }
        }

        public static void LoadCommonView(Panel settingsPanel)
        {
            _presenterPanel = settingsPanel;

            var commonSettingsPanel = new SubItemsPanel();
            commonSettingsPanel.Caption = "Configuration settings";
            commonSettingsPanel.ItemSize = new System.Drawing.Size(300, 90);
            commonSettingsPanel.Dock = DockStyle.Fill;
            commonSettingsPanel.CaptionForeColor = Color.White;
            commonSettingsPanel.CaptionBackColor = Color.CornflowerBlue;
            // commonSettingsPanel.ItemsImageList = itemsImageList;

            //Load esttings items
            var erpCommunicator = new InfoItem("CRM Communicator", "Settings for CRM client ", Resources.CRMCommunicator);
            erpCommunicator.Tag = SettingsType.CrmCommunicator;
            erpCommunicator.Click += settingsItem_Click;

            var erpCommunicationComponent = new InfoItem("ERP Communicator", "Settings of ERP Client ", Resources.ERPCommunicator);
            erpCommunicationComponent.Tag = SettingsType.ErpCommunicator;
            erpCommunicationComponent.Click += settingsItem_Click;

            var crmCommunicator = new InfoItem("ERPCommunicationComponent", "Settings of ERP Server (ERPCommunicationComponent) ", Resources.ERPCommunicationComponent);
            crmCommunicator.Tag = SettingsType.ErpCommunicationComponent;
            crmCommunicator.Click += settingsItem_Click;

            var services = new InfoItem("Service Types ", "Existing services types", Resources.Service);
            services.Tag = SettingsType.ServiceType;
            services.Click += settingsItem_Click;

            //Add items
            commonSettingsPanel.AddSubItemToPanel(crmCommunicator);
            commonSettingsPanel.AddSubItemToPanel(erpCommunicator);
            commonSettingsPanel.AddSubItemToPanel(erpCommunicationComponent);
            commonSettingsPanel.AddSubItemToPanel(services);

            //Add common info panel to settings form
            settingsPanel.Controls.Clear();
            settingsPanel.Controls.Add(commonSettingsPanel);
        }


        private static void settingsItem_Click(object sender, EventArgs e)
        {
            var item = sender as InfoItem;
            if (item != null)
            {
                var settType = (SettingsType)item.Tag;
                LoadDetailedView(_presenterPanel, settType, item.Title);
            }
        }

        public void Show(Panel panel)
        {
            LoadCommonView(panel);
        }

        #endregion

        #region Data FROM DB

        #region Properties

        public static string CRMCommunicatorIDColumnName
        {
            get { return ConfigDatabase.Dal.CRMCommunicator.IDColumnName; }
        }

        public static List<string> CRMCommunicatorVisibleColumns
        {
            get
            {
                List<string> visibleColumns = new List<string>();
                visibleColumns.Add(ConfigDatabase.Dal.CRMCommunicator.ColumnCRMHost);
                visibleColumns.Add(ConfigDatabase.Dal.CRMCommunicator.ColumnCRMPort);
                return visibleColumns;
            }
        }


        public static string ERPCommunicationComponentIDColumnName
        {
            get { return ConfigDatabase.Dal.ERPCommunicationComponent.IDColumnName; }
        }

        public static List<string> ERPCommunicationComponentVisibleColumns
        {
            get
            {
                List<string> visibleColumns = new List<string>();
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnName);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnERPHost);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnERPPort);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnInactivityTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnActive);
                return visibleColumns;
            }
        }

        public static List<string> ERPCommunicatorVisibleColumns
        {
            get
            {
                List<string> visibleColumns = new List<string>();
                visibleColumns.Add(ConfigDatabase.Dal.ERPClientType.ColumnServiceType);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnAnswerHost);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnAnswerPort);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnOpenTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnOpenTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnCloseTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnSendTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnReceiveTimeOut);
                visibleColumns.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnInactiveTimeOut);
                return visibleColumns;
            }
        }

        public static List<string> ECCServicesVisibleColumns
        {
            get
            {
                List<string> visibleColumns = new List<string>();
                visibleColumns.Add(ConfigDatabase.Dal.ServiceType.ColumnServiceType);
                visibleColumns.Add(ConfigDatabase.Dal.EndPoint.ColumnListenHost);
                visibleColumns.Add(ConfigDatabase.Dal.EndPoint.ColumnListenPort);
                //visibleColumns.Add(ConfigDatabase.Dal.EndPoint.ColumnAnswerHost);
                //visibleColumns.Add(ConfigDatabase.Dal.EndPoint.ColumnAnswerPort);

                return visibleColumns;
            }
        }

        public static string ServiceIDColumnName
        {
            get { return ConfigDatabase.Dal.Service.IDColumnName; }
        }

        public static List<string> ServiceTypeVisibleColumns
        {
            get
            {
                List<string> visibleColumns = new List<string>();
                visibleColumns.Add(ConfigDatabase.Dal.ServiceType.ColumnServiceType);
                return visibleColumns;
            }
        }

        #endregion

        public static void LoadDetailedData(Panel parentPanel, SettingsType settType, string title)
        {
            try
            {
                //1
                if (parentPanel != null)
                {
                    var datailedPanel = new DetailedControl(settType);
                    datailedPanel.Title = title;
                    datailedPanel.Dock = DockStyle.Fill;

                    parentPanel.Controls.Clear();
                    parentPanel.Controls.Add(datailedPanel);
                }

                //2
                BeginChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static ConfigDatabase.Business.BusinessType GetDataFromDataBase(SettingsType settingsType, int objectID)
        {
            ConfigDatabase.Business.BusinessType resObject = null;
            try
            {
                switch (settingsType)
                {
                    case SettingsType.ErpCommunicationComponent:
                        resObject = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponent(objectID);
                        break;

                    case SettingsType.CrmCommunicator:
                        resObject = ConfigDatabase.Dal.CRMCommunicator.GetCRMCommunicator(objectID);
                        break;

                    case SettingsType.ErpCommunicator:
                        resObject = ConfigDatabase.Dal.ERPCommunicator.GetERPCommunicator(objectID);
                        break;

                    case SettingsType.ServiceType:
                        resObject = ConfigDatabase.Dal.ServiceType.GetServiceType(objectID);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Exception during access to DB" + ex.Message);
            }


            return resObject;

        }

        public static DataTable GetDataFromDataBase(SettingsType settingsType)
        {
            //ConfigSettingsDS resultDS = new ConfigSettingsDS();
            DataTable resTable = null;

            switch (settingsType)
            {
                case SettingsType.ErpCommunicationComponent:
                    //resultDS = dal.ExecuteStorProc(ConfigDatabase.Dal.ConfigStoredProcedure.GetERPCommunicationComponents, null);
                    resTable = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponents();
                    break;

                case SettingsType.CrmCommunicator:
                    resTable = ConfigDatabase.Dal.CRMCommunicator.GetCRMCommunicators();
                    //List<ConfigDatabase.business.CRMCommunicator> ccc =   ConfigDatabase.Dal.CRMCommunicator.GetCRMCommunicators();                      

                    break;

                case SettingsType.ErpCommunicator:
                    //List<ConfigDatabase.business.ERPCommunicationComponent> cmp = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponents();                    
                    resTable = ConfigDatabase.Dal.ERPCommunicator.GetERPCommunicators();

                    //int str = ConfigDatabase.Dal.ERPCommunicator.GetERPCommunicator(17)[0].ActiveERPCommunicationComponent.ERPPort;
                    break;

                case SettingsType.ServiceType:
                    resTable = ConfigDatabase.Dal.ServiceType.GetServiceTypes();
                    break;
            }

            return resTable;
        }


        public static DataTable GetServiceTypes()
        {
            return ConfigDatabase.Dal.ServiceType.GetServiceTypes();
        }

        public static DataTable GetERPClientTypes()
        {
            return ConfigDatabase.Dal.ERPClientType.GetERPClientTypes();
        }

        public static DataTable GetEndPoints()
        {
            return ConfigDatabase.Dal.EndPoint.GetEndPoints();
        }

        public static DataTable GetERPCommunicationComponents()
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponents();
        }

        public static ConfigSettingsDS.ServiceDataTable GetERPCommunicationComponentServices(int ERPComponentId)
        {
            try
            {
                return Service.GetECCServices(ERPComponentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public static ConfigDatabase.Business.ERPCommunicationComponent GetActiveERPCommunicationComponent()
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.GetActiveCommunicationComponent();
        }

        /// <summary>
        /// Returns 4 types of ERPClients
        /// </summary>
        /// <param name="ecc_ID"></param>
        /// <returns></returns>
        public static List<ConfigDatabase.Business.ERPCommunicator> GetERPCommunicatorsByECC_ID(int ecc_ID)
        {
            return ConfigDatabase.Dal.ERPCommunicator.GetERPCommunicatorsByECC_ID(ecc_ID);
        }

        public static ConfigDatabase.Business.CRMCommunicator GetActiveCRMCommunicator()
        {
            return ConfigDatabase.Dal.CRMCommunicator.GetActiveCRMCommunicator();
        }

        #region Transactions

        static ConfigSettingsDS settingsDS = new ConfigSettingsDS();

        public static void BeginChanges()
        {
            settingsDS.BeginInit();
        }

        public static void RejectChanges()
        {
            settingsDS.RejectChanges();
        }

        public static void AcceptChanges()
        {
            settingsDS.AcceptChanges();
        }

        #endregion

        #region Retrieve/ Manipulate Data of Config DB DAL

        public static int AddEndPoint(string listenHost, int listenPort, string answerHost, int answerPort)
        {
            return ConfigDatabase.Dal.EndPoint.AddEndPoint(listenHost, listenPort, answerHost, answerPort);
        }

        public static int AddEndPointToECCService(int ECC_ID, int eccService_ID, int endPoint_ID)
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.AddEndPointToECCService(ECC_ID, eccService_ID, endPoint_ID);
        }

        public static int AddCRMCommunicator(string crmHost, int crmPort)
        {
            return ConfigDatabase.Dal.CRMCommunicator.AddCRMCommunicator(crmHost, crmPort);
        }

        public static int AddERPCommunicator(int erpClientTypeId, string answerHost, int answerPort, int openTimeOut, int closeTimeOut, int sendTimeOut, int receiveTimeOut, int inactivetimeOut)
        {
            return ConfigDatabase.Dal.ERPCommunicator.AddERPCommunicator(erpClientTypeId, answerHost, answerPort, openTimeOut, closeTimeOut, sendTimeOut, receiveTimeOut, inactivetimeOut);
        }

        public static int AddERPCommunicationComponent(string name, string erpHost, int erpPort, int inactivityTimeOut, bool isActive)
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.AddERPCommunicationComponent(name, erpHost, erpPort, inactivityTimeOut, isActive);
        }

        public static int AddServiceType(string serviceTypeName)
        {
            return ConfigDatabase.Dal.ServiceType.AddServiceType(serviceTypeName);
        }

        /// <summary>
        /// Add certaint Service Type to ERP Communication Component
        /// </summary>
        /// <param name="eccID"></param>
        /// <param name="serviceTypeID"></param>
        /// <returns>ID of added of erp Communication Component Service</returns>
        public static int AddECCService(int eccID, int serviceTypeID)
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.AddECCService(eccID, serviceTypeID);
        }


        public static void RetrieveCRMPCommunicatorInfo(DataRow rowToView, out string crmHost, out int crmPort, out bool isActive)
        {
            var row = rowToView as ConfigSettingsDS.CRMCommunicatorRow;
            if (row != null)
            {
                crmHost = row.CRMHost;
                crmPort = row.CRMPort;
                isActive = row.Active;
            }
            else
            {
                crmHost = string.Empty;
                crmPort = 0;
                isActive = false;
            }
        }

        public static void RetrieveECCServiceEndPointInfo(DataRow data, out int eccServiceID, out int endPointID)
        {
            endPointID = -1;
            if (!(data[ConfigDatabase.Dal.ERPCommunicationComponent.EndPointID] is System.DBNull))
                endPointID = Convert.ToInt32(data[ConfigDatabase.Dal.ERPCommunicationComponent.EndPointID]);
            eccServiceID = Convert.ToInt32(data[ConfigDatabase.Dal.ERPCommunicationComponent.ECCServiceID]);
        }

        public static void RetrieveERPCommunicationComponentInfo(int eccID, out string name, out string erpHost, out int erpPort,
                        out int inactivityTimeOut, out bool isActive)
        {
            var row = ConfigDatabase.Dal.ERPCommunicationComponent.GetERPCommunicationComponent(eccID);

            if (row != null)
            {
                name = row.Name;
                erpHost = row.ERPHost;
                erpPort = row.ERPPort;
                inactivityTimeOut = row.InactivityTimeOut;
                isActive = row.Active;
            }
            else
            {
                name = string.Empty;
                erpHost = string.Empty;
                erpPort = 0;
                inactivityTimeOut = 0;
                isActive = false;
            }
        }

        public static void RetrieveERPCommunicationComponentInfo(DataRow rowToView,
                                        out int ECC_ID, out string Name, out string ERPHost, out int ERPPort,
                                        out int InactivityTimeOut, out bool IsActive)
        {
            var row = (ConfigSettingsDS.ERPCommunicationComponentRow)rowToView;
            ECC_ID = row.ID;
            Name = row.Name;
            ERPHost = row.ERPHost;
            ERPPort = row.ERPPort;
            InactivityTimeOut = row.InactivityTimeOut;
            IsActive = row.Active;
        }


        public static void RetrieveERPCommunicatorInfo(DataRow rowToView, out int erpCommunicationComponentID, out int openTimeOut, out int closeTimeOut, out int sendTimeOut, out int receiveTimeOut, out int inactivetimeOut)
        {
            var row = (ConfigSettingsDS.ERPCommunicatorRow)rowToView;

            openTimeOut = row.OpenTimeOut;
            closeTimeOut = row.CloseTimeOut;
            sendTimeOut = row.SendTimeOut;
            receiveTimeOut = row.ReceiveTimeOut;
            inactivetimeOut = row.InactiveTimeOut;

            try
            {
                erpCommunicationComponentID = row.ERPCommunicationComponent_ID;
            }
            catch
            {
                erpCommunicationComponentID = -1;
            }
        }

        public static void RetrieveServiceTypeInfo(DataRow rowToView, out string serviceTypeName)
        {
            var row = (ConfigSettingsDS.ServiceTypeRow)rowToView;
            serviceTypeName = row.Name;
        }

        public static int ChangeECCServiceEndPoint(int erpCommunicationComponentID, int eccServiceID, int oldEndPoint_ID, int endPoint_ID)
        {
            return Service.ChangeECCServiceEndPoint(erpCommunicationComponentID, eccServiceID, oldEndPoint_ID, endPoint_ID);
        }

        public static int UpdateCRMCommunicator(int ID, string crmHost, int crmPort, bool isActive)
        {
            return ConfigDatabase.Dal.CRMCommunicator.UpdateCRMCommunicator(ID, crmHost, crmPort, isActive);
        }

        public static int UpdateERPCommunicationComponent(int ID, string eccName, string erpHost, int erpPort, int inactivityTimeOut, bool isActive)
        {
            return ConfigDatabase.Dal.ERPCommunicationComponent.UpdateERPCommunicationComponent(ID, eccName, erpHost, erpPort, inactivityTimeOut, isActive);
        }

        public static int UpdateERPCommunicator(int ID, int erpClientTypeID, int erpCommunicationComponentID,
                                                string answerHost, int answerPort,
            int openTimeOut, int closeTimeOut, int sendTimeOut, int receiveTimeOut, int inactivetimeOut)
        {
            return ConfigDatabase.Dal.ERPCommunicator.UpdateERPCommunicator(ID, erpClientTypeID, erpCommunicationComponentID,
                                                                            answerHost, answerPort,
                                                                            openTimeOut, closeTimeOut, sendTimeOut, receiveTimeOut, inactivetimeOut);
        }

        public static int UpdateServiceType(int ID, string serviceTypeName)
        {
            return ConfigDatabase.Dal.ServiceType.UpdateServiceType(ID, serviceTypeName);
        }


        public static void DeleteECCService(int eccServiceID, bool deleteRelatedEndPoints)
        {
            Service.DeleteECCService(eccServiceID, deleteRelatedEndPoints);
        }

        public static void DeleteEndPoint(int eccServiceID, int endPointID, bool deleteEndPoint)
        {
            if (!deleteEndPoint)
                ConfigDatabase.Dal.EndPoint.DeleteECCLinkToEndPoint(eccServiceID, endPointID);
            else// if there are  no links to EndPoint
                ConfigDatabase.Dal.EndPoint.DeleteEndPoint(eccServiceID, endPointID);
        }

        public static void DeleteCRMCommunicator(int crmCommunicatorID)
        {
            ConfigDatabase.Dal.CRMCommunicator.DeleteCRMCommunicator(crmCommunicatorID);
        }

        public static void DeleteERPCommunicationComponent(int eccID)
        {
            ConfigDatabase.Dal.ERPCommunicationComponent.DeleteERPCommunicationComponent(eccID);
        }

        public static void DeleteERPCommunicator(int erpCommunicatorID)
        {
            ConfigDatabase.Dal.ERPCommunicator.DeleteERPCommunicator(erpCommunicatorID);
        }

        public static void DeleteServiceType(int serviceTypeID)
        {
            ConfigDatabase.Dal.ServiceType.DeleteServiceType(serviceTypeID);
        }

        #endregion

        #endregion

        public static IPAddress[] GetAvailableHosts()
        {
            IPAddress[] addrs = Dns.GetHostEntry("127.0.0.1").AddressList;

            return addrs;
        }

        public static IPAddress[] GetIPsByHostName(string hostName)
        {
            try
            {
                IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
                if (ipEntry != null)
                {
                    IPAddress[] addrs = ipEntry.AddressList;
                    return addrs;
                }
            }
            catch { }
            return null;
        }


        public static bool IsPortFree(string host, int port)
        {
            var ipAddr = Dns.GetHostByName(host).AddressList[0];

            var endPoint = new IPEndPoint(ipAddr, port);

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Blocking = false;
                //int av = socket.Available;
                //if (av > 0)   return true;
                //return false;                
                try
                {
                    socket.Bind(endPoint);//.Connect                 
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}