namespace LanaSoft.ConfigDatabase.Business
{
    public class ServiceType : BusinessType
    {
        #region Properties

        public override string Description
        {
            get
            {
                return TypeName;
            }
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as ServiceType;

            if (toObj != null && (toObj.TypeName.Equals(this.TypeName) && base.Equals(obj)))
                return true;
            return false;
        }

        public string TypeName { get; set; }

        #endregion

        public ServiceType()
        {
            TypeName = string.Empty;
        }
    }
}
