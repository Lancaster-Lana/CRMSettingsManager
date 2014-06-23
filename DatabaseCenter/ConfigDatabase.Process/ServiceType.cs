using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public class ServiceType : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.ServiceType obj = bObj as ConfigDatabase.Bussines.ServiceType;            

            if (string.IsNullOrEmpty(obj.TypeName)) return false;
            return true;
        }

    }
}
