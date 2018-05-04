namespace EWSEditor.Forms
{
    partial class FolderRetentionSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPR_POLICY_TAG = new System.Windows.Forms.TextBox();
            this.txtPR_RETENTION_FLAGS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPR_RETENTION_PERIOD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "PR_POLICY_TAG (0x3019):";
            // 
            // txtPR_POLICY_TAG
            // 
            this.txtPR_POLICY_TAG.Location = new System.Drawing.Point(265, 166);
            this.txtPR_POLICY_TAG.Name = "txtPR_POLICY_TAG";
            this.txtPR_POLICY_TAG.Size = new System.Drawing.Size(479, 22);
            this.txtPR_POLICY_TAG.TabIndex = 1;
            // 
            // txtPR_RETENTION_FLAGS
            // 
            this.txtPR_RETENTION_FLAGS.Location = new System.Drawing.Point(265, 194);
            this.txtPR_RETENTION_FLAGS.Name = "txtPR_RETENTION_FLAGS";
            this.txtPR_RETENTION_FLAGS.Size = new System.Drawing.Size(145, 22);
            this.txtPR_RETENTION_FLAGS.TabIndex = 3;
            this.txtPR_RETENTION_FLAGS.TextChanged += new System.EventHandler(this.txtPR_RETENTION_FLAGS_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "PR_RETENTION_FLAGS (0x301D): ";
            // 
            // txtPR_RETENTION_PERIOD
            // 
            this.txtPR_RETENTION_PERIOD.Location = new System.Drawing.Point(265, 247);
            this.txtPR_RETENTION_PERIOD.Name = "txtPR_RETENTION_PERIOD";
            this.txtPR_RETENTION_PERIOD.Size = new System.Drawing.Size(145, 22);
            this.txtPR_RETENTION_PERIOD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "PR_RETENTION_PERIOD (0x301A):";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(783, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(890, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(265, 219);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(2, 19);
            this.lblInfo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(416, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "This is the number of days. 0 or -1 means never expire.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(416, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bitmask value. ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "See: ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(48, 60);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(917, 17);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://blogs.msdn.microsoft.com/akashb/2011/08/10/stamping-retention-policy-tag-" +
    "using-ews-managed-api-1-1-from-powershellexchange-2010/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(803, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Note that GUID for PR_POLICY_TAG is created/obtained through the Exchange console" +
    " or by PowerShell by an Administrator.";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(48, 88);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(790, 17);
            this.linkLabel2.TabIndex = 28;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://blogs.technet.microsoft.com/surama/2011/10/19/search-and-replace-retentio" +
    "n-tag-on-microsoft-exchange-2010-mrm/";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(48, 119);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(762, 17);
            this.linkLabel3.TabIndex = 29;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://blogs.technet.microsoft.com/anya/2014/11/19/understanding-of-managed-fold" +
    "er-assistant-with-retention-policies/";
            // 
            // FolderRetentionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 350);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPR_RETENTION_PERIOD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPR_RETENTION_FLAGS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPR_POLICY_TAG);
            this.Controls.Add(this.label1);
            this.Name = "FolderRetentionSettings";
            this.Text = "Folder Retention Settings";
            this.Load += new System.EventHandler(this.FolderRetentionSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPR_POLICY_TAG;
        private System.Windows.Forms.TextBox txtPR_RETENTION_FLAGS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPR_RETENTION_PERIOD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}