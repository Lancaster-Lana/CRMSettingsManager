namespace LanaSoft.SettingsTool
{
    partial class RemoveEndPointFromECCServiceDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.removeEndPointECCServiceGroupBox = new System.Windows.Forms.GroupBox();
            this.endPointRemoveCheckBox = new System.Windows.Forms.CheckBox();
            this.relatedEndPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.eccServiceDelRadioButton = new System.Windows.Forms.RadioButton();
            this.endPointLinkRadioButton = new System.Windows.Forms.RadioButton();
            this.removeEndPointECCServiceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(180, 107);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(55, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(241, 107);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(55, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // removeEndPointECCServiceGroupBox
            // 
            this.removeEndPointECCServiceGroupBox.Controls.Add(this.endPointRemoveCheckBox);
            this.removeEndPointECCServiceGroupBox.Controls.Add(this.relatedEndPointsCheckBox);
            this.removeEndPointECCServiceGroupBox.Controls.Add(this.eccServiceDelRadioButton);
            this.removeEndPointECCServiceGroupBox.Controls.Add(this.endPointLinkRadioButton);
            this.removeEndPointECCServiceGroupBox.Location = new System.Drawing.Point(12, 13);
            this.removeEndPointECCServiceGroupBox.Name = "removeEndPointECCServiceGroupBox";
            this.removeEndPointECCServiceGroupBox.Size = new System.Drawing.Size(306, 90);
            this.removeEndPointECCServiceGroupBox.TabIndex = 4;
            this.removeEndPointECCServiceGroupBox.TabStop = false;
            this.removeEndPointECCServiceGroupBox.Text = "Delete";
            // 
            // endPointRemoveCheckBox
            // 
            this.endPointRemoveCheckBox.AutoSize = true;
            this.endPointRemoveCheckBox.Location = new System.Drawing.Point(146, 35);
            this.endPointRemoveCheckBox.Name = "endPointRemoveCheckBox";
            this.endPointRemoveCheckBox.Size = new System.Drawing.Size(114, 17);
            this.endPointRemoveCheckBox.TabIndex = 4;
            this.endPointRemoveCheckBox.Text = "including EndPoint";
            this.endPointRemoveCheckBox.UseVisualStyleBackColor = true;
            // 
            // relatedEndPointsCheckBox
            // 
            this.relatedEndPointsCheckBox.AutoSize = true;
            this.relatedEndPointsCheckBox.Location = new System.Drawing.Point(146, 67);
            this.relatedEndPointsCheckBox.Name = "relatedEndPointsCheckBox";
            this.relatedEndPointsCheckBox.Size = new System.Drawing.Size(154, 17);
            this.relatedEndPointsCheckBox.TabIndex = 3;
            this.relatedEndPointsCheckBox.Text = "including related EndPoints";
            this.relatedEndPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // eccServiceDelRadioButton
            // 
            this.eccServiceDelRadioButton.AutoSize = true;
            this.eccServiceDelRadioButton.Location = new System.Drawing.Point(15, 67);
            this.eccServiceDelRadioButton.Name = "eccServiceDelRadioButton";
            this.eccServiceDelRadioButton.Size = new System.Drawing.Size(85, 17);
            this.eccServiceDelRadioButton.TabIndex = 2;
            this.eccServiceDelRadioButton.Text = "ECC Service";
            this.eccServiceDelRadioButton.UseVisualStyleBackColor = true;
            // 
            // endPointLinkRadioButton
            // 
            this.endPointLinkRadioButton.AutoSize = true;
            this.endPointLinkRadioButton.Checked = true;
            this.endPointLinkRadioButton.Location = new System.Drawing.Point(15, 34);
            this.endPointLinkRadioButton.Name = "endPointLinkRadioButton";
            this.endPointLinkRadioButton.Size = new System.Drawing.Size(123, 17);
            this.endPointLinkRadioButton.TabIndex = 1;
            this.endPointLinkRadioButton.TabStop = true;
            this.endPointLinkRadioButton.Text = "Only link to EndPoint";
            this.endPointLinkRadioButton.UseVisualStyleBackColor = true;
            // 
            // RemoveEndPointFromECCServiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 142);
            this.Controls.Add(this.removeEndPointECCServiceGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RemoveEndPointFromECCServiceDialog";
            this.Text = "Remove Dialog";
            this.Load += new System.EventHandler(this.RemoveEndPointFromECCServiceDialog_Load);
            this.removeEndPointECCServiceGroupBox.ResumeLayout(false);
            this.removeEndPointECCServiceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox removeEndPointECCServiceGroupBox;
        private System.Windows.Forms.RadioButton eccServiceDelRadioButton;
        private System.Windows.Forms.RadioButton endPointLinkRadioButton;
        private System.Windows.Forms.CheckBox relatedEndPointsCheckBox;
        private System.Windows.Forms.CheckBox endPointRemoveCheckBox;
    }
}