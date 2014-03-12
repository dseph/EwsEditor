namespace EWSEditor.Forms
{
    partial class UserIdDialog
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
        private new void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DisplayNameText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SmtpAddressText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserSidText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TempStandardUserCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ResolveNameButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserId information...";
            // 
            // DisplayNameText
            // 
            this.DisplayNameText.Location = new System.Drawing.Point(99, 31);
            this.DisplayNameText.Name = "DisplayNameText";
            this.DisplayNameText.Size = new System.Drawing.Size(219, 20);
            this.DisplayNameText.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Display Name:";
            // 
            // SmtpAddressText
            // 
            this.SmtpAddressText.Location = new System.Drawing.Point(99, 61);
            this.SmtpAddressText.Name = "SmtpAddressText";
            this.SmtpAddressText.Size = new System.Drawing.Size(219, 20);
            this.SmtpAddressText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primary SMTP:";
            // 
            // UserSidText
            // 
            this.UserSidText.Location = new System.Drawing.Point(99, 92);
            this.UserSidText.Name = "UserSidText";
            this.UserSidText.Size = new System.Drawing.Size(219, 20);
            this.UserSidText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User SID:";
            // 
            // TempStandardUserCombo
            // 
            this.TempStandardUserCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempStandardUserCombo.FormattingEnabled = true;
            this.TempStandardUserCombo.Location = new System.Drawing.Point(99, 129);
            this.TempStandardUserCombo.Name = "TempStandardUserCombo";
            this.TempStandardUserCombo.Size = new System.Drawing.Size(219, 21);
            this.TempStandardUserCombo.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Standard User:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(8, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 10);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(180, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ResolveNameButton
            // 
            this.ResolveNameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResolveNameButton.Location = new System.Drawing.Point(271, 162);
            this.ResolveNameButton.Name = "ResolveNameButton";
            this.ResolveNameButton.Size = new System.Drawing.Size(26, 23);
            this.ResolveNameButton.TabIndex = 10;
            this.ResolveNameButton.Text = "...";
            this.ResolveNameButton.UseVisualStyleBackColor = true;
            this.ResolveNameButton.Click += new System.EventHandler(this.ResolveNameButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "User ResolveNames dialog to get UserId information";
            // 
            // UserIdDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(346, 237);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ResolveNameButton);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TempStandardUserCombo);
            this.Controls.Add(this.UserSidText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SmtpAddressText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DisplayNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "UserIdDialog";
            this.Text = "Get UserId";
            this.Load += new System.EventHandler(this.UserIdDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DisplayNameText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SmtpAddressText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserSidText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TempStandardUserCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button ResolveNameButton;
        private System.Windows.Forms.Label label6;
    }
}
