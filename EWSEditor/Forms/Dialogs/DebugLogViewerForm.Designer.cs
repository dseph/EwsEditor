namespace EWSEditor.Forms
{
    partial class DebugLogViewerForm
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
            this.ViewControlPanel = new System.Windows.Forms.Panel();
            this.EwsTraceTypeCheck = new System.Windows.Forms.CheckBox();
            this.VerboseTypeCheck = new System.Windows.Forms.CheckBox();
            this.InformationTypeCheck = new System.Windows.Forms.CheckBox();
            this.ErrorTypeCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SplitGroup1 = new System.Windows.Forms.GroupBox();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.LogViewerPanel = new System.Windows.Forms.Panel();
            this.LogViewerContainer = new System.Windows.Forms.SplitContainer();
            this.LogItemsGrid = new System.Windows.Forms.DataGridView();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataViewTabs = new System.Windows.Forms.TabControl();
            this.TextTabPage = new System.Windows.Forms.TabPage();
            this.TextDataViewText = new System.Windows.Forms.TextBox();
            this.WebTagPage = new System.Windows.Forms.TabPage();
            this.WebDataBrowser = new System.Windows.Forms.WebBrowser();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TitleLabelLabel = new System.Windows.Forms.Label();
            this.TypeLabelLabel = new System.Windows.Forms.Label();
            this.SourceLabelLabel = new System.Windows.Forms.Label();
            this.TimeLabelLabel = new System.Windows.Forms.Label();
            this.ViewControlPanel.SuspendLayout();
            this.LogViewerPanel.SuspendLayout();
            this.LogViewerContainer.Panel1.SuspendLayout();
            this.LogViewerContainer.Panel2.SuspendLayout();
            this.LogViewerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogItemsGrid)).BeginInit();
            this.DataViewTabs.SuspendLayout();
            this.TextTabPage.SuspendLayout();
            this.WebTagPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewControlPanel
            // 
            this.ViewControlPanel.Controls.Add(this.EwsTraceTypeCheck);
            this.ViewControlPanel.Controls.Add(this.VerboseTypeCheck);
            this.ViewControlPanel.Controls.Add(this.InformationTypeCheck);
            this.ViewControlPanel.Controls.Add(this.ErrorTypeCheck);
            this.ViewControlPanel.Controls.Add(this.label1);
            this.ViewControlPanel.Controls.Add(this.SplitGroup1);
            this.ViewControlPanel.Controls.Add(this.ReloadButton);
            this.ViewControlPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ViewControlPanel.Location = new System.Drawing.Point(658, 0);
            this.ViewControlPanel.Name = "ViewControlPanel";
            this.ViewControlPanel.Size = new System.Drawing.Size(147, 618);
            this.ViewControlPanel.TabIndex = 6;
            // 
            // EwsTraceTypeCheck
            // 
            this.EwsTraceTypeCheck.AutoSize = true;
            this.EwsTraceTypeCheck.Checked = true;
            this.EwsTraceTypeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EwsTraceTypeCheck.Location = new System.Drawing.Point(21, 123);
            this.EwsTraceTypeCheck.Name = "EwsTraceTypeCheck";
            this.EwsTraceTypeCheck.Size = new System.Drawing.Size(74, 17);
            this.EwsTraceTypeCheck.TabIndex = 11;
            this.EwsTraceTypeCheck.Text = "EwsTrace";
            this.EwsTraceTypeCheck.UseVisualStyleBackColor = true;
            // 
            // VerboseTypeCheck
            // 
            this.VerboseTypeCheck.AutoSize = true;
            this.VerboseTypeCheck.Checked = true;
            this.VerboseTypeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VerboseTypeCheck.Location = new System.Drawing.Point(21, 100);
            this.VerboseTypeCheck.Name = "VerboseTypeCheck";
            this.VerboseTypeCheck.Size = new System.Drawing.Size(65, 17);
            this.VerboseTypeCheck.TabIndex = 10;
            this.VerboseTypeCheck.Text = "Verbose";
            this.VerboseTypeCheck.UseVisualStyleBackColor = true;
            // 
            // InformationTypeCheck
            // 
            this.InformationTypeCheck.AutoSize = true;
            this.InformationTypeCheck.Checked = true;
            this.InformationTypeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InformationTypeCheck.Location = new System.Drawing.Point(21, 77);
            this.InformationTypeCheck.Name = "InformationTypeCheck";
            this.InformationTypeCheck.Size = new System.Drawing.Size(78, 17);
            this.InformationTypeCheck.TabIndex = 9;
            this.InformationTypeCheck.Text = "Information";
            this.InformationTypeCheck.UseVisualStyleBackColor = true;
            // 
            // ErrorTypeCheck
            // 
            this.ErrorTypeCheck.AutoSize = true;
            this.ErrorTypeCheck.Checked = true;
            this.ErrorTypeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ErrorTypeCheck.Location = new System.Drawing.Point(21, 54);
            this.ErrorTypeCheck.Name = "ErrorTypeCheck";
            this.ErrorTypeCheck.Size = new System.Drawing.Size(48, 17);
            this.ErrorTypeCheck.TabIndex = 8;
            this.ErrorTypeCheck.Text = "Error";
            this.ErrorTypeCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Show only the following log types...";
            // 
            // SplitGroup1
            // 
            this.SplitGroup1.Location = new System.Drawing.Point(9, 146);
            this.SplitGroup1.Name = "SplitGroup1";
            this.SplitGroup1.Size = new System.Drawing.Size(129, 10);
            this.SplitGroup1.TabIndex = 6;
            this.SplitGroup1.TabStop = false;
            // 
            // ReloadButton
            // 
            this.ReloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadButton.Location = new System.Drawing.Point(36, 165);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(75, 23);
            this.ReloadButton.TabIndex = 5;
            this.ReloadButton.Text = "Refresh";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // LogViewerPanel
            // 
            this.LogViewerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LogViewerPanel.Controls.Add(this.LogViewerContainer);
            this.LogViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewerPanel.Location = new System.Drawing.Point(0, 0);
            this.LogViewerPanel.Name = "LogViewerPanel";
            this.LogViewerPanel.Size = new System.Drawing.Size(658, 618);
            this.LogViewerPanel.TabIndex = 7;
            // 
            // LogViewerContainer
            // 
            this.LogViewerContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LogViewerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewerContainer.Location = new System.Drawing.Point(0, 0);
            this.LogViewerContainer.Name = "LogViewerContainer";
            this.LogViewerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LogViewerContainer.Panel1
            // 
            this.LogViewerContainer.Panel1.Controls.Add(this.LogItemsGrid);
            // 
            // LogViewerContainer.Panel2
            // 
            this.LogViewerContainer.Panel2.Controls.Add(this.DataViewTabs);
            this.LogViewerContainer.Panel2.Controls.Add(this.TitleLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.SourceLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.TypeLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.TimeLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.TitleLabelLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.TypeLabelLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.SourceLabelLabel);
            this.LogViewerContainer.Panel2.Controls.Add(this.TimeLabelLabel);
            this.LogViewerContainer.Size = new System.Drawing.Size(656, 616);
            this.LogViewerContainer.SplitterDistance = 266;
            this.LogViewerContainer.TabIndex = 0;
            // 
            // LogItemsGrid
            // 
            this.LogItemsGrid.AllowUserToAddRows = false;
            this.LogItemsGrid.AllowUserToDeleteRows = false;
            this.LogItemsGrid.AllowUserToResizeRows = false;
            this.LogItemsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogItemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeColumn,
            this.SourceColumn,
            this.TypeColumn,
            this.TitleColumn});
            this.LogItemsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogItemsGrid.Location = new System.Drawing.Point(0, 0);
            this.LogItemsGrid.MultiSelect = false;
            this.LogItemsGrid.Name = "LogItemsGrid";
            this.LogItemsGrid.ReadOnly = true;
            this.LogItemsGrid.RowHeadersVisible = false;
            this.LogItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LogItemsGrid.Size = new System.Drawing.Size(652, 262);
            this.LogItemsGrid.TabIndex = 0;
            this.LogItemsGrid.SelectionChanged += new System.EventHandler(this.LogItemsGrid_SelectionChanged);
            // 
            // TimeColumn
            // 
            this.TimeColumn.HeaderText = "Time";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            this.TimeColumn.Width = 150;
            // 
            // SourceColumn
            // 
            this.SourceColumn.HeaderText = "Source";
            this.SourceColumn.Name = "SourceColumn";
            this.SourceColumn.ReadOnly = true;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            // 
            // TitleColumn
            // 
            this.TitleColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TitleColumn.HeaderText = "Title";
            this.TitleColumn.Name = "TitleColumn";
            this.TitleColumn.ReadOnly = true;
            // 
            // DataViewTabs
            // 
            this.DataViewTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DataViewTabs.Controls.Add(this.TextTabPage);
            this.DataViewTabs.Controls.Add(this.WebTagPage);
            this.DataViewTabs.Location = new System.Drawing.Point(16, 68);
            this.DataViewTabs.Name = "DataViewTabs";
            this.DataViewTabs.SelectedIndex = 0;
            this.DataViewTabs.Size = new System.Drawing.Size(636, 265);
            this.DataViewTabs.TabIndex = 9;
            // 
            // TextTabPage
            // 
            this.TextTabPage.Controls.Add(this.TextDataViewText);
            this.TextTabPage.Location = new System.Drawing.Point(4, 22);
            this.TextTabPage.Name = "TextTabPage";
            this.TextTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TextTabPage.Size = new System.Drawing.Size(628, 239);
            this.TextTabPage.TabIndex = 0;
            this.TextTabPage.Text = "Text View";
            this.TextTabPage.UseVisualStyleBackColor = true;
            // 
            // TextDataViewText
            // 
            this.TextDataViewText.BackColor = System.Drawing.SystemColors.Control;
            this.TextDataViewText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextDataViewText.Location = new System.Drawing.Point(3, 3);
            this.TextDataViewText.Multiline = true;
            this.TextDataViewText.Name = "TextDataViewText";
            this.TextDataViewText.ReadOnly = true;
            this.TextDataViewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextDataViewText.Size = new System.Drawing.Size(622, 233);
            this.TextDataViewText.TabIndex = 1;
            // 
            // WebTagPage
            // 
            this.WebTagPage.Controls.Add(this.WebDataBrowser);
            this.WebTagPage.Location = new System.Drawing.Point(4, 22);
            this.WebTagPage.Name = "WebTagPage";
            this.WebTagPage.Padding = new System.Windows.Forms.Padding(3);
            this.WebTagPage.Size = new System.Drawing.Size(628, 239);
            this.WebTagPage.TabIndex = 1;
            this.WebTagPage.Text = "XML View";
            this.WebTagPage.UseVisualStyleBackColor = true;
            // 
            // WebDataBrowser
            // 
            this.WebDataBrowser.AllowWebBrowserDrop = false;
            this.WebDataBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebDataBrowser.Location = new System.Drawing.Point(3, 3);
            this.WebDataBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebDataBrowser.Name = "WebDataBrowser";
            this.WebDataBrowser.ScriptErrorsSuppressed = true;
            this.WebDataBrowser.Size = new System.Drawing.Size(781, 255);
            this.WebDataBrowser.TabIndex = 0;
            this.WebDataBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TitleLabel.Location = new System.Drawing.Point(98, 42);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(540, 23);
            this.TitleLabel.TabIndex = 8;
            // 
            // SourceLabel
            // 
            this.SourceLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SourceLabel.Location = new System.Drawing.Point(250, 12);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(196, 23);
            this.SourceLabel.TabIndex = 7;
            // 
            // TypeLabel
            // 
            this.TypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TypeLabel.Location = new System.Drawing.Point(537, 13);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(100, 23);
            this.TypeLabel.TabIndex = 6;
            // 
            // TimeLabel
            // 
            this.TimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TimeLabel.Location = new System.Drawing.Point(98, 13);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(100, 23);
            this.TimeLabel.TabIndex = 5;
            // 
            // TitleLabelLabel
            // 
            this.TitleLabelLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabelLabel.Location = new System.Drawing.Point(13, 43);
            this.TitleLabelLabel.Name = "TitleLabelLabel";
            this.TitleLabelLabel.Size = new System.Drawing.Size(30, 13);
            this.TitleLabelLabel.TabIndex = 4;
            this.TitleLabelLabel.Text = "Title:";
            // 
            // TypeLabelLabel
            // 
            this.TypeLabelLabel.Location = new System.Drawing.Point(452, 13);
            this.TypeLabelLabel.Name = "TypeLabelLabel";
            this.TypeLabelLabel.Size = new System.Drawing.Size(55, 13);
            this.TypeLabelLabel.TabIndex = 3;
            this.TypeLabelLabel.Text = "Log Type:";
            // 
            // SourceLabelLabel
            // 
            this.SourceLabelLabel.Location = new System.Drawing.Point(204, 14);
            this.SourceLabelLabel.Name = "SourceLabelLabel";
            this.SourceLabelLabel.Size = new System.Drawing.Size(44, 13);
            this.SourceLabelLabel.TabIndex = 2;
            this.SourceLabelLabel.Text = "Source:";
            // 
            // TimeLabelLabel
            // 
            this.TimeLabelLabel.Location = new System.Drawing.Point(13, 13);
            this.TimeLabelLabel.Name = "TimeLabelLabel";
            this.TimeLabelLabel.Size = new System.Drawing.Size(66, 13);
            this.TimeLabelLabel.TabIndex = 1;
            this.TimeLabelLabel.Text = "Time of Log:";
            // 
            // DebugLogViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 618);
            this.Controls.Add(this.LogViewerPanel);
            this.Controls.Add(this.ViewControlPanel);
            this.Name = "DebugLogViewerForm";
            this.Text = "Debug Log Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DebugLogViewerForm_FormClosed);
            this.Load += new System.EventHandler(this.DebugLogViewerForm_Load);
            this.ViewControlPanel.ResumeLayout(false);
            this.ViewControlPanel.PerformLayout();
            this.LogViewerPanel.ResumeLayout(false);
            this.LogViewerContainer.Panel1.ResumeLayout(false);
            this.LogViewerContainer.Panel2.ResumeLayout(false);
            this.LogViewerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogItemsGrid)).EndInit();
            this.DataViewTabs.ResumeLayout(false);
            this.TextTabPage.ResumeLayout(false);
            this.TextTabPage.PerformLayout();
            this.WebTagPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ViewControlPanel;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Panel LogViewerPanel;
        private System.Windows.Forms.SplitContainer LogViewerContainer;
        private System.Windows.Forms.DataGridView LogItemsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleColumn;
        private System.Windows.Forms.TabControl DataViewTabs;
        private System.Windows.Forms.TabPage TextTabPage;
        private System.Windows.Forms.TextBox TextDataViewText;
        private System.Windows.Forms.TabPage WebTagPage;
        private System.Windows.Forms.WebBrowser WebDataBrowser;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label TitleLabelLabel;
        private System.Windows.Forms.Label TypeLabelLabel;
        private System.Windows.Forms.Label SourceLabelLabel;
        private System.Windows.Forms.Label TimeLabelLabel;
        private System.Windows.Forms.GroupBox SplitGroup1;
        private System.Windows.Forms.CheckBox EwsTraceTypeCheck;
        private System.Windows.Forms.CheckBox VerboseTypeCheck;
        private System.Windows.Forms.CheckBox InformationTypeCheck;
        private System.Windows.Forms.CheckBox ErrorTypeCheck;
        private System.Windows.Forms.Label label1;

    }
}

