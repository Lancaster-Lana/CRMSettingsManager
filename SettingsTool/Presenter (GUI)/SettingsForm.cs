using System;
using System.Windows.Forms;
using System.Configuration;

namespace LanaSoft.SettingsTool
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Settings_Tool_Load(object sender, EventArgs e)
        {            
            SettingsManager.LoadCommonView(this.settingsPanel);
            //Init DataBase path
            //ConfigDatabase.Dal.ConfigDatabase.SetConnectionString(ConfigurationManager.ConnectionStrings["CONFIG_ConnectionString"].ConnectionString);
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

