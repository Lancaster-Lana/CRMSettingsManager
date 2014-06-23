using System;

namespace LanaSoft.SettingsTool
{
    public enum ExceptionType {none = 0, portIsBusy = 0, hostAlreadyExist = 1}

    public class SettingsToolException:Exception
    {
        ExceptionType _exceptionType = ExceptionType.none;

        public SettingsToolException(ExceptionType exType, string message)
        {
            this.Data.Add(exType, message);
        }

        public override string ToString()
        {
            return Data[_exceptionType].ToString();
        }
    }
}
