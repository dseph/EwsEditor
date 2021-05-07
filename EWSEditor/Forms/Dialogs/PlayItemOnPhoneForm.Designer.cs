namespace EWSEditor.Forms
{
    partial class PlayItemOnPhoneForm
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
            this.btnPlayOnPhone = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDialString = new System.Windows.Forms.TextBox();
            this.lblOrganizer = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.btnEndCall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlayOnPhone
            // 
            this.btnPlayOnPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayOnPhone.Location = new System.Drawing.Point(532, 16);
            this.btnPlayOnPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlayOnPhone.Name = "btnPlayOnPhone";
            this.btnPlayOnPhone.Size = new System.Drawing.Size(161, 28);
            this.btnPlayOnPhone.TabIndex = 2;
            this.btnPlayOnPhone.Text = "Play On Phone";
            this.btnPlayOnPhone.UseVisualStyleBackColor = true;
            this.btnPlayOnPhone.Click += new System.EventHandler(this.btnPlayOnPhone_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(767, 314);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDialString
            // 
            this.txtDialString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDialString.Location = new System.Drawing.Point(103, 18);
            this.txtDialString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDialString.Name = "txtDialString";
            this.txtDialString.Size = new System.Drawing.Size(409, 22);
            this.txtDialString.TabIndex = 66;
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Location = new System.Drawing.Point(17, 22);
            this.lblOrganizer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(77, 17);
            this.lblOrganizer.TabIndex = 1;
            this.lblOrganizer.Text = "Dial String:";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(16, 53);
            this.txtBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(849, 253);
            this.txtBody.TabIndex = 4;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // btnEndCall
            // 
            this.btnEndCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndCall.Enabled = false;
            this.btnEndCall.Location = new System.Drawing.Point(705, 17);
            this.btnEndCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(161, 28);
            this.btnEndCall.TabIndex = 3;
            this.btnEndCall.Text = "End Call";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // PlayItemOnPhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 358);
            this.Controls.Add(this.btnEndCall);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnPlayOnPhone);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDialString);
            this.Controls.Add(this.lblOrganizer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PlayItemOnPhoneForm";
            this.Text = "PlayItemOnPhone";
            this.Load += new System.EventHandler(this.PlayItemOnPhoneForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayOnPhone;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtDialString;
        private System.Windows.Forms.Label lblOrganizer;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button btnEndCall;
    }
}