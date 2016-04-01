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
            this.label12 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.chkMinimalLogging = new System.Windows.Forms.CheckBox();
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
            this.grpSmtpSettings.Location = new System.Drawing.Point(3, 2);
            this.grpSmtpSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpSmtpSettings.Name = "grpSmtpSettings";
            this.grpSmtpSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpSmtpSettings.Size = new System.Drawing.Size(681, 183);
            this.grpSmtpSettings.TabIndex = 0;
            this.grpSmtpSettings.TabStop = false;
            this.grpSmtpSettings.Text = "SMTP Settings";
            this.grpSmtpSettings.Enter += new System.EventHandler(this.grpSmtpSettings_Enter);
            // 
            // txtPickupFolder
            // 
            this.txtPickupFolder.Location = new System.Drawing.Point(209, 150);
            this.txtPickupFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPickupFolder.Name = "txtPickupFolder";
            this.txtPickupFolder.Size = new System.Drawing.Size(465, 22);
            this.txtPickupFolder.TabIndex = 8;
            // 
            // chkSpecifyPickupFolder
            // 
            this.chkSpecifyPickupFolder.AutoSize = true;
            this.chkSpecifyPickupFolder.Location = new System.Drawing.Point(32, 155);
            this.chkSpecifyPickupFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSpecifyPickupFolder.Name = "chkSpecifyPickupFolder";
            this.chkSpecifyPickupFolder.Size = new System.Drawing.Size(170, 21);
            this.chkSpecifyPickupFolder.TabIndex = 7;
            this.chkSpecifyPickupFolder.Text = "Specify Pickup Folder:";
            this.chkSpecifyPickupFolder.UseVisualStyleBackColor = true;
            this.chkSpecifyPickupFolder.CheckedChanged += new System.EventHandler(this.chkSpecifyPickupFolder_CheckedChanged);
            // 
            // rdoSendByPickupFolder
            // 
            this.rdoSendByPickupFolder.AutoSize = true;
            this.rdoSendByPickupFolder.Location = new System.Drawing.Point(12, 129);
            this.rdoSendByPickupFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoSendByPickupFolder.Name = "rdoSendByPickupFolder";
            this.rdoSendByPickupFolder.Size = new System.Drawing.Size(166, 21);
            this.rdoSendByPickupFolder.TabIndex = 6;
            this.rdoSendByPickupFolder.Text = "Send by pickup folder";
            this.rdoSendByPickupFolder.UseVisualStyleBackColor = true;
            this.rdoSendByPickupFolder.CheckedChanged += new System.EventHandler(this.rdoSendByPickupFolder_CheckedChanged);
            // 
            // chkSendByPort
            // 
            this.chkSendByPort.AutoSize = true;
            this.chkSendByPort.Checked = true;
            this.chkSendByPort.Location = new System.Drawing.Point(9, 18);
            this.chkSendByPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSendByPort.Name = "chkSendByPort";
            this.chkSendByPort.Size = new System.Drawing.Size(108, 21);
            this.chkSendByPort.TabIndex = 0;
            this.chkSendByPort.TabStop = true;
            this.chkSendByPort.Text = "SendByPort:";
            this.chkSendByPort.UseVisualStyleBackColor = true;
            this.chkSendByPort.CheckedChanged += new System.EventHandler(this.chkSendByPort_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // chkEnableSSL
            // 
            this.chkEnableSSL.AutoSize = true;
            this.chkEnableSSL.Checked = true;
            this.chkEnableSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableSSL.Location = new System.Drawing.Point(203, 76);
            this.chkEnableSSL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkEnableSSL.Name = "chkEnableSSL";
            this.chkEnableSSL.Size = new System.Drawing.Size(104, 21);
            this.chkEnableSSL.TabIndex = 5;
            this.chkEnableSSL.Text = "Enable SSL";
            this.chkEnableSSL.UseVisualStyleBackColor = true;
            this.chkEnableSSL.CheckedChanged += new System.EventHandler(this.chkEnableSSL_CheckedChanged);
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Items.AddRange(new object[] {
            "25",
            "465",
            "587"});
            this.cboPort.Location = new System.Drawing.Point(88, 73);
            this.cboPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(73, 24);
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
            this.grpUserCreds.Location = new System.Drawing.Point(329, 18);
            this.grpUserCreds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUserCreds.Name = "grpUserCreds";
            this.grpUserCreds.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUserCreds.Size = new System.Drawing.Size(347, 106);
            this.grpUserCreds.TabIndex = 9;
            this.grpUserCreds.TabStop = false;
            this.grpUserCreds.Text = "User Credentials";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(104, 76);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(236, 22);
            this.txtDomain.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Domain:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(104, 16);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(236, 22);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(104, 49);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(236, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(24, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserSmtp
            // 
            this.lblUserSmtp.AutoSize = true;
            this.lblUserSmtp.Location = new System.Drawing.Point(24, 18);
            this.lblUserSmtp.Name = "lblUserSmtp";
            this.lblUserSmtp.Size = new System.Drawing.Size(42, 17);
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
            this.cboServer.Location = new System.Drawing.Point(88, 46);
            this.cboServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(235, 24);
            this.cboServer.TabIndex = 3;
            this.cboServer.Text = "smtp.live.com";
            this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server:";
            // 
            // grpMailMessage
            // 
            this.grpMailMessage.Controls.Add(this.label12);
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
            this.grpMailMessage.Location = new System.Drawing.Point(3, 283);
            this.grpMailMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpMailMessage.Name = "grpMailMessage";
            this.grpMailMessage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpMailMessage.Size = new System.Drawing.Size(675, 430);
            this.grpMailMessage.TabIndex = 2;
            this.grpMailMessage.TabStop = false;
            this.grpMailMessage.Text = "Mail Message";
            this.grpMailMessage.Enter += new System.EventHandler(this.grpMailMessage_Enter);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(310, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Note: Recipeints support one address currently.";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(88, 28);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(528, 22);
            this.txtFrom.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "From:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, -12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "To:";
            // 
            // rtfMessageBody
            // 
            this.rtfMessageBody.Location = new System.Drawing.Point(11, 206);
            this.rtfMessageBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtfMessageBody.MaxLength = 0;
            this.rtfMessageBody.Name = "rtfMessageBody";
            this.rtfMessageBody.Size = new System.Drawing.Size(663, 180);
            this.rtfMessageBody.TabIndex = 11;
            this.rtfMessageBody.Text = "";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(88, 176);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(564, 22);
            this.txtSubject.TabIndex = 10;
            // 
            // chkIsHtml
            // 
            this.chkIsHtml.AutoSize = true;
            this.chkIsHtml.Location = new System.Drawing.Point(9, 409);
            this.chkIsHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsHtml.Name = "chkIsHtml";
            this.chkIsHtml.Size = new System.Drawing.Size(118, 21);
            this.chkIsHtml.TabIndex = 15;
            this.chkIsHtml.Text = "Body is HTML";
            this.chkIsHtml.UseVisualStyleBackColor = true;
            // 
            // txtBcc
            // 
            this.txtBcc.Location = new System.Drawing.Point(88, 110);
            this.txtBcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBcc.Name = "txtBcc";
            this.txtBcc.Size = new System.Drawing.Size(528, 22);
            this.txtBcc.TabIndex = 7;
            // 
            // txtCc
            // 
            this.txtCc.Location = new System.Drawing.Point(88, 84);
            this.txtCc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCc.Name = "txtCc";
            this.txtCc.Size = new System.Drawing.Size(528, 22);
            this.txtCc.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Subject:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bcc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cc:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(88, 58);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(528, 22);
            this.txtTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "To:";
            // 
            // rdoLowPri
            // 
            this.rdoLowPri.AutoSize = true;
            this.rdoLowPri.Location = new System.Drawing.Point(208, 21);
            this.rdoLowPri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoLowPri.Name = "rdoLowPri";
            this.rdoLowPri.Size = new System.Drawing.Size(54, 21);
            this.rdoLowPri.TabIndex = 3;
            this.rdoLowPri.Text = "Low";
            this.rdoLowPri.UseVisualStyleBackColor = true;
            // 
            // rdoHighPri
            // 
            this.rdoHighPri.AutoSize = true;
            this.rdoHighPri.Location = new System.Drawing.Point(143, 21);
            this.rdoHighPri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoHighPri.Name = "rdoHighPri";
            this.rdoHighPri.Size = new System.Drawing.Size(58, 21);
            this.rdoHighPri.TabIndex = 2;
            this.rdoHighPri.Text = "High";
            this.rdoHighPri.UseVisualStyleBackColor = true;
            // 
            // rdoNormalPri
            // 
            this.rdoNormalPri.AutoSize = true;
            this.rdoNormalPri.Checked = true;
            this.rdoNormalPri.Location = new System.Drawing.Point(67, 21);
            this.rdoNormalPri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoNormalPri.Name = "rdoNormalPri";
            this.rdoNormalPri.Size = new System.Drawing.Size(74, 21);
            this.rdoNormalPri.TabIndex = 1;
            this.rdoNormalPri.TabStop = true;
            this.rdoNormalPri.Text = "Normal";
            this.rdoNormalPri.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnDeleteHeader);
            this.groupBox2.Controls.Add(this.btnAddHeaders);
            this.groupBox2.Location = new System.Drawing.Point(689, 241);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(629, 153);
            this.groupBox2.TabIndex = 6;
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(565, 130);
            this.dataGridView1.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 74;
            // 
            // colValue
            // 
            this.colValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 73;
            // 
            // btnDeleteHeader
            // 
            this.btnDeleteHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteHeader.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteHeader.Location = new System.Drawing.Point(577, 63);
            this.btnDeleteHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteHeader.Name = "btnDeleteHeader";
            this.btnDeleteHeader.Size = new System.Drawing.Size(43, 39);
            this.btnDeleteHeader.TabIndex = 2;
            this.btnDeleteHeader.UseVisualStyleBackColor = true;
            this.btnDeleteHeader.Click += new System.EventHandler(this.btnDeleteHeader_Click);
            // 
            // btnAddHeaders
            // 
            this.btnAddHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHeaders.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnAddHeaders.Location = new System.Drawing.Point(579, 18);
            this.btnAddHeaders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddHeaders.Name = "btnAddHeaders";
            this.btnAddHeaders.Size = new System.Drawing.Size(43, 39);
            this.btnAddHeaders.TabIndex = 1;
            this.btnAddHeaders.UseVisualStyleBackColor = true;
            this.btnAddHeaders.Click += new System.EventHandler(this.btnAddHeaders_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkListAttachments);
            this.groupBox3.Controls.Add(this.btnInsertAttachment);
            this.groupBox3.Controls.Add(this.btnDeleteAttachment);
            this.groupBox3.Location = new System.Drawing.Point(691, 399);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(629, 186);
            this.groupBox3.TabIndex = 7;
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
            this.chkListAttachments.Location = new System.Drawing.Point(7, 18);
            this.chkListAttachments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkListAttachments.Name = "chkListAttachments";
            this.chkListAttachments.Size = new System.Drawing.Size(565, 140);
            this.chkListAttachments.TabIndex = 0;
            // 
            // btnInsertAttachment
            // 
            this.btnInsertAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertAttachment.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnInsertAttachment.Location = new System.Drawing.Point(579, 18);
            this.btnInsertAttachment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsertAttachment.Name = "btnInsertAttachment";
            this.btnInsertAttachment.Size = new System.Drawing.Size(43, 39);
            this.btnInsertAttachment.TabIndex = 1;
            this.btnInsertAttachment.UseVisualStyleBackColor = true;
            this.btnInsertAttachment.Click += new System.EventHandler(this.btnInsertAttachment_Click);
            // 
            // btnDeleteAttachment
            // 
            this.btnDeleteAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAttachment.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteAttachment.Location = new System.Drawing.Point(579, 63);
            this.btnDeleteAttachment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(43, 39);
            this.btnDeleteAttachment.TabIndex = 2;
            this.btnDeleteAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMinimalLogging);
            this.groupBox1.Controls.Add(this.txtBoxErrorLog);
            this.groupBox1.Location = new System.Drawing.Point(691, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(629, 234);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Error Log";
            // 
            // chkMinimalLogging
            // 
            this.chkMinimalLogging.AutoSize = true;
            this.chkMinimalLogging.Location = new System.Drawing.Point(7, 21);
            this.chkMinimalLogging.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkMinimalLogging.Name = "chkMinimalLogging";
            this.chkMinimalLogging.Size = new System.Drawing.Size(132, 21);
            this.chkMinimalLogging.TabIndex = 0;
            this.chkMinimalLogging.Text = "Minimal Logging";
            this.chkMinimalLogging.UseVisualStyleBackColor = true;
            // 
            // txtBoxErrorLog
            // 
            this.txtBoxErrorLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxErrorLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtBoxErrorLog.Location = new System.Drawing.Point(7, 48);
            this.txtBoxErrorLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxErrorLog.Multiline = true;
            this.txtBoxErrorLog.Name = "txtBoxErrorLog";
            this.txtBoxErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxErrorLog.Size = new System.Drawing.Size(616, 174);
            this.txtBoxErrorLog.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTimedSendEnd);
            this.groupBox4.Controls.Add(this.btnTimedSendStart);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numericUpDownResendSeconds);
            this.groupBox4.Location = new System.Drawing.Point(1017, 590);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(303, 89);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sending Loop";
            // 
            // btnTimedSendEnd
            // 
            this.btnTimedSendEnd.Location = new System.Drawing.Point(196, 57);
            this.btnTimedSendEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimedSendEnd.Name = "btnTimedSendEnd";
            this.btnTimedSendEnd.Size = new System.Drawing.Size(91, 27);
            this.btnTimedSendEnd.TabIndex = 3;
            this.btnTimedSendEnd.Text = "Stop";
            this.btnTimedSendEnd.UseVisualStyleBackColor = true;
            this.btnTimedSendEnd.Click += new System.EventHandler(this.btnTimedSendEnd_Click);
            // 
            // btnTimedSendStart
            // 
            this.btnTimedSendStart.Location = new System.Drawing.Point(77, 57);
            this.btnTimedSendStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTimedSendStart.Name = "btnTimedSendStart";
            this.btnTimedSendStart.Size = new System.Drawing.Size(81, 23);
            this.btnTimedSendStart.TabIndex = 2;
            this.btnTimedSendStart.Text = "Start";
            this.btnTimedSendStart.UseVisualStyleBackColor = true;
            this.btnTimedSendStart.Click += new System.EventHandler(this.btnTimedSendStart_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Wait seconds between sends:";
            // 
            // numericUpDownResendSeconds
            // 
            this.numericUpDownResendSeconds.Location = new System.Drawing.Point(215, 27);
            this.numericUpDownResendSeconds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownResendSeconds.Name = "numericUpDownResendSeconds";
            this.numericUpDownResendSeconds.Size = new System.Drawing.Size(83, 22);
            this.numericUpDownResendSeconds.TabIndex = 1;
            this.numericUpDownResendSeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(1115, 683);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(200, 32);
            this.btnSendEmail.TabIndex = 4;
            this.btnSendEmail.Text = "Send one email";
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
            this.label10.Location = new System.Drawing.Point(11, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Priority:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdoLowPri);
            this.groupBox5.Controls.Add(this.rdoHighPri);
            this.groupBox5.Controls.Add(this.rdoNormalPri);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(3, 192);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(681, 86);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options:";
            // 
            // SystemNetMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1335, 726);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSmtpSettings);
            this.Controls.Add(this.grpMailMessage);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label label12;
    }
}