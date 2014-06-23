using System;
using LanaSoft.ConfigDatabase.Dal;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    /// <summary>
    /// Class to make changes to ERPCommunicator table by use of ConfigSettingsDS (typed DataSet) ERPCommunicatorTableAdapter class
    /// </summary>
    public partial class ERPCommunicator
    {
        #region  Business ERPCommunicator Object Methods

        public static int AddERPCommunicator(Business.ERPCommunicator bERPCommunicator)
        {
            return AddERPCommunicator(bERPCommunicator.ERPClientType.ID,
                bERPCommunicator.AnswerHost, bERPCommunicator.AnswerPort,
                bERPCommunicator.OpenTimeOut, bERPCommunicator.CloseTimeOut, bERPCommunicator.SendTimeOut, bERPCommunicator.ReceiveTimeOut, bERPCommunicator.InactiveTimeOut);
        }


        public static int UpdateERPCommunicator(Business.ERPCommunicator bERPCommunicator)
        {
            return UpdateERPCommunicator(bERPCommunicator.ID, bERPCommunicator.ERPClientType.ID, bERPCommunicator.ERPCommunicationComponent.ID,
                    bERPCommunicator.AnswerHost, bERPCommunicator.AnswerPort,
                    bERPCommunicator.OpenTimeOut, bERPCommunicator.CloseTimeOut, bERPCommunicator.SendTimeOut, bERPCommunicator.ReceiveTimeOut, bERPCommunicator.InactiveTimeOut);
        }

        #endregion

        #region DataTableAdapter DAL Methods

        #region Properties

        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).ColumnIdName; }
        }

        public static string ColumnAnswerHost
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).AnswerHostColumn.ColumnName; }
        }

        public static string ColumnAnswerPort
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).AnswerPortColumn.ColumnName; }
        }

        public static string ColumnOpenTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).OpenTimeOutColumn.ColumnName; }
        }

        public static string ColumnCloseTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).CloseTimeOutColumn.ColumnName; }
        }

        public static string ColumnSendTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).SendTimeOutColumn.ColumnName; }
        }

        public static string ColumnReceiveTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).ReceiveTimeOutColumn.ColumnName; }
        }

        public static string ColumnInactiveTimeOut
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).InactiveTimeOutColumn.ColumnName; }
        }

        public static string ColumnERPCommunicationComponentID
        {
            get { return (new ConfigSettingsDS.ERPCommunicatorDataTable()).ERPCommunicationComponent_IDColumn.ColumnName; }
        }

        #endregion

        public static ConfigSettingsDS.ERPCommunicationComponentRow ActiveERPCommunicationComponent
        {
            get { return Dal.ERPCommunicationComponent.GetActiveCommunicationComponent(); }
        }

        public static ConfigSettingsDS.ERPCommunicatorDataTable GetERPCommunicators()
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                return adapt.GetERPCommunicators();
            }
        }

        public static ConfigSettingsDS.ERPCommunicatorRow GetERPCommunicator(int erpCommunicatorId)
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                var tbl = adapt.GetERPCommunicator(erpCommunicatorId);
                return (tbl.Count > 0) ? tbl[0] : null;
            }
        }

        public static ConfigSettingsDS.ERPCommunicatorDataTable GetERPCommunicatorsByECC_ID(int eccID)
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                var tbl = adapt.GetERPCommunicatorsByECC_ID(eccID);
                return tbl;
            }
        }

        /// <summary>
        /// Create new AddERPCommunicator and auto refered it to Active ECC (ERP Communication Component)
        /// </summary>
        /// <param name="openTimeOut"></param>
        /// <param name="closeTimeOut"></param>
        /// <param name="sentTimeOut"></param>
        /// <param name="receiveTimeOut"></param>
        /// <param name="inactiveTimeOut"></param>
        /// <returns></returns>
        public static int AddERPCommunicator(int? erpClientTypeId, string answerHost, int? answerPort, int? openTimeOut, int? closeTimeOut, int? sentTimeOut, int? receiveTimeOut, int? inactiveTimeOut)
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                object ID = adapt.AddERPCommunicator(erpClientTypeId, answerHost, answerPort, openTimeOut, closeTimeOut, sentTimeOut, receiveTimeOut, inactiveTimeOut);
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        public static int DeleteERPCommunicator(int erpCommunicatorId)
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                return adapt.DeleteERPCommunicator(erpCommunicatorId);
            }
        }

        public static int UpdateERPCommunicator(int id, int? erpClientTypeId, int? ecc_ID,
                                                string answerHost, int? answerPort,
                                                int? openTimeOut, int? closeTimeOut, 
                                                int? sentTimeOut, int? receiveTimeOut, int? inactiveTimeOut)
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                return adapt.UpdateERPCommunicator(id, 
                     erpClientTypeId, ecc_ID,
                     answerHost, answerPort,
                     openTimeOut, closeTimeOut, 
                     sentTimeOut, receiveTimeOut, inactiveTimeOut);
            }
        }

        public static int ClearERPCommunicators()
        {
            using (var adapt = new ERPCommunicatorTableAdapter())
            {
                return adapt.ClearERPCommunicators();
            }
        }

        #endregion
    }
}
