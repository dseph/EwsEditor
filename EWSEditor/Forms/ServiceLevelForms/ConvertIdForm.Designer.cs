namespace EWSEditor.Forms
{
    partial class ConvertIdForm
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
            this.TempReqFormatCombo = new System.Windows.Forms.ComboBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.SourceIdLabel = new System.Windows.Forms.Label();
            this.ScrIdMbxLabel = new System.Windows.Forms.Label();
            this.SrcMbxText = new System.Windows.Forms.TextBox();
            this.SrcIdLabel = new System.Windows.Forms.Label();
            this.SrcIdFormatLabel = new System.Windows.Forms.Label();
            this.TempSrcFormatCombo = new System.Windows.Forms.ComboBox();
            this.SrcIdText = new System.Windows.Forms.TextBox();
            this.ConvertIdLabel = new System.Windows.Forms.Label();
            this.ReqFormatLabel = new System.Windows.Forms.Label();
            this.CvrtIdFormatText = new System.Windows.Forms.TextBox();
            this.CvrtIdMbxLabel = new System.Windows.Forms.Label();
            this.CvrtIdMbxText = new System.Windows.Forms.TextBox();
            this.CvrtIdLabel = new System.Windows.Forms.Label();
            this.CvrtIdFormatLabel = new System.Windows.Forms.Label();
            this.CvrtIdText = new System.Windows.Forms.TextBox();
            this.SplitterGroup = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // TempReqFormatCombo
            // 
            this.TempReqFormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempReqFormatCombo.FormattingEnabled = true;
            this.TempReqFormatCombo.Location = new System.Drawing.Point(157, 266);
            this.TempReqFormatCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TempReqFormatCombo.Name = "TempReqFormatCombo";
            this.TempReqFormatCombo.Size = new System.Drawing.Size(361, 24);
            this.TempReqFormatCombo.TabIndex = 8;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(420, 299);
            this.ConvertButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(100, 28);
            this.ConvertButton.TabIndex = 9;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // SourceIdLabel
            // 
            this.SourceIdLabel.AutoSize = true;
            this.SourceIdLabel.Location = new System.Drawing.Point(17, 17);
            this.SourceIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SourceIdLabel.Name = "SourceIdLabel";
            this.SourceIdLabel.Size = new System.Drawing.Size(0, 17);
            this.SourceIdLabel.TabIndex = 4;
            // 
            // ScrIdMbxLabel
            // 
            this.ScrIdMbxLabel.Location = new System.Drawing.Point(19, 238);
            this.ScrIdMbxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScrIdMbxLabel.Name = "ScrIdMbxLabel";
            this.ScrIdMbxLabel.Size = new System.Drawing.Size(131, 21);
            this.ScrIdMbxLabel.TabIndex = 5;
            this.ScrIdMbxLabel.Text = "Identifier Mailbox:";
            // 
            // SrcMbxText
            // 
            this.SrcMbxText.Location = new System.Drawing.Point(157, 234);
            this.SrcMbxText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SrcMbxText.Name = "SrcMbxText";
            this.SrcMbxText.Size = new System.Drawing.Size(361, 22);
            this.SrcMbxText.TabIndex = 6;
            // 
            // SrcIdLabel
            // 
            this.SrcIdLabel.Location = new System.Drawing.Point(16, 111);
            this.SrcIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SrcIdLabel.Name = "SrcIdLabel";
            this.SrcIdLabel.Size = new System.Drawing.Size(131, 15);
            this.SrcIdLabel.TabIndex = 3;
            this.SrcIdLabel.Text = "Original Identifier:";
            // 
            // SrcIdFormatLabel
            // 
            this.SrcIdFormatLabel.Location = new System.Drawing.Point(17, 78);
            this.SrcIdFormatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SrcIdFormatLabel.Name = "SrcIdFormatLabel";
            this.SrcIdFormatLabel.Size = new System.Drawing.Size(129, 22);
            this.SrcIdFormatLabel.TabIndex = 1;
            this.SrcIdFormatLabel.Text = "Original Format:";
            // 
            // TempSrcFormatCombo
            // 
            this.TempSrcFormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempSrcFormatCombo.FormattingEnabled = true;
            this.TempSrcFormatCombo.Location = new System.Drawing.Point(156, 74);
            this.TempSrcFormatCombo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TempSrcFormatCombo.Name = "TempSrcFormatCombo";
            this.TempSrcFormatCombo.Size = new System.Drawing.Size(363, 24);
            this.TempSrcFormatCombo.TabIndex = 2;
            // 
            // SrcIdText
            // 
            this.SrcIdText.Location = new System.Drawing.Point(156, 107);
            this.SrcIdText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SrcIdText.Multiline = true;
            this.SrcIdText.Name = "SrcIdText";
            this.SrcIdText.Size = new System.Drawing.Size(363, 118);
            this.SrcIdText.TabIndex = 4;
            // 
            // ConvertIdLabel
            // 
            this.ConvertIdLabel.Location = new System.Drawing.Point(17, 16);
            this.ConvertIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConvertIdLabel.Name = "ConvertIdLabel";
            this.ConvertIdLabel.Size = new System.Drawing.Size(503, 54);
            this.ConvertIdLabel.TabIndex = 0;
            this.ConvertIdLabel.Text = "Convert an Id from one Exchange format to another using the ConvertId operation. " +
    " Select a source format and requested format for the source Id to be converted t" +
    "o.";
            // 
            // ReqFormatLabel
            // 
            this.ReqFormatLabel.AutoSize = true;
            this.ReqFormatLabel.Location = new System.Drawing.Point(17, 270);
            this.ReqFormatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReqFormatLabel.Name = "ReqFormatLabel";
            this.ReqFormatLabel.Size = new System.Drawing.Size(129, 17);
            this.ReqFormatLabel.TabIndex = 7;
            this.ReqFormatLabel.Text = "Requested Format:";
            // 
            // CvrtIdFormatText
            // 
            this.CvrtIdFormatText.Location = new System.Drawing.Point(157, 368);
            this.CvrtIdFormatText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CvrtIdFormatText.Name = "CvrtIdFormatText";
            this.CvrtIdFormatText.ReadOnly = true;
            this.CvrtIdFormatText.Size = new System.Drawing.Size(361, 22);
            this.CvrtIdFormatText.TabIndex = 11;
            // 
            // CvrtIdMbxLabel
            // 
            this.CvrtIdMbxLabel.Location = new System.Drawing.Point(19, 535);
            this.CvrtIdMbxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CvrtIdMbxLabel.Name = "CvrtIdMbxLabel";
            this.CvrtIdMbxLabel.Size = new System.Drawing.Size(131, 21);
            this.CvrtIdMbxLabel.TabIndex = 14;
            this.CvrtIdMbxLabel.Text = "Identifier Mailbox:";
            // 
            // CvrtIdMbxText
            // 
            this.CvrtIdMbxText.Location = new System.Drawing.Point(157, 532);
            this.CvrtIdMbxText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CvrtIdMbxText.Name = "CvrtIdMbxText";
            this.CvrtIdMbxText.ReadOnly = true;
            this.CvrtIdMbxText.Size = new System.Drawing.Size(361, 22);
            this.CvrtIdMbxText.TabIndex = 15;
            // 
            // CvrtIdLabel
            // 
            this.CvrtIdLabel.AutoSize = true;
            this.CvrtIdLabel.Location = new System.Drawing.Point(17, 409);
            this.CvrtIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CvrtIdLabel.Name = "CvrtIdLabel";
            this.CvrtIdLabel.Size = new System.Drawing.Size(135, 17);
            this.CvrtIdLabel.TabIndex = 12;
            this.CvrtIdLabel.Text = "Converted Identifier:";
            // 
            // CvrtIdFormatLabel
            // 
            this.CvrtIdFormatLabel.Location = new System.Drawing.Point(17, 372);
            this.CvrtIdFormatLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CvrtIdFormatLabel.Name = "CvrtIdFormatLabel";
            this.CvrtIdFormatLabel.Size = new System.Drawing.Size(129, 21);
            this.CvrtIdFormatLabel.TabIndex = 10;
            this.CvrtIdFormatLabel.Text = "Converted Format:";
            // 
            // CvrtIdText
            // 
            this.CvrtIdText.Location = new System.Drawing.Point(157, 405);
            this.CvrtIdText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CvrtIdText.Multiline = true;
            this.CvrtIdText.Name = "CvrtIdText";
            this.CvrtIdText.ReadOnly = true;
            this.CvrtIdText.Size = new System.Drawing.Size(361, 118);
            this.CvrtIdText.TabIndex = 13;
            // 
            // SplitterGroup
            // 
            this.SplitterGroup.Location = new System.Drawing.Point(13, 343);
            this.SplitterGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SplitterGroup.Name = "SplitterGroup";
            this.SplitterGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SplitterGroup.Size = new System.Drawing.Size(527, 10);
            this.SplitterGroup.TabIndex = 29;
            this.SplitterGroup.TabStop = false;
            // 
            // ConvertIdForm
            // 
            this.AcceptButton = this.ConvertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(537, 586);
            this.Controls.Add(this.SplitterGroup);
            this.Controls.Add(this.CvrtIdFormatText);
            this.Controls.Add(this.CvrtIdMbxLabel);
            this.Controls.Add(this.CvrtIdMbxText);
            this.Controls.Add(this.CvrtIdLabel);
            this.Controls.Add(this.CvrtIdFormatLabel);
            this.Controls.Add(this.CvrtIdText);
            this.Controls.Add(this.ConvertIdLabel);
            this.Controls.Add(this.ScrIdMbxLabel);
            this.Controls.Add(this.SrcMbxText);
            this.Controls.Add(this.SrcIdLabel);
            this.Controls.Add(this.SrcIdFormatLabel);
            this.Controls.Add(this.TempSrcFormatCombo);
            this.Controls.Add(this.SrcIdText);
            this.Controls.Add(this.SourceIdLabel);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.ReqFormatLabel);
            this.Controls.Add(this.TempReqFormatCombo);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertIdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConvertId";
            this.Load += new System.EventHandler(this.ConvertIdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TempReqFormatCombo;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.Label SourceIdLabel;
        private System.Windows.Forms.Label ScrIdMbxLabel;
        private System.Windows.Forms.TextBox SrcMbxText;
        private System.Windows.Forms.Label SrcIdLabel;
        private System.Windows.Forms.Label SrcIdFormatLabel;
        private System.Windows.Forms.ComboBox TempSrcFormatCombo;
        private System.Windows.Forms.TextBox SrcIdText;
        private System.Windows.Forms.Label ConvertIdLabel;
        private System.Windows.Forms.Label ReqFormatLabel;
        private System.Windows.Forms.TextBox CvrtIdFormatText;
        private System.Windows.Forms.Label CvrtIdMbxLabel;
        private System.Windows.Forms.TextBox CvrtIdMbxText;
        private System.Windows.Forms.Label CvrtIdLabel;
        private System.Windows.Forms.Label CvrtIdFormatLabel;
        private System.Windows.Forms.TextBox CvrtIdText;
        private System.Windows.Forms.GroupBox SplitterGroup;
    }
}
