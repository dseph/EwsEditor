namespace EWSEditor.Forms
{
    partial class ServiceDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblExImp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TempExchangeVersionCombo = new System.Windows.Forms.ComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblImpId = new System.Windows.Forms.Label();
            this.ImpersonationCheck = new System.Windows.Forms.CheckBox();
            this.lblImpIdType = new System.Windows.Forms.Label();
            this.TempConnectingIdCombo = new System.Windows.Forms.ComboBox();
            this.ImpersonatedIdTextBox = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.chkCredentials = new System.Windows.Forms.CheckBox();
            this.ExchangeServiceURLText = new System.Windows.Forms.TextBox();
            this.ExchangeServiceLabel = new System.Windows.Forms.Label();
            this.AutodiscoverEmailText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UseAutodiscoverCheck = new System.Windows.Forms.CheckBox();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(223, 429);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(304, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblExImp
            // 
            this.lblExImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExImp.AutoSize = true;
            this.lblExImp.Location = new System.Drawing.Point(22, 136);
            this.lblExImp.Name = "lblExImp";
            this.lblExImp.Size = new System.Drawing.Size(0, 13);
            this.lblExImp.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(11, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 10);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // TempExchangeVersionCombo
            // 
            this.TempExchangeVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempExchangeVersionCombo.FormattingEnabled = true;
            this.TempExchangeVersionCombo.Location = new System.Drawing.Point(126, 112);
            this.TempExchangeVersionCombo.Name = "TempExchangeVersionCombo";
            this.TempExchangeVersionCombo.Size = new System.Drawing.Size(211, 21);
            this.TempExchangeVersionCombo.TabIndex = 2;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(8, 112);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(100, 37);
            this.lblVersion.TabIndex = 26;
            this.lblVersion.Text = "Requested Exchange Version:";
            // 
            // lblImpId
            // 
            this.lblImpId.AutoSize = true;
            this.lblImpId.Enabled = false;
            this.lblImpId.Location = new System.Drawing.Point(43, 377);
            this.lblImpId.Name = "lblImpId";
            this.lblImpId.Size = new System.Drawing.Size(19, 13);
            this.lblImpId.TabIndex = 36;
            this.lblImpId.Text = "Id:";
            // 
            // ImpersonationCheck
            // 
            this.ImpersonationCheck.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ImpersonationCheck.Location = new System.Drawing.Point(11, 311);
            this.ImpersonationCheck.Name = "ImpersonationCheck";
            this.ImpersonationCheck.Size = new System.Drawing.Size(352, 31);
            this.ImpersonationCheck.TabIndex = 7;
            this.ImpersonationCheck.Text = "Use impersonation to log on to another mailbox using the credentials specified on" +
                " the credentials tab by identifying the mailbox Id below.";
            this.ImpersonationCheck.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ImpersonationCheck.UseVisualStyleBackColor = true;
            this.ImpersonationCheck.CheckedChanged += new System.EventHandler(this.ChkImpersonation_CheckedChanged);
            // 
            // lblImpIdType
            // 
            this.lblImpIdType.AutoSize = true;
            this.lblImpIdType.Enabled = false;
            this.lblImpIdType.Location = new System.Drawing.Point(43, 350);
            this.lblImpIdType.Name = "lblImpIdType";
            this.lblImpIdType.Size = new System.Drawing.Size(46, 13);
            this.lblImpIdType.TabIndex = 35;
            this.lblImpIdType.Text = "Id Type:";
            // 
            // TempConnectingIdCombo
            // 
            this.TempConnectingIdCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempConnectingIdCombo.Enabled = false;
            this.TempConnectingIdCombo.FormattingEnabled = true;
            this.TempConnectingIdCombo.Location = new System.Drawing.Point(114, 347);
            this.TempConnectingIdCombo.Name = "TempConnectingIdCombo";
            this.TempConnectingIdCombo.Size = new System.Drawing.Size(211, 21);
            this.TempConnectingIdCombo.TabIndex = 8;
            // 
            // ImpersonatedIdTextBox
            // 
            this.ImpersonatedIdTextBox.Enabled = false;
            this.ImpersonatedIdTextBox.Location = new System.Drawing.Point(114, 375);
            this.ImpersonatedIdTextBox.Name = "ImpersonatedIdTextBox";
            this.ImpersonatedIdTextBox.Size = new System.Drawing.Size(211, 20);
            this.ImpersonatedIdTextBox.TabIndex = 9;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Enabled = false;
            this.lblUserName.Location = new System.Drawing.Point(43, 210);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 37;
            this.lblUserName.Text = "User Name:";
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.txtDomain.Location = new System.Drawing.Point(114, 258);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(211, 20);
            this.txtDomain.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(114, 207);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(211, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(114, 233);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(211, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Enabled = false;
            this.lblDomain.Location = new System.Drawing.Point(43, 261);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 42;
            this.lblDomain.Text = "Domain:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Location = new System.Drawing.Point(43, 236);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 39;
            this.lblPassword.Text = "Password:";
            // 
            // chkCredentials
            // 
            this.chkCredentials.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCredentials.Location = new System.Drawing.Point(11, 170);
            this.chkCredentials.Name = "chkCredentials";
            this.chkCredentials.Size = new System.Drawing.Size(352, 31);
            this.chkCredentials.TabIndex = 3;
            this.chkCredentials.Text = "Use the following credentials instead of the default Windows credentials.";
            this.chkCredentials.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCredentials.UseVisualStyleBackColor = true;
            this.chkCredentials.CheckedChanged += new System.EventHandler(this.ChkCredentials_CheckedChanged);
            // 
            // ExchangeServiceURLText
            // 
            this.ExchangeServiceURLText.Location = new System.Drawing.Point(126, 80);
            this.ExchangeServiceURLText.Name = "ExchangeServiceURLText";
            this.ExchangeServiceURLText.ReadOnly = true;
            this.ExchangeServiceURLText.Size = new System.Drawing.Size(211, 20);
            this.ExchangeServiceURLText.TabIndex = 1;
            // 
            // ExchangeServiceLabel
            // 
            this.ExchangeServiceLabel.Location = new System.Drawing.Point(49, 80);
            this.ExchangeServiceLabel.Name = "ExchangeServiceLabel";
            this.ExchangeServiceLabel.Size = new System.Drawing.Size(56, 29);
            this.ExchangeServiceLabel.TabIndex = 58;
            this.ExchangeServiceLabel.Text = "Service URL:";
            // 
            // AutodiscoverEmailText
            // 
            this.AutodiscoverEmailText.Location = new System.Drawing.Point(126, 41);
            this.AutodiscoverEmailText.Name = "AutodiscoverEmailText";
            this.AutodiscoverEmailText.Size = new System.Drawing.Size(211, 20);
            this.AutodiscoverEmailText.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(46, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 30);
            this.label5.TabIndex = 61;
            this.label5.Text = "Autodiscover Email:";
            // 
            // UseAutodiscoverCheck
            // 
            this.UseAutodiscoverCheck.Checked = true;
            this.UseAutodiscoverCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAutodiscoverCheck.Location = new System.Drawing.Point(11, 12);
            this.UseAutodiscoverCheck.Name = "UseAutodiscoverCheck";
            this.UseAutodiscoverCheck.Size = new System.Drawing.Size(352, 24);
            this.UseAutodiscoverCheck.TabIndex = 62;
            this.UseAutodiscoverCheck.Text = "Use Autodiscover to get the Exchange Web Services URL.";
            this.UseAutodiscoverCheck.UseVisualStyleBackColor = true;
            this.UseAutodiscoverCheck.CheckedChanged += new System.EventHandler(this.UseAutodiscoverCheck_CheckedChanged);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            // 
            // ServiceDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(386, 464);
            this.Controls.Add(this.UseAutodiscoverCheck);
            this.Controls.Add(this.AutodiscoverEmailText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExchangeServiceURLText);
            this.Controls.Add(this.ExchangeServiceLabel);
            this.Controls.Add(this.chkCredentials);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblImpId);
            this.Controls.Add(this.ImpersonationCheck);
            this.Controls.Add(this.lblImpIdType);
            this.Controls.Add(this.TempConnectingIdCombo);
            this.Controls.Add(this.ImpersonatedIdTextBox);
            this.Controls.Add(this.TempExchangeVersionCombo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblExImp);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ServiceDialog";
            this.Text = "EWS Editor - Exchange Service Configuration";
            this.Load += new System.EventHandler(this.ServiceDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblExImp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox TempExchangeVersionCombo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblImpId;
        private System.Windows.Forms.CheckBox ImpersonationCheck;
        private System.Windows.Forms.Label lblImpIdType;
        private System.Windows.Forms.ComboBox TempConnectingIdCombo;
        private System.Windows.Forms.TextBox ImpersonatedIdTextBox;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblDomain;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.CheckBox chkCredentials;
        private System.Windows.Forms.TextBox ExchangeServiceURLText;
        private System.Windows.Forms.Label ExchangeServiceLabel;
        private System.Windows.Forms.TextBox AutodiscoverEmailText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox UseAutodiscoverCheck;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}