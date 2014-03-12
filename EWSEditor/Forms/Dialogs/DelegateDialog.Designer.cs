namespace EWSEditor.Forms
{
    partial class DelegateDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDelInfo = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstDelegates = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoDelegateAndMe = new System.Windows.Forms.RadioButton();
            this.rdoDelegateOnly = new System.Windows.Forms.RadioButton();
            this.rdoDelegateAndCopy = new System.Windows.Forms.RadioButton();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.btnResolvePrin = new System.Windows.Forms.Button();
            this.btnGetDelegates = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(222, 432);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(303, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpDelInfo
            // 
            this.grpDelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDelInfo.Controls.Add(this.btnUpdate);
            this.grpDelInfo.Controls.Add(this.btnRemove);
            this.grpDelInfo.Controls.Add(this.btnAdd);
            this.grpDelInfo.Controls.Add(this.lstDelegates);
            this.grpDelInfo.Controls.Add(this.panel1);
            this.grpDelInfo.Controls.Add(this.lblDescription);
            this.grpDelInfo.Location = new System.Drawing.Point(12, 91);
            this.grpDelInfo.Name = "grpDelInfo";
            this.grpDelInfo.Size = new System.Drawing.Size(367, 314);
            this.grpDelInfo.TabIndex = 14;
            this.grpDelInfo.TabStop = false;
            this.grpDelInfo.Text = "Delegate Information for {0}";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(272, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update...";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(271, 59);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(80, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove...";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(272, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstDelegates
            // 
            this.lstDelegates.FormattingEnabled = true;
            this.lstDelegates.Location = new System.Drawing.Point(19, 30);
            this.lstDelegates.Name = "lstDelegates";
            this.lstDelegates.Size = new System.Drawing.Size(246, 121);
            this.lstDelegates.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoDelegateAndMe);
            this.panel1.Controls.Add(this.rdoDelegateOnly);
            this.panel1.Controls.Add(this.rdoDelegateAndCopy);
            this.panel1.Location = new System.Drawing.Point(30, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 90);
            this.panel1.TabIndex = 13;
            // 
            // rdoDelegateAndMe
            // 
            this.rdoDelegateAndMe.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateAndMe.Location = new System.Drawing.Point(3, 62);
            this.rdoDelegateAndMe.Name = "rdoDelegateAndMe";
            this.rdoDelegateAndMe.Size = new System.Drawing.Size(300, 24);
            this.rdoDelegateAndMe.TabIndex = 2;
            this.rdoDelegateAndMe.TabStop = true;
            this.rdoDelegateAndMe.Text = "My delegates and me";
            this.rdoDelegateAndMe.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateAndMe.UseVisualStyleBackColor = true;
            // 
            // rdoDelegateOnly
            // 
            this.rdoDelegateOnly.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateOnly.Location = new System.Drawing.Point(4, 38);
            this.rdoDelegateOnly.Name = "rdoDelegateOnly";
            this.rdoDelegateOnly.Size = new System.Drawing.Size(300, 24);
            this.rdoDelegateOnly.TabIndex = 1;
            this.rdoDelegateOnly.TabStop = true;
            this.rdoDelegateOnly.Text = "My delegates only";
            this.rdoDelegateOnly.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateOnly.UseVisualStyleBackColor = true;
            // 
            // rdoDelegateAndCopy
            // 
            this.rdoDelegateAndCopy.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateAndCopy.Location = new System.Drawing.Point(4, 4);
            this.rdoDelegateAndCopy.Name = "rdoDelegateAndCopy";
            this.rdoDelegateAndCopy.Size = new System.Drawing.Size(300, 34);
            this.rdoDelegateAndCopy.TabIndex = 0;
            this.rdoDelegateAndCopy.TabStop = true;
            this.rdoDelegateAndCopy.Text = "My delegates only, but send a copy of meeting requests and responses to me (recom" +
    "mended)";
            this.rdoDelegateAndCopy.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rdoDelegateAndCopy.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(16, 162);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(321, 33);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Deliver meeting requests addresed to me and responses to meeting requests where I" +
    " am the organizer to:";
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.Location = new System.Drawing.Point(31, 38);
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(302, 20);
            this.txtPrincipal.TabIndex = 1;
            // 
            // btnResolvePrin
            // 
            this.btnResolvePrin.Location = new System.Drawing.Point(339, 36);
            this.btnResolvePrin.Name = "btnResolvePrin";
            this.btnResolvePrin.Size = new System.Drawing.Size(24, 23);
            this.btnResolvePrin.TabIndex = 2;
            this.btnResolvePrin.Text = "...";
            this.btnResolvePrin.UseVisualStyleBackColor = true;
            this.btnResolvePrin.Click += new System.EventHandler(this.btnResolvePrin_Click);
            // 
            // btnGetDelegates
            // 
            this.btnGetDelegates.Location = new System.Drawing.Point(262, 65);
            this.btnGetDelegates.Name = "btnGetDelegates";
            this.btnGetDelegates.Size = new System.Drawing.Size(101, 23);
            this.btnGetDelegates.TabIndex = 3;
            this.btnGetDelegates.Text = "Get Delegates";
            this.btnGetDelegates.UseVisualStyleBackColor = true;
            this.btnGetDelegates.Click += new System.EventHandler(this.btnGetDelegates_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the SMTP address of the principal mailbox to retrieve delegates from...";
            // 
            // DelegateDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 467);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetDelegates);
            this.Controls.Add(this.btnResolvePrin);
            this.Controls.Add(this.txtPrincipal);
            this.Controls.Add(this.grpDelInfo);
            this.Name = "DelegateDialog";
            this.Text = "Delegate Information";
            this.Load += new System.EventHandler(this.DelegateDialog_Load);
            this.grpDelInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpDelInfo;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstDelegates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoDelegateAndMe;
        private System.Windows.Forms.RadioButton rdoDelegateOnly;
        private System.Windows.Forms.RadioButton rdoDelegateAndCopy;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.Button btnResolvePrin;
        private System.Windows.Forms.Button btnGetDelegates;
        private System.Windows.Forms.Label label1;
    }
}