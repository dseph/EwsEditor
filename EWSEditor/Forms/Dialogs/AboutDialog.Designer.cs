namespace EWSEditor.Forms
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        private new void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblProductVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.grpLine1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.CodeGalleryLink = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(16, 15);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(99, 81);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(124, 16);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(141, 17);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "[PRODUCT NAME]";
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.AutoSize = true;
            this.lblProductVersion.Location = new System.Drawing.Point(124, 47);
            this.lblProductVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(149, 17);
            this.lblProductVersion.TabIndex = 4;
            this.lblProductVersion.Text = "[PRODUCT VERSION]";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(124, 80);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(97, 17);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "[COPYRIGHT]";
            // 
            // grpLine1
            // 
            this.grpLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLine1.Location = new System.Drawing.Point(16, 157);
            this.grpLine1.Margin = new System.Windows.Forms.Padding(4);
            this.grpLine1.Name = "grpLine1";
            this.grpLine1.Padding = new System.Windows.Forms.Padding(4);
            this.grpLine1.Size = new System.Drawing.Size(803, 16);
            this.grpLine1.TabIndex = 6;
            this.grpLine1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(16, 181);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(801, 306);
            this.txtDescription.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(719, 15);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkStartup
            // 
            this.chkStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStartup.AutoSize = true;
            this.chkStartup.Checked = true;
            this.chkStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartup.Location = new System.Drawing.Point(16, 497);
            this.chkStartup.Margin = new System.Windows.Forms.Padding(4);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(140, 21);
            this.chkStartup.TabIndex = 8;
            this.chkStartup.Text = "Display at startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.ChkStartup_CheckedChanged);
            // 
            // CodeGalleryLink
            // 
            this.CodeGalleryLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeGalleryLink.Location = new System.Drawing.Point(618, 47);
            this.CodeGalleryLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CodeGalleryLink.Name = "CodeGalleryLink";
            this.CodeGalleryLink.Size = new System.Drawing.Size(198, 17);
            this.CodeGalleryLink.TabIndex = 1;
            this.CodeGalleryLink.TabStop = true;
            this.CodeGalleryLink.Text = "EWSEditor Project Website";
            this.CodeGalleryLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CodeGalleryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CodeGalleryLink_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 104);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(800, 55);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(835, 521);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CodeGalleryLink);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grpLine1);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblProductVersion);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.logoPictureBox);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowIcon = false;
            this.Text = "About EWS Editor";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblProductVersion;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.GroupBox grpLine1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkStartup;
        private System.Windows.Forms.LinkLabel CodeGalleryLink;
        private System.Windows.Forms.TextBox textBox1;


    }
}
