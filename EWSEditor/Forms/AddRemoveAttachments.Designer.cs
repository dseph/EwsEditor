namespace EWSEditor.Forms
{
    partial class AddRemoveAttachments
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvFileAttachments = new System.Windows.Forms.ListView();
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsInline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInsertFileAttachment = new System.Windows.Forms.Button();
            this.btnDeleteFileAttachment = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lvFileAttachments);
            this.groupBox3.Controls.Add(this.btnInsertFileAttachment);
            this.groupBox3.Controls.Add(this.btnDeleteFileAttachment);
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(1317, 482);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "File Attachments:";
            // 
            // lvFileAttachments
            // 
            this.lvFileAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileAttachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colContentId,
            this.colType,
            this.colIsInline});
            this.lvFileAttachments.Location = new System.Drawing.Point(7, 34);
            this.lvFileAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.lvFileAttachments.Name = "lvFileAttachments";
            this.lvFileAttachments.Size = new System.Drawing.Size(1253, 442);
            this.lvFileAttachments.TabIndex = 13;
            this.lvFileAttachments.UseCompatibleStateImageBehavior = false;
            this.lvFileAttachments.SelectedIndexChanged += new System.EventHandler(this.lvFileAttachments_SelectedIndexChanged);
            this.lvFileAttachments.DoubleClick += new System.EventHandler(this.lvFileAttachments_DoubleClick);
            // 
            // btnInsertFileAttachment
            // 
            this.btnInsertFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertFileAttachment.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnInsertFileAttachment.Location = new System.Drawing.Point(1268, 34);
            this.btnInsertFileAttachment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsertFileAttachment.Name = "btnInsertFileAttachment";
            this.btnInsertFileAttachment.Size = new System.Drawing.Size(43, 39);
            this.btnInsertFileAttachment.TabIndex = 12;
            this.btnInsertFileAttachment.UseVisualStyleBackColor = true;
            this.btnInsertFileAttachment.Click += new System.EventHandler(this.btnInsertAttachment_Click);
            // 
            // btnDeleteFileAttachment
            // 
            this.btnDeleteFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFileAttachment.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteFileAttachment.Location = new System.Drawing.Point(1267, 77);
            this.btnDeleteFileAttachment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteFileAttachment.Name = "btnDeleteFileAttachment";
            this.btnDeleteFileAttachment.Size = new System.Drawing.Size(43, 39);
            this.btnDeleteFileAttachment.TabIndex = 2;
            this.btnDeleteFileAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteFileAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select attachment to insert";
            // 
            // AddRemoveAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 504);
            this.Controls.Add(this.groupBox3);
            this.Name = "AddRemoveAttachments";
            this.Text = "AddRemoveAttachments";
            this.Load += new System.EventHandler(this.AddRemoveAttachments_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInsertFileAttachment;
        private System.Windows.Forms.Button btnDeleteFileAttachment;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListView lvFileAttachments;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colContentId;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colIsInline;
        private System.Windows.Forms.Label label1;
    }
}