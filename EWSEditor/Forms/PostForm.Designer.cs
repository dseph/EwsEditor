namespace EWSEditor.Common
{
    partial class PostForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.chkDefaultWindowsCredentials = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.GoRun = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboVerb = new System.Windows.Forms.ComboBox();
            this.cmboContentType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtHeader1 = new System.Windows.Forms.TextBox();
            this.txtHeader2 = new System.Windows.Forms.TextBox();
            this.txtHeader3 = new System.Windows.Forms.TextBox();
            this.txtHeaderValue3 = new System.Windows.Forms.TextBox();
            this.txtHeaderValue2 = new System.Windows.Forms.TextBox();
            this.txtHeaderValue1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.chkDefaultWindowsCredentials);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(90, 83);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(217, 20);
            this.txtDomain.TabIndex = 2;
            // 
            // chkDefaultWindowsCredentials
            // 
            this.chkDefaultWindowsCredentials.AutoSize = true;
            this.chkDefaultWindowsCredentials.Checked = true;
            this.chkDefaultWindowsCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultWindowsCredentials.Location = new System.Drawing.Point(6, 13);
            this.chkDefaultWindowsCredentials.Name = "chkDefaultWindowsCredentials";
            this.chkDefaultWindowsCredentials.Size = new System.Drawing.Size(162, 17);
            this.chkDefaultWindowsCredentials.TabIndex = 42;
            this.chkDefaultWindowsCredentials.Text = "Default Windows Credentials";
            this.chkDefaultWindowsCredentials.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(90, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(217, 20);
            this.txtUser.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(217, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Password:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(40, 164);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(1014, 20);
            this.txtUrl.TabIndex = 46;
            this.txtUrl.Text = "https://mail.contoso.com/EWS/Exchange.asmx";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "URL:";
            // 
            // txtRequest
            // 
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.Location = new System.Drawing.Point(5, 203);
            this.txtRequest.MaxLength = 0;
            this.txtRequest.Multiline = true;
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRequest.Size = new System.Drawing.Size(1049, 161);
            this.txtRequest.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Request:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Response:";
            // 
            // txtResponse
            // 
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(5, 383);
            this.txtResponse.MaxLength = 0;
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(1049, 141);
            this.txtResponse.TabIndex = 66;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(980, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // GoRun
            // 
            this.GoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoRun.Location = new System.Drawing.Point(887, 530);
            this.GoRun.Name = "GoRun";
            this.GoRun.Size = new System.Drawing.Size(74, 23);
            this.GoRun.TabIndex = 68;
            this.GoRun.Text = "Run";
            this.GoRun.UseVisualStyleBackColor = true;
            this.GoRun.Click += new System.EventHandler(this.GoRun_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "ContentType:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Verb:";
            // 
            // cmboVerb
            // 
            this.cmboVerb.FormattingEnabled = true;
            this.cmboVerb.Items.AddRange(new object[] {
            "POST",
            "GET",
            "PUT"});
            this.cmboVerb.Location = new System.Drawing.Point(439, 5);
            this.cmboVerb.Name = "cmboVerb";
            this.cmboVerb.Size = new System.Drawing.Size(120, 21);
            this.cmboVerb.TabIndex = 73;
            this.cmboVerb.Text = "POST";
            // 
            // cmboContentType
            // 
            this.cmboContentType.FormattingEnabled = true;
            this.cmboContentType.Items.AddRange(new object[] {
            "text/xml",
            "text/html"});
            this.cmboContentType.Location = new System.Drawing.Point(439, 32);
            this.cmboContentType.Name = "cmboContentType";
            this.cmboContentType.Size = new System.Drawing.Size(120, 21);
            this.cmboContentType.TabIndex = 74;
            this.cmboContentType.Text = "text/xml";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Timeout Seconds:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(439, 59);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 76;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(643, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 78;
            this.label11.Text = "Header1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(643, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 13);
            this.label12.TabIndex = 79;
            this.label12.Text = "Header2:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(640, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 80;
            this.label13.Text = "Header 3:";
            // 
            // txtHeader1
            // 
            this.txtHeader1.Location = new System.Drawing.Point(700, 11);
            this.txtHeader1.Name = "txtHeader1";
            this.txtHeader1.Size = new System.Drawing.Size(131, 20);
            this.txtHeader1.TabIndex = 81;
            // 
            // txtHeader2
            // 
            this.txtHeader2.Location = new System.Drawing.Point(700, 37);
            this.txtHeader2.Name = "txtHeader2";
            this.txtHeader2.Size = new System.Drawing.Size(131, 20);
            this.txtHeader2.TabIndex = 82;
            // 
            // txtHeader3
            // 
            this.txtHeader3.Location = new System.Drawing.Point(700, 63);
            this.txtHeader3.Name = "txtHeader3";
            this.txtHeader3.Size = new System.Drawing.Size(131, 20);
            this.txtHeader3.TabIndex = 83;
            // 
            // txtHeaderValue3
            // 
            this.txtHeaderValue3.Location = new System.Drawing.Point(908, 63);
            this.txtHeaderValue3.Name = "txtHeaderValue3";
            this.txtHeaderValue3.Size = new System.Drawing.Size(131, 20);
            this.txtHeaderValue3.TabIndex = 86;
            // 
            // txtHeaderValue2
            // 
            this.txtHeaderValue2.Location = new System.Drawing.Point(908, 37);
            this.txtHeaderValue2.Name = "txtHeaderValue2";
            this.txtHeaderValue2.Size = new System.Drawing.Size(131, 20);
            this.txtHeaderValue2.TabIndex = 85;
            // 
            // txtHeaderValue1
            // 
            this.txtHeaderValue1.Location = new System.Drawing.Point(908, 11);
            this.txtHeaderValue1.Name = "txtHeaderValue1";
            this.txtHeaderValue1.Size = new System.Drawing.Size(131, 20);
            this.txtHeaderValue1.TabIndex = 84;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(848, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 89;
            this.label14.Text = "Value:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(851, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 88;
            this.label15.Text = "Value:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(851, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 87;
            this.label16.Text = "Value:";
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 556);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtHeaderValue3);
            this.Controls.Add(this.txtHeaderValue2);
            this.Controls.Add(this.txtHeaderValue1);
            this.Controls.Add(this.txtHeader3);
            this.Controls.Add(this.txtHeader2);
            this.Controls.Add(this.txtHeader1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmboContentType);
            this.Controls.Add(this.cmboVerb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.GoRun);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "PostForm";
            this.Text = "PostForm";
            this.Load += new System.EventHandler(this.PostForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.CheckBox chkDefaultWindowsCredentials;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button GoRun;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmboVerb;
        private System.Windows.Forms.ComboBox cmboContentType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtHeader1;
        private System.Windows.Forms.TextBox txtHeader2;
        private System.Windows.Forms.TextBox txtHeader3;
        private System.Windows.Forms.TextBox txtHeaderValue3;
        private System.Windows.Forms.TextBox txtHeaderValue2;
        private System.Windows.Forms.TextBox txtHeaderValue1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}