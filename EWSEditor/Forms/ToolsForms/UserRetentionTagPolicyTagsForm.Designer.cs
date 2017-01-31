namespace EWSEditor.Forms
{
    partial class UserRetentionTagPolicyTagsForm
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
            this.lvUserRetentionTags = new System.Windows.Forms.ListView();
            this.btnDisplayUsersRetentionTags = new System.Windows.Forms.Button();
            this.oLvRetionStampedFolders = new System.Windows.Forms.ListView();
            this.btnFindRetentionStampedFolders = new System.Windows.Forms.Button();
            this.TempWellKnownFolderCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmboSearchDepth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTagId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvUserRetentionTags
            // 
            this.lvUserRetentionTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvUserRetentionTags.FullRowSelect = true;
            this.lvUserRetentionTags.HideSelection = false;
            this.lvUserRetentionTags.Location = new System.Drawing.Point(12, 44);
            this.lvUserRetentionTags.Name = "lvUserRetentionTags";
            this.lvUserRetentionTags.Size = new System.Drawing.Size(1082, 302);
            this.lvUserRetentionTags.TabIndex = 1;
            this.lvUserRetentionTags.UseCompatibleStateImageBehavior = false;
            this.lvUserRetentionTags.SelectedIndexChanged += new System.EventHandler(this.lvUserRetentionTags_SelectedIndexChanged);
            this.lvUserRetentionTags.Click += new System.EventHandler(this.lvUserRetentionTags_Click);
            this.lvUserRetentionTags.DoubleClick += new System.EventHandler(this.lvUserRetentionTags_DoubleClick);
            // 
            // btnDisplayUsersRetentionTags
            // 
            this.btnDisplayUsersRetentionTags.Location = new System.Drawing.Point(12, 12);
            this.btnDisplayUsersRetentionTags.Name = "btnDisplayUsersRetentionTags";
            this.btnDisplayUsersRetentionTags.Size = new System.Drawing.Size(245, 26);
            this.btnDisplayUsersRetentionTags.TabIndex = 0;
            this.btnDisplayUsersRetentionTags.Text = "Display User\'s Retention Tags";
            this.btnDisplayUsersRetentionTags.UseVisualStyleBackColor = true;
            this.btnDisplayUsersRetentionTags.Click += new System.EventHandler(this.btnDisplayUsersRetentionTags_Click);
            // 
            // oLvRetionStampedFolders
            // 
            this.oLvRetionStampedFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oLvRetionStampedFolders.FullRowSelect = true;
            this.oLvRetionStampedFolders.HideSelection = false;
            this.oLvRetionStampedFolders.Location = new System.Drawing.Point(12, 388);
            this.oLvRetionStampedFolders.Name = "oLvRetionStampedFolders";
            this.oLvRetionStampedFolders.Size = new System.Drawing.Size(1057, 31);
            this.oLvRetionStampedFolders.TabIndex = 5;
            this.oLvRetionStampedFolders.UseCompatibleStateImageBehavior = false;
            this.oLvRetionStampedFolders.Visible = false;
            this.oLvRetionStampedFolders.SelectedIndexChanged += new System.EventHandler(this.oLvRetionStampedFolders_SelectedIndexChanged);
            // 
            // btnFindRetentionStampedFolders
            // 
            this.btnFindRetentionStampedFolders.Location = new System.Drawing.Point(12, 355);
            this.btnFindRetentionStampedFolders.Name = "btnFindRetentionStampedFolders";
            this.btnFindRetentionStampedFolders.Size = new System.Drawing.Size(154, 26);
            this.btnFindRetentionStampedFolders.TabIndex = 2;
            this.btnFindRetentionStampedFolders.Text = "Find Tag on Folder:";
            this.btnFindRetentionStampedFolders.UseVisualStyleBackColor = true;
            this.btnFindRetentionStampedFolders.Visible = false;
            this.btnFindRetentionStampedFolders.Click += new System.EventHandler(this.btnFindRetentionStampedFolders_Click);
            // 
            // TempWellKnownFolderCombo
            // 
            this.TempWellKnownFolderCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempWellKnownFolderCombo.FormattingEnabled = true;
            this.TempWellKnownFolderCombo.Location = new System.Drawing.Point(502, 353);
            this.TempWellKnownFolderCombo.Margin = new System.Windows.Forms.Padding(4);
            this.TempWellKnownFolderCombo.Name = "TempWellKnownFolderCombo";
            this.TempWellKnownFolderCombo.Size = new System.Drawing.Size(369, 24);
            this.TempWellKnownFolderCombo.TabIndex = 3;
            this.TempWellKnownFolderCombo.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 356);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Name:";
            this.label8.Visible = false;
            // 
            // cmboSearchDepth
            // 
            this.cmboSearchDepth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboSearchDepth.Items.AddRange(new object[] {
            "Shallow",
            "Deep"});
            this.cmboSearchDepth.Location = new System.Drawing.Point(934, 355);
            this.cmboSearchDepth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmboSearchDepth.Name = "cmboSearchDepth";
            this.cmboSearchDepth.Size = new System.Drawing.Size(126, 24);
            this.cmboSearchDepth.TabIndex = 4;
            this.cmboSearchDepth.Visible = false;
            this.cmboSearchDepth.SelectedIndexChanged += new System.EventHandler(this.cmboSearchDepth_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(878, 360);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Depth:";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 360);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tag Id:";
            this.label1.Visible = false;
            // 
            // txtTagId
            // 
            this.txtTagId.Location = new System.Drawing.Point(245, 355);
            this.txtTagId.Name = "txtTagId";
            this.txtTagId.Size = new System.Drawing.Size(193, 22);
            this.txtTagId.TabIndex = 11;
            this.txtTagId.Visible = false;
            // 
            // UserRetentionTagPolicyTagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 431);
            this.Controls.Add(this.txtTagId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboSearchDepth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TempWellKnownFolderCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnFindRetentionStampedFolders);
            this.Controls.Add(this.oLvRetionStampedFolders);
            this.Controls.Add(this.lvUserRetentionTags);
            this.Controls.Add(this.btnDisplayUsersRetentionTags);
            this.Name = "UserRetentionTagPolicyTagsForm";
            this.Text = "UserRetentionTagPolicyTagsForm";
            this.Load += new System.EventHandler(this.UserRetentionTagPolicyTagsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUserRetentionTags;
        private System.Windows.Forms.Button btnDisplayUsersRetentionTags;
        private System.Windows.Forms.ListView oLvRetionStampedFolders;
        private System.Windows.Forms.Button btnFindRetentionStampedFolders;
        private System.Windows.Forms.ComboBox TempWellKnownFolderCombo;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cmboSearchDepth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTagId;
    }
}