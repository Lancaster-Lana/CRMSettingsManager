namespace LanaSoft.ConfigDatabase.Dal
{
    public class ConfigDatabase
    {
        #region Methods

        public static void SetConnectionString(string connStr)
        {
            Properties.Settings.Default.ConfigDBConnectionString = connStr;
        }

        #endregion
    }
}