using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public class CRMCommunicator : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.CRMCommunicator obj = bObj as ConfigDatabase.Bussines.CRMCommunicator;
            ConfigDatabase.Bussines.CRMCommunicator resObj = bObj as ConfigDatabase.Bussines.CRMCommunicator;

            if(string.IsNullOrEmpty(obj.CRMHost)) return false;
            if (obj.Active) return false;
            return true;
        }

    }
}
