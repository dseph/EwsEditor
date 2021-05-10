
namespace EWSEditor.Common
{
    partial class PostFormQuickHeaders
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
            this.chkClientRequestId = new System.Windows.Forms.CheckBox();
            this.chkReturnClientRequestId = new System.Windows.Forms.CheckBox();
            this.chkoAuthHeaderFromLogin = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkXAnchorMailbox = new System.Windows.Forms.CheckBox();
            this.txtXAnchorMailbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkClientRequestId
            // 
            this.chkClientRequestId.AutoSize = true;
            this.chkClientRequestId.Location = new System.Drawing.Point(32, 142);
            this.chkClientRequestId.Name = "chkClientRequestId";
            this.chkClientRequestId.Size = new System.Drawing.Size(263, 29);
            this.chkClientRequestId.TabIndex = 1;
            this.chkClientRequestId.Text = "A new client-request-id";
            this.chkClientRequestId.UseVisualStyleBackColor = true;
            // 
            // chkReturnClientRequestId
            // 
            this.chkReturnClientRequestId.AutoSize = true;
            this.chkReturnClientRequestId.Location = new System.Drawing.Point(32, 187);
            this.chkReturnClientRequestId.Name = "chkReturnClientRequestId";
            this.chkReturnClientRequestId.Size = new System.Drawing.Size(370, 29);
            this.chkReturnClientRequestId.TabIndex = 2;
            this.chkReturnClientRequestId.Text = "return-client-request-id set to True";
            this.chkReturnClientRequestId.UseVisualStyleBackColor = true;
            // 
            // chkoAuthHeaderFromLogin
            // 
            this.chkoAuthHeaderFromLogin.AutoSize = true;
            this.chkoAuthHeaderFromLogin.Location = new System.Drawing.Point(32, 238);
            this.chkoAuthHeaderFromLogin.Name = "chkoAuthHeaderFromLogin";
            this.chkoAuthHeaderFromLogin.Size = new System.Drawing.Size(429, 29);
            this.chkoAuthHeaderFromLogin.TabIndex = 3;
            this.chkoAuthHeaderFromLogin.Text = "oAuthHeader from current login session.";
            this.chkoAuthHeaderFromLogin.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(32, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1001, 91);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "This window lets you quickly add headers to the POST window.  It will replace exi" +
    "sting headers with a new one.";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(680, 354);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(159, 50);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(874, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 50);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkXAnchorMailbox
            // 
            this.chkXAnchorMailbox.AutoSize = true;
            this.chkXAnchorMailbox.Location = new System.Drawing.Point(32, 290);
            this.chkXAnchorMailbox.Name = "chkXAnchorMailbox";
            this.chkXAnchorMailbox.Size = new System.Drawing.Size(208, 29);
            this.chkXAnchorMailbox.TabIndex = 4;
            this.chkXAnchorMailbox.Text = "X-AnchorMailbox";
            this.chkXAnchorMailbox.UseVisualStyleBackColor = true;
            // 
            // txtXAnchorMailbox
            // 
            this.txtXAnchorMailbox.Location = new System.Drawing.Point(246, 288);
            this.txtXAnchorMailbox.Name = "txtXAnchorMailbox";
            this.txtXAnchorMailbox.Size = new System.Drawing.Size(374, 31);
            this.txtXAnchorMailbox.TabIndex = 5;
            // 
            // PostFormQuickHeaders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 430);
            this.Controls.Add(this.txtXAnchorMailbox);
            this.Controls.Add(this.chkXAnchorMailbox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkoAuthHeaderFromLogin);
            this.Controls.Add(this.chkReturnClientRequestId);
            this.Controls.Add(this.chkClientRequestId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PostFormQuickHeaders";
            this.Text = "Post Form Quick Headers";
            this.Load += new System.EventHandler(this.PostFormQuickHeaders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkClientRequestId;
        private System.Windows.Forms.CheckBox chkReturnClientRequestId;
        private System.Windows.Forms.CheckBox chkoAuthHeaderFromLogin;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkXAnchorMailbox;
        private System.Windows.Forms.TextBox txtXAnchorMailbox;
    }
}