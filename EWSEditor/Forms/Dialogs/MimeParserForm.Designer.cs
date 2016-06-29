namespace EWSEditor
{
    partial class MimeParserForm
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
            this.components = new System.ComponentModel.Container();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtStream = new System.Windows.Forms.RichTextBox();
            this.cmsBPStream = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPStream_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPStream_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtEncoded = new System.Windows.Forms.RichTextBox();
            this.cmsBPEncStream = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPEncStream_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPEncStream_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDecoded = new System.Windows.Forms.RichTextBox();
            this.cmsBPDecStream = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPDecStream_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsBPDecStream_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMime = new System.Windows.Forms.RichTextBox();
            this.cmsMime = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMime_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsMime_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.cmsBPTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveBodypartToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveEncodedBodypartStreamToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDecodedBodypartStreamToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBodypartStreamToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdLoad = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.ListView2 = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label5 = new System.Windows.Forms.Label();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.btnLoadTextEntry = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.CmBpTree = new System.Windows.Forms.ContextMenu();
            this.mnuSaveBodyPartToFile = new System.Windows.Forms.MenuItem();
            this.mnuSaveEncodedBodyPartToFile = new System.Windows.Forms.MenuItem();
            this.mnuSaveDecodedBodyPartToFile = new System.Windows.Forms.MenuItem();
            this.mnuSaveBodyPartStreamToFile = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.wbView = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.cmsBPStream.SuspendLayout();
            this.cmsBPEncStream.SuspendLayout();
            this.cmsBPDecStream.SuspendLayout();
            this.cmsMime.SuspendLayout();
            this.cmsBPTree.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Location = new System.Drawing.Point(8, 10);
            this.Label7.Margin = new System.Windows.Forms.Padding(0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(230, 21);
            this.Label7.TabIndex = 53;
            this.Label7.Text = "Bodypart Stream";
            // 
            // txtStream
            // 
            this.txtStream.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStream.ContextMenuStrip = this.cmsBPStream;
            this.txtStream.HideSelection = false;
            this.txtStream.Location = new System.Drawing.Point(12, 35);
            this.txtStream.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStream.Name = "txtStream";
            this.txtStream.Size = new System.Drawing.Size(770, 79);
            this.txtStream.TabIndex = 54;
            this.txtStream.Text = "";
            // 
            // cmsBPStream
            // 
            this.cmsBPStream.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsBPStream.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator3,
            this.cmsBPStream_Copy,
            this.ToolStripSeparator4,
            this.cmsBPStream_SelectAll});
            this.cmsBPStream.Name = "cmsRequest";
            this.cmsBPStream.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsBPStream.ShowCheckMargin = true;
            this.cmsBPStream.ShowImageMargin = false;
            this.cmsBPStream.Size = new System.Drawing.Size(147, 68);
            this.cmsBPStream.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBPStream_Opening);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPStream_Copy
            // 
            this.cmsBPStream_Copy.Name = "cmsBPStream_Copy";
            this.cmsBPStream_Copy.Size = new System.Drawing.Size(146, 26);
            this.cmsBPStream_Copy.Text = "Copy";
            this.cmsBPStream_Copy.Click += new System.EventHandler(this.cmsBPStream_Copy_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPStream_SelectAll
            // 
            this.cmsBPStream_SelectAll.Name = "cmsBPStream_SelectAll";
            this.cmsBPStream_SelectAll.Size = new System.Drawing.Size(146, 26);
            this.cmsBPStream_SelectAll.Text = "Select All";
            this.cmsBPStream_SelectAll.Click += new System.EventHandler(this.cmsBPStream_SelectAll_Click);
            // 
            // txtEncoded
            // 
            this.txtEncoded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEncoded.ContextMenuStrip = this.cmsBPEncStream;
            this.txtEncoded.HideSelection = false;
            this.txtEncoded.Location = new System.Drawing.Point(12, 142);
            this.txtEncoded.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEncoded.Name = "txtEncoded";
            this.txtEncoded.Size = new System.Drawing.Size(770, 71);
            this.txtEncoded.TabIndex = 56;
            this.txtEncoded.Text = "";
            // 
            // cmsBPEncStream
            // 
            this.cmsBPEncStream.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsBPEncStream.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator5,
            this.cmsBPEncStream_Copy,
            this.ToolStripSeparator6,
            this.cmsBPEncStream_SelectAll});
            this.cmsBPEncStream.Name = "cmsRequest";
            this.cmsBPEncStream.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsBPEncStream.ShowCheckMargin = true;
            this.cmsBPEncStream.ShowImageMargin = false;
            this.cmsBPEncStream.Size = new System.Drawing.Size(147, 68);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPEncStream_Copy
            // 
            this.cmsBPEncStream_Copy.Name = "cmsBPEncStream_Copy";
            this.cmsBPEncStream_Copy.Size = new System.Drawing.Size(146, 26);
            this.cmsBPEncStream_Copy.Text = "Copy";
            this.cmsBPEncStream_Copy.Click += new System.EventHandler(this.cmsBPEncStream_Copy_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPEncStream_SelectAll
            // 
            this.cmsBPEncStream_SelectAll.Name = "cmsBPEncStream_SelectAll";
            this.cmsBPEncStream_SelectAll.Size = new System.Drawing.Size(146, 26);
            this.cmsBPEncStream_SelectAll.Text = "Select All";
            this.cmsBPEncStream_SelectAll.Click += new System.EventHandler(this.cmsBPEncStream_SelectAll_Click);
            // 
            // txtDecoded
            // 
            this.txtDecoded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDecoded.ContextMenuStrip = this.cmsBPDecStream;
            this.txtDecoded.HideSelection = false;
            this.txtDecoded.Location = new System.Drawing.Point(12, 242);
            this.txtDecoded.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDecoded.Name = "txtDecoded";
            this.txtDecoded.Size = new System.Drawing.Size(770, 60);
            this.txtDecoded.TabIndex = 58;
            this.txtDecoded.Text = "";
            // 
            // cmsBPDecStream
            // 
            this.cmsBPDecStream.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsBPDecStream.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator7,
            this.cmsBPDecStream_Copy,
            this.ToolStripSeparator8,
            this.cmsBPDecStream_SelectAll});
            this.cmsBPDecStream.Name = "cmsRequest";
            this.cmsBPDecStream.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsBPDecStream.ShowCheckMargin = true;
            this.cmsBPDecStream.ShowImageMargin = false;
            this.cmsBPDecStream.Size = new System.Drawing.Size(147, 68);
            this.cmsBPDecStream.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBPDecStream_Opening);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPDecStream_Copy
            // 
            this.cmsBPDecStream_Copy.Name = "cmsBPDecStream_Copy";
            this.cmsBPDecStream_Copy.Size = new System.Drawing.Size(146, 26);
            this.cmsBPDecStream_Copy.Text = "Copy";
            this.cmsBPDecStream_Copy.Click += new System.EventHandler(this.cmsBPDecStream_Copy_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsBPDecStream_SelectAll
            // 
            this.cmsBPDecStream_SelectAll.Name = "cmsBPDecStream_SelectAll";
            this.cmsBPDecStream_SelectAll.Size = new System.Drawing.Size(146, 26);
            this.cmsBPDecStream_SelectAll.Text = "Select All";
            this.cmsBPDecStream_SelectAll.Click += new System.EventHandler(this.cmsBPDecStream_SelectAll_Click);
            // 
            // txtMime
            // 
            this.txtMime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMime.ContextMenuStrip = this.cmsMime;
            this.txtMime.HideSelection = false;
            this.txtMime.Location = new System.Drawing.Point(9, 6);
            this.txtMime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMime.Name = "txtMime";
            this.txtMime.Size = new System.Drawing.Size(778, 293);
            this.txtMime.TabIndex = 46;
            this.txtMime.Text = "";
            this.txtMime.TextChanged += new System.EventHandler(this.txtMime_TextChanged);
            // 
            // cmsMime
            // 
            this.cmsMime.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsMime.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator1,
            this.cmsMime_Copy,
            this.ToolStripSeparator2,
            this.cmsMime_SelectAll});
            this.cmsMime.Name = "cmsRequest";
            this.cmsMime.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMime.ShowCheckMargin = true;
            this.cmsMime.ShowImageMargin = false;
            this.cmsMime.Size = new System.Drawing.Size(147, 68);
            this.cmsMime.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMime_Opening);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsMime_Copy
            // 
            this.cmsMime_Copy.Name = "cmsMime_Copy";
            this.cmsMime_Copy.Size = new System.Drawing.Size(146, 26);
            this.cmsMime_Copy.Text = "Copy";
            this.cmsMime_Copy.Click += new System.EventHandler(this.cmsMime_Copy_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // cmsMime_SelectAll
            // 
            this.cmsMime_SelectAll.Name = "cmsMime_SelectAll";
            this.cmsMime_SelectAll.Size = new System.Drawing.Size(146, 26);
            this.cmsMime_SelectAll.Text = "Select All";
            this.cmsMime_SelectAll.Click += new System.EventHandler(this.cmsMime_SelectAll_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.HideSelection = false;
            this.txtFileName.Location = new System.Drawing.Point(245, 11);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(428, 22);
            this.txtFileName.TabIndex = 40;
            this.txtFileName.Text = "C:\\";
            // 
            // Label3
            // 
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Location = new System.Drawing.Point(8, 117);
            this.Label3.Margin = new System.Windows.Forms.Padding(0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(280, 21);
            this.Label3.TabIndex = 55;
            this.Label3.Text = "Bodypart Encoded Content Stream";
            // 
            // Label1
            // 
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Location = new System.Drawing.Point(11, 5);
            this.Label1.Margin = new System.Windows.Forms.Padding(0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(200, 21);
            this.Label1.TabIndex = 49;
            this.Label1.Text = "Bodypart Fields";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 532);
            this.StatusBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(826, 21);
            this.StatusBar1.TabIndex = 59;
            this.StatusBar1.Text = "Not Loaded";
            // 
            // TreeView1
            // 
            this.TreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView1.ContextMenuStrip = this.cmsBPTree;
            this.TreeView1.HideSelection = false;
            this.TreeView1.Location = new System.Drawing.Point(91, 39);
            this.TreeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(725, 126);
            this.TreeView1.TabIndex = 44;
            this.TreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect_1);
            // 
            // cmsBPTree
            // 
            this.cmsBPTree.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBPTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBodypartToFileToolStripMenuItem,
            this.saveEncodedBodypartStreamToFileToolStripMenuItem,
            this.saveDecodedBodypartStreamToFileToolStripMenuItem,
            this.saveBodypartStreamToFileToolStripMenuItem});
            this.cmsBPTree.Name = "cmsBPTree";
            this.cmsBPTree.Size = new System.Drawing.Size(344, 108);
            // 
            // saveBodypartToFileToolStripMenuItem
            // 
            this.saveBodypartToFileToolStripMenuItem.Name = "saveBodypartToFileToolStripMenuItem";
            this.saveBodypartToFileToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.saveBodypartToFileToolStripMenuItem.Text = "Save Bodypart To File";
            this.saveBodypartToFileToolStripMenuItem.Click += new System.EventHandler(this.saveBodypartToFileToolStripMenuItem_Click);
            // 
            // saveEncodedBodypartStreamToFileToolStripMenuItem
            // 
            this.saveEncodedBodypartStreamToFileToolStripMenuItem.Name = "saveEncodedBodypartStreamToFileToolStripMenuItem";
            this.saveEncodedBodypartStreamToFileToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.saveEncodedBodypartStreamToFileToolStripMenuItem.Text = "Save Encoded Bodypart Stream To File";
            this.saveEncodedBodypartStreamToFileToolStripMenuItem.Click += new System.EventHandler(this.saveEncodedBodypartStreamToFileToolStripMenuItem_Click);
            // 
            // saveDecodedBodypartStreamToFileToolStripMenuItem
            // 
            this.saveDecodedBodypartStreamToFileToolStripMenuItem.Name = "saveDecodedBodypartStreamToFileToolStripMenuItem";
            this.saveDecodedBodypartStreamToFileToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.saveDecodedBodypartStreamToFileToolStripMenuItem.Text = "Save Decoded Bodypart Stream To File";
            this.saveDecodedBodypartStreamToFileToolStripMenuItem.Click += new System.EventHandler(this.saveDecodedBodypartStreamToFileToolStripMenuItem_Click);
            // 
            // saveBodypartStreamToFileToolStripMenuItem
            // 
            this.saveBodypartStreamToFileToolStripMenuItem.Name = "saveBodypartStreamToFileToolStripMenuItem";
            this.saveBodypartStreamToFileToolStripMenuItem.Size = new System.Drawing.Size(343, 26);
            this.saveBodypartStreamToFileToolStripMenuItem.Text = "Save Bodypart Stream To File";
            this.saveBodypartStreamToFileToolStripMenuItem.Click += new System.EventHandler(this.saveBodypartStreamToFileToolStripMenuItem_Click);
            // 
            // ListView1
            // 
            this.ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.ColValue});
            this.ListView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListView1.FullRowSelect = true;
            this.ListView1.HideSelection = false;
            this.ListView1.LabelWrap = false;
            this.ListView1.Location = new System.Drawing.Point(6, 26);
            this.ListView1.Margin = new System.Windows.Forms.Padding(0);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(784, 96);
            this.ListView1.TabIndex = 50;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 212;
            // 
            // ColValue
            // 
            this.ColValue.Text = "Value";
            this.ColValue.Width = 487;
            // 
            // cmdLoad
            // 
            this.cmdLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLoad.Location = new System.Drawing.Point(757, 6);
            this.cmdLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(60, 27);
            this.cmdLoad.TabIndex = 42;
            this.cmdLoad.Text = "Load";
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click_1);
            // 
            // Label4
            // 
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Location = new System.Drawing.Point(8, 217);
            this.Label4.Margin = new System.Windows.Forms.Padding(0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(280, 21);
            this.Label4.TabIndex = 57;
            this.Label4.Text = "Bodypart Decoded Content Stream";
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Location = new System.Drawing.Point(3, 122);
            this.Label6.Margin = new System.Windows.Forms.Padding(0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(144, 21);
            this.Label6.TabIndex = 51;
            this.Label6.Text = "Bodypart Properties";
            // 
            // ListView2
            // 
            this.ListView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.ListView2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListView2.FullRowSelect = true;
            this.ListView2.HideSelection = false;
            this.ListView2.LabelWrap = false;
            this.ListView2.Location = new System.Drawing.Point(6, 143);
            this.ListView2.Margin = new System.Windows.Forms.Padding(0);
            this.ListView2.Name = "ListView2";
            this.ListView2.Size = new System.Drawing.Size(784, 157);
            this.ListView2.TabIndex = 52;
            this.ListView2.UseCompatibleStateImageBehavior = false;
            this.ListView2.View = System.Windows.Forms.View.Details;
            this.ListView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView2_ColumnClick);
            this.ListView2.SelectedIndexChanged += new System.EventHandler(this.ListView2_SelectedIndexChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 212;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Value";
            this.ColumnHeader2.Width = 487;
            // 
            // Label5
            // 
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Location = new System.Drawing.Point(12, 39);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(73, 19);
            this.Label5.TabIndex = 43;
            this.Label5.Text = "Body Parts:";
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdBrowse.Location = new System.Drawing.Point(679, 7);
            this.cmdBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(72, 26);
            this.cmdBrowse.TabIndex = 41;
            this.cmdBrowse.Text = "Browse. . .";
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // btnLoadTextEntry
            // 
            this.btnLoadTextEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadTextEntry.Location = new System.Drawing.Point(8, 6);
            this.btnLoadTextEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoadTextEntry.Name = "btnLoadTextEntry";
            this.btnLoadTextEntry.Size = new System.Drawing.Size(129, 27);
            this.btnLoadTextEntry.TabIndex = 60;
            this.btnLoadTextEntry.Text = "Load Text Entry";
            this.btnLoadTextEntry.Click += new System.EventHandler(this.btnLoadTextEntry_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFileName.Location = new System.Drawing.Point(170, 13);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(69, 22);
            this.lblFileName.TabIndex = 61;
            this.lblFileName.Text = "Load File:";
            // 
            // CmBpTree
            // 
            this.CmBpTree.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSaveBodyPartToFile,
            this.mnuSaveEncodedBodyPartToFile,
            this.mnuSaveDecodedBodyPartToFile,
            this.mnuSaveBodyPartStreamToFile});
            this.CmBpTree.Popup += new System.EventHandler(this.CmBpTree_Popup);
            // 
            // mnuSaveBodyPartToFile
            // 
            this.mnuSaveBodyPartToFile.Index = 0;
            this.mnuSaveBodyPartToFile.Text = "Save Bodypart To File";
            this.mnuSaveBodyPartToFile.Click += new System.EventHandler(this.mnuSaveBodyPartToFile_Click);
            // 
            // mnuSaveEncodedBodyPartToFile
            // 
            this.mnuSaveEncodedBodyPartToFile.Index = 1;
            this.mnuSaveEncodedBodyPartToFile.Text = "Save Encoded Bodypart Stream To File";
            this.mnuSaveEncodedBodyPartToFile.Click += new System.EventHandler(this.mnuSaveEncodedBodyPartToFile_Click);
            // 
            // mnuSaveDecodedBodyPartToFile
            // 
            this.mnuSaveDecodedBodyPartToFile.Index = 2;
            this.mnuSaveDecodedBodyPartToFile.Text = "Save Decoded Bodypart Stream To File";
            this.mnuSaveDecodedBodyPartToFile.Click += new System.EventHandler(this.mnuSaveDecodedBodyPartToFile_Click);
            // 
            // mnuSaveBodyPartStreamToFile
            // 
            this.mnuSaveBodyPartStreamToFile.Index = 3;
            this.mnuSaveBodyPartStreamToFile.Text = "Save Bodypart Stream To File";
            this.mnuSaveBodyPartStreamToFile.Click += new System.EventHandler(this.mnuSaveBodyPartStreamToFile_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(8, 198);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 334);
            this.tabControl1.TabIndex = 62;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMime);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(800, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Full Item MIME";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Label1);
            this.tabPage2.Controls.Add(this.ListView1);
            this.tabPage2.Controls.Add(this.Label6);
            this.tabPage2.Controls.Add(this.ListView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(800, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Selected Body Part";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Label7);
            this.tabPage3.Controls.Add(this.txtStream);
            this.tabPage3.Controls.Add(this.Label3);
            this.tabPage3.Controls.Add(this.txtEncoded);
            this.tabPage3.Controls.Add(this.Label4);
            this.tabPage3.Controls.Add(this.txtDecoded);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(800, 305);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Selected Body Part Streams";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.wbView);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(800, 305);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Selected Body Part Web Browser View";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // wbView
            // 
            this.wbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbView.Location = new System.Drawing.Point(0, 0);
            this.wbView.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbView.Name = "wbView";
            this.wbView.Size = new System.Drawing.Size(800, 305);
            this.wbView.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(771, 27);
            this.label2.TabIndex = 63;
            this.label2.Text = "Note: Load MIME and select a node above, then click on the tabs below for details" +
    ". Right click on node above to export.";
            // 
            // MimeParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(826, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnLoadTextEntry);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.TreeView1);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cmdBrowse);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MimeParserForm";
            this.Text = "CDOSYS MimeParser";
            this.Load += new System.EventHandler(this.MimeParser_Load);
            this.cmsBPStream.ResumeLayout(false);
            this.cmsBPEncStream.ResumeLayout(false);
            this.cmsBPDecStream.ResumeLayout(false);
            this.cmsMime.ResumeLayout(false);
            this.cmsBPTree.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.RichTextBox txtStream;
        internal System.Windows.Forms.RichTextBox txtEncoded;
        internal System.Windows.Forms.RichTextBox txtDecoded;
        internal System.Windows.Forms.RichTextBox txtMime;
        internal System.Windows.Forms.TextBox txtFileName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.TreeView TreeView1;
        internal System.Windows.Forms.ListView ListView1;
        internal System.Windows.Forms.ColumnHeader colName;
        internal System.Windows.Forms.ColumnHeader ColValue;
        internal System.Windows.Forms.Button cmdLoad;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ListView ListView2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.Button btnLoadTextEntry;
        internal System.Windows.Forms.Label lblFileName;
        internal System.Windows.Forms.MenuItem mnuSaveBodyPartToFile;
        internal System.Windows.Forms.MenuItem mnuSaveEncodedBodyPartToFile;
        internal System.Windows.Forms.MenuItem mnuSaveDecodedBodyPartToFile;
        internal System.Windows.Forms.MenuItem mnuSaveBodyPartStreamToFile;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem cmsMime_Copy;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem cmsMime_SelectAll;
        internal System.Windows.Forms.ContextMenuStrip cmsMime;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPDecStream_Copy;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPDecStream_SelectAll;
        internal System.Windows.Forms.ContextMenuStrip cmsBPDecStream;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPStream_Copy;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPStream_SelectAll;
        internal System.Windows.Forms.ContextMenuStrip cmsBPStream;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPEncStream_Copy;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripMenuItem cmsBPEncStream_SelectAll;
        internal System.Windows.Forms.ContextMenuStrip cmsBPEncStream;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.ContextMenu CmBpTree;
        private System.Windows.Forms.ContextMenuStrip cmsBPTree;
        private System.Windows.Forms.ToolStripMenuItem saveBodypartToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveEncodedBodypartStreamToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDecodedBodypartStreamToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBodypartStreamToFileToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser wbView;
        internal System.Windows.Forms.Label label2;
    }
}