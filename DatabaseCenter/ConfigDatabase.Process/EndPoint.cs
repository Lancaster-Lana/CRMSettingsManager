using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public class EndPoint : BussinesRule
    {
        public bool Verify(ConfigDatabase.Bussines.BussinesType bObj)
        {
            ConfigDatabase.Bussines.EndPoint obj = bObj as ConfigDatabase.Bussines.EndPoint;

            if (string.IsNullOrEmpty(obj.ListenHost)) return false;
            return true;
        }

    }
}
