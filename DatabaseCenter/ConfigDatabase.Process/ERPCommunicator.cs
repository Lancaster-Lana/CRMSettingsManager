using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{

    public class ERPCommunicator : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.ERPCommunicator obj = bObj as ConfigDatabase.Bussines.ERPCommunicator;

            if (obj.ERPCommunicationComponent == null) return false;
            return true;
        }
 
    }
}
