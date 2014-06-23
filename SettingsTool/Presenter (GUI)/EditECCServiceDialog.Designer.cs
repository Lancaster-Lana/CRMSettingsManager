namespace SettingsTool
{
    partial class EditECCServiceDialog
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
            this.endPointGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.serviceHostLabel = new System.Windows.Forms.Label();
            this.servicePortLabel = new System.Windows.Forms.Label();
            this.answerPortTextBox = new System.Windows.Forms.TextBox();
            this.answerHostTextBox = new System.Windows.Forms.TextBox();
            this.listenLabel = new System.Windows.Forms.Label();
            this.answerLabel = new System.Windows.Forms.Label();
            this.listenHostTextBox = new System.Windows.Forms.TextBox();
            this.listenPortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.endPointComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.endPointGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // endPointGroupBox
            // 
            this.endPointGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.endPointGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPointGroupBox.ForeColor = System.Drawing.Color.RoyalBlue;
            this.endPointGroupBox.Location = new System.Drawing.Point(100, 89);
            this.endPointGroupBox.Name = "endPointGroupBox";
            this.endPointGroupBox.Size = new System.Drawing.Size(259, 104);
            this.endPointGroupBox.TabIndex = 27;
            this.endPointGroupBox.TabStop = false;
            this.endPointGroupBox.Text = "EndPoint";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel3.Controls.Add(this.serviceHostLabel, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.servicePortLabel, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.answerPortTextBox, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.answerHostTextBox, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.listenLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.answerLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.listenHostTextBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.listenPortTextBox, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(253, 85);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // serviceHostLabel
            // 
            this.serviceHostLabel.AutoSize = true;
            this.serviceHostLabel.Location = new System.Drawing.Point(85, 0);
            this.serviceHostLabel.Name = "serviceHostLabel";
            this.serviceHostLabel.Size = new System.Drawing.Size(29, 13);
            this.serviceHostLabel.TabIndex = 3;
            this.serviceHostLabel.Text = "Host";
            // 
            // servicePortLabel
            // 
            this.servicePortLabel.AutoSize = true;
            this.servicePortLabel.Location = new System.Drawing.Point(213, 0);
            this.servicePortLabel.Name = "servicePortLabel";
            this.servicePortLabel.Size = new System.Drawing.Size(26, 13);
            this.servicePortLabel.TabIndex = 5;
            this.servicePortLabel.Text = "Port";
            // 
            // answerPortTextBox
            // 
            this.answerPortTextBox.Location = new System.Drawing.Point(213, 56);
            this.answerPortTextBox.Name = "answerPortTextBox";
            this.answerPortTextBox.Size = new System.Drawing.Size(34, 20);
            this.answerPortTextBox.TabIndex = 4;
            // 
            // answerHostTextBox
            // 
            this.answerHostTextBox.Location = new System.Drawing.Point(85, 56);
            this.answerHostTextBox.Name = "answerHostTextBox";
            this.answerHostTextBox.Size = new System.Drawing.Size(122, 20);
            this.answerHostTextBox.TabIndex = 3;
            // 
            // listenLabel
            // 
            this.listenLabel.AutoSize = true;
            this.listenLabel.Location = new System.Drawing.Point(18, 23);
            this.listenLabel.Name = "listenLabel";
            this.listenLabel.Size = new System.Drawing.Size(35, 13);
            this.listenLabel.TabIndex = 9;
            this.listenLabel.Text = "Listen";
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(18, 53);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(42, 13);
            this.answerLabel.TabIndex = 10;
            this.answerLabel.Text = "Answer";
            // 
            // listenHostTextBox
            // 
            this.listenHostTextBox.Location = new System.Drawing.Point(85, 26);
            this.listenHostTextBox.Name = "listenHostTextBox";
            this.listenHostTextBox.Size = new System.Drawing.Size(122, 20);
            this.listenHostTextBox.TabIndex = 1;
            // 
            // listenPortTextBox
            // 
            this.listenPortTextBox.Location = new System.Drawing.Point(213, 26);
            this.listenPortTextBox.Name = "listenPortTextBox";
            this.listenPortTextBox.Size = new System.Drawing.Size(34, 20);
            this.listenPortTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Type";
            // 
            // serviceTypeComboBox
            // 
            this.serviceTypeComboBox.Location = new System.Drawing.Point(100, 19);
            this.serviceTypeComboBox.Name = "serviceTypeComboBox";
            this.serviceTypeComboBox.Size = new System.Drawing.Size(165, 21);
            this.serviceTypeComboBox.TabIndex = 0;
            this.serviceTypeComboBox.ValueMember = "ID";
            this.serviceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.serviceTypeComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(362, 170);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(55, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(420, 170);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(55, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // endPointComboBox
            // 
            this.endPointComboBox.DisplayMember = "ID";
            this.endPointComboBox.FormattingEnabled = true;
            this.endPointComboBox.Location = new System.Drawing.Point(100, 62);
            this.endPointComboBox.Name = "endPointComboBox";
            this.endPointComboBox.Size = new System.Drawing.Size(381, 21);
            this.endPointComboBox.TabIndex = 28;
            this.endPointComboBox.ValueMember = "ID";
            this.endPointComboBox.SelectedIndexChanged += new System.EventHandler(this.endPointComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "EndPoint";
            // 
            // EditECCServiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 204);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endPointComboBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.endPointGroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serviceTypeComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditECCServiceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditECCServiceDialog";
            this.Load += new System.EventHandler(this.EditECCServiceDialog_Load);
            this.endPointGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox endPointGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label serviceHostLabel;
        private System.Windows.Forms.Label servicePortLabel;
        private System.Windows.Forms.TextBox answerPortTextBox;
        private System.Windows.Forms.TextBox answerHostTextBox;
        private System.Windows.Forms.Label listenLabel;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox listenHostTextBox;
        private System.Windows.Forms.TextBox listenPortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox serviceTypeComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ComboBox endPointComboBox;
        private System.Windows.Forms.Label label1;
    }
}