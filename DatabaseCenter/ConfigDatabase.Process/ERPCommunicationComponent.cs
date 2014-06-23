using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public class ERPCommunicationComponent : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.ERPCommunicationComponent obj = bObj as ConfigDatabase.Bussines.ERPCommunicationComponent;

            if (string.IsNullOrEmpty(obj.ERPHost)) return false;
            return true;
        }
    }
}
