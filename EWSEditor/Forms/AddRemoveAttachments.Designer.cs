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
            this.groupBox3.Location = new System.Drawing.Point(9, 9);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(734, 317);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Attachments:";
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
            this.lvFileAttachments.Location = new System.Drawing.Point(5, 28);
            this.lvFileAttachments.Name = "lvFileAttachments";
            this.lvFileAttachments.Size = new System.Drawing.Size(687, 284);
            this.lvFileAttachments.TabIndex = 1;
            this.lvFileAttachments.UseCompatibleStateImageBehavior = false;
            this.lvFileAttachments.SelectedIndexChanged += new System.EventHandler(this.lvFileAttachments_SelectedIndexChanged);
            this.lvFileAttachments.DoubleClick += new System.EventHandler(this.lvFileAttachments_DoubleClick);
            // 
            // btnInsertFileAttachment
            // 
            this.btnInsertFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertFileAttachment.Image = global::EWSEditor.Properties.Resources.action_add_16xLG;
            this.btnInsertFileAttachment.Location = new System.Drawing.Point(697, 28);
            this.btnInsertFileAttachment.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsertFileAttachment.Name = "btnInsertFileAttachment";
            this.btnInsertFileAttachment.Size = new System.Drawing.Size(32, 32);
            this.btnInsertFileAttachment.TabIndex = 2;
            this.btnInsertFileAttachment.UseVisualStyleBackColor = true;
            this.btnInsertFileAttachment.Click += new System.EventHandler(this.btnInsertAttachment_Click);
            // 
            // btnDeleteFileAttachment
            // 
            this.btnDeleteFileAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteFileAttachment.Image = global::EWSEditor.Properties.Resources.StatusAnnotations_Blocked_16xLG;
            this.btnDeleteFileAttachment.Location = new System.Drawing.Point(696, 63);
            this.btnDeleteFileAttachment.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteFileAttachment.Name = "btnDeleteFileAttachment";
            this.btnDeleteFileAttachment.Size = new System.Drawing.Size(32, 32);
            this.btnDeleteFileAttachment.TabIndex = 3;
            this.btnDeleteFileAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteFileAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Select attachment to insert";
            // 
            // AddRemoveAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 337);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
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