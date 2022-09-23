
namespace EWSEditor.Forms.ToolsForms
{
    partial class FindWrongClassItems
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
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstErrors = new System.Windows.Forms.ListView();
            this.colItemClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtErrorInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType1 = new System.Windows.Forms.TextBox();
            this.txtType2 = new System.Windows.Forms.TextBox();
            this.txtType3 = new System.Windows.Forms.TextBox();
            this.txtType4 = new System.Windows.Forms.TextBox();
            this.btnMessageFolderSet = new System.Windows.Forms.Button();
            this.btnCalendarFolderSet = new System.Windows.Forms.Button();
            this.btnContactsFolderSet = new System.Windows.Forms.Button();
            this.textMax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.colHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(1665, 149);
            this.btnGetFolderId.Margin = new System.Windows.Forms.Padding(6);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(50, 44);
            this.btnGetFolderId.TabIndex = 5;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(143, 154);
            this.txtFolderId.Margin = new System.Windows.Forms.Padding(6);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(1510, 31);
            this.txtFolderId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "Folder Id:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 420);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Processing Item:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(437, 420);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(24, 25);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "0";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(27, 410);
            this.btnRunTest.Margin = new System.Windows.Forms.Padding(6);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(192, 44);
            this.btnRunTest.TabIndex = 7;
            this.btnRunTest.Text = "Run Test";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 507);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Items with loading errors:";
            // 
            // lstErrors
            // 
            this.lstErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHidden,
            this.colItemClass,
            this.colSubject,
            this.colId});
            this.lstErrors.FullRowSelect = true;
            this.lstErrors.HideSelection = false;
            this.lstErrors.Location = new System.Drawing.Point(15, 549);
            this.lstErrors.Margin = new System.Windows.Forms.Padding(6);
            this.lstErrors.MultiSelect = false;
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(1722, 436);
            this.lstErrors.TabIndex = 11;
            this.lstErrors.UseCompatibleStateImageBehavior = false;
            this.lstErrors.View = System.Windows.Forms.View.Details;
            this.lstErrors.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstErrors_ColumnClick);
            this.lstErrors.SelectedIndexChanged += new System.EventHandler(this.lstErrors_SelectedIndexChanged);
            this.lstErrors.DoubleClick += new System.EventHandler(this.lstErrors_DoubleClick);
            // 
            // colItemClass
            // 
            this.colItemClass.Text = "Item Class";
            this.colItemClass.Width = 200;
            // 
            // colSubject
            // 
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 400;
            // 
            // colId
            // 
            this.colId.Text = "Id (EWS)";
            this.colId.Width = 400;
            // 
            // txtErrorInfo
            // 
            this.txtErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrorInfo.Font = new System.Drawing.Font("Courier New", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorInfo.Location = new System.Drawing.Point(2, 997);
            this.txtErrorInfo.Margin = new System.Windows.Forms.Padding(6);
            this.txtErrorInfo.Multiline = true;
            this.txtErrorInfo.Name = "txtErrorInfo";
            this.txtErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtErrorInfo.Size = new System.Drawing.Size(1722, 164);
            this.txtErrorInfo.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(347, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Valid Item Classes (will be ignored)";
            // 
            // txtType1
            // 
            this.txtType1.Location = new System.Drawing.Point(37, 243);
            this.txtType1.Name = "txtType1";
            this.txtType1.Size = new System.Drawing.Size(438, 31);
            this.txtType1.TabIndex = 14;
            // 
            // txtType2
            // 
            this.txtType2.Location = new System.Drawing.Point(37, 280);
            this.txtType2.Name = "txtType2";
            this.txtType2.Size = new System.Drawing.Size(438, 31);
            this.txtType2.TabIndex = 15;
            // 
            // txtType3
            // 
            this.txtType3.Location = new System.Drawing.Point(37, 317);
            this.txtType3.Name = "txtType3";
            this.txtType3.Size = new System.Drawing.Size(438, 31);
            this.txtType3.TabIndex = 16;
            // 
            // txtType4
            // 
            this.txtType4.Location = new System.Drawing.Point(37, 354);
            this.txtType4.Name = "txtType4";
            this.txtType4.Size = new System.Drawing.Size(438, 31);
            this.txtType4.TabIndex = 17;
            // 
            // btnMessageFolderSet
            // 
            this.btnMessageFolderSet.Location = new System.Drawing.Point(590, 236);
            this.btnMessageFolderSet.Margin = new System.Windows.Forms.Padding(6);
            this.btnMessageFolderSet.Name = "btnMessageFolderSet";
            this.btnMessageFolderSet.Size = new System.Drawing.Size(292, 44);
            this.btnMessageFolderSet.TabIndex = 18;
            this.btnMessageFolderSet.Text = "Load Message Folder Set";
            this.btnMessageFolderSet.UseVisualStyleBackColor = true;
            this.btnMessageFolderSet.Click += new System.EventHandler(this.btnMessageFolderSet_Click);
            // 
            // btnCalendarFolderSet
            // 
            this.btnCalendarFolderSet.Location = new System.Drawing.Point(590, 292);
            this.btnCalendarFolderSet.Margin = new System.Windows.Forms.Padding(6);
            this.btnCalendarFolderSet.Name = "btnCalendarFolderSet";
            this.btnCalendarFolderSet.Size = new System.Drawing.Size(292, 44);
            this.btnCalendarFolderSet.TabIndex = 19;
            this.btnCalendarFolderSet.Text = "Load Calendar Folder Set";
            this.btnCalendarFolderSet.UseVisualStyleBackColor = true;
            this.btnCalendarFolderSet.Click += new System.EventHandler(this.btnCalendarFolderSet_Click);
            // 
            // btnContactsFolderSet
            // 
            this.btnContactsFolderSet.Location = new System.Drawing.Point(590, 347);
            this.btnContactsFolderSet.Margin = new System.Windows.Forms.Padding(6);
            this.btnContactsFolderSet.Name = "btnContactsFolderSet";
            this.btnContactsFolderSet.Size = new System.Drawing.Size(292, 44);
            this.btnContactsFolderSet.TabIndex = 20;
            this.btnContactsFolderSet.Text = "Load Contact Folder Set";
            this.btnContactsFolderSet.UseVisualStyleBackColor = true;
            this.btnContactsFolderSet.Click += new System.EventHandler(this.btnContactsFolderSet_Click);
            // 
            // textMax
            // 
            this.textMax.Location = new System.Drawing.Point(1280, 243);
            this.textMax.Name = "textMax";
            this.textMax.Size = new System.Drawing.Size(122, 31);
            this.textMax.TabIndex = 21;
            this.textMax.Text = "1000";
            this.textMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMax_KeyPress);
            this.textMax.Validating += new System.ComponentModel.CancelEventHandler(this.textMax_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(916, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(349, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Maximum to check (0 is unlimited): ";
            // 
            // colHidden
            // 
            this.colHidden.Text = "Hidden";
            this.colHidden.Width = 50;
            // 
            // txtHelp
            // 
            this.txtHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHelp.Location = new System.Drawing.Point(15, 15);
            this.txtHelp.Margin = new System.Windows.Forms.Padding(6);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHelp.Size = new System.Drawing.Size(1709, 129);
            this.txtHelp.TabIndex = 23;
            this.txtHelp.Text = " ";
            // 
            // FindWrongClassItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 1176);
            this.Controls.Add(this.txtHelp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textMax);
            this.Controls.Add(this.btnContactsFolderSet);
            this.Controls.Add(this.btnCalendarFolderSet);
            this.Controls.Add(this.btnMessageFolderSet);
            this.Controls.Add(this.txtType4);
            this.Controls.Add(this.txtType3);
            this.Controls.Add(this.txtType2);
            this.Controls.Add(this.txtType1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtErrorInfo);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRunTest);
            this.Controls.Add(this.btnGetFolderId);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.label2);
            this.Name = "FindWrongClassItems";
            this.Text = "Find items with wrong item class.";
            this.Load += new System.EventHandler(this.FindWrongClassItems_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstErrors;
        private System.Windows.Forms.ColumnHeader colItemClass;
        private System.Windows.Forms.TextBox txtErrorInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType1;
        private System.Windows.Forms.TextBox txtType2;
        private System.Windows.Forms.TextBox txtType3;
        private System.Windows.Forms.TextBox txtType4;
        private System.Windows.Forms.Button btnMessageFolderSet;
        private System.Windows.Forms.Button btnCalendarFolderSet;
        private System.Windows.Forms.Button btnContactsFolderSet;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.TextBox textMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colHidden;
        private System.Windows.Forms.TextBox txtHelp;
    }
}