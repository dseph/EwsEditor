namespace EWSEditor.Forms.Controls
{
    partial class PropertyDetialsGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PropertyListDataGridView = new System.Windows.Forms.DataGridView();
            this.PropIconColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KnownNamesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmartViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyClassColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SortNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propertyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridDataTables = new EWSEditor.Forms.Controls.GridDataTables();
            this.mnuPropertyContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PropertyListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataTables)).BeginInit();
            this.mnuPropertyContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyListDataGridView
            // 
            this.PropertyListDataGridView.AllowUserToAddRows = false;
            this.PropertyListDataGridView.AllowUserToResizeRows = false;
            this.PropertyListDataGridView.AutoGenerateColumns = false;
            this.PropertyListDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.PropertyListDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.PropertyListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PropertyListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PropIconColumn,
            this.NameColumn,
            this.KnownNamesColumn,
            this.TypeColumn,
            this.ValueColumn,
            this.SmartViewColumn,
            this.PropertyClassColumn,
            this.SortNameColumn});
            this.PropertyListDataGridView.DataSource = this.propertyListBindingSource;
            this.PropertyListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyListDataGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.PropertyListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PropertyListDataGridView.MultiSelect = false;
            this.PropertyListDataGridView.Name = "PropertyListDataGridView";
            this.PropertyListDataGridView.ReadOnly = true;
            this.PropertyListDataGridView.RowHeadersVisible = false;
            this.PropertyListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PropertyListDataGridView.ShowEditingIcon = false;
            this.PropertyListDataGridView.Size = new System.Drawing.Size(678, 431);
            this.PropertyListDataGridView.TabIndex = 1;
            this.PropertyListDataGridView.Sorted += new System.EventHandler(this.PropertyListDataGridView_Sorted);
            this.PropertyListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PropertyListDataGridView_CellDoubleClick);
            this.PropertyListDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PropertyListDataGridView_ColumnHeaderMouseClick);
            this.PropertyListDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.PropertyListDataGridView_RowsAdded);
            this.PropertyListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.PropertyListDataGridView_DataError);
            // 
            // PropIconColumn
            // 
            this.PropIconColumn.DataPropertyName = "Icon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = "System.Drawing.Bitmap";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.PropIconColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.PropIconColumn.HeaderText = "";
            this.PropIconColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.PropIconColumn.Name = "PropIconColumn";
            this.PropIconColumn.ReadOnly = true;
            this.PropIconColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PropIconColumn.Width = 25;
            // 
            // NameColumn
            // 
            this.NameColumn.DataPropertyName = "Name";
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.NameColumn.Width = 150;
            // 
            // KnownNamesColumn
            // 
            this.KnownNamesColumn.DataPropertyName = "KnownNames";
            this.KnownNamesColumn.HeaderText = "KnownNames";
            this.KnownNamesColumn.Name = "KnownNamesColumn";
            this.KnownNamesColumn.ReadOnly = true;
            this.KnownNamesColumn.Width = 150;
            // 
            // TypeColumn
            // 
            this.TypeColumn.DataPropertyName = "Type";
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 150;
            // 
            // ValueColumn
            // 
            this.ValueColumn.DataPropertyName = "Value";
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.Width = 150;
            // 
            // SmartViewColumn
            // 
            this.SmartViewColumn.DataPropertyName = "SmartView";
            this.SmartViewColumn.HeaderText = "Value - Smart View";
            this.SmartViewColumn.Name = "SmartViewColumn";
            this.SmartViewColumn.ReadOnly = true;
            this.SmartViewColumn.Width = 150;
            // 
            // PropertyClassColumn
            // 
            this.PropertyClassColumn.DataPropertyName = "PropertyClass";
            this.PropertyClassColumn.HeaderText = "PropertyClass";
            this.PropertyClassColumn.Name = "PropertyClassColumn";
            this.PropertyClassColumn.ReadOnly = true;
            this.PropertyClassColumn.Visible = false;
            // 
            // SortNameColumn
            // 
            this.SortNameColumn.DataPropertyName = "SortName";
            this.SortNameColumn.HeaderText = "SortName";
            this.SortNameColumn.Name = "SortNameColumn";
            this.SortNameColumn.ReadOnly = true;
            this.SortNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SortNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SortNameColumn.Visible = false;
            // 
            // propertyListBindingSource
            // 
            this.propertyListBindingSource.DataMember = "PropertyList";
            this.propertyListBindingSource.DataSource = this.gridDataTables;
            // 
            // gridDataTables
            // 
            this.gridDataTables.DataSetName = "GridDataTables";
            this.gridDataTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mnuPropertyContext
            // 
            this.mnuPropertyContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditProperty,
            this.mnuRemoveProperty});
            this.mnuPropertyContext.Name = "mnuProp";
            this.mnuPropertyContext.Size = new System.Drawing.Size(166, 70);
            // 
            // mnuEditProperty
            // 
            this.mnuEditProperty.Name = "mnuEditProperty";
            this.mnuEditProperty.Size = new System.Drawing.Size(165, 22);
            this.mnuEditProperty.Text = "Edit Property...";
            this.mnuEditProperty.Click += new System.EventHandler(this.mnuEditProperty_Click);
            // 
            // mnuRemoveProperty
            // 
            this.mnuRemoveProperty.Name = "mnuRemoveProperty";
            this.mnuRemoveProperty.Size = new System.Drawing.Size(165, 22);
            this.mnuRemoveProperty.Text = "Remove Property";
            this.mnuRemoveProperty.Click += new System.EventHandler(this.mnuRemoveProperty_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "PropertyIcon";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PropertyType";
            this.dataGridViewTextBoxColumn1.HeaderText = "PropertyType";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // PropertyDetialsGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PropertyListDataGridView);
            this.Name = "PropertyDetialsGrid";
            this.Size = new System.Drawing.Size(678, 431);
            ((System.ComponentModel.ISupportInitialize)(this.PropertyListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.propertyListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataTables)).EndInit();
            this.mnuPropertyContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PropertyListDataGridView;
        private System.Windows.Forms.BindingSource propertyListBindingSource;
        private Controls.GridDataTables gridDataTables;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ContextMenuStrip mnuPropertyContext;
        private System.Windows.Forms.ToolStripMenuItem mnuEditProperty;
        private System.Windows.Forms.DataGridViewImageColumn PropIconColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KnownNamesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SmartViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PropertyClassColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortNameColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveProperty;
    }
}
