CRM server -and- ERP clients systems settings configuration tool.
1. In app.config <connectionStrings> in CONFIG_DataConnectionString change DB server name to your default instance, for example     
     connectionString="data source=.\SQLEXPRESS;
2. If CONFIG_Data.MDF if attached to default MS SQL Server instance, DETACH it (it will be atached automatically)
3. Rebuild and start SettingTool application to create\change existing CRM\ERP configurations.
