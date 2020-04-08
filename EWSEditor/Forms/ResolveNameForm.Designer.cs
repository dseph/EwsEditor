namespace EWSEditor.Forms
{
    partial class ResolveNameForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkReturnContactDetails = new System.Windows.Forms.CheckBox();
            this.cmboResolveNameSearchLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyDetailsGrid
            // 
            this.PropertyDetailsGrid.Size = new System.Drawing.Size(800, 206);
            // 
            // splitter
            // 
            this.Splitter.Location = new System.Drawing.Point(0, 84);
            this.Splitter.Size = new System.Drawing.Size(800, 397);
            this.Splitter.SplitterDistance = 187;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkReturnContactDetails);
            this.panel1.Controls.Add(this.cmboResolveNameSearchLocation);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 6;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(708, 33);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(80, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Resolve";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Search location:";
            // 
            // chkReturnContactDetails
            // 
            this.chkReturnContactDetails.AutoSize = true;
            this.chkReturnContactDetails.Checked = true;
            this.chkReturnContactDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturnContactDetails.Location = new System.Drawing.Point(277, 36);
            this.chkReturnContactDetails.Name = "chkReturnContactDetails";
            this.chkReturnContactDetails.Size = new System.Drawing.Size(133, 17);
            this.chkReturnContactDetails.TabIndex = 14;
            this.chkReturnContactDetails.Text = "Return Contact Details";
            this.chkReturnContactDetails.UseVisualStyleBackColor = true;
            // 
            // cmboResolveNameSearchLocation
            // 
            this.cmboResolveNameSearchLocation.FormattingEnabled = true;
            this.cmboResolveNameSearchLocation.Items.AddRange(new object[] {
            "DirectoryOnly ",
            "DirectoryThenContacts",
            "ContactsOnly",
            "ContactsThenDirectory"});
            this.cmboResolveNameSearchLocation.Location = new System.Drawing.Point(107, 33);
            this.cmboResolveNameSearchLocation.Name = "cmboResolveNameSearchLocation";
            this.cmboResolveNameSearchLocation.Size = new System.Drawing.Size(156, 21);
            this.cmboResolveNameSearchLocation.TabIndex = 13;
            this.cmboResolveNameSearchLocation.Text = "DirectoryThenContacts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Enter smtp, name, etc. to resolve:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(183, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(605, 20);
            this.txtName.TabIndex = 12;
            // 
            // ResolveNameForm
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.panel1);
            this.Name = "ResolveNameForm";
            this.Text = "ResolveNameForm";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.Splitter, 0);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkReturnContactDetails;
        private System.Windows.Forms.ComboBox cmboResolveNameSearchLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnGo;
    }
}