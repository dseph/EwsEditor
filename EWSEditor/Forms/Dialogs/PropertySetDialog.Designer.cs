namespace EWSEditor.Forms
{
    partial class PropertySetDialog
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
            this.PropertiesGrid = new System.Windows.Forms.DataGridView();
            this.lblProperties = new System.Windows.Forms.Label();
            this.btnAddSchemaProps = new System.Windows.Forms.Button();
            this.btnAddExtProps = new System.Windows.Forms.Button();
            this.btnAddKnownProps = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.TempFilterHtmlCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TempBodyTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TempBasePropertySetCombo = new System.Windows.Forms.ComboBox();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesGrid)).BeginInit();
            this.grpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertiesGrid
            // 
            this.PropertiesGrid.AllowUserToAddRows = false;
            this.PropertiesGrid.AllowUserToDeleteRows = false;
            this.PropertiesGrid.AllowUserToResizeRows = false;
            this.PropertiesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PropertiesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PropertiesGrid.Location = new System.Drawing.Point(18, 214);
            this.PropertiesGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertiesGrid.MultiSelect = false;
            this.PropertiesGrid.Name = "PropertiesGrid";
            this.PropertiesGrid.ReadOnly = true;
            this.PropertiesGrid.RowHeadersVisible = false;
            this.PropertiesGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PropertiesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PropertiesGrid.Size = new System.Drawing.Size(955, 387);
            this.PropertiesGrid.TabIndex = 10;
            this.PropertiesGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.PropertiesGrid_SortCompare);
            // 
            // lblProperties
            // 
            this.lblProperties.Location = new System.Drawing.Point(15, 184);
            this.lblProperties.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProperties.Name = "lblProperties";
            this.lblProperties.Size = new System.Drawing.Size(266, 25);
            this.lblProperties.TabIndex = 1;
            this.lblProperties.Text = "Additional Properties...";
            // 
            // btnAddSchemaProps
            // 
            this.btnAddSchemaProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSchemaProps.Location = new System.Drawing.Point(985, 215);
            this.btnAddSchemaProps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddSchemaProps.Name = "btnAddSchemaProps";
            this.btnAddSchemaProps.Size = new System.Drawing.Size(199, 37);
            this.btnAddSchemaProps.TabIndex = 2;
            this.btnAddSchemaProps.Text = "Add Schema Property";
            this.btnAddSchemaProps.UseVisualStyleBackColor = true;
            this.btnAddSchemaProps.Click += new System.EventHandler(this.BtnAddSchema_Click);
            // 
            // btnAddExtProps
            // 
            this.btnAddExtProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExtProps.Location = new System.Drawing.Point(985, 262);
            this.btnAddExtProps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddExtProps.Name = "btnAddExtProps";
            this.btnAddExtProps.Size = new System.Drawing.Size(199, 37);
            this.btnAddExtProps.TabIndex = 3;
            this.btnAddExtProps.Text = "Add Extended Property";
            this.btnAddExtProps.UseVisualStyleBackColor = true;
            this.btnAddExtProps.Click += new System.EventHandler(this.BtnAddExtended_Click);
            // 
            // btnAddKnownProps
            // 
            this.btnAddKnownProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddKnownProps.Location = new System.Drawing.Point(985, 339);
            this.btnAddKnownProps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddKnownProps.Name = "btnAddKnownProps";
            this.btnAddKnownProps.Size = new System.Drawing.Size(199, 37);
            this.btnAddKnownProps.TabIndex = 4;
            this.btnAddKnownProps.Text = "Add All Known Extended Properties";
            this.btnAddKnownProps.UseVisualStyleBackColor = true;
            this.btnAddKnownProps.Click += new System.EventHandler(this.BtnAddAllProps_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(985, 415);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(199, 37);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Property";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.TempFilterHtmlCombo);
            this.grpBox1.Controls.Add(this.label3);
            this.grpBox1.Controls.Add(this.label2);
            this.grpBox1.Controls.Add(this.TempBodyTypeCombo);
            this.grpBox1.Controls.Add(this.label1);
            this.grpBox1.Controls.Add(this.TempBasePropertySetCombo);
            this.grpBox1.Location = new System.Drawing.Point(15, 16);
            this.grpBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBox1.Size = new System.Drawing.Size(884, 159);
            this.grpBox1.TabIndex = 0;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "Property Set Configuration...";
            // 
            // TempFilterHtmlCombo
            // 
            this.TempFilterHtmlCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempFilterHtmlCombo.FormattingEnabled = true;
            this.TempFilterHtmlCombo.Location = new System.Drawing.Point(216, 75);
            this.TempFilterHtmlCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TempFilterHtmlCombo.Name = "TempFilterHtmlCombo";
            this.TempFilterHtmlCombo.Size = new System.Drawing.Size(659, 28);
            this.TempFilterHtmlCombo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filter HTML Content:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Requested Body Type:";
            // 
            // TempBodyTypeCombo
            // 
            this.TempBodyTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempBodyTypeCombo.FormattingEnabled = true;
            this.TempBodyTypeCombo.Location = new System.Drawing.Point(216, 115);
            this.TempBodyTypeCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TempBodyTypeCombo.Name = "TempBodyTypeCombo";
            this.TempBodyTypeCombo.Size = new System.Drawing.Size(660, 28);
            this.TempBodyTypeCombo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Property Set:";
            // 
            // TempBasePropertySetCombo
            // 
            this.TempBasePropertySetCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempBasePropertySetCombo.FormattingEnabled = true;
            this.TempBasePropertySetCombo.Location = new System.Drawing.Point(216, 35);
            this.TempBasePropertySetCombo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TempBasePropertySetCombo.Name = "TempBasePropertySetCombo";
            this.TempBasePropertySetCombo.Size = new System.Drawing.Size(660, 28);
            this.TempBasePropertySetCombo.TabIndex = 1;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAll.Location = new System.Drawing.Point(985, 462);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(199, 37);
            this.btnRemoveAll.TabIndex = 6;
            this.btnRemoveAll.Text = "Remove All";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(985, 547);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 37);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1097, 547);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 37);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PropertySetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1202, 617);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddKnownProps);
            this.Controls.Add(this.btnAddExtProps);
            this.Controls.Add(this.btnAddSchemaProps);
            this.Controls.Add(this.lblProperties);
            this.Controls.Add(this.PropertiesGrid);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "PropertySetDialog";
            this.Text = "Property Set Editor";
            this.Load += new System.EventHandler(this.PropertySetDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PropertiesGrid)).EndInit();
            this.grpBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PropertiesGrid;
        private System.Windows.Forms.Label lblProperties;
        private System.Windows.Forms.Button btnAddSchemaProps;
        private System.Windows.Forms.Button btnAddExtProps;
        private System.Windows.Forms.Button btnAddKnownProps;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TempBodyTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TempBasePropertySetCombo;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.ComboBox TempFilterHtmlCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}
