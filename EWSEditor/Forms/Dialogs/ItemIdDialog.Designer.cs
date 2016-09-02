﻿namespace EWSEditor.Forms
{
    partial class ItemIdDialog
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
            this.txtUniqueId = new System.Windows.Forms.TextBox();
            this.cmboIdType = new System.Windows.Forms.ComboBox();
            this.lblSmtpAddress = new System.Windows.Forms.Label();
            this.txtSmtpAddress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 213);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(861, 12);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(771, 232);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(663, 232);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // lblUnique
            // 
            this.lblUnique.AutoSize = true;
            this.lblUnique.Location = new System.Drawing.Point(17, 16);
            this.lblUnique.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnique.Name = "lblUnique";
            this.lblUnique.Size = new System.Drawing.Size(72, 17);
            this.lblUnique.TabIndex = 3;
            this.lblUnique.Text = "Unique Id:";
            // 
            // txtUniqueId
            // 
            this.txtUniqueId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUniqueId.Location = new System.Drawing.Point(20, 60);
            this.txtUniqueId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUniqueId.Multiline = true;
            this.txtUniqueId.Name = "txtUniqueId";
            this.txtUniqueId.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtUniqueId.Size = new System.Drawing.Size(844, 145);
            this.txtUniqueId.TabIndex = 5;
            this.txtUniqueId.WordWrap = false;
            // 
            // cmboIdType
            // 
            this.cmboIdType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboIdType.FormattingEnabled = true;
            this.cmboIdType.Items.AddRange(new object[] {
            "UniqueId",
            "StoreId"});
            this.cmboIdType.Location = new System.Drawing.Point(96, 12);
            this.cmboIdType.Name = "cmboIdType";
            this.cmboIdType.Size = new System.Drawing.Size(121, 24);
            this.cmboIdType.TabIndex = 6;
            this.cmboIdType.SelectedIndexChanged += new System.EventHandler(this.cmboIdType_SelectedIndexChanged);
            // 
            // lblSmtpAddress
            // 
            this.lblSmtpAddress.AutoSize = true;
            this.lblSmtpAddress.Location = new System.Drawing.Point(265, 15);
            this.lblSmtpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSmtpAddress.Name = "lblSmtpAddress";
            this.lblSmtpAddress.Size = new System.Drawing.Size(100, 17);
            this.lblSmtpAddress.TabIndex = 7;
            this.lblSmtpAddress.Text = "Smtp Address:";
            // 
            // txtSmtpAddress
            // 
            this.txtSmtpAddress.Location = new System.Drawing.Point(372, 13);
            this.txtSmtpAddress.Name = "txtSmtpAddress";
            this.txtSmtpAddress.Size = new System.Drawing.Size(250, 22);
            this.txtSmtpAddress.TabIndex = 8;
            // 
            // ItemIdDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(881, 277);
            this.Controls.Add(this.txtSmtpAddress);
            this.Controls.Add(this.lblSmtpAddress);
            this.Controls.Add(this.cmboIdType);
            this.Controls.Add(this.txtUniqueId);
            this.Controls.Add(this.lblUnique);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "ItemIdDialog";
            this.Text = "Input ItemId Details";
            this.Load += new System.EventHandler(this.ItemIdDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblUnique;
        private System.Windows.Forms.TextBox txtUniqueId;
        private System.Windows.Forms.ComboBox cmboIdType;
        private System.Windows.Forms.Label lblSmtpAddress;
        private System.Windows.Forms.TextBox txtSmtpAddress;
    }
}