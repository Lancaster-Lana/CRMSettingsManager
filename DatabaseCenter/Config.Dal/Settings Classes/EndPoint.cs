using System;
using LanaSoft.ConfigDatabase.Dal.ConfigSettingsDSTableAdapters;

namespace LanaSoft.ConfigDatabase.Dal
{
    public class EndPoint
    {
        #region Business EndPoint Object Methods

        public static int AddEndPoint(Business.EndPoint endPoint)
        {
            return AddEndPoint(endPoint.ListenHost, endPoint.ListenPort, endPoint.AnswerHost, endPoint.AnswerPort);
        }

        public static int DeleteEndPoint(Business.EndPoint endPoint)
        {
            return DeleteEndPoint(endPoint.ID);
        }

        /// <summary>
        ///Cascade deleting of related links from ECC Service
        /// </summary>
        /// <param name="endPoint_ID"></param>
        /// <param name="eccService_ID"></param>
        /// <returns></returns>
        public static int DeleteECCServiceEndPoint(int? eccService_ID, int? endPoint_ID)
        {
            using (var adapt = new EndPointTableAdapter())
            {
                DeleteECCLinkToEndPoint(eccService_ID, endPoint_ID);
                //try to delete EndPoint
                return adapt.DeleteEndPoint(endPoint_ID);
            }
        }

        #endregion

        #region DataTableAdapter DAL Methods

        #region Properties

        public static string IDColumnName
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).IDColumn.ColumnName; }

        }

        public static string ColumnListenHost
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).ListenHostColumn.ColumnName; }

        }

        public static string ColumnListenPort
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).ListenPortColumn.ColumnName; }
        }

        public static string ColumnAnswerHost
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).AnswerHostColumn.ColumnName; }
        }

        public static string ColumnAnswerPort
        {
            get { return (new ConfigSettingsDS.EndPointDataTable()).AnswerPortColumn.ColumnName; }
        }

        #endregion

        #region Methods

        public static int AddEndPoint(string listenHost, int listenPort, string answerHost, int answerPort)
        {
            using (var adapt = new EndPointTableAdapter())
            {
                object ID = adapt.AddEndPoint(listenHost, listenPort, answerHost, answerPort);
                return (ID != null) ? Convert.ToInt32(ID) : -1;
            }
        }

        public static int DeleteECCLinkToEndPoint(int? eccService_ID, int? endPoint_ID)
        {
            using (var adapt = new EndPointTableAdapter())
            {
                return adapt.DeleteLinkToEndPoint(endPoint_ID, eccService_ID);
            }
        }

        public static int DeleteEndPoint(int? endPoint_ID)
        {
            using (var adapt = new EndPointTableAdapter())
            {               
                return adapt.DeleteEndPoint(endPoint_ID);
            }
        }

        /// <summary>
        ///  Cascade deleting of related links from ECC Service
        /// </summary>
        /// <param name="endPoint_ID"></param>
        /// <param name="eccService_ID"></param>
        /// <returns></returns>
        public static int DeleteEndPoint(int? eccService_ID, int? endPoint_ID)
        {
            using (var adapt = new EndPointTableAdapter())
            {
                DeleteECCLinkToEndPoint(eccService_ID, endPoint_ID);            
                return adapt.DeleteEndPoint(endPoint_ID);
            }
        }

        public static ConfigSettingsDS.EndPointDataTable GetEndPoints()
        {
            using (var adapt = new EndPointTableAdapter())
            {
                return adapt.GetEndPoints();
            }
        }

        #endregion

        #endregion
    }
}
