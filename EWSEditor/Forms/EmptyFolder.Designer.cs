﻿namespace EWSEditor.Forms
{
    partial class EmptyFolder
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
            this.rdoHardDelete = new System.Windows.Forms.RadioButton();
            this.rdoHardDeleteAndIncludeSubfolders = new System.Windows.Forms.RadioButton();
            this.rdoSoftDelete = new System.Windows.Forms.RadioButton();
            this.rdoSoftDeleteAndIncludeSubfolders = new System.Windows.Forms.RadioButton();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders = new System.Windows.Forms.RadioButton();
            this.rdoMovetodeleteditmesfolder = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdoHardDelete
            // 
            this.rdoHardDelete.AutoSize = true;
            this.rdoHardDelete.Location = new System.Drawing.Point(33, 26);
            this.rdoHardDelete.Name = "rdoHardDelete";
            this.rdoHardDelete.Size = new System.Drawing.Size(80, 17);
            this.rdoHardDelete.TabIndex = 0;
            this.rdoHardDelete.TabStop = true;
            this.rdoHardDelete.Text = "Hard delete";
            this.rdoHardDelete.UseVisualStyleBackColor = true;
            // 
            // rdoHardDeleteAndIncludeSubfolders
            // 
            this.rdoHardDeleteAndIncludeSubfolders.AutoSize = true;
            this.rdoHardDeleteAndIncludeSubfolders.Location = new System.Drawing.Point(33, 49);
            this.rdoHardDeleteAndIncludeSubfolders.Name = "rdoHardDeleteAndIncludeSubfolders";
            this.rdoHardDeleteAndIncludeSubfolders.Size = new System.Drawing.Size(189, 17);
            this.rdoHardDeleteAndIncludeSubfolders.TabIndex = 1;
            this.rdoHardDeleteAndIncludeSubfolders.TabStop = true;
            this.rdoHardDeleteAndIncludeSubfolders.Text = "Hard delete and include subfolders";
            this.rdoHardDeleteAndIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // rdoSoftDelete
            // 
            this.rdoSoftDelete.AutoSize = true;
            this.rdoSoftDelete.Location = new System.Drawing.Point(33, 72);
            this.rdoSoftDelete.Name = "rdoSoftDelete";
            this.rdoSoftDelete.Size = new System.Drawing.Size(76, 17);
            this.rdoSoftDelete.TabIndex = 2;
            this.rdoSoftDelete.TabStop = true;
            this.rdoSoftDelete.Text = "Soft delete";
            this.rdoSoftDelete.UseVisualStyleBackColor = true;
            // 
            // rdoSoftDeleteAndIncludeSubfolders
            // 
            this.rdoSoftDeleteAndIncludeSubfolders.AutoSize = true;
            this.rdoSoftDeleteAndIncludeSubfolders.Location = new System.Drawing.Point(33, 95);
            this.rdoSoftDeleteAndIncludeSubfolders.Name = "rdoSoftDeleteAndIncludeSubfolders";
            this.rdoSoftDeleteAndIncludeSubfolders.Size = new System.Drawing.Size(185, 17);
            this.rdoSoftDeleteAndIncludeSubfolders.TabIndex = 3;
            this.rdoSoftDeleteAndIncludeSubfolders.TabStop = true;
            this.rdoSoftDeleteAndIncludeSubfolders.Text = "Soft delete and include subfolders";
            this.rdoSoftDeleteAndIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(144, 180);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(225, 180);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // rdoMovetodeleteditmesfolderAndIncludeSubfolders
            // 
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.AutoSize = true;
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.Location = new System.Drawing.Point(33, 142);
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.Name = "rdoMovetodeleteditmesfolderAndIncludeSubfolders";
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.Size = new System.Drawing.Size(267, 17);
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.TabIndex = 7;
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.TabStop = true;
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.Text = "Move to deleted items folder and include subfolders";
            this.rdoMovetodeleteditmesfolderAndIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // rdoMovetodeleteditmesfolder
            // 
            this.rdoMovetodeleteditmesfolder.AutoSize = true;
            this.rdoMovetodeleteditmesfolder.Location = new System.Drawing.Point(33, 119);
            this.rdoMovetodeleteditmesfolder.Name = "rdoMovetodeleteditmesfolder";
            this.rdoMovetodeleteditmesfolder.Size = new System.Drawing.Size(158, 17);
            this.rdoMovetodeleteditmesfolder.TabIndex = 6;
            this.rdoMovetodeleteditmesfolder.TabStop = true;
            this.rdoMovetodeleteditmesfolder.Text = "Move to deleted items folder";
            this.rdoMovetodeleteditmesfolder.UseVisualStyleBackColor = true;
            // 
            // EmptyFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 216);
            this.Controls.Add(this.rdoMovetodeleteditmesfolderAndIncludeSubfolders);
            this.Controls.Add(this.rdoMovetodeleteditmesfolder);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.rdoSoftDeleteAndIncludeSubfolders);
            this.Controls.Add(this.rdoSoftDelete);
            this.Controls.Add(this.rdoHardDeleteAndIncludeSubfolders);
            this.Controls.Add(this.rdoHardDelete);
            this.Name = "EmptyFolder";
            this.Text = "EmptyFolder";
            this.Load += new System.EventHandler(this.EmptyFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoHardDelete;
        private System.Windows.Forms.RadioButton rdoHardDeleteAndIncludeSubfolders;
        private System.Windows.Forms.RadioButton rdoSoftDelete;
        private System.Windows.Forms.RadioButton rdoSoftDeleteAndIncludeSubfolders;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.RadioButton rdoMovetodeleteditmesfolderAndIncludeSubfolders;
        private System.Windows.Forms.RadioButton rdoMovetodeleteditmesfolder;
    }
}