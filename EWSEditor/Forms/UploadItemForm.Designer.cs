namespace EWSEditor.Forms
{
    partial class UploadItemForm
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
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.rdoCreateNew = new System.Windows.Forms.RadioButton();
            this.rdoUpdate = new System.Windows.Forms.RadioButton();
            this.rdoUpdateOrCreate = new System.Windows.Forms.RadioButton();
            this.lblItemId = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCreateAction = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(10, 11);
            this.lblFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 13);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "File:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(40, 8);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(399, 20);
            this.txtFile.TabIndex = 1;
            // 
            // rdoCreateNew
            // 
            this.rdoCreateNew.AutoSize = true;
            this.rdoCreateNew.Checked = true;
            this.rdoCreateNew.Location = new System.Drawing.Point(28, 62);
            this.rdoCreateNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoCreateNew.Name = "rdoCreateNew";
            this.rdoCreateNew.Size = new System.Drawing.Size(78, 17);
            this.rdoCreateNew.TabIndex = 3;
            this.rdoCreateNew.TabStop = true;
            this.rdoCreateNew.Text = "CreateNew";
            this.rdoCreateNew.UseVisualStyleBackColor = true;
            this.rdoCreateNew.CheckedChanged += new System.EventHandler(this.rdoCreateNew_CheckedChanged);
            // 
            // rdoUpdate
            // 
            this.rdoUpdate.AutoSize = true;
            this.rdoUpdate.Location = new System.Drawing.Point(28, 84);
            this.rdoUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoUpdate.Name = "rdoUpdate";
            this.rdoUpdate.Size = new System.Drawing.Size(60, 17);
            this.rdoUpdate.TabIndex = 4;
            this.rdoUpdate.Text = "Update";
            this.rdoUpdate.UseVisualStyleBackColor = true;
            this.rdoUpdate.CheckedChanged += new System.EventHandler(this.rdoUpdate_CheckedChanged);
            // 
            // rdoUpdateOrCreate
            // 
            this.rdoUpdateOrCreate.AutoSize = true;
            this.rdoUpdateOrCreate.Location = new System.Drawing.Point(28, 106);
            this.rdoUpdateOrCreate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoUpdateOrCreate.Name = "rdoUpdateOrCreate";
            this.rdoUpdateOrCreate.Size = new System.Drawing.Size(102, 17);
            this.rdoUpdateOrCreate.TabIndex = 5;
            this.rdoUpdateOrCreate.Text = "UpdateOrCreate";
            this.rdoUpdateOrCreate.UseVisualStyleBackColor = true;
            this.rdoUpdateOrCreate.CheckedChanged += new System.EventHandler(this.rdoUpdateOrCreate_CheckedChanged);
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(8, 135);
            this.lblItemId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(39, 13);
            this.lblItemId.TabIndex = 6;
            this.lblItemId.Text = "ItemId:";
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(49, 135);
            this.txtItemId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(425, 20);
            this.txtItemId.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(344, 173);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCreateAction
            // 
            this.lblCreateAction.AutoSize = true;
            this.lblCreateAction.Location = new System.Drawing.Point(8, 44);
            this.lblCreateAction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateAction.Name = "lblCreateAction";
            this.lblCreateAction.Size = new System.Drawing.Size(74, 13);
            this.lblCreateAction.TabIndex = 2;
            this.lblCreateAction.Text = "Create Action:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(410, 173);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(442, 8);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(27, 19);
            this.btnSelectFile.TabIndex = 12;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // UploadItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 202);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCreateAction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.rdoUpdateOrCreate);
            this.Controls.Add(this.rdoUpdate);
            this.Controls.Add(this.rdoCreateNew);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblFile);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UploadItemForm";
            this.Text = "Upload Item";
            this.Load += new System.EventHandler(this.UploadItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.RadioButton rdoCreateNew;
        private System.Windows.Forms.RadioButton rdoUpdate;
        private System.Windows.Forms.RadioButton rdoUpdateOrCreate;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCreateAction;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSelectFile;
    }
}