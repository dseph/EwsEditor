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
            this.MoreEwsEditor = new System.Windows.Forms.LinkLabel();
            this.CodeGalleryLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(74, 66);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 13;
            this.logoPictureBox.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(93, 13);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(114, 13);
            this.lblProductName.TabIndex = 14;
            this.lblProductName.Text = "[PRODUCT NAME]";
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.AutoSize = true;
            this.lblProductVersion.Location = new System.Drawing.Point(93, 38);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.Size = new System.Drawing.Size(117, 13);
            this.lblProductVersion.TabIndex = 15;
            this.lblProductVersion.Text = "[PRODUCT VERSION]";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(93, 65);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(76, 13);
            this.lblCopyright.TabIndex = 16;
            this.lblCopyright.Text = "[COPYRIGHT]";
            // 
            // grpLine1
            // 
            this.grpLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLine1.Location = new System.Drawing.Point(12, 84);
            this.grpLine1.Name = "grpLine1";
            this.grpLine1.Size = new System.Drawing.Size(599, 13);
            this.grpLine1.TabIndex = 17;
            this.grpLine1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(12, 103);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(599, 296);
            this.txtDescription.TabIndex = 24;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(536, 12);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // chkStartup
            // 
            this.chkStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStartup.AutoSize = true;
            this.chkStartup.Checked = true;
            this.chkStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartup.Location = new System.Drawing.Point(12, 406);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(107, 17);
            this.chkStartup.TabIndex = 26;
            this.chkStartup.Text = "Display at startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            this.chkStartup.CheckedChanged += new System.EventHandler(this.ChkStartup_CheckedChanged);
            // 
            // MoreEwsEditor
            // 
            this.MoreEwsEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MoreEwsEditor.Location = new System.Drawing.Point(399, 65);
            this.MoreEwsEditor.Name = "MoreEwsEditor";
            this.MoreEwsEditor.Size = new System.Drawing.Size(212, 13);
            this.MoreEwsEditor.TabIndex = 27;
            this.MoreEwsEditor.TabStop = true;
            this.MoreEwsEditor.Text = "More EWSEditor Info...";
            this.MoreEwsEditor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.MoreEwsEditor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MoreEwsEditor_LinkClicked);
            // 
            // CodeGalleryLink
            // 
            this.CodeGalleryLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeGalleryLink.Location = new System.Drawing.Point(381, 38);
            this.CodeGalleryLink.Name = "CodeGalleryLink";
            this.CodeGalleryLink.Size = new System.Drawing.Size(230, 13);
            this.CodeGalleryLink.TabIndex = 28;
            this.CodeGalleryLink.TabStop = true;
            this.CodeGalleryLink.Text = "EWSEditor Project Website";
            this.CodeGalleryLink.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.CodeGalleryLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CodeGalleryLink_LinkClicked);
            // 
            // AboutDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 426);
            this.Controls.Add(this.CodeGalleryLink);
            this.Controls.Add(this.MoreEwsEditor);
            this.Controls.Add(this.chkStartup);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.grpLine1);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblProductVersion);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(9);
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
        private System.Windows.Forms.LinkLabel MoreEwsEditor;
        private System.Windows.Forms.LinkLabel CodeGalleryLink;


    }
}
