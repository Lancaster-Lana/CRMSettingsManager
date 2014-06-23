namespace LanaSoft.SettingsTool.Controls
{
    partial class DetailedControl
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.tileLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.mainSettingsToolBar = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.choiseItemsToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.choisePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.titlePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainSettingsToolBar.SuspendLayout();
            this.choisePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.SteelBlue;
            this.titlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titlePanel.Controls.Add(this.tileLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(645, 46);
            this.titlePanel.TabIndex = 0;
            // 
            // tileLabel
            // 
            this.tileLabel.AutoSize = true;
            this.tileLabel.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tileLabel.Location = new System.Drawing.Point(22, 19);
            this.tileLabel.Name = "tileLabel";
            this.tileLabel.Size = new System.Drawing.Size(41, 20);
            this.tileLabel.TabIndex = 0;
            this.tileLabel.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cancelButton);
            this.panel2.Controls.Add(this.applyButton);
            this.panel2.Controls.Add(this.previousButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 364);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 47);
            this.panel2.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cancelButton.Location = new System.Drawing.Point(536, 9);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 27);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.applyButton.Location = new System.Drawing.Point(437, 9);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(93, 27);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Visible = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.previousButton.Location = new System.Drawing.Point(3, 9);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(82, 27);
            this.previousButton.TabIndex = 1;
            this.previousButton.Text = "<<";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // mainSettingsToolBar
            // 
            this.mainSettingsToolBar.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.mainSettingsToolBar.CausesValidation = true;
            this.mainSettingsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.toolStripSeparator1,
            this.saveButton,
            this.toolStripSeparator3,
            this.deleteButton,
            this.toolStripSeparator2,
            this.choiseItemsToolStripButton});
            this.mainSettingsToolBar.Location = new System.Drawing.Point(0, 46);
            this.mainSettingsToolBar.Name = "mainSettingsToolBar";
            this.mainSettingsToolBar.Padding = new System.Windows.Forms.Padding(3);
            this.mainSettingsToolBar.Size = new System.Drawing.Size(645, 29);
            this.mainSettingsToolBar.TabIndex = 15;
            this.mainSettingsToolBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mainSettingsToolBar_ItemClicked);
            // 
            // newButton
            // 
            this.newButton.Image = global::LanaSoft.SettingsTool.Properties.Resources.New;
            this.newButton.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(44, 20);
            this.newButton.Tag = "new";
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(10, 23);
            // 
            // saveButton
            // 
            this.saveButton.Image = global::LanaSoft.SettingsTool.Properties.Resources.Save;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(51, 20);
            this.saveButton.Tag = "save";
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(10, 23);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = global::LanaSoft.SettingsTool.Properties.Resources.Delete;
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(58, 20);
            this.deleteButton.Tag = "delete";
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(10, 23);
            // 
            // choiseItemsToolStripButton
            // 
            this.choiseItemsToolStripButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.choiseItemsToolStripButton.DropDownDirection = System.Windows.Forms.ToolStripDropDownDirection.BelowRight;
            this.choiseItemsToolStripButton.Image = global::LanaSoft.SettingsTool.Properties.Resources.Settingslist;
            this.choiseItemsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.choiseItemsToolStripButton.Name = "choiseItemsToolStripButton";
            this.choiseItemsToolStripButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.choiseItemsToolStripButton.RightToLeftAutoMirrorImage = true;
            this.choiseItemsToolStripButton.Size = new System.Drawing.Size(157, 20);
            this.choiseItemsToolStripButton.Text = "Choose another settings";
            this.choiseItemsToolStripButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.choiseItemsToolStripButton.ToolTipText = "Select saved settings data";
            // 
            // choisePanel
            // 
            this.choisePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.choisePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.choisePanel.Controls.Add(this.label1);
            this.choisePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.choisePanel.Location = new System.Drawing.Point(0, 75);
            this.choisePanel.Name = "choisePanel";
            this.choisePanel.Size = new System.Drawing.Size(645, 29);
            this.choisePanel.TabIndex = 18;
            this.choisePanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select current data to view";
            // 
            // infoPanel
            // 
            this.infoPanel.AutoScroll = true;
            this.infoPanel.BackColor = System.Drawing.Color.AliceBlue;
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoPanel.Location = new System.Drawing.Point(0, 104);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(5);
            this.infoPanel.Size = new System.Drawing.Size(645, 260);
            this.infoPanel.TabIndex = 20;
            // 
            // DetailedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.choisePanel);
            this.Controls.Add(this.mainSettingsToolBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.titlePanel);
            this.Name = "DetailedControl";
            this.Size = new System.Drawing.Size(645, 411);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mainSettingsToolBar.ResumeLayout(false);
            this.mainSettingsToolBar.PerformLayout();
            this.choisePanel.ResumeLayout(false);
            this.choisePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label tileLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.ToolStrip mainSettingsToolBar;
        private System.Windows.Forms.ToolStripLabel newButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel choisePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton choiseItemsToolStripButton;
    }
}
