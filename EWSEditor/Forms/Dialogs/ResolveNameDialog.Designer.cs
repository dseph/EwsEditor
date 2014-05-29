namespace EWSEditor.Forms
{
    partial class ResolveNameDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkReturnContactDetails = new System.Windows.Forms.CheckBox();
            this.cmboResolveNameSearchLocation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.lstNames = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColRoutingType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUniqueId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(705, 326);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkReturnContactDetails
            // 
            this.chkReturnContactDetails.AutoSize = true;
            this.chkReturnContactDetails.Checked = true;
            this.chkReturnContactDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReturnContactDetails.Location = new System.Drawing.Point(225, 53);
            this.chkReturnContactDetails.Name = "chkReturnContactDetails";
            this.chkReturnContactDetails.Size = new System.Drawing.Size(133, 17);
            this.chkReturnContactDetails.TabIndex = 9;
            this.chkReturnContactDetails.Text = "Return Contact Details";
            this.chkReturnContactDetails.UseVisualStyleBackColor = true;
            // 
            // cmboResolveNameSearchLocation
            // 
            this.cmboResolveNameSearchLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboResolveNameSearchLocation.FormattingEnabled = true;
            this.cmboResolveNameSearchLocation.Items.AddRange(new object[] {
            "DirectoryOnly ",
            "DirectoryThenContacts",
            "ContactsOnly",
            "ContactsThenDirectory"});
            this.cmboResolveNameSearchLocation.Location = new System.Drawing.Point(12, 51);
            this.cmboResolveNameSearchLocation.Name = "cmboResolveNameSearchLocation";
            this.cmboResolveNameSearchLocation.Size = new System.Drawing.Size(195, 21);
            this.cmboResolveNameSearchLocation.TabIndex = 8;
            this.cmboResolveNameSearchLocation.Text = "DirectoryThenContacts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter information to resolve.";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(749, 25);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(31, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(12, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(731, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Names resolved...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(624, 326);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lstNames
            // 
            this.lstNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAddress,
            this.ColRoutingType,
            this.colUniqueId});
            this.lstNames.FullRowSelect = true;
            this.lstNames.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstNames.HideSelection = false;
            this.lstNames.Location = new System.Drawing.Point(16, 106);
            this.lstNames.MultiSelect = false;
            this.lstNames.Name = "lstNames";
            this.lstNames.Size = new System.Drawing.Size(768, 214);
            this.lstNames.TabIndex = 4;
            this.lstNames.UseCompatibleStateImageBehavior = false;
            this.lstNames.View = System.Windows.Forms.View.Details;
            this.lstNames.DoubleClick += new System.EventHandler(this.lstNames_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 250;
            // 
            // ColRoutingType
            // 
            this.ColRoutingType.DisplayIndex = 3;
            this.ColRoutingType.Text = "RoutingType";
            this.ColRoutingType.Width = 100;
            // 
            // colUniqueId
            // 
            this.colUniqueId.DisplayIndex = 2;
            this.colUniqueId.Text = "Id.UniqueId";
            this.colUniqueId.Width = 200;
            // 
            // ResolveNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(792, 359);
            this.Controls.Add(this.chkReturnContactDetails);
            this.Controls.Add(this.cmboResolveNameSearchLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstNames);
            this.Name = "ResolveNameDialog";
            this.Text = "Resolve Name...";
            this.Load += new System.EventHandler(this.ResolveNameDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstNames;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colUniqueId;
        private System.Windows.Forms.ColumnHeader ColRoutingType;
        private System.Windows.Forms.ComboBox cmboResolveNameSearchLocation;
        private System.Windows.Forms.CheckBox chkReturnContactDetails;
    }
}