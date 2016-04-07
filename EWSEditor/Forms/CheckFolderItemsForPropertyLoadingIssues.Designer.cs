namespace EWSEditor.Forms
{
    partial class CheckFolderItemsForPropertyLoadingIssues
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
            this.btnPropSet = new System.Windows.Forms.Button();
            this.lstErrors = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtErrorInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPropSet
            // 
            this.btnPropSet.Location = new System.Drawing.Point(13, 62);
            this.btnPropSet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPropSet.Name = "btnPropSet";
            this.btnPropSet.Size = new System.Drawing.Size(191, 28);
            this.btnPropSet.TabIndex = 3;
            this.btnPropSet.Text = "Configure Property Set";
            this.btnPropSet.UseVisualStyleBackColor = true;
            this.btnPropSet.Click += new System.EventHandler(this.btnPropSet_Click);
            // 
            // lstErrors
            // 
            this.lstErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstErrors.FullRowSelect = true;
            this.lstErrors.Location = new System.Drawing.Point(13, 128);
            this.lstErrors.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstErrors.MultiSelect = false;
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(1234, 250);
            this.lstErrors.TabIndex = 8;
            this.lstErrors.UseCompatibleStateImageBehavior = false;
            this.lstErrors.View = System.Windows.Forms.View.Details;
            this.lstErrors.SelectedIndexChanged += new System.EventHandler(this.lstErrors_SelectedIndexChanged);
            this.lstErrors.DoubleClick += new System.EventHandler(this.lstErrors_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ItemId";
            this.columnHeader1.Width = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Items with loading errors:";
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(1153, 5);
            this.btnGetFolderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(33, 28);
            this.btnGetFolderId.TabIndex = 2;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(101, 8);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(1044, 22);
            this.txtFolderId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Folder Id:";
            // 
            // txtErrorInfo
            // 
            this.txtErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorInfo.Location = new System.Drawing.Point(13, 402);
            this.txtErrorInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrorInfo.Multiline = true;
            this.txtErrorInfo.Name = "txtErrorInfo";
            this.txtErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorInfo.Size = new System.Drawing.Size(1236, 199);
            this.txtErrorInfo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 382);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Error:";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(228, 62);
            this.btnRunTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(128, 28);
            this.btnRunTest.TabIndex = 4;
            this.btnRunTest.Text = "Run Test";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(508, 68);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Processing Item:";
            // 
            // CheckFolderItemsForPropertyLoadingIssues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 614);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRunTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrorInfo);
            this.Controls.Add(this.btnGetFolderId);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.btnPropSet);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "CheckFolderItemsForPropertyLoadingIssues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckFolderItemsForPropertyLoadingIssues";
            this.Load += new System.EventHandler(this.CheckFolderItemsForPropertyLoadingIssues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPropSet;
        private System.Windows.Forms.ListView lstErrors;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtErrorInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label4;
    }
}