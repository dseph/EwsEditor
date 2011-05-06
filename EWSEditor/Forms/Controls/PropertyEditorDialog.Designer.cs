namespace EWSEditor.Forms
{
    partial class PropertyEditorDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.tbpSmart = new System.Windows.Forms.TabPage();
            this.txtSmartView = new System.Windows.Forms.RichTextBox();
            this.tbpDefault = new System.Windows.Forms.TabPage();
            this.tabValue = new System.Windows.Forms.TabControl();
            this.tabMoreInfo = new System.Windows.Forms.TabPage();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.tbcPropertyInfo = new System.Windows.Forms.TabControl();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNames = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtKnownNames = new System.Windows.Forms.TextBox();
            this.tabPropertyDef = new System.Windows.Forms.TabPage();
            this.tbpSmart.SuspendLayout();
            this.tabValue.SuspendLayout();
            this.tabMoreInfo.SuspendLayout();
            this.tbcPropertyInfo.SuspendLayout();
            this.tabPropertyDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(363, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(273, 484);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbpSmart
            // 
            this.tbpSmart.Controls.Add(this.txtSmartView);
            this.tbpSmart.Location = new System.Drawing.Point(4, 22);
            this.tbpSmart.Name = "tbpSmart";
            this.tbpSmart.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSmart.Size = new System.Drawing.Size(429, 285);
            this.tbpSmart.TabIndex = 2;
            this.tbpSmart.Text = "Value - Smart View";
            this.tbpSmart.UseVisualStyleBackColor = true;
            // 
            // txtSmartView
            // 
            this.txtSmartView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSmartView.Location = new System.Drawing.Point(3, 3);
            this.txtSmartView.Name = "txtSmartView";
            this.txtSmartView.ReadOnly = true;
            this.txtSmartView.Size = new System.Drawing.Size(423, 279);
            this.txtSmartView.TabIndex = 0;
            this.txtSmartView.Text = "";
            // 
            // tbpDefault
            // 
            this.tbpDefault.Location = new System.Drawing.Point(4, 22);
            this.tbpDefault.Name = "tbpDefault";
            this.tbpDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDefault.Size = new System.Drawing.Size(429, 285);
            this.tbpDefault.TabIndex = 0;
            this.tbpDefault.Text = "Value (Default)";
            this.tbpDefault.UseVisualStyleBackColor = true;
            // 
            // tabValue
            // 
            this.tabValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabValue.Controls.Add(this.tbpDefault);
            this.tabValue.Controls.Add(this.tbpSmart);
            this.tabValue.Location = new System.Drawing.Point(4, 161);
            this.tabValue.Name = "tabValue";
            this.tabValue.SelectedIndex = 0;
            this.tabValue.Size = new System.Drawing.Size(437, 311);
            this.tabValue.TabIndex = 9;
            // 
            // tabMoreInfo
            // 
            this.tabMoreInfo.Controls.Add(this.txtComments);
            this.tabMoreInfo.Location = new System.Drawing.Point(4, 22);
            this.tabMoreInfo.Name = "tabMoreInfo";
            this.tabMoreInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabMoreInfo.Size = new System.Drawing.Size(429, 117);
            this.tabMoreInfo.TabIndex = 1;
            this.tabMoreInfo.Text = "More Information";
            this.tabMoreInfo.UseVisualStyleBackColor = true;
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(6, 6);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            this.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComments.Size = new System.Drawing.Size(417, 105);
            this.txtComments.TabIndex = 13;
            // 
            // tbcPropertyInfo
            // 
            this.tbcPropertyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcPropertyInfo.Controls.Add(this.tabPropertyDef);
            this.tbcPropertyInfo.Controls.Add(this.tabMoreInfo);
            this.tbcPropertyInfo.Location = new System.Drawing.Point(4, 12);
            this.tbcPropertyInfo.Name = "tbcPropertyInfo";
            this.tbcPropertyInfo.SelectedIndex = 0;
            this.tbcPropertyInfo.Size = new System.Drawing.Size(437, 143);
            this.tbcPropertyInfo.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type:";
            // 
            // lblNames
            // 
            this.lblNames.Location = new System.Drawing.Point(6, 65);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(47, 39);
            this.lblNames.TabIndex = 10;
            this.lblNames.Text = "Known Names:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(50, 14);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(373, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtType
            // 
            this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtType.Location = new System.Drawing.Point(50, 38);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(373, 20);
            this.txtType.TabIndex = 8;
            // 
            // txtKnownNames
            // 
            this.txtKnownNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKnownNames.Location = new System.Drawing.Point(50, 62);
            this.txtKnownNames.Multiline = true;
            this.txtKnownNames.Name = "txtKnownNames";
            this.txtKnownNames.ReadOnly = true;
            this.txtKnownNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKnownNames.Size = new System.Drawing.Size(373, 42);
            this.txtKnownNames.TabIndex = 11;
            // 
            // tabPropertyDef
            // 
            this.tabPropertyDef.Controls.Add(this.txtKnownNames);
            this.tabPropertyDef.Controls.Add(this.txtType);
            this.tabPropertyDef.Controls.Add(this.txtName);
            this.tabPropertyDef.Controls.Add(this.lblNames);
            this.tabPropertyDef.Controls.Add(this.label1);
            this.tabPropertyDef.Controls.Add(this.lblName);
            this.tabPropertyDef.Location = new System.Drawing.Point(4, 22);
            this.tabPropertyDef.Name = "tabPropertyDef";
            this.tabPropertyDef.Padding = new System.Windows.Forms.Padding(3);
            this.tabPropertyDef.Size = new System.Drawing.Size(429, 117);
            this.tabPropertyDef.TabIndex = 0;
            this.tabPropertyDef.Text = "Property Definition";
            this.tabPropertyDef.UseVisualStyleBackColor = true;
            // 
            // PropertyEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(451, 517);
            this.Controls.Add(this.tbcPropertyInfo);
            this.Controls.Add(this.tabValue);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "PropertyEditorDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Property Editor";
            this.Load += new System.EventHandler(this.PropertyEditorDialog_Load);
            this.tbpSmart.ResumeLayout(false);
            this.tabValue.ResumeLayout(false);
            this.tabMoreInfo.ResumeLayout(false);
            this.tabMoreInfo.PerformLayout();
            this.tbcPropertyInfo.ResumeLayout(false);
            this.tabPropertyDef.ResumeLayout(false);
            this.tabPropertyDef.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tbpSmart;
        private System.Windows.Forms.RichTextBox txtSmartView;
        private System.Windows.Forms.TabPage tbpDefault;
        private System.Windows.Forms.TabControl tabValue;
        private System.Windows.Forms.TabPage tabMoreInfo;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TabControl tbcPropertyInfo;
        private System.Windows.Forms.TabPage tabPropertyDef;
        private System.Windows.Forms.TextBox txtKnownNames;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
    }
}
