using System;
using System.Windows.Forms;

namespace LanaSoft.SettingsTool
{
    public enum ServiceDeletionMode { none, endPointLinkOnly, endPointLinkAndEndPoint, eccServiceOnly, eccServiceAndRelatedEndPoint }

    public partial class RemoveEndPointFromECCServiceDialog : Form
    {
        public int EndPointID { get; set; }

        public int ECCServiceID { get; set; }

        public ServiceDeletionMode DeletionMode { get; set; }

        public RemoveEndPointFromECCServiceDialog()
        {
            DeletionMode = ServiceDeletionMode.none;
            InitializeComponent();
        }

        public RemoveEndPointFromECCServiceDialog(int endPointID, int eccServiceID)
            : this()
        {
            EndPointID = endPointID;
            ECCServiceID = eccServiceID;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (eccServiceDelRadioButton.Checked)
            {
                DeletionMode = (relatedEndPointsCheckBox.Checked) ? ServiceDeletionMode.eccServiceAndRelatedEndPoint : ServiceDeletionMode.eccServiceOnly;
            }
            else if (endPointLinkRadioButton.Checked)
            {
                DeletionMode = (endPointRemoveCheckBox.Checked) ? ServiceDeletionMode.endPointLinkAndEndPoint : ServiceDeletionMode.endPointLinkOnly;
            }
        }

        private void RemoveEndPointFromECCServiceDialog_Load(object sender, EventArgs e)
        {

        }
    }
}