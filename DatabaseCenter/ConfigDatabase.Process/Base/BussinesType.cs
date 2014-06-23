using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigDatabase.Process
{
    public abstract class BussinesRule
    {
        public bool VerifyData(ConfigDatabase.Bussines.BussinesType bObject) 
        {
            return true;
        }

    }
}
