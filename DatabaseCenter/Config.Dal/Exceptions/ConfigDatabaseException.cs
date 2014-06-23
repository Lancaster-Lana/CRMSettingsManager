using System;

namespace LanaSoft.ConfigDatabase.Dal
{
    public enum ConfigDatabaseExceptionType { emptyRow = 0, nullReferenceException = 1 }

    public class ConfigDatabaseException : Exception
    {
        public new string Message { get; set; }

        public ConfigDatabaseException(ConfigDatabaseExceptionType exType)
        {
            switch (exType)
            {
                case ConfigDatabaseExceptionType.emptyRow:
                    Message = "DataRow empty!";
                    break;
                case ConfigDatabaseExceptionType.nullReferenceException:
                    Message = "Check all data fields not to be null !";
                    break;
            }
        }
    }
}
