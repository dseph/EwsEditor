namespace EWSEditor.Forms
{
    partial class FindSearchFolder
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
            this.btnFind = new System.Windows.Forms.Button();
            this.lvFolders = new System.Windows.Forms.ListView();
            this.chkShowFolderUnderSharedFolders = new System.Windows.Forms.CheckBox();
            this.chkShowFoldersUnderRootFolder = new System.Windows.Forms.CheckBox();
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(792, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(146, 36);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lvFolders
            // 
            this.lvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFolders.FullRowSelect = true;
            this.lvFolders.GridLines = true;
            this.lvFolders.Location = new System.Drawing.Point(12, 103);
            this.lvFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvFolders.MultiSelect = false;
            this.lvFolders.Name = "lvFolders";
            this.lvFolders.Size = new System.Drawing.Size(940, 406);
            this.lvFolders.TabIndex = 33;
            this.lvFolders.UseCompatibleStateImageBehavior = false;
            this.lvFolders.SelectedIndexChanged += new System.EventHandler(this.lvFolders_SelectedIndexChanged);
            // 
            // chkShowFolderUnderSharedFolders
            // 
            this.chkShowFolderUnderSharedFolders.AutoSize = true;
            this.chkShowFolderUnderSharedFolders.Location = new System.Drawing.Point(24, 13);
            this.chkShowFolderUnderSharedFolders.Name = "chkShowFolderUnderSharedFolders";
            this.chkShowFolderUnderSharedFolders.Size = new System.Drawing.Size(354, 21);
            this.chkShowFolderUnderSharedFolders.TabIndex = 34;
            this.chkShowFolderUnderSharedFolders.Text = "Show search folders under SharedFolders (\\Finder)";
            this.chkShowFolderUnderSharedFolders.UseVisualStyleBackColor = true;
            // 
            // chkShowFoldersUnderRootFolder
            // 
            this.chkShowFoldersUnderRootFolder.AutoSize = true;
            this.chkShowFoldersUnderRootFolder.Location = new System.Drawing.Point(24, 40);
            this.chkShowFoldersUnderRootFolder.Name = "chkShowFoldersUnderRootFolder";
            this.chkShowFoldersUnderRootFolder.Size = new System.Drawing.Size(291, 21);
            this.chkShowFoldersUnderRootFolder.TabIndex = 35;
            this.chkShowFoldersUnderRootFolder.Text = "Show search folders under Root (\\) folder";
            this.chkShowFoldersUnderRootFolder.UseVisualStyleBackColor = true;
            // 
            // chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot
            // 
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.AutoSize = true;
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.Location = new System.Drawing.Point(24, 67);
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.Name = "chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot";
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.Size = new System.Drawing.Size(371, 21);
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.TabIndex = 36;
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.Text = "Show search folders not under SharedFolders or Root";
            this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot.UseVisualStyleBackColor = true;
            // 
            // FindSearchFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 520);
            this.Controls.Add(this.chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot);
            this.Controls.Add(this.chkShowFoldersUnderRootFolder);
            this.Controls.Add(this.chkShowFolderUnderSharedFolders);
            this.Controls.Add(this.lvFolders);
            this.Controls.Add(this.btnFind);
            this.Name = "FindSearchFolder";
            this.Text = "Find Search Folders";
            this.Load += new System.EventHandler(this.FindSearchFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ListView lvFolders;
        private System.Windows.Forms.CheckBox chkShowFolderUnderSharedFolders;
        private System.Windows.Forms.CheckBox chkShowFoldersUnderRootFolder;
        private System.Windows.Forms.CheckBox chkShowSearchFoldersNotUnderSharedFoldersAndNotUnderRoot;
    }
}