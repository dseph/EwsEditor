namespace EWSEditor.Forms
{
    partial class SystemNetMainForm
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
            this.grpSmtpSettings = new System.Windows.Forms.GroupBox();
            this.txtPickupFolder = new System.Windows.Forms.TextBox();
            this.chkSpecifyPickupFolder = new System.Windows.Forms.CheckBox();
            this.rdoSendByPickupFolder = new System.Windows.Forms.RadioButton();
            this.chkSendByPort = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEnableSSL = new System.Windows.Forms.CheckBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.grpUserCreds = new System.Windows.Forms.GroupBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserSmtp = new System.Windows.Forms.Label();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpMailMessage = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtfMessageBody = new System.Windows.Forms.RichTextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.chkIsHtml = new System.Windows.Forms.CheckBox();
            this.txtBcc = new System.Windows.Forms.TextBox();
            this.txtCc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoLowPri = new System.Windows.Forms.RadioButton();
            this.rdoHighPri = new System.Windows.Forms.RadioButton();
            this.rdoNormalPri = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteHeader = new System.Windows.Forms.Button();
            this.btnAddHeaders = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkListAttachments = new System.Windows.Forms.CheckedListBox();
            this.btnInsertAttachment = new System.Windows.Forms.Button();
            this.btnDeleteAttachment = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxErrorLog = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTimedSendEnd = new System.Windows.Forms.Button();
            this.btnTimedSendStart = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownResendSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.chkMinimalLogging = new System.Windows.Forms.CheckBox();
            this.grpSmtpSettings.SuspendLayout();
            this.grpUserCreds.SuspendLayout();
            this.grpMailMessage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResendSeconds)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSmtpSettings
            // 
            this.grpSmtpSettings.Controls.Add(this.txtPickupFolder);
            this.grpSmtpSettings.Controls.Add(this.chkSpecifyPickupFolder);
            this.grpSmtpSettings.Controls.Add(this.rdoSendByPickupFolder);
            this.grpSmtpSettings.Controls.Add(this.chkSendByPort);
            this.grpSmtpSettings.Controls.Add(this.label2);
            this.grpSmtpSettings.Controls.Add(this.chkEnableSSL);
            this.grpSmtpSettings.Controls.Add(this.cboPort);
            this.grpSmtpSettings.Controls.Add(this.grpUserCreds);
            this.grpSmtpSettings.Controls.Add(this.cboServer);
            this.grpSmtpSettings.Controls.Add(this.label1);
            this.grpSmtpSettings.Location = new System.Drawing.Point(2, 2);
            this.grpSmtpSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSmtpSettings.Name = "grpSmtpSettings";
            this.grpSmtpSettings.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpSmtpSettings.Size = new System.Drawing.Size(511, 149);
            this.grpSmtpSettings.TabIndex = 7;
            this.grpSmtpSettings.TabStop = false;
            this.grpSmtpSettings.Text = "SMTP Settings";
            this.grpSmtpSettings.Enter += new System.EventHandler(this.grpSmtpSettings_Enter);
            // 
            // txtPickupFolder
            // 
            this.txtPickupFolder.Location = new System.Drawing.Point(157, 122);
            this.txtPickupFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPickupFolder.Name = "txtPickupFolder";
            this.txtPickupFolder.Size = new System.Drawing.Size(350, 20);
            this.txtPickupFolder.TabIndex = 19;
            // 
            // chkSpecifyPickupFolder
            // 
            this.chkSpecifyPickupFolder.AutoSize = true;
            this.chkSpecifyPickupFolder.Location = new System.Drawing.Point(24, 126);
            this.chkSpecifyPickupFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkSpecifyPickupFolder.Name = "chkSpecifyPickupFolder";
            this.chkSpecifyPickupFolder.Size = new System.Drawing.Size(132, 17);
            this.chkSpecifyPickupFolder.TabIndex = 21;
            this.chkSpecifyPickupFolder.Text = "Specify Pickup Folder:";
            this.chkSpecifyPickupFolder.UseVisualStyleBackColor = true;
            this.chkSpecifyPickupFolder.CheckedChanged += new System.EventHandler(this.chkSpecifyPickupFolder_CheckedChanged);
            // 
            // rdoSendByPickupFolder
            // 
            this.rdoSendByPickupFolder.AutoSize = true;
            this.rdoSendByPickupFolder.Location = new System.Drawing.Point(9, 105);
            this.rdoSendByPickupFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoSendByPickupFolder.Name = "rdoSendByPickupFolder";
            this.rdoSendByPickupFolder.Size = new System.Drawing.Size(128, 17);
            this.rdoSendByPickupFolder.TabIndex = 20;
            this.rdoSendByPickupFolder.Text = "Send by pickup folder";
            this.rdoSendByPickupFolder.UseVisualStyleBackColor = true;
            this.rdoSendByPickupFolder.CheckedChanged += new System.EventHandler(this.rdoSendByPickupFolder_CheckedChanged);
            // 
            // chkSendByPort
            // 
            this.chkSendByPort.AutoSize = true;
            this.chkSendByPort.Checked = true;
            this.chkSendByPort.Location = new System.Drawing.Point(7, 15);
            this.chkSendByPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkSendByPort.Name = "chkSendByPort";
            this.chkSendByPort.Size = new System.Drawing.Size(84, 17);
            this.chkSendByPort.TabIndex = 19;
            this.chkSendByPort.TabStop = true;
            this.chkSendByPort.Text = "SendByPort:";
            this.chkSendByPort.UseVisualStyleBackColor = true;
            this.chkSendByPort.CheckedChanged += new System.EventHandler(this.chkSendByPort_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Checked = true;
            this.chkEnableSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableSSL.Location = new System.Drawing.Point(152, 62);
            this.chkEnableSSL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(82, 17);
            this.chkEnableSSL.TabIndex = 3;
            this.chkEnableSSL.Text = "Enable SSL";
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Items.AddRange(new object[] {
            "25",
            "465",
            "587"});
            this.cboPort.Location = new System.Drawing.Point(66, 59);
            this.cboPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(56, 21);
            this.cboPort.TabIndex = 4;
            this.cboPort.Text = "587";
            // 
            // grpUserCreds
            // 
            this.grpUserCreds.Controls.Add(this.txtDomain);
            this.grpUserCreds.Controls.Add(this.label8);
            this.grpUserCreds.Controls.Add(this.txtUser);
            this.grpUserCreds.Controls.Add(this.txtPassword);
            this.grpUserCreds.Controls.Add(this.lblPassword);
            this.grpUserCreds.Controls.Add(this.lblUserSmtp);
            this.grpUserCreds.Location = new System.Drawing.Point(247, 15);
            this.grpUserCreds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpUserCreds.Name = "grpUserCreds";
            this.grpUserCreds.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpUserCreds.Size = new System.Drawing.Size(260, 86);
            this.grpUserCreds.TabIndex = 5;
            this.grpUserCreds.TabStop = false;
            this.grpUserCreds.Text = "User Credentials";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(78, 62);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(178, 20);
            this.txtDomain.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Domain:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(78, 13);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(78, 40);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(18, 40);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserSmtp
            // 
            this.lblUserSmtp.AutoSize = true;
            this.lblUserSmtp.Location = new System.Drawing.Point(18, 15);
            this.lblUserSmtp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserSmtp.Name = "lblUserSmtp";
            this.lblUserSmtp.Size = new System.Drawing.Size(32, 13);
            this.lblUserSmtp.TabIndex = 0;
            this.lblUserSmtp.Text = "User:";
            // 
            // cboServer
            // 
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Items.AddRange(new object[] {
            "smtp.live.com",
            "smtp.gmail.com",
            "smtp.mail.yahoo.com"});
            this.cboServer.Location = new System.Drawing.Point(66, 37);
            this.cboServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(177, 21);
            this.cboServer.TabIndex = 3;
            this.cboServer.Text = "smtp.live.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // grpMailMessage
            // 
            this.grpMailMessage.Controls.Add(this.txtFrom);
            this.grpMailMessage.Controls.Add(this.label11);
            this.grpMailMessage.Controls.Add(this.label7);
            this.grpMailMessage.Controls.Add(this.rtfMessageBody);
            this.grpMailMessage.Controls.Add(this.txtSubject);
            this.grpMailMessage.Controls.Add(this.chkIsHtml);
            this.grpMailMessage.Controls.Add(this.txtBcc);
            this.grpMailMessage.Controls.Add(this.txtCc);
            this.grpMailMessage.Controls.Add(this.label6);
            this.grpMailMessage.Controls.Add(this.label5);
            this.grpMailMessage.Controls.Add(this.label4);
            this.grpMailMessage.Controls.Add(this.txtTo);
            this.grpMailMessage.Controls.Add(this.label3);
            this.grpMailMessage.Location = new System.Drawing.Point(2, 230);
            this.grpMailMessage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMailMessage.Name = "grpMailMessage";
            this.grpMailMessage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMailMessage.Size = new System.Drawing.Size(506, 349);
            this.grpMailMessage.TabIndex = 6;
            this.grpMailMessage.TabStop = false;
            this.grpMailMessage.Text = "Mail Message";
            this.grpMailMessage.Enter += new System.EventHandler(this.grpMailMessage_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, -10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "To:";
            // 
            // rtfMessageBody
            // 
            this.rtfMessageBody.Location = new System.Drawing.Point(8, 135);
            this.rtfMessageBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtfMessageBody.MaxLength = 0;
            this.rtfMessageBody.Name = "rtfMessageBody";
            this.rtfMessageBody.Size = new System.Drawing.Size(498, 179);
            this.rtfMessageBody.TabIndex = 9;
            this.rtfMessageBody.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(66, 111);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(424, 20);
            this.txtSubject.TabIndex = 8;
            // 
            // chkIsHtml
            // 
            this.chkIsHtml.AutoSize = true;
            this.chkIsHtml.Location = new System.Drawing.Point(7, 332);
            this.chkIsHtml.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkIsHtml.Name = "chkIsHtml";
            this.chkIsHtml.Size = new System.Drawing.Size(93, 17);
            this.chkIsHtml.TabIndex = 15;
            this.chkIsHtml.Text = "Body is HTML";
            this.chkIsHtml.UseVisualStyleBackColor = true;
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(66, 89);
            this.txtBcc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(397, 20);
            this.txtBcc.TabIndex = 7;
            // 
            // txtCc
            // 
            this.txtCc.Location = new System.Drawing.Point(66, 68);
            this.txtCc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(397, 20);
            this.txtCc.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Subject:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Bcc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 71);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Cc:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(66, 47);
            this.txtTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(397, 20);
            this.txtTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "To:";
            // 
            // rdoLowPri
            // 
            this.rdoLowPri.AutoSize = true;
            this.rdoLowPri.Location = new System.Drawing.Point(156, 17);
            this.rdoLowPri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoLowPri.Name = "rdoLowPri";
            this.rdoLowPri.Size = new System.Drawing.Size(45, 17);
            this.rdoLowPri.TabIndex = 2;
            this.rdoLowPri.Text = "Low";
            this.rdoLowPri.UseVisualStyleBackColor = true;
            // 
            // rdoHighPri
            // 
            this.rdoHighPri.AutoSize = true;
            this.rdoHighPri.Location = new System.Drawing.Point(107, 17);
            this.rdoHighPri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoHighPri.Name = "rdoHighPri";
            this.rdoHighPri.Size = new System.Drawing.Size(47, 17);
            this.rdoHighPri.TabIndex = 1;
            this.rdoHighPri.Text = "High";
            this.rdoHighPri.UseVisualStyleBackColor = true;
            // 
            // rdoNormalPri
            // 
            this.rdoNormalPri.AutoSize = true;
            this.rdoNormalPri.Checked = true;
            this.rdoNormalPri.Location = new System.Drawing.Point(50, 17);
            this.rdoNormalPri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoNormalPri.Name = "rdoNormalPri";
            this.rdoNormalPri.Size = new System.Drawing.Size(58, 17);
            this.rdoNormalPri.TabIndex = 0;
            this.rdoNormalPri.TabStop = true;
            this.rdoNormalPri.Text = "Normal";
            this.rdoNormalPri.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnDeleteHeader);
            this.groupBox2.Controls.Add(this.btnAddHeaders);
            this.groupBox2.Location = new System.Drawing.Point(517, 196);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(472, 124);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Headers - (select row to use delete button)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colValue});
            this.dataGridView1.Location = new System.Drawing.Point(5, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(424, 106);
            this.dataGridView1.TabIndex = 20;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 60;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 59;
            // 
            // btnDeleteHeader
            // 
            this.btnDeleteHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHeader.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteHeader.Location = new System.Drawing.Point(433, 51);
            this.btnDeleteHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteHeader.Name = "btnDeleteHeader";
            this.btnDeleteHeader.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteHeader.TabIndex = 19;
            this.btnDeleteHeader.UseVisualStyleBackColor = true;
            this.btnDeleteHeader.Click += new System.EventHandler(this.btnDeleteHeader_Click);
            // 
            // btnAddHeaders
            // 
            this.btnAddHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHeaders.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnAddHeaders.Location = new System.Drawing.Point(434, 15);
            this.btnAddHeaders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddHeaders.Name = "btnAddHeaders";
            this.btnAddHeaders.Size = new System.Drawing.Size(32, 32);
            this.btnAddHeaders.TabIndex = 14;
            this.btnAddHeaders.UseVisualStyleBackColor = true;
            this.btnAddHeaders.Click += new System.EventHandler(this.btnAddHeaders_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkListAttachments);
            this.groupBox3.Controls.Add(this.btnInsertAttachment);
            this.groupBox3.Controls.Add(this.btnDeleteAttachment);
            this.groupBox3.Location = new System.Drawing.Point(518, 324);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(472, 151);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message Attachments - (check item to use delete button)";
            // 
            // chkListAttachments
            // 
            this.chkListAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkListAttachments.CausesValidation = false;
            this.chkListAttachments.CheckOnClick = true;
            this.chkListAttachments.FormattingEnabled = true;
            this.chkListAttachments.Location = new System.Drawing.Point(5, 15);
            this.chkListAttachments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkListAttachments.Name = "chkListAttachments";
            this.chkListAttachments.Size = new System.Drawing.Size(425, 124);
            this.chkListAttachments.TabIndex = 1;
            // 
            // btnInsertAttachment
            // 
            this.btnInsertAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertAttachment.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnInsertAttachment.Location = new System.Drawing.Point(434, 15);
            this.btnInsertAttachment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInsertAttachment.Name = "btnInsertAttachment";
            this.btnInsertAttachment.Size = new System.Drawing.Size(32, 32);
            this.btnInsertAttachment.TabIndex = 12;
            this.btnInsertAttachment.UseVisualStyleBackColor = true;
            this.btnInsertAttachment.Click += new System.EventHandler(this.btnInsertAttachment_Click);
            // 
            // btnDeleteAttachment
            // 
            this.btnDeleteAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAttachment.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteAttachment.Location = new System.Drawing.Point(434, 51);
            this.btnDeleteAttachment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteAttachment.TabIndex = 2;
            this.btnDeleteAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMinimalLogging);
            this.groupBox1.Controls.Add(this.txtBoxErrorLog);
            this.groupBox1.Location = new System.Drawing.Point(518, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(472, 190);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Error Log";
            // 
            // txtBoxErrorLog
            // 
            this.txtBoxErrorLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxErrorLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtBoxErrorLog.Location = new System.Drawing.Point(5, 39);
            this.txtBoxErrorLog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxErrorLog.Multiline = true;
            this.txtBoxErrorLog.Name = "txtBoxErrorLog";
            this.txtBoxErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxErrorLog.Size = new System.Drawing.Size(463, 142);
            this.txtBoxErrorLog.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTimedSendEnd);
            this.groupBox4.Controls.Add(this.btnTimedSendStart);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numericUpDownResendSeconds);
            this.groupBox4.Location = new System.Drawing.Point(763, 479);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(227, 72);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sending Loop";
            // 
            // btnTimedSendEnd
            // 
            this.btnTimedSendEnd.Location = new System.Drawing.Point(147, 46);
            this.btnTimedSendEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimedSendEnd.Name = "btnTimedSendEnd";
            this.btnTimedSendEnd.Size = new System.Drawing.Size(68, 22);
            this.btnTimedSendEnd.TabIndex = 20;
            this.btnTimedSendEnd.Text = "Stop";
            this.btnTimedSendEnd.UseVisualStyleBackColor = true;
            this.btnTimedSendEnd.Click += new System.EventHandler(this.btnTimedSendEnd_Click);
            // 
            // btnTimedSendStart
            // 
            this.btnTimedSendStart.Location = new System.Drawing.Point(58, 46);
            this.btnTimedSendStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimedSendStart.Name = "btnTimedSendStart";
            this.btnTimedSendStart.Size = new System.Drawing.Size(61, 19);
            this.btnTimedSendStart.TabIndex = 19;
            this.btnTimedSendStart.Text = "Start";
            this.btnTimedSendStart.UseVisualStyleBackColor = true;
            this.btnTimedSendStart.Click += new System.EventHandler(this.btnTimedSendStart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Wait seconds between sends:";
            // 
            // numericUpDownResendSeconds
            // 
            this.numericUpDownResendSeconds.Location = new System.Drawing.Point(161, 22);
            this.numericUpDownResendSeconds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDownResendSeconds.Name = "numericUpDownResendSeconds";
            this.numericUpDownResendSeconds.Size = new System.Drawing.Size(62, 20);
            this.numericUpDownResendSeconds.TabIndex = 21;
            this.numericUpDownResendSeconds.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(924, 562);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(66, 19);
            this.btnSendEmail.TabIndex = 27;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select attachment to insert";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Priority:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoLowPri);
            this.groupBox5.Controls.Add(this.rdoHighPri);
            this.groupBox5.Controls.Add(this.rdoNormalPri);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(2, 156);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(511, 70);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "From:";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(66, 23);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(397, 20);
            this.txtFrom.TabIndex = 21;
            // 
            // chkMinimalLogging
            // 
            this.chkMinimalLogging.AutoSize = true;
            this.chkMinimalLogging.Location = new System.Drawing.Point(5, 17);
            this.chkMinimalLogging.Margin = new System.Windows.Forms.Padding(2);
            this.chkMinimalLogging.Name = "chkMinimalLogging";
            this.chkMinimalLogging.Size = new System.Drawing.Size(102, 17);
            this.chkMinimalLogging.TabIndex = 22;
            this.chkMinimalLogging.Text = "Minimal Logging";
            this.chkMinimalLogging.UseVisualStyleBackColor = true;
            // 
            // SystemNetMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 590);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSmtpSettings);
            this.Controls.Add(this.grpMailMessage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SystemNetMainForm";
            this.Text = "System.Net.Main - Sends email by  SMTP port or pickup folder";
            this.Load += new System.EventHandler(this.SystemNetMainForm_Load);
            this.grpSmtpSettings.ResumeLayout(false);
            this.grpSmtpSettings.PerformLayout();
            this.grpUserCreds.ResumeLayout(false);
            this.grpUserCreds.PerformLayout();
            this.grpMailMessage.ResumeLayout(false);
            this.grpMailMessage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResendSeconds)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSmtpSettings;
        private System.Windows.Forms.TextBox txtPickupFolder;
        private System.Windows.Forms.CheckBox chkSpecifyPickupFolder;
        private System.Windows.Forms.RadioButton rdoSendByPickupFolder;
        private System.Windows.Forms.RadioButton chkSendByPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEnableSSL;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpMailMessage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtfMessageBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RadioButton rdoLowPri;
        private System.Windows.Forms.RadioButton rdoHighPri;
        private System.Windows.Forms.RadioButton rdoNormalPri;
        private System.Windows.Forms.CheckBox chkIsHtml;
        private System.Windows.Forms.TextBox txtBcc;
        private System.Windows.Forms.TextBox txtCc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpUserCreds;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserSmtp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.Button btnDeleteHeader;
        private System.Windows.Forms.Button btnAddHeaders;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chkListAttachments;
        private System.Windows.Forms.Button btnInsertAttachment;
        private System.Windows.Forms.Button btnDeleteAttachment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBoxErrorLog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTimedSendEnd;
        private System.Windows.Forms.Button btnTimedSendStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownResendSeconds;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkMinimalLogging;
    }
}