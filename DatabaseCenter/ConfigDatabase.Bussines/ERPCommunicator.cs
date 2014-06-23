
namespace LanaSoft.ConfigDatabase.Business
{
    public class ERPCommunicator : BusinessType
    {
        #region Properties

        public override string Description
        {
            get
            {
                if (ERPCommunicationComponent != null)
                {
                    string actStr = (ERPCommunicationComponent.Active) ? " Active " : string.Empty;
                    return ERPCommunicationComponent.Name + " (" + ERPClientType.ClientName + ")" + actStr;
                }
                return base.Description;
            }
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as ERPCommunicator;

            if (toObj != null)
            {
                if (toObj.AnswerHost.Equals(this.AnswerHost)
                        && toObj.AnswerPort.Equals(this.AnswerPort)
                        && toObj.ERPClientType.Equals(this.ERPClientType)
                        && toObj.OpenTimeOut.Equals(this.OpenTimeOut)
                        && toObj.CloseTimeOut.Equals(this.CloseTimeOut)
                        && toObj.SendTimeOut.Equals(this.SendTimeOut)
                        && toObj.ReceiveTimeOut.Equals(this.ReceiveTimeOut)
                        && toObj.InactiveTimeOut.Equals(this.InactiveTimeOut)
                        && toObj.ERPCommunicationComponent.Equals(this.ERPCommunicationComponent)
                        && base.Equals(obj))
                    return true;
            }
            return false;
        }

        public string AnswerHost { get; set; }

        public int AnswerPort { get; set; }

        /// <summary>
        /// Related ECC component - active one
        /// </summary>
        public ERPCommunicationComponent ERPCommunicationComponent { get; set; }

        public ERPClientType ERPClientType { get; set; }

        public int OpenTimeOut { get; set; }

        public int CloseTimeOut { get; set; }

        public int SendTimeOut { get; set; }

        public int ReceiveTimeOut { get; set; }

        public int InactiveTimeOut { get; set; }

        #endregion

        public ERPCommunicator()
        {
            SendTimeOut = 0;
            InactiveTimeOut = 0;
            ReceiveTimeOut = 0;
            CloseTimeOut = 0;
            OpenTimeOut = 0;
            AnswerHost = string.Empty;
            AnswerPort = 0;
        }
    }
}
