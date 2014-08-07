namespace EWSEditor.Forms
{
    partial class ConversationIdDialog
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
        private new void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblUnique = new System.Windows.Forms.Label();
            this.txtConversationId = new System.Windows.Forms.TextBox();
            this.btnGetFolderId = new System.Windows.Forms.Button();
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPropSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(916, 10);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(848, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(767, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblUnique
            // 
            this.lblUnique.AutoSize = true;
            this.lblUnique.Location = new System.Drawing.Point(13, 49);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(84, 13);
            this.lblUnique.TabIndex = 3;
            this.lblUnique.Text = "Conversation Id:";
            // 
            // txtConversationId
            // 
            this.txtConversationId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversationId.Location = new System.Drawing.Point(103, 46);
            this.txtConversationId.MaxLength = 0;
            this.txtConversationId.Multiline = true;
            this.txtConversationId.Name = "txtConversationId";
            this.txtConversationId.Size = new System.Drawing.Size(774, 55);
            this.txtConversationId.TabIndex = 4;
            // 
            // btnGetFolderId
            // 
            this.btnGetFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetFolderId.Location = new System.Drawing.Point(727, 12);
            this.btnGetFolderId.Name = "btnGetFolderId";
            this.btnGetFolderId.Size = new System.Drawing.Size(25, 23);
            this.btnGetFolderId.TabIndex = 1;
            this.btnGetFolderId.Text = "...";
            this.btnGetFolderId.UseVisualStyleBackColor = true;
            this.btnGetFolderId.Click += new System.EventHandler(this.btnGetFolderId_Click);
            // 
            // txtFolderId
            // 
            this.txtFolderId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderId.Location = new System.Drawing.Point(102, 12);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.ReadOnly = true;
            this.txtFolderId.Size = new System.Drawing.Size(619, 20);
            this.txtFolderId.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 28;
            this.label2.Text = "Folder Id:";
            // 
            // btnPropSet
            // 
            this.btnPropSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPropSet.Location = new System.Drawing.Point(776, 12);
            this.btnPropSet.Name = "btnPropSet";
            this.btnPropSet.Size = new System.Drawing.Size(143, 23);
            this.btnPropSet.TabIndex = 2;
            this.btnPropSet.Text = "Configure Property Set";
            this.btnPropSet.UseVisualStyleBackColor = true;
            this.btnPropSet.Click += new System.EventHandler(this.btnPropSet_Click);
            // 
            // ConversationIdDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(931, 174);
            this.Controls.Add(this.btnPropSet);
            this.Controls.Add(this.btnGetFolderId);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConversationId);
            this.Controls.Add(this.lblUnique);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConversationIdDialog";
            this.Text = "Enter a Conversation\'s Id...";
            this.Load += new System.EventHandler(this.ConversationIdDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblUnique;
        private System.Windows.Forms.TextBox txtConversationId;
        private System.Windows.Forms.Button btnGetFolderId;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPropSet;
    }
}