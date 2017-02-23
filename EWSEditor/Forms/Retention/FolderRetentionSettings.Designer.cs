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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "PR_POLICY_TAG:";
            // 
            // txtPR_POLICY_TAG
            // 
            this.txtPR_POLICY_TAG.Location = new System.Drawing.Point(212, 31);
            this.txtPR_POLICY_TAG.Name = "txtPR_POLICY_TAG";
            this.txtPR_POLICY_TAG.Size = new System.Drawing.Size(479, 22);
            this.txtPR_POLICY_TAG.TabIndex = 1;
            // 
            // txtPR_RETENTION_FLAGS
            // 
            this.txtPR_RETENTION_FLAGS.Location = new System.Drawing.Point(212, 59);
            this.txtPR_RETENTION_FLAGS.Name = "txtPR_RETENTION_FLAGS";
            this.txtPR_RETENTION_FLAGS.Size = new System.Drawing.Size(145, 22);
            this.txtPR_RETENTION_FLAGS.TabIndex = 3;
            this.txtPR_RETENTION_FLAGS.TextChanged += new System.EventHandler(this.txtPR_RETENTION_FLAGS_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "PR_RETENTION_FLAGS: ";
            // 
            // txtPR_RETENTION_PERIOD
            // 
            this.txtPR_RETENTION_PERIOD.Location = new System.Drawing.Point(212, 112);
            this.txtPR_RETENTION_PERIOD.Name = "txtPR_RETENTION_PERIOD";
            this.txtPR_RETENTION_PERIOD.Size = new System.Drawing.Size(145, 22);
            this.txtPR_RETENTION_PERIOD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "PR_RETENTION_PERIOD:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(540, 151);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(647, 151);
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
            this.lblInfo.Location = new System.Drawing.Point(212, 84);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(2, 19);
            this.lblInfo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(363, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "This is the number of days. 0 or -1 means never expire.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(363, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Bitmask value. ";
            // 
            // FolderRetentionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 184);
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
            this.Text = "Folder Retention Settings:";
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
    }
}