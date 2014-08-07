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
            this.btnPlayOnPhone.Location = new System.Drawing.Point(462, 13);
            this.btnPlayOnPhone.Name = "btnPlayOnPhone";
            this.btnPlayOnPhone.Size = new System.Drawing.Size(121, 23);
            this.btnPlayOnPhone.TabIndex = 2;
            this.btnPlayOnPhone.Text = "Play On Phone";
            this.btnPlayOnPhone.UseVisualStyleBackColor = true;
            this.btnPlayOnPhone.Click += new System.EventHandler(this.btnPlayOnPhone_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(638, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDialString
            // 
            this.txtDialString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDialString.Location = new System.Drawing.Point(77, 15);
            this.txtDialString.Name = "txtDialString";
            this.txtDialString.Size = new System.Drawing.Size(348, 20);
            this.txtDialString.TabIndex = 66;
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Location = new System.Drawing.Point(13, 18);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(58, 13);
            this.lblOrganizer.TabIndex = 1;
            this.lblOrganizer.Text = "Dial String:";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(12, 43);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(701, 226);
            this.txtBody.TabIndex = 4;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // btnEndCall
            // 
            this.btnEndCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndCall.Enabled = false;
            this.btnEndCall.Location = new System.Drawing.Point(592, 14);
            this.btnEndCall.Name = "btnEndCall";
            this.btnEndCall.Size = new System.Drawing.Size(121, 23);
            this.btnEndCall.TabIndex = 3;
            this.btnEndCall.Text = "End Call";
            this.btnEndCall.UseVisualStyleBackColor = true;
            this.btnEndCall.Click += new System.EventHandler(this.btnEndCall_Click);
            // 
            // PlayItemOnPhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 310);
            this.Controls.Add(this.btnEndCall);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnPlayOnPhone);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDialString);
            this.Controls.Add(this.lblOrganizer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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