using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public class Service : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.Service obj = bObj as ConfigDatabase.Bussines.Service;

            if (obj.ERPCommunicationComponentID == null) return false;
            return true;
        }
    }
}
