using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace LanaSoft.UserControls.MultiPanel
{

    [Designer(typeof(InfoControlDesigner))]
    public partial class InfoItem : UserControl
    {
        public event EventHandler Click;

        [Browsable(false)]
        internal SubItemsPanel ParentPanel { get; set; }

        [Category("CustomProperties")]
        [Browsable(true)]
        public string Title
        {
            get { return titleLabel.Text; }
            set
            {
                titleLabel.Text = value;
            }
        }

        [Category("CustomProperties")]
        [Browsable(true)]
        public string Description
        {
            get { return descriptionLabel.Text; }
            set
            {
                descriptionLabel.Text = value;
            }
        }

        [Category("CustomProperties")]
        [Browsable(true)]
        public Image Image
        {
            get { return Picture.Image; }
            set { Picture.Image = value; }
        }

        public InfoItem()
        {
            InitializeComponent();
            //this.Click +=new EventHandler(InfoItem_Click);
        }

        public InfoItem(string title, string description, Image img)
            : this()
        {
            Title = title;
            Description = description;
            //if (img != null)
            Image = img;
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }

        private void titleLabel_MouseHover(object sender, EventArgs e)
        {
            titleLabel.ForeColor = Color.LightSkyBlue;            
            titleLabel.Invalidate();        
        }

        private void titlePanel_MouseLeave(object sender, EventArgs e)
        {
            titleLabel.ForeColor = Color.Blue;
            splitLabel.ForeColor = Color.Blue;
            titleLabel.Invalidate();
            splitLabel.Invalidate();
        }
    }

    public class InfoControlDesigner : ControlDesigner
    {
        private Adorner adorner;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            adorner = new Adorner();
            BehaviorService.Adorners.Add(adorner);
            adorner.Glyphs.Add(new InfoControlGlyph(BehaviorService, Control));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && adorner != null)
            {
                BehaviorService b = BehaviorService;
                if (b != null)
                {
                    b.Adorners.Remove(adorner);
                }
            }
        }

        protected override void OnMouseDragMove(int x, int y)
        {
            //base.OnMouseDragMove(x, y);
        }
    }

    public class InfoControlGlyph : Glyph
    {
        Control control;
        BehaviorService behaviorSvc;

        public InfoControlGlyph(BehaviorService behaviorSvc, Control control)
            : base(new InfoControlBehavior())
        {
            this.behaviorSvc = behaviorSvc;
            this.control = control;
        }

        public override void Paint(PaintEventArgs pe)
        {

        }

        public override Cursor GetHitTest(Point p)
        {
            if (Bounds.Contains(p))
            {
                return Cursors.Hand;
            }

            return null;
        }

    }

    public class InfoControlBehavior : Behavior
    {
    }
}
