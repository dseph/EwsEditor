namespace EWSEditor.Forms.ToolsForms
{
    partial class CredentialCacheForm
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
            this.txtCredentials = new System.Windows.Forms.TextBox();
            this.btnEnumerateCredentials = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShowPasswords = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtCredentials
            // 
            this.txtCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredentials.Location = new System.Drawing.Point(3, 42);
            this.txtCredentials.MaxLength = 0;
            this.txtCredentials.Multiline = true;
            this.txtCredentials.Name = "txtCredentials";
            this.txtCredentials.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCredentials.Size = new System.Drawing.Size(1179, 399);
            this.txtCredentials.TabIndex = 1;
            this.txtCredentials.WordWrap = false;
            // 
            // btnEnumerateCredentials
            // 
            this.btnEnumerateCredentials.Location = new System.Drawing.Point(12, 13);
            this.btnEnumerateCredentials.Name = "btnEnumerateCredentials";
            this.btnEnumerateCredentials.Size = new System.Drawing.Size(184, 23);
            this.btnEnumerateCredentials.TabIndex = 2;
            this.btnEnumerateCredentials.Text = "Enumerate Credentials";
            this.btnEnumerateCredentials.UseVisualStyleBackColor = true;
            this.btnEnumerateCredentials.Click += new System.EventHandler(this.btnEnumerateCredentials_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nulls in passwords are stripped for presentation.  The hex encoded password cotai" +
    "ns all data.";
            // 
            // chkShowPasswords
            // 
            this.chkShowPasswords.AutoSize = true;
            this.chkShowPasswords.Location = new System.Drawing.Point(424, 13);
            this.chkShowPasswords.Name = "chkShowPasswords";
            this.chkShowPasswords.Size = new System.Drawing.Size(136, 21);
            this.chkShowPasswords.TabIndex = 4;
            this.chkShowPasswords.Text = "Show Passwords";
            this.chkShowPasswords.UseVisualStyleBackColor = true;
            // 
            // CredentialCacheForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 475);
            this.Controls.Add(this.chkShowPasswords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnumerateCredentials);
            this.Controls.Add(this.txtCredentials);
            this.Name = "CredentialCacheForm";
            this.Text = "CredentialCacheForm";
            this.Load += new System.EventHandler(this.CredentialCacheForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtCredentials;
        private System.Windows.Forms.Button btnEnumerateCredentials;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowPasswords;
    }
}