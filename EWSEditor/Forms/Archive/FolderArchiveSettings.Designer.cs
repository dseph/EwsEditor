namespace EWSEditor.Forms
{
    partial class FolderArchiveSettings
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPR_ARCHIVE_PERIOD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPR_RETENTION_FLAGS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPR_ARCHIVE_TAG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(430, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Bitmask value. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(430, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "This is the number of days. 0 or -1 means never expire.";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(279, 252);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(2, 19);
            this.lblInfo.TabIndex = 19;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1053, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(946, 367);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPR_ARCHIVE_PERIOD
            // 
            this.txtPR_ARCHIVE_PERIOD.Location = new System.Drawing.Point(279, 280);
            this.txtPR_ARCHIVE_PERIOD.Name = "txtPR_ARCHIVE_PERIOD";
            this.txtPR_ARCHIVE_PERIOD.Size = new System.Drawing.Size(145, 22);
            this.txtPR_ARCHIVE_PERIOD.TabIndex = 16;
            this.txtPR_ARCHIVE_PERIOD.TextChanged += new System.EventHandler(this.txtPR_ARCHIVE_PERIOD_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "PR_ARCHIVE_PERIOD (0x301E):";
            // 
            // txtPR_RETENTION_FLAGS
            // 
            this.txtPR_RETENTION_FLAGS.Location = new System.Drawing.Point(279, 227);
            this.txtPR_RETENTION_FLAGS.Name = "txtPR_RETENTION_FLAGS";
            this.txtPR_RETENTION_FLAGS.Size = new System.Drawing.Size(145, 22);
            this.txtPR_RETENTION_FLAGS.TabIndex = 14;
            this.txtPR_RETENTION_FLAGS.TextChanged += new System.EventHandler(this.txtPR_RETENTION_FLAGS_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "PR_RETENTION_FLAGS (0x301D): ";
            // 
            // txtPR_ARCHIVE_TAG
            // 
            this.txtPR_ARCHIVE_TAG.Location = new System.Drawing.Point(279, 199);
            this.txtPR_ARCHIVE_TAG.Name = "txtPR_ARCHIVE_TAG";
            this.txtPR_ARCHIVE_TAG.Size = new System.Drawing.Size(479, 22);
            this.txtPR_ARCHIVE_TAG.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "PR_ARCHIVE_TAG (0x3018):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(813, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Note that GUID for PR_ARCHIVE_TAG is created/obtained through the Exchange consol" +
    "e or by PowerShell by an Administrator.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(67, 116);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(881, 17);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://blogs.msdn.microsoft.com/akashb/2012/12/07/stamping-archive-policy-tag-us" +
    "ing-ews-managed-api-from-powershellexchange-2010/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "See: ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(67, 142);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(790, 17);
            this.linkLabel2.TabIndex = 29;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://blogs.technet.microsoft.com/surama/2011/10/19/search-and-replace-retentio" +
    "n-tag-on-microsoft-exchange-2010-mrm/";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(67, 60);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(762, 17);
            this.linkLabel3.TabIndex = 30;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://blogs.technet.microsoft.com/anya/2014/11/19/understanding-of-managed-fold" +
    "er-assistant-with-retention-policies/";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(67, 87);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(442, 17);
            this.linkLabel4.TabIndex = 31;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "https://msdn.microsoft.com/en-us/library/ee202166(v=exchg.80).aspx";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1007, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "Note: When PR_RETENTION_FLAGS is set, Exchange may update its bitmask include the" +
    " next action to perform - such as NeedsRescan and PendingRescan.";
            // 
            // FolderArchiveSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 412);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.linkLabel4);
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
            this.Controls.Add(this.txtPR_ARCHIVE_PERIOD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPR_RETENTION_FLAGS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPR_ARCHIVE_TAG);
            this.Controls.Add(this.label1);
            this.Name = "FolderArchiveSettings";
            this.Text = "Folder Archive Settings";
            this.Load += new System.EventHandler(this.FolderArchiveSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPR_ARCHIVE_PERIOD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPR_RETENTION_FLAGS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPR_ARCHIVE_TAG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Label label9;
    }
}