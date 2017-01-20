namespace EWSEditor.Forms.Dialogs
{
    partial class SelectFolder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFolder));
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.FolderTreeView.FullRowSelect = true;
            this.FolderTreeView.HideSelection = false;
            this.FolderTreeView.ImageIndex = 1;
            this.FolderTreeView.ImageList = this.imageList;
            this.FolderTreeView.ItemHeight = 16;
            this.FolderTreeView.Location = new System.Drawing.Point(13, 13);
            this.FolderTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.SelectedImageIndex = 1;
            this.FolderTreeView.ShowNodeToolTips = true;
            this.FolderTreeView.Size = new System.Drawing.Size(613, 475);
            this.FolderTreeView.TabIndex = 1;
            this.FolderTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeCollapse);
            this.FolderTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeExpand);
            this.FolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            this.FolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FolderTreeView_NodeMouseClick);
            this.FolderTreeView.Click += new System.EventHandler(this.FolderTreeView_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.HotPink;
            this.imageList.Images.SetKeyName(0, "ServerConfig.png");
            this.imageList.Images.SetKeyName(1, "folder.ico");
            this.imageList.Images.SetKeyName(2, "calendar.png");
            this.imageList.Images.SetKeyName(3, "contact.png");
            this.imageList.Images.SetKeyName(4, "task.png");
            this.imageList.Images.SetKeyName(5, "journal.png");
            this.imageList.Images.SetKeyName(6, "mail.png");
            this.imageList.Images.SetKeyName(7, "post.png");
            this.imageList.Images.SetKeyName(8, "sticknote.png");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(423, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(514, 502);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SelectFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 532);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.FolderTreeView);
            this.Name = "SelectFolder";
            this.Text = "SelectFolder";
            this.Load += new System.EventHandler(this.SelectFolder_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imageList;
    }
}