namespace LanaSoft.SettingsTool.Controls
{
    partial class ServiceType
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
            this.ERPServiceDataGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.serviceTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.serviceTypeLabel = new System.Windows.Forms.Label();
            this.ERPServiceDataGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ERPServiceDataGroupBox
            // 
            this.ERPServiceDataGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.ERPServiceDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ERPServiceDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.ERPServiceDataGroupBox.Name = "ERPServiceDataGroupBox";
            this.ERPServiceDataGroupBox.Size = new System.Drawing.Size(274, 51);
            this.ERPServiceDataGroupBox.TabIndex = 0;
            this.ERPServiceDataGroupBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.Controls.Add(this.serviceTypeNameTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.serviceTypeLabel, 1, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(262, 27);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // serviceTypeNameTextBox
            // 
            this.serviceTypeNameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.serviceTypeNameTextBox.Location = new System.Drawing.Point(118, 3);
            this.serviceTypeNameTextBox.Name = "serviceTypeNameTextBox";
            this.serviceTypeNameTextBox.Size = new System.Drawing.Size(141, 20);
            this.serviceTypeNameTextBox.TabIndex = 4;
            this.serviceTypeNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.serviceTypeNameTextBox_Validating);
            // 
            // serviceTypeLabel
            // 
            this.serviceTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serviceTypeLabel.AutoSize = true;
            this.serviceTypeLabel.Location = new System.Drawing.Point(18, 7);
            this.serviceTypeLabel.Name = "serviceTypeLabel";
            this.serviceTypeLabel.Size = new System.Drawing.Size(70, 13);
            this.serviceTypeLabel.TabIndex = 1;
            this.serviceTypeLabel.Text = "Service Type";
            // 
            // ServiceType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ERPServiceDataGroupBox);
            this.Name = "ServiceType";
            this.Size = new System.Drawing.Size(283, 55);
            this.CausesValidationChanged += new System.EventHandler(this.ServiceType_CausesValidationChanged);
            this.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.ServiceType_ChangeUICues);
            this.ERPServiceDataGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ERPServiceDataGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label serviceTypeLabel;
        private System.Windows.Forms.TextBox serviceTypeNameTextBox;

    }
}
