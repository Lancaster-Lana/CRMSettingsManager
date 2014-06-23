using System.Collections.Generic;

namespace LanaSoft.SettingsTool
{
    public enum PropertyException {cannotBeNull = 0, isToBeInt =1, incorrectSyntax =2 }

    public class ValidationRule
    {
        public static bool Validate(ConfigDatabase.Business.CRMCommunicator bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if(string.IsNullOrEmpty(bObject.CRMHost))
                incorrectProperties.Add(ConfigDatabase.Dal.CRMCommunicator.ColumnCRMHost, PropertyException.cannotBeNull);
            if (bObject.CRMPort == 0)
                incorrectProperties.Add(ConfigDatabase.Dal.CRMCommunicator.ColumnCRMPort, PropertyException.cannotBeNull);

            if (incorrectProperties.Count > 0) return false;
            return true;
        }

        public static bool Validate(ConfigDatabase.Business.ERPCommunicator bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if(bObject.ERPCommunicationComponent == null)
                incorrectProperties.Add(ConfigDatabase.Dal.ERPCommunicator.ColumnERPCommunicationComponentID, PropertyException.cannotBeNull);

            if (incorrectProperties.Count > 0) return false;            
            return true;
        }

        public static bool Validate(ConfigDatabase.Business.ERPCommunicationComponent bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if(string.IsNullOrEmpty(bObject.ERPHost))
                incorrectProperties.Add(ConfigDatabase.Dal.ERPCommunicationComponent.ColumnERPHost, PropertyException.cannotBeNull);

            if (incorrectProperties.Count > 0) return false;            
            return true;
        }

        public static bool Validate(ConfigDatabase.Business.ServiceType bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if(string.IsNullOrEmpty(bObject.TypeName))
                incorrectProperties.Add(ConfigDatabase.Dal.ServiceType.ColumnServiceType, PropertyException.cannotBeNull);

            if (incorrectProperties.Count > 0) return false;            
            return true;
        }

        public static bool Validate(ConfigDatabase.Business.Service bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if (bObject.ERPCommunicationComponentID < 0)
                incorrectProperties.Add(ConfigDatabase.Dal.Service.ColumnERPCommunicationComponentID, PropertyException.cannotBeNull);


            if (incorrectProperties.Count > 0) return false;            
            return true;
        }

        public static bool Validate(ConfigDatabase.Business.EndPoint bObject, out Dictionary<string, PropertyException> incorrectProperties)
        {
            incorrectProperties = new Dictionary<string, PropertyException>();

            if (incorrectProperties.Count > 0) return false;            
            return true;
        }

    }
}
