namespace EWSEditor.Forms
{
    partial class ManagedApiDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.lnkDownload = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(173, 123);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblBack
            // 
            this.lblBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBack.Location = new System.Drawing.Point(0, 0);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(421, 101);
            this.lblBack.TabIndex = 1;
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblText.Location = new System.Drawing.Point(65, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(344, 52);
            this.lblText.TabIndex = 2;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picError
            // 
            this.picError.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picError.Location = new System.Drawing.Point(7, 9);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(52, 52);
            this.picError.TabIndex = 9;
            this.picError.TabStop = false;
            // 
            // lnkDownload
            // 
            this.lnkDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDownload.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lnkDownload.Location = new System.Drawing.Point(7, 64);
            this.lnkDownload.Name = "lnkDownload";
            this.lnkDownload.Size = new System.Drawing.Size(402, 26);
            this.lnkDownload.TabIndex = 10;
            this.lnkDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkDownload_LinkClicked);
            // 
            // ManagedApiDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 158);
            this.Controls.Add(this.lnkDownload);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagedApiDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exchange Web Services Managed API";
            this.Load += new System.EventHandler(this.ManagedApiDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.LinkLabel lnkDownload;
    }
}