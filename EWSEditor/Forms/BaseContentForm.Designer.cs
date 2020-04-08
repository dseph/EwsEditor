namespace EWSEditor.Forms
{
    partial class BaseContentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseContentForm));
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.ContentsGrid = new System.Windows.Forms.DataGridView();
            this.TestColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropertyDetailsGrid = new EWSEditor.Forms.Controls.PropertyDetialsGrid();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(0, 33);
            this.Splitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Splitter.Name = "splitter";
            this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.ContentsGrid);
            // 
            // splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.PropertyDetailsGrid);
            this.Splitter.Size = new System.Drawing.Size(1129, 628);
            this.Splitter.SplitterDistance = 299;
            this.Splitter.SplitterWidth = 6;
            this.Splitter.TabIndex = 5;
            // 
            // ContentsGrid
            // 
            this.ContentsGrid.AllowUserToAddRows = false;
            this.ContentsGrid.AllowUserToDeleteRows = false;
            this.ContentsGrid.AllowUserToOrderColumns = true;
            this.ContentsGrid.AllowUserToResizeRows = false;
            this.ContentsGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ContentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContentsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestColumn});
            this.ContentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ContentsGrid.Location = new System.Drawing.Point(0, 0);
            this.ContentsGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ContentsGrid.MultiSelect = false;
            this.ContentsGrid.Name = "ContentsGrid";
            this.ContentsGrid.ReadOnly = true;
            this.ContentsGrid.RowHeadersVisible = false;
            this.ContentsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ContentsGrid.Size = new System.Drawing.Size(1129, 299);
            this.ContentsGrid.TabIndex = 1;
            this.ContentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ContentsGrid_CellContentClick);
            this.ContentsGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ContentsGrid_CellMouseClick);
            this.ContentsGrid.SelectionChanged += new System.EventHandler(this.ContentsGrid_SelectionChanged);
            this.ContentsGrid.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.ContentsGrid_SortCompare);
            // 
            // TestColumn
            // 
            this.TestColumn.HeaderText = ".";
            this.TestColumn.Name = "TestColumn";
            this.TestColumn.ReadOnly = true;
            // 
            // PropertyDetailsGrid
            // 
            this.PropertyDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyDetailsGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyDetailsGrid.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.PropertyDetailsGrid.Name = "PropertyDetailsGrid";
            this.PropertyDetailsGrid.Size = new System.Drawing.Size(1129, 323);
            this.PropertyDetailsGrid.TabIndex = 1;
            // 
            // BaseContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 683);
            this.Controls.Add(this.Splitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.Name = "BaseContentForm";
            this.Load += new System.EventHandler(this.BaseContentForm_Load);
            this.Controls.SetChildIndex(this.Splitter, 0);
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.SplitContainer Splitter;
        protected System.Windows.Forms.DataGridView ContentsGrid;
        protected EWSEditor.Forms.Controls.PropertyDetialsGrid PropertyDetailsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestColumn;



    }
}