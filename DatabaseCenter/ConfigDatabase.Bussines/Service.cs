using System.Collections.Generic;

namespace LanaSoft.ConfigDatabase.Business
{
    public class Service : BusinessType
    {
        #region Properties

        //ERPCommunicationComponent _parentERPCommunicationComponent;

        public ServiceType ServiceType { get; set; }

        public List<EndPoint> EndPoints { get; set; }

        public int ERPCommunicationComponentID { get; set; }

        #endregion

        public Service()
        {
            ERPCommunicationComponentID = 0;
            EndPoints = new List<EndPoint>();
            ServiceType = new ServiceType();
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as Service;

            if (toObj != null && (toObj.ERPCommunicationComponentID.Equals(this.ERPCommunicationComponentID)
                                  && toObj.ServiceType.Equals(this.ServiceType)
                                  && toObj.EndPoints.Equals(this.EndPoints)
                                  && base.Equals(obj)))
                return true;
            return false;
        }
    }
}
