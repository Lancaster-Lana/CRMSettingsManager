using System.Globalization;

namespace LanaSoft.ConfigDatabase.Business
{
    public class CRMCommunicator : BusinessType
    {
        public override string Description
        {
            get
            {
                return CRMHost + " : " + CRMPort.ToString(CultureInfo.InvariantCulture);
            }
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as CRMCommunicator;

            if (toObj != null && (toObj.CRMHost.Equals(this.CRMHost)
                                  && toObj.CRMPort.Equals(this.CRMPort)
                                  && toObj.Active.Equals(this.Active)
                                  && base.Equals(obj)))
                return true;
            return false;
        }

        public string CRMHost { get; set; }

        public int CRMPort { get; set; }

        public bool Active { get; set; }

        public CRMCommunicator()
        {
            CRMHost = string.Empty;
            CRMPort = 0;
            Active = false;
        }

        public CRMCommunicator(string crmHost, int crmPort, bool active)
        {
            CRMHost = crmHost;
            CRMPort = crmPort;
            Active = active;
        }

        public CRMCommunicator(string crmHost, int crmPort):this(crmHost,  crmPort, false)
        {
        } 
    }
}
