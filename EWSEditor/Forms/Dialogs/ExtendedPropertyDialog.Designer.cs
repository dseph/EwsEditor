namespace EWSEditor.Forms
{
    partial class ExtendedPropertyDialog
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
            this.OKButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TempPropertyTypeCombo = new System.Windows.Forms.ComboBox();
            this.grpIdentifier = new System.Windows.Forms.GroupBox();
            this.NamedPropRadio = new System.Windows.Forms.RadioButton();
            this.TagRadio = new System.Windows.Forms.RadioButton();
            this.TempExtendedPropertySetComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PropertyNameOrIdText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PropTagText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpType = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKnownNames = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.KnownNameText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpIdentifier.SuspendLayout();
            this.grpType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(306, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(225, 449);
            this.OKButton.Name = "btnOK";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Property Type:";
            // 
            // cboDataType
            // 
            this.TempPropertyTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempPropertyTypeCombo.FormattingEnabled = true;
            this.TempPropertyTypeCombo.Location = new System.Drawing.Point(150, 35);
            this.TempPropertyTypeCombo.Name = "cboDataType";
            this.TempPropertyTypeCombo.Size = new System.Drawing.Size(211, 21);
            this.TempPropertyTypeCombo.TabIndex = 0;
            this.TempPropertyTypeCombo.Leave += new System.EventHandler(this.PropertyDefinitionControl_Leave);
            // 
            // grpIdentifier
            // 
            this.grpIdentifier.Controls.Add(this.NamedPropRadio);
            this.grpIdentifier.Controls.Add(this.TagRadio);
            this.grpIdentifier.Controls.Add(this.TempExtendedPropertySetComboBox);
            this.grpIdentifier.Controls.Add(this.label5);
            this.grpIdentifier.Controls.Add(this.PropertyNameOrIdText);
            this.grpIdentifier.Controls.Add(this.label4);
            this.grpIdentifier.Controls.Add(this.PropTagText);
            this.grpIdentifier.Controls.Add(this.label1);
            this.grpIdentifier.Location = new System.Drawing.Point(9, 65);
            this.grpIdentifier.Name = "grpIdentifier";
            this.grpIdentifier.Size = new System.Drawing.Size(372, 179);
            this.grpIdentifier.TabIndex = 1;
            this.grpIdentifier.TabStop = false;
            this.grpIdentifier.Text = "Property Identifier";
            // 
            // rdoNamedProp
            // 
            this.NamedPropRadio.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.NamedPropRadio.Location = new System.Drawing.Point(10, 70);
            this.NamedPropRadio.Name = "rdoNamedProp";
            this.NamedPropRadio.Size = new System.Drawing.Size(349, 30);
            this.NamedPropRadio.TabIndex = 37;
            this.NamedPropRadio.Text = "Use a named property name or Id along with a property set to identify the extende" +
                "d property.";
            this.NamedPropRadio.UseVisualStyleBackColor = true;
            this.NamedPropRadio.CheckedChanged += new System.EventHandler(this.NamedPropRadio_CheckedChanged);
            // 
            // rdoTag
            // 
            this.TagRadio.AutoSize = true;
            this.TagRadio.Checked = true;
            this.TagRadio.Location = new System.Drawing.Point(10, 20);
            this.TagRadio.Name = "rdoTag";
            this.TagRadio.Size = new System.Drawing.Size(269, 17);
            this.TagRadio.TabIndex = 36;
            this.TagRadio.TabStop = true;
            this.TagRadio.Text = "Use a property tag to identify the extended property.";
            this.TagRadio.UseVisualStyleBackColor = true;
            this.TagRadio.CheckedChanged += new System.EventHandler(this.TagRadio_CheckedChanged);
            // 
            // cboExPropSet
            // 
            this.TempExtendedPropertySetComboBox.Enabled = false;
            this.TempExtendedPropertySetComboBox.FormattingEnabled = true;
            this.TempExtendedPropertySetComboBox.Location = new System.Drawing.Point(149, 137);
            this.TempExtendedPropertySetComboBox.Name = "cboExPropSet";
            this.TempExtendedPropertySetComboBox.Size = new System.Drawing.Size(211, 21);
            this.TempExtendedPropertySetComboBox.TabIndex = 2;
            this.TempExtendedPropertySetComboBox.Leave += new System.EventHandler(this.PropertyDefinitionControl_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Property Set:";
            // 
            // txtNamedPropName
            // 
            this.PropertyNameOrIdText.Enabled = false;
            this.PropertyNameOrIdText.Location = new System.Drawing.Point(149, 106);
            this.PropertyNameOrIdText.Name = "txtNamedPropName";
            this.PropertyNameOrIdText.Size = new System.Drawing.Size(211, 20);
            this.PropertyNameOrIdText.TabIndex = 1;
            this.PropertyNameOrIdText.Leave += new System.EventHandler(this.PropertyDefinitionControl_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Name or ID:";
            // 
            // txtPropTag
            // 
            this.PropTagText.Location = new System.Drawing.Point(149, 44);
            this.PropTagText.Name = "txtPropTag";
            this.PropTagText.Size = new System.Drawing.Size(211, 20);
            this.PropTagText.TabIndex = 0;
            this.PropTagText.Leave += new System.EventHandler(this.PropertyDefinitionControl_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Property Tag:";
            // 
            // grpType
            // 
            this.grpType.Controls.Add(this.lblType);
            this.grpType.Controls.Add(this.label2);
            this.grpType.Controls.Add(this.TempPropertyTypeCombo);
            this.grpType.Location = new System.Drawing.Point(9, 250);
            this.grpType.Name = "grpType";
            this.grpType.Size = new System.Drawing.Size(372, 73);
            this.grpType.TabIndex = 2;
            this.grpType.TabStop = false;
            this.grpType.Text = "Property Type";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(10, 20);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(217, 13);
            this.lblType.TabIndex = 22;
            this.lblType.Text = "Select a data type for the extended property.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKnownNames);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(9, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alternate Known Names";
            // 
            // txtKnownNames
            // 
            this.txtKnownNames.Location = new System.Drawing.Point(13, 42);
            this.txtKnownNames.Multiline = true;
            this.txtKnownNames.Name = "txtKnownNames";
            this.txtKnownNames.ReadOnly = true;
            this.txtKnownNames.Size = new System.Drawing.Size(348, 63);
            this.txtKnownNames.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(293, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "This property definition is also known by the following names:";
            // 
            // txtKnownName
            // 
            this.KnownNameText.Location = new System.Drawing.Point(156, 30);
            this.KnownNameText.Name = "txtKnownName";
            this.KnownNameText.Size = new System.Drawing.Size(211, 20);
            this.KnownNameText.TabIndex = 0;
            this.KnownNameText.TextChanged += new System.EventHandler(this.KnownNameText_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Lookup extended property definition by known name.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Known Name:";
            // 
            // ExtendedPropertyDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 484);
            this.Controls.Add(this.KnownNameText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpType);
            this.Controls.Add(this.grpIdentifier);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.OKButton);
            this.Name = "ExtendedPropertyDialog";
            this.Text = "EWS Editor - Extended Property Definition";
            this.Load += new System.EventHandler(this.ExtendedPropertyDialog_Load);
            this.grpIdentifier.ResumeLayout(false);
            this.grpIdentifier.PerformLayout();
            this.grpType.ResumeLayout(false);
            this.grpType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TempPropertyTypeCombo;
        private System.Windows.Forms.GroupBox grpIdentifier;
        private System.Windows.Forms.ComboBox TempExtendedPropertySetComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PropertyNameOrIdText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PropTagText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TagRadio;
        private System.Windows.Forms.RadioButton NamedPropRadio;
        private System.Windows.Forms.GroupBox grpType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKnownNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox KnownNameText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}