using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace LanaSoft.UserControls.MultiPanel
{
    public partial class SubItemsPanel : UserControl
    {
        [Browsable(true), Category("CustomProperties")]
        public Size ItemSize { get; set; }

        [Browsable(true)]
        [Category("CustomProperties")]
        public string Caption
        {
            get { return titleLabel.Text; }
            set { titleLabel.Text = value; }
        }

        [Browsable(true)]
        [Category("CustomProperties")]
        public Color CaptionBackColor
        {
            get { return titlePanel.BackColor; }
            set { titlePanel.BackColor = value; }
        }

        [Browsable(true)]
        [Category("CustomProperties")]
        public Color CaptionForeColor
        {
            get { return titleLabel.ForeColor; }
            set { titleLabel.ForeColor = value; }
        }

        [Browsable(true)]
        [Category("CustomProperties")]
        public ImageList ItemsImageList { get; set; }

        [Category("CustomProperties")]
        [Editor(typeof(SubItemsCollectionDesigner), typeof(UITypeEditor))]
        InfoItemsCollection _items;
        public InfoItemsCollection SubItems
        {
            get { return _items; }
            set
            {
                if (_items != null && _items != value)
                    _items = value;
            }
        }

        public SubItemsPanel()
        {
            ItemSize = new Size(300, 90);
            InitializeComponent();

            if (SubItems == null)
                SubItems = new InfoItemsCollection(this);
        }

        public SubItemsPanel(InfoItem[] items)
        {
            ItemSize = new Size(300, 90);
            SubItems = new InfoItemsCollection(this, items);
        }

        public void AddSubItemToPanel(InfoItem subItem)
        {
            if (!this.subItemsLayoutPanel.Controls.Contains(subItem))
            {
                subItem.Size = this.ItemSize;
                this.subItemsLayoutPanel.Controls.Add(subItem);
                this.subItemsLayoutPanel.ResumeLayout();
            }
        }

        public void Clear()
        {
            SubItems.Clear();
            subItemsLayoutPanel.Controls.Clear();
        }
    }
}
