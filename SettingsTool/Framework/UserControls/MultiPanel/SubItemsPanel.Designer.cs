namespace LanaSoft.UserControls.MultiPanel
{
    partial class SubItemsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.splitLabel = new System.Windows.Forms.Label();
            this.subItemsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.itemsImageList = new System.Windows.Forms.ImageList(this.components);
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(424, 43);
            this.titlePanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(5, 12);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(101, 17);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Common Info";
            // 
            // splitLabel
            // 
            this.splitLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitLabel.Location = new System.Drawing.Point(0, 43);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(424, 1);
            this.splitLabel.TabIndex = 8;
            // 
            // subItemsLayoutPanel
            // 
            this.subItemsLayoutPanel.AutoScroll = true;
            this.subItemsLayoutPanel.BackColor = System.Drawing.Color.DarkGray;
            this.subItemsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subItemsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.subItemsLayoutPanel.Location = new System.Drawing.Point(0, 44);
            this.subItemsLayoutPanel.Name = "subItemsLayoutPanel";
            this.subItemsLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.subItemsLayoutPanel.Size = new System.Drawing.Size(424, 386);
            this.subItemsLayoutPanel.TabIndex = 9;
            // 
            // itemsImageList
            // 
            this.itemsImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.itemsImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.itemsImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SubItemsPanel
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.subItemsLayoutPanel);
            this.Controls.Add(this.splitLabel);
            this.Controls.Add(this.titlePanel);
            this.Name = "SubItemsPanel";
            this.Size = new System.Drawing.Size(424, 430);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label splitLabel;
        public System.Windows.Forms.FlowLayoutPanel subItemsLayoutPanel;
        private System.Windows.Forms.ImageList itemsImageList;
    }
}
