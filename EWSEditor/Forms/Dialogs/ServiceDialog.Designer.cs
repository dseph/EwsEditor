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
            this.label1 = new System.Windows.Forms.Label();
            this.cmboTimeZoneIds = new System.Windows.Forms.ComboBox();
            this.chkUseSpecifiedTimezone = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(306, 539);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(387, 539);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblExImp
            // 
            this.lblExImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExImp.AutoSize = true;
            this.lblExImp.Location = new System.Drawing.Point(23, -42);
            this.lblExImp.Name = "lblExImp";
            this.lblExImp.Size = new System.Drawing.Size(0, 13);
            this.lblExImp.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(13, 523);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 10);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // TempExchangeVersionCombo
            // 
            this.TempExchangeVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempExchangeVersionCombo.FormattingEnabled = true;
            this.TempExchangeVersionCombo.Location = new System.Drawing.Point(121, 117);
            this.TempExchangeVersionCombo.Name = "TempExchangeVersionCombo";
            this.TempExchangeVersionCombo.Size = new System.Drawing.Size(295, 21);
            this.TempExchangeVersionCombo.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(13, 120);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(102, 21);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Exchange Version:";
            // 
            // lblImpId
            // 
            this.lblImpId.AutoSize = true;
            this.lblImpId.Enabled = false;
            this.lblImpId.Location = new System.Drawing.Point(41, 85);
            this.lblImpId.Name = "lblImpId";
            this.lblImpId.Size = new System.Drawing.Size(19, 13);
            this.lblImpId.TabIndex = 3;
            this.lblImpId.Text = "Id:";
            // 
            // ImpersonationCheck
            // 
            this.ImpersonationCheck.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ImpersonationCheck.Location = new System.Drawing.Point(9, 15);
            this.ImpersonationCheck.Name = "ImpersonationCheck";
            this.ImpersonationCheck.Size = new System.Drawing.Size(352, 31);
            this.ImpersonationCheck.TabIndex = 0;
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
            this.lblImpIdType.Location = new System.Drawing.Point(41, 54);
            this.lblImpIdType.Name = "lblImpIdType";
            this.lblImpIdType.Size = new System.Drawing.Size(46, 13);
            this.lblImpIdType.TabIndex = 1;
            this.lblImpIdType.Text = "Id Type:";
            // 
            // TempConnectingIdCombo
            // 
            this.TempConnectingIdCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempConnectingIdCombo.Enabled = false;
            this.TempConnectingIdCombo.FormattingEnabled = true;
            this.TempConnectingIdCombo.ItemHeight = 13;
            this.TempConnectingIdCombo.Location = new System.Drawing.Point(112, 51);
            this.TempConnectingIdCombo.Name = "TempConnectingIdCombo";
            this.TempConnectingIdCombo.Size = new System.Drawing.Size(289, 21);
            this.TempConnectingIdCombo.TabIndex = 2;
            // 
            // ImpersonatedIdTextBox
            // 
            this.ImpersonatedIdTextBox.Enabled = false;
            this.ImpersonatedIdTextBox.Location = new System.Drawing.Point(112, 78);
            this.ImpersonatedIdTextBox.Name = "ImpersonatedIdTextBox";
            this.ImpersonatedIdTextBox.Size = new System.Drawing.Size(289, 20);
            this.ImpersonatedIdTextBox.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Enabled = false;
            this.lblUserName.Location = new System.Drawing.Point(44, 59);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "User Name:";
            // 
            // txtDomain
            // 
            this.txtDomain.Enabled = false;
            this.txtDomain.Location = new System.Drawing.Point(115, 107);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(286, 20);
            this.txtDomain.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(115, 56);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(286, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(115, 82);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(286, 20);
            this.txtPassword.TabIndex = 0;
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Enabled = false;
            this.lblDomain.Location = new System.Drawing.Point(44, 110);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 1;
            this.lblDomain.Text = "Domain:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Enabled = false;
            this.lblPassword.Location = new System.Drawing.Point(44, 85);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // chkCredentials
            // 
            this.chkCredentials.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCredentials.Location = new System.Drawing.Point(12, 19);
            this.chkCredentials.Name = "chkCredentials";
            this.chkCredentials.Size = new System.Drawing.Size(351, 31);
            this.chkCredentials.TabIndex = 4;
            this.chkCredentials.Text = "Use the following credentials instead of the default Windows credentials.";
            this.chkCredentials.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCredentials.UseVisualStyleBackColor = true;
            this.chkCredentials.CheckedChanged += new System.EventHandler(this.ChkCredentials_CheckedChanged);
            // 
            // ExchangeServiceURLText
            // 
            this.ExchangeServiceURLText.Location = new System.Drawing.Point(121, 81);
            this.ExchangeServiceURLText.Name = "ExchangeServiceURLText";
            this.ExchangeServiceURLText.ReadOnly = true;
            this.ExchangeServiceURLText.Size = new System.Drawing.Size(295, 20);
            this.ExchangeServiceURLText.TabIndex = 5;
            // 
            // ExchangeServiceLabel
            // 
            this.ExchangeServiceLabel.Location = new System.Drawing.Point(47, 81);
            this.ExchangeServiceLabel.Name = "ExchangeServiceLabel";
            this.ExchangeServiceLabel.Size = new System.Drawing.Size(56, 29);
            this.ExchangeServiceLabel.TabIndex = 4;
            this.ExchangeServiceLabel.Text = "Service URL:";
            // 
            // AutodiscoverEmailText
            // 
            this.AutodiscoverEmailText.Location = new System.Drawing.Point(121, 44);
            this.AutodiscoverEmailText.Name = "AutodiscoverEmailText";
            this.AutodiscoverEmailText.Size = new System.Drawing.Size(295, 20);
            this.AutodiscoverEmailText.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(44, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Autodiscover Email:";
            // 
            // UseAutodiscoverCheck
            // 
            this.UseAutodiscoverCheck.Checked = true;
            this.UseAutodiscoverCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAutodiscoverCheck.Location = new System.Drawing.Point(12, 14);
            this.UseAutodiscoverCheck.Name = "UseAutodiscoverCheck";
            this.UseAutodiscoverCheck.Size = new System.Drawing.Size(323, 24);
            this.UseAutodiscoverCheck.TabIndex = 1;
            this.UseAutodiscoverCheck.Text = "Use Autodiscover to get the Exchange Web Services URL.";
            this.UseAutodiscoverCheck.UseVisualStyleBackColor = true;
            this.UseAutodiscoverCheck.CheckedChanged += new System.EventHandler(this.UseAutodiscoverCheck_CheckedChanged);
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(35, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "TimeZone:";
            // 
            // cmboTimeZoneIds
            // 
            this.cmboTimeZoneIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboTimeZoneIds.Enabled = false;
            this.cmboTimeZoneIds.FormattingEnabled = true;
            this.cmboTimeZoneIds.Location = new System.Drawing.Point(105, 473);
            this.cmboTimeZoneIds.Name = "cmboTimeZoneIds";
            this.cmboTimeZoneIds.Size = new System.Drawing.Size(307, 21);
            this.cmboTimeZoneIds.TabIndex = 5;
            // 
            // chkUseSpecifiedTimezone
            // 
            this.chkUseSpecifiedTimezone.Location = new System.Drawing.Point(12, 448);
            this.chkUseSpecifiedTimezone.Name = "chkUseSpecifiedTimezone";
            this.chkUseSpecifiedTimezone.Size = new System.Drawing.Size(352, 19);
            this.chkUseSpecifiedTimezone.TabIndex = 3;
            this.chkUseSpecifiedTimezone.Text = "Use specified timezone:";
            this.chkUseSpecifiedTimezone.UseVisualStyleBackColor = true;
            this.chkUseSpecifiedTimezone.CheckedChanged += new System.EventHandler(this.chkUseSpecifiedTimezone_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExchangeServiceURLText);
            this.panel1.Controls.Add(this.ExchangeServiceLabel);
            this.panel1.Controls.Add(this.UseAutodiscoverCheck);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.AutodiscoverEmailText);
            this.panel1.Controls.Add(this.TempExchangeVersionCombo);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 157);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDomain);
            this.panel2.Controls.Add(this.lblExImp);
            this.panel2.Controls.Add(this.lblPassword);
            this.panel2.Controls.Add(this.lblDomain);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Controls.Add(this.chkCredentials);
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Location = new System.Drawing.Point(11, 175);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 137);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TempConnectingIdCombo);
            this.panel3.Controls.Add(this.lblImpIdType);
            this.panel3.Controls.Add(this.ImpersonationCheck);
            this.panel3.Controls.Add(this.lblImpId);
            this.panel3.Controls.Add(this.ImpersonatedIdTextBox);
            this.panel3.Location = new System.Drawing.Point(11, 318);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(445, 111);
            this.panel3.TabIndex = 2;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Location = new System.Drawing.Point(11, 497);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(88, 23);
            this.btnOptions.TabIndex = 6;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // ServiceDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(469, 574);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkUseSpecifiedTimezone);
            this.Controls.Add(this.cmboTimeZoneIds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "ServiceDialog";
            this.Text = "EWS Editor - Exchange Service Configuration";
            this.Load += new System.EventHandler(this.ServiceDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmboTimeZoneIds;
        private System.Windows.Forms.CheckBox chkUseSpecifiedTimezone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnOptions;
    }
}