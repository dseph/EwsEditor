namespace EWSEditor.Forms.IMAP
{
    partial class ImapTest
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
            this.cmboScope = new System.Windows.Forms.ComboBox();
            this.lblScope = new System.Windows.Forms.Label();
            this.chkValidateAuthority = new System.Windows.Forms.CheckBox();
            this.cmboAuthority = new System.Windows.Forms.ComboBox();
            this.lblAuthority = new System.Windows.Forms.Label();
            this.cmboRedirectUrl = new System.Windows.Forms.ComboBox();
            this.lblOAuthRedirect = new System.Windows.Forms.Label();
            this.BtnLoadCertificate = new System.Windows.Forms.Button();
            this.txtAuthCertificatePath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCredentialsOAuthCertificate = new System.Windows.Forms.RadioButton();
            this.rdoCredentialsOAuthDelegated = new System.Windows.Forms.RadioButton();
            this.rdoCredentialsOAuthApplication = new System.Windows.Forms.RadioButton();
            this.txtOAuthClientSecret = new System.Windows.Forms.TextBox();
            this.lblOAuthClientSecret = new System.Windows.Forms.Label();
            this.txtOAuthTenantId = new System.Windows.Forms.TextBox();
            this.lblOAuthTenantId = new System.Windows.Forms.Label();
            this.txtOAuthApplicationId = new System.Windows.Forms.TextBox();
            this.lblOAuthApplicationId = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMailbox = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.txtTestResults = new System.Windows.Forms.TextBox();
            this.txtImapServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtImapPort = new System.Windows.Forms.TextBox();
            this.btnShowCS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmboScope
            // 
            this.cmboScope.BackColor = System.Drawing.SystemColors.Control;
            this.cmboScope.FormattingEnabled = true;
            this.cmboScope.Items.AddRange(new object[] {
            "https://outlook.office.com/.default",
            "https://outlook.office365.us/.default",
            "https://outlook.office365.de/.default",
            "https://outlook.office365.cn/.default",
            "https://outlook.office365.com/EWS.AccessAsUser.All",
            "https://outlook.office365.us/EWS.AccessAsUser.All",
            "https://outlook.office365.de/EWS.AccessAsUser.All",
            "https://outlook.office365.cn/EWS.AccessAsUser.All"});
            this.cmboScope.Location = new System.Drawing.Point(178, 255);
            this.cmboScope.Name = "cmboScope";
            this.cmboScope.Size = new System.Drawing.Size(686, 33);
            this.cmboScope.TabIndex = 45;
            this.cmboScope.Text = "https://outlook.office.com/IMAP.AccessAsUser.All";
            // 
            // lblScope
            // 
            this.lblScope.AutoSize = true;
            this.lblScope.Location = new System.Drawing.Point(15, 263);
            this.lblScope.Margin = new System.Windows.Forms.Padding(0);
            this.lblScope.Name = "lblScope";
            this.lblScope.Size = new System.Drawing.Size(79, 25);
            this.lblScope.TabIndex = 44;
            this.lblScope.Text = "Scope:";
            // 
            // chkValidateAuthority
            // 
            this.chkValidateAuthority.AccessibleName = "";
            this.chkValidateAuthority.AutoSize = true;
            this.chkValidateAuthority.Checked = true;
            this.chkValidateAuthority.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValidateAuthority.Location = new System.Drawing.Point(727, 224);
            this.chkValidateAuthority.Name = "chkValidateAuthority";
            this.chkValidateAuthority.Size = new System.Drawing.Size(213, 29);
            this.chkValidateAuthority.TabIndex = 38;
            this.chkValidateAuthority.Text = "Validate Authority";
            this.chkValidateAuthority.UseVisualStyleBackColor = true;
            // 
            // cmboAuthority
            // 
            this.cmboAuthority.BackColor = System.Drawing.SystemColors.Control;
            this.cmboAuthority.FormattingEnabled = true;
            this.cmboAuthority.Items.AddRange(new object[] {
            "https://login.microsoftonline.com",
            "https://login.microsoftonline.us",
            "https://login.microsoftonline.de",
            "https://login.partner.microsoftonline.cn"});
            this.cmboAuthority.Location = new System.Drawing.Point(178, 220);
            this.cmboAuthority.Name = "cmboAuthority";
            this.cmboAuthority.Size = new System.Drawing.Size(537, 33);
            this.cmboAuthority.TabIndex = 37;
            this.cmboAuthority.Text = "https://login.microsoftonline.com";
            // 
            // lblAuthority
            // 
            this.lblAuthority.AutoSize = true;
            this.lblAuthority.Location = new System.Drawing.Point(14, 223);
            this.lblAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.lblAuthority.Name = "lblAuthority";
            this.lblAuthority.Size = new System.Drawing.Size(103, 25);
            this.lblAuthority.TabIndex = 36;
            this.lblAuthority.Text = "Authority:";
            // 
            // cmboRedirectUrl
            // 
            this.cmboRedirectUrl.BackColor = System.Drawing.SystemColors.Control;
            this.cmboRedirectUrl.FormattingEnabled = true;
            this.cmboRedirectUrl.Items.AddRange(new object[] {
            "https://login.microsoftonline.com/common/oauth2/nativeclient",
            "urn:ietf:wg:oauth:2.0:oob",
            "https://127.0.0.1",
            "https://localhost",
            "<Do not use a redirect URL.>"});
            this.cmboRedirectUrl.Location = new System.Drawing.Point(177, 294);
            this.cmboRedirectUrl.Name = "cmboRedirectUrl";
            this.cmboRedirectUrl.Size = new System.Drawing.Size(773, 33);
            this.cmboRedirectUrl.TabIndex = 40;
            this.cmboRedirectUrl.Text = "http://localhost";
            // 
            // lblOAuthRedirect
            // 
            this.lblOAuthRedirect.AutoSize = true;
            this.lblOAuthRedirect.Location = new System.Drawing.Point(12, 298);
            this.lblOAuthRedirect.Margin = new System.Windows.Forms.Padding(0);
            this.lblOAuthRedirect.Name = "lblOAuthRedirect";
            this.lblOAuthRedirect.Size = new System.Drawing.Size(146, 25);
            this.lblOAuthRedirect.TabIndex = 39;
            this.lblOAuthRedirect.Text = "Redirect URL:";
            // 
            // BtnLoadCertificate
            // 
            this.BtnLoadCertificate.Location = new System.Drawing.Point(814, 333);
            this.BtnLoadCertificate.Margin = new System.Windows.Forms.Padding(6);
            this.BtnLoadCertificate.Name = "BtnLoadCertificate";
            this.BtnLoadCertificate.Size = new System.Drawing.Size(64, 31);
            this.BtnLoadCertificate.TabIndex = 43;
            this.BtnLoadCertificate.Text = ". . .";
            this.BtnLoadCertificate.UseVisualStyleBackColor = true;
            this.BtnLoadCertificate.Click += new System.EventHandler(this.BtnLoadCertificate_Click);
            // 
            // txtAuthCertificatePath
            // 
            this.txtAuthCertificatePath.Location = new System.Drawing.Point(175, 336);
            this.txtAuthCertificatePath.Margin = new System.Windows.Forms.Padding(0);
            this.txtAuthCertificatePath.Name = "txtAuthCertificatePath";
            this.txtAuthCertificatePath.PasswordChar = '*';
            this.txtAuthCertificatePath.Size = new System.Drawing.Size(608, 31);
            this.txtAuthCertificatePath.TabIndex = 42;
            this.txtAuthCertificatePath.TextChanged += new System.EventHandler(this.txtAuthCertificatePath_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 336);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 25);
            this.label10.TabIndex = 41;
            this.label10.Text = "Certificate:";
            this.label10.Visible = false;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCredentialsOAuthCertificate);
            this.groupBox1.Controls.Add(this.rdoCredentialsOAuthDelegated);
            this.groupBox1.Controls.Add(this.rdoCredentialsOAuthApplication);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(768, 75);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Authentication Flow";
            // 
            // rdoCredentialsOAuthCertificate
            // 
            this.rdoCredentialsOAuthCertificate.AutoSize = true;
            this.rdoCredentialsOAuthCertificate.Location = new System.Drawing.Point(556, 33);
            this.rdoCredentialsOAuthCertificate.Margin = new System.Windows.Forms.Padding(6);
            this.rdoCredentialsOAuthCertificate.Name = "rdoCredentialsOAuthCertificate";
            this.rdoCredentialsOAuthCertificate.Size = new System.Drawing.Size(140, 29);
            this.rdoCredentialsOAuthCertificate.TabIndex = 2;
            this.rdoCredentialsOAuthCertificate.Tag = " ";
            this.rdoCredentialsOAuthCertificate.Text = "Certificate";
            this.rdoCredentialsOAuthCertificate.UseVisualStyleBackColor = true;
            this.rdoCredentialsOAuthCertificate.CheckedChanged += new System.EventHandler(this.rdoCredentialsOAuthCertificate_CheckedChanged);
            // 
            // rdoCredentialsOAuthDelegated
            // 
            this.rdoCredentialsOAuthDelegated.AutoSize = true;
            this.rdoCredentialsOAuthDelegated.Checked = true;
            this.rdoCredentialsOAuthDelegated.Location = new System.Drawing.Point(4, 33);
            this.rdoCredentialsOAuthDelegated.Margin = new System.Windows.Forms.Padding(6);
            this.rdoCredentialsOAuthDelegated.Name = "rdoCredentialsOAuthDelegated";
            this.rdoCredentialsOAuthDelegated.Size = new System.Drawing.Size(141, 29);
            this.rdoCredentialsOAuthDelegated.TabIndex = 0;
            this.rdoCredentialsOAuthDelegated.TabStop = true;
            this.rdoCredentialsOAuthDelegated.Text = "Delegated";
            this.rdoCredentialsOAuthDelegated.UseVisualStyleBackColor = true;
            this.rdoCredentialsOAuthDelegated.CheckedChanged += new System.EventHandler(this.rdoCredentialsOAuthDelegated_CheckedChanged);
            // 
            // rdoCredentialsOAuthApplication
            // 
            this.rdoCredentialsOAuthApplication.AutoSize = true;
            this.rdoCredentialsOAuthApplication.Location = new System.Drawing.Point(276, 33);
            this.rdoCredentialsOAuthApplication.Margin = new System.Windows.Forms.Padding(6);
            this.rdoCredentialsOAuthApplication.Name = "rdoCredentialsOAuthApplication";
            this.rdoCredentialsOAuthApplication.Size = new System.Drawing.Size(149, 29);
            this.rdoCredentialsOAuthApplication.TabIndex = 1;
            this.rdoCredentialsOAuthApplication.Tag = " ";
            this.rdoCredentialsOAuthApplication.Text = "Application";
            this.rdoCredentialsOAuthApplication.UseVisualStyleBackColor = true;
            this.rdoCredentialsOAuthApplication.CheckedChanged += new System.EventHandler(this.rdoCredentialsOAuthApplication_CheckedChanged);
            // 
            // txtOAuthClientSecret
            // 
            this.txtOAuthClientSecret.Location = new System.Drawing.Point(177, 167);
            this.txtOAuthClientSecret.Margin = new System.Windows.Forms.Padding(0);
            this.txtOAuthClientSecret.Name = "txtOAuthClientSecret";
            this.txtOAuthClientSecret.PasswordChar = '*';
            this.txtOAuthClientSecret.Size = new System.Drawing.Size(688, 31);
            this.txtOAuthClientSecret.TabIndex = 35;
            // 
            // lblOAuthClientSecret
            // 
            this.lblOAuthClientSecret.AutoSize = true;
            this.lblOAuthClientSecret.Location = new System.Drawing.Point(15, 174);
            this.lblOAuthClientSecret.Margin = new System.Windows.Forms.Padding(0);
            this.lblOAuthClientSecret.Name = "lblOAuthClientSecret";
            this.lblOAuthClientSecret.Size = new System.Drawing.Size(141, 25);
            this.lblOAuthClientSecret.TabIndex = 34;
            this.lblOAuthClientSecret.Text = "Client Secret:";
            // 
            // txtOAuthTenantId
            // 
            this.txtOAuthTenantId.Location = new System.Drawing.Point(177, 136);
            this.txtOAuthTenantId.Margin = new System.Windows.Forms.Padding(0);
            this.txtOAuthTenantId.Name = "txtOAuthTenantId";
            this.txtOAuthTenantId.Size = new System.Drawing.Size(688, 31);
            this.txtOAuthTenantId.TabIndex = 33;
            // 
            // lblOAuthTenantId
            // 
            this.lblOAuthTenantId.AutoSize = true;
            this.lblOAuthTenantId.Location = new System.Drawing.Point(15, 142);
            this.lblOAuthTenantId.Margin = new System.Windows.Forms.Padding(0);
            this.lblOAuthTenantId.Name = "lblOAuthTenantId";
            this.lblOAuthTenantId.Size = new System.Drawing.Size(111, 25);
            this.lblOAuthTenantId.TabIndex = 32;
            this.lblOAuthTenantId.Text = "Tenant ID:";
            // 
            // txtOAuthApplicationId
            // 
            this.txtOAuthApplicationId.Location = new System.Drawing.Point(177, 101);
            this.txtOAuthApplicationId.Margin = new System.Windows.Forms.Padding(0);
            this.txtOAuthApplicationId.Name = "txtOAuthApplicationId";
            this.txtOAuthApplicationId.Size = new System.Drawing.Size(688, 31);
            this.txtOAuthApplicationId.TabIndex = 31;
            // 
            // lblOAuthApplicationId
            // 
            this.lblOAuthApplicationId.AutoSize = true;
            this.lblOAuthApplicationId.Location = new System.Drawing.Point(15, 103);
            this.lblOAuthApplicationId.Margin = new System.Windows.Forms.Padding(0);
            this.lblOAuthApplicationId.Name = "lblOAuthApplicationId";
            this.lblOAuthApplicationId.Size = new System.Drawing.Size(143, 25);
            this.lblOAuthApplicationId.TabIndex = 30;
            this.lblOAuthApplicationId.Text = "Client App ID:";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(19, 476);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(124, 46);
            this.btnTest.TabIndex = 46;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 436);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Mailbox:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMailbox
            // 
            this.txtMailbox.Location = new System.Drawing.Point(166, 430);
            this.txtMailbox.Margin = new System.Windows.Forms.Padding(0);
            this.txtMailbox.Name = "txtMailbox";
            this.txtMailbox.Size = new System.Drawing.Size(688, 31);
            this.txtMailbox.TabIndex = 48;
            // 
            // txtToken
            // 
            this.txtToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToken.Location = new System.Drawing.Point(16, 560);
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtToken.Size = new System.Drawing.Size(1033, 147);
            this.txtToken.TabIndex = 50;
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // txtTestResults
            // 
            this.txtTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestResults.Location = new System.Drawing.Point(16, 755);
            this.txtTestResults.Multiline = true;
            this.txtTestResults.Name = "txtTestResults";
            this.txtTestResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTestResults.Size = new System.Drawing.Size(1033, 205);
            this.txtTestResults.TabIndex = 51;
            // 
            // txtImapServer
            // 
            this.txtImapServer.Location = new System.Drawing.Point(167, 390);
            this.txtImapServer.Margin = new System.Windows.Forms.Padding(0);
            this.txtImapServer.Name = "txtImapServer";
            this.txtImapServer.Size = new System.Drawing.Size(384, 31);
            this.txtImapServer.TabIndex = 53;
            this.txtImapServer.Text = "outlook.office365.com";
            this.txtImapServer.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(11, 396);
            this.lblServer.Margin = new System.Windows.Forms.Padding(0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(81, 25);
            this.lblServer.TabIndex = 52;
            this.lblServer.Text = "Server:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(594, 396);
            this.lblPort.Margin = new System.Windows.Forms.Padding(0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(57, 25);
            this.lblPort.TabIndex = 54;
            this.lblPort.Text = "Port:";
            // 
            // txtImapPort
            // 
            this.txtImapPort.Location = new System.Drawing.Point(689, 390);
            this.txtImapPort.Margin = new System.Windows.Forms.Padding(0);
            this.txtImapPort.Name = "txtImapPort";
            this.txtImapPort.Size = new System.Drawing.Size(165, 31);
            this.txtImapPort.TabIndex = 55;
            this.txtImapPort.Text = "993";
            this.txtImapPort.TextChanged += new System.EventHandler(this.txtImapPort_TextChanged);
            // 
            // btnShowCS
            // 
            this.btnShowCS.Location = new System.Drawing.Point(886, 167);
            this.btnShowCS.Margin = new System.Windows.Forms.Padding(6);
            this.btnShowCS.Name = "btnShowCS";
            this.btnShowCS.Size = new System.Drawing.Size(97, 32);
            this.btnShowCS.TabIndex = 56;
            this.btnShowCS.Text = "Show";
            this.btnShowCS.UseVisualStyleBackColor = true;
            this.btnShowCS.Click += new System.EventHandler(this.btnShowCS_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(14, 727);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "Results:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(12, 532);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 59;
            this.label2.Text = "Token:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ImapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 988);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowCS);
            this.Controls.Add(this.txtImapPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtImapServer);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtTestResults);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.txtMailbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.cmboScope);
            this.Controls.Add(this.lblScope);
            this.Controls.Add(this.chkValidateAuthority);
            this.Controls.Add(this.cmboAuthority);
            this.Controls.Add(this.lblAuthority);
            this.Controls.Add(this.cmboRedirectUrl);
            this.Controls.Add(this.lblOAuthRedirect);
            this.Controls.Add(this.BtnLoadCertificate);
            this.Controls.Add(this.txtAuthCertificatePath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtOAuthClientSecret);
            this.Controls.Add(this.lblOAuthClientSecret);
            this.Controls.Add(this.txtOAuthTenantId);
            this.Controls.Add(this.lblOAuthTenantId);
            this.Controls.Add(this.txtOAuthApplicationId);
            this.Controls.Add(this.lblOAuthApplicationId);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImapTest";
            this.Text = "IMAP Test";
            this.Load += new System.EventHandler(this.ImapTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmboScope;
        private System.Windows.Forms.Label lblScope;
        private System.Windows.Forms.CheckBox chkValidateAuthority;
        private System.Windows.Forms.ComboBox cmboAuthority;
        private System.Windows.Forms.Label lblAuthority;
        private System.Windows.Forms.ComboBox cmboRedirectUrl;
        private System.Windows.Forms.Label lblOAuthRedirect;
        private System.Windows.Forms.Button BtnLoadCertificate;
        private System.Windows.Forms.TextBox txtAuthCertificatePath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCredentialsOAuthCertificate;
        private System.Windows.Forms.RadioButton rdoCredentialsOAuthDelegated;
        private System.Windows.Forms.RadioButton rdoCredentialsOAuthApplication;
        private System.Windows.Forms.TextBox txtOAuthClientSecret;
        private System.Windows.Forms.Label lblOAuthClientSecret;
        private System.Windows.Forms.TextBox txtOAuthTenantId;
        private System.Windows.Forms.Label lblOAuthTenantId;
        private System.Windows.Forms.TextBox txtOAuthApplicationId;
        private System.Windows.Forms.Label lblOAuthApplicationId;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailbox;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.TextBox txtTestResults;
        private System.Windows.Forms.TextBox txtImapServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtImapPort;
        private System.Windows.Forms.Button btnShowCS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}