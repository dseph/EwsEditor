namespace EWSEditor.Forms.Dialogs
{
    partial class DomainSettingsForm
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
            this.TempExchangeVersionCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDefaultUser = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.chkDefaultWindowsCredentials = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.TargetMailDomain = new System.Windows.Forms.TextBox();
            this.GoRun = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TempExchangeVersionCombo
            // 
            this.TempExchangeVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempExchangeVersionCombo.FormattingEnabled = true;
            this.TempExchangeVersionCombo.Location = new System.Drawing.Point(120, 152);
            this.TempExchangeVersionCombo.Margin = new System.Windows.Forms.Padding(4);
            this.TempExchangeVersionCombo.Name = "TempExchangeVersionCombo";
            this.TempExchangeVersionCombo.Size = new System.Drawing.Size(293, 24);
            this.TempExchangeVersionCombo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "EWS Schema:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDefaultUser);
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.chkDefaultWindowsCredentials);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(11, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(499, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDefaultUser
            // 
            this.btnDefaultUser.Location = new System.Drawing.Point(423, 37);
            this.btnDefaultUser.Margin = new System.Windows.Forms.Padding(4);
            this.btnDefaultUser.Name = "btnDefaultUser";
            this.btnDefaultUser.Size = new System.Drawing.Size(68, 28);
            this.btnDefaultUser.TabIndex = 6;
            this.btnDefaultUser.Text = "Default";
            this.btnDefaultUser.UseVisualStyleBackColor = true;
            this.btnDefaultUser.Click += new System.EventHandler(this.btnDefaultUser_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(109, 86);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(1);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(293, 22);
            this.txtDomain.TabIndex = 5;
            // 
            // chkDefaultWindowsCredentials
            // 
            this.chkDefaultWindowsCredentials.AutoSize = true;
            this.chkDefaultWindowsCredentials.Checked = true;
            this.chkDefaultWindowsCredentials.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefaultWindowsCredentials.Location = new System.Drawing.Point(8, 16);
            this.chkDefaultWindowsCredentials.Margin = new System.Windows.Forms.Padding(4);
            this.chkDefaultWindowsCredentials.Name = "chkDefaultWindowsCredentials";
            this.chkDefaultWindowsCredentials.Size = new System.Drawing.Size(210, 21);
            this.chkDefaultWindowsCredentials.TabIndex = 0;
            this.chkDefaultWindowsCredentials.Text = "Default Windows Credentials";
            this.chkDefaultWindowsCredentials.UseVisualStyleBackColor = true;
            this.chkDefaultWindowsCredentials.CheckedChanged += new System.EventHandler(this.chkDefaultWindowsCredentials_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(109, 37);
            this.txtUser.Margin = new System.Windows.Forms.Padding(1);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(293, 22);
            this.txtUser.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 62);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(1);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(293, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(8, 131);
            this.TargetMailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(89, 17);
            this.TargetMailboxLabel.TabIndex = 4;
            this.TargetMailboxLabel.Text = "Mail Domain:";
            // 
            // TargetMailDomain
            // 
            this.TargetMailDomain.Location = new System.Drawing.Point(120, 125);
            this.TargetMailDomain.Margin = new System.Windows.Forms.Padding(4);
            this.TargetMailDomain.Name = "TargetMailDomain";
            this.TargetMailDomain.Size = new System.Drawing.Size(293, 22);
            this.TargetMailDomain.TabIndex = 5;
            // 
            // GoRun
            // 
            this.GoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GoRun.Location = new System.Drawing.Point(620, 148);
            this.GoRun.Margin = new System.Windows.Forms.Padding(4);
            this.GoRun.Name = "GoRun";
            this.GoRun.Size = new System.Drawing.Size(105, 28);
            this.GoRun.TabIndex = 8;
            this.GoRun.Text = "Run";
            this.GoRun.UseVisualStyleBackColor = true;
            this.GoRun.Click += new System.EventHandler(this.GoRun_Click);
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(11, 184);
            this.txtResults.Margin = new System.Windows.Forms.Padding(4);
            this.txtResults.MaxLength = 0;
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(714, 174);
            this.txtResults.TabIndex = 9;
            // 
            // DomainSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(738, 367);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.GoRun);
            this.Controls.Add(this.TempExchangeVersionCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.TargetMailDomain);
            this.Name = "DomainSettingsForm";
            this.Text = "Domain Settings Form";
            this.Load += new System.EventHandler(this.DomainSettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TempExchangeVersionCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDefaultUser;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.CheckBox chkDefaultWindowsCredentials;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox TargetMailDomain;
        private System.Windows.Forms.Button GoRun;
        private System.Windows.Forms.TextBox txtResults;

    }
}