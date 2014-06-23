using System.Globalization;

namespace LanaSoft.ConfigDatabase.Business
{
    public abstract class BusinessType
    {
        int _id = -1;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string Description
        {
            get { return ID.ToString(CultureInfo.InvariantCulture); }
        }

        public virtual bool Equals(BusinessType obj)
        {
            if/*((this.ID == obj.ID)&&*/( this.Description.Equals(obj.Description))
                return true;
            return false;
        }

    }
}
