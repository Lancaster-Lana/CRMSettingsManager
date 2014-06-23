using System.Collections.Generic;

namespace LanaSoft.ConfigDatabase.Business
{
    public class ERPCommunicationComponent : BusinessType
    {
        #region Properties

        public override string Description
        {
            get
            {
                return Name;
            }
        }

        public string Name { get; set; }

        public string ERPHost { get; set; }

        public int ERPPort { get; set; }

        public int InactivityTimeOut { get; set; }

        public bool Active { get; set; }

        public List<Service> ERPCommunicationComponentServices { get; set; }

        #endregion

        public ERPCommunicationComponent()
        {
            InactivityTimeOut = 0;
            Active = false;
            ERPPort = 0;
            Name = string.Empty;
            ERPHost = string.Empty;
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as ERPCommunicationComponent;

            if (toObj != null && (toObj.Name.Equals(this.Name)
                                  && toObj.Active.Equals(this.Active)
                                  && toObj.ERPHost.Equals(this.ERPHost)
                                  && toObj.ERPPort.Equals(this.ERPPort)
                                  && toObj.InactivityTimeOut.Equals(this.InactivityTimeOut)
                                  && base.Equals(obj)))
                return true;
            return false;
        }
    }
}
