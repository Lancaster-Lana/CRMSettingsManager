namespace LanaSoft.SettingsTool.Controls
{
    partial class CRMCommunicator
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
            this.CRMCommunicatorDataGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hostLabel = new System.Windows.Forms.Label();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.CRMCommunicatorDataGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CRMCommunicatorDataGroupBox
            // 
            this.CRMCommunicatorDataGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.CRMCommunicatorDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRMCommunicatorDataGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CRMCommunicatorDataGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CRMCommunicatorDataGroupBox.Name = "CRMCommunicatorDataGroupBox";
            this.CRMCommunicatorDataGroupBox.Size = new System.Drawing.Size(276, 130);
            this.CRMCommunicatorDataGroupBox.TabIndex = 0;
            this.CRMCommunicatorDataGroupBox.TabStop = false;
            this.CRMCommunicatorDataGroupBox.Text = "CRMCommunicator Configuration";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.8432F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.1568F));
            this.tableLayoutPanel1.Controls.Add(this.hostLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.hostTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.portLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.portTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.activeCheckBox, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(265, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 114);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hostLabel.Location = new System.Drawing.Point(18, 21);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(82, 13);
            this.hostLabel.TabIndex = 3;
            this.hostLabel.Text = "CRM Host";
            // 
            // hostTextBox
            // 
            this.hostTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.hostTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hostTextBox.Location = new System.Drawing.Point(106, 13);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.hostTextBox.Size = new System.Drawing.Size(161, 20);
            this.hostTextBox.TabIndex = 1;
            this.hostTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.hostTextBox_Validating);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.portLabel.Location = new System.Drawing.Point(18, 46);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(82, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "CRM Port";
            // 
            // portTextBox
            // 
            this.portTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.portTextBox.Location = new System.Drawing.Point(106, 37);
            this.portTextBox.Mask = "00000";
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(161, 20);
            this.portTextBox.TabIndex = 2;
            this.portTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.portTextBox_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(18, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Active";
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.activeCheckBox.Location = new System.Drawing.Point(106, 64);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(161, 14);
            this.activeCheckBox.TabIndex = 3;
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // CRMCommunicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.CRMCommunicatorDataGroupBox);
            this.MinimumSize = new System.Drawing.Size(272, 88);
            this.Name = "CRMCommunicator";
            this.Size = new System.Drawing.Size(276, 130);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.CRMCommunicator_Validating);
            this.CRMCommunicatorDataGroupBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CRMCommunicatorDataGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.MaskedTextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox activeCheckBox;

    }
}
