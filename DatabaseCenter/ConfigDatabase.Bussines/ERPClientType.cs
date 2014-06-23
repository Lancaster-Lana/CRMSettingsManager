namespace LanaSoft.ConfigDatabase.Business
{
    public class ERPClientType : BusinessType
    {
        public ERPClientType()
        {
            ClientName = string.Empty;
        }

        #region Properties

        public string ClientName { get; set; }

        public override string Description
        {
            get
            {
                return ClientName;
            }
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as ERPClientType;
            if (obj != null)
            {
                if (toObj != null && (toObj.ClientName.Equals(this.ClientName)
                                      && base.Equals(obj)))
                    return true;
            }
            return false;
        }

        #endregion       
    }
}
