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
            this.TempReqFormatCombo.Location = new System.Drawing.Point(118, 216);
            this.TempReqFormatCombo.Name = "TempReqFormatCombo";
            this.TempReqFormatCombo.Size = new System.Drawing.Size(272, 21);
            this.TempReqFormatCombo.TabIndex = 3;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(315, 243);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 4;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // SourceIdLabel
            // 
            this.SourceIdLabel.AutoSize = true;
            this.SourceIdLabel.Location = new System.Drawing.Point(13, 14);
            this.SourceIdLabel.Name = "SourceIdLabel";
            this.SourceIdLabel.Size = new System.Drawing.Size(0, 13);
            this.SourceIdLabel.TabIndex = 4;
            // 
            // ScrIdMbxLabel
            // 
            this.ScrIdMbxLabel.Location = new System.Drawing.Point(14, 193);
            this.ScrIdMbxLabel.Name = "ScrIdMbxLabel";
            this.ScrIdMbxLabel.Size = new System.Drawing.Size(98, 17);
            this.ScrIdMbxLabel.TabIndex = 21;
            this.ScrIdMbxLabel.Text = "Identifier Mailbox:";
            // 
            // SrcMbxText
            // 
            this.SrcMbxText.Location = new System.Drawing.Point(118, 190);
            this.SrcMbxText.Name = "SrcMbxText";
            this.SrcMbxText.Size = new System.Drawing.Size(272, 20);
            this.SrcMbxText.TabIndex = 2;
            // 
            // SrcIdLabel
            // 
            this.SrcIdLabel.Location = new System.Drawing.Point(12, 90);
            this.SrcIdLabel.Name = "SrcIdLabel";
            this.SrcIdLabel.Size = new System.Drawing.Size(98, 12);
            this.SrcIdLabel.TabIndex = 20;
            this.SrcIdLabel.Text = "Original Identifier:";
            // 
            // SrcIdFormatLabel
            // 
            this.SrcIdFormatLabel.Location = new System.Drawing.Point(13, 63);
            this.SrcIdFormatLabel.Name = "SrcIdFormatLabel";
            this.SrcIdFormatLabel.Size = new System.Drawing.Size(97, 18);
            this.SrcIdFormatLabel.TabIndex = 19;
            this.SrcIdFormatLabel.Text = "Original Format:";
            // 
            // TempSrcFormatCombo
            // 
            this.TempSrcFormatCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TempSrcFormatCombo.FormattingEnabled = true;
            this.TempSrcFormatCombo.Location = new System.Drawing.Point(117, 60);
            this.TempSrcFormatCombo.Name = "TempSrcFormatCombo";
            this.TempSrcFormatCombo.Size = new System.Drawing.Size(273, 21);
            this.TempSrcFormatCombo.TabIndex = 0;
            // 
            // SrcIdText
            // 
            this.SrcIdText.Location = new System.Drawing.Point(117, 87);
            this.SrcIdText.Multiline = true;
            this.SrcIdText.Name = "SrcIdText";
            this.SrcIdText.Size = new System.Drawing.Size(273, 97);
            this.SrcIdText.TabIndex = 1;
            // 
            // ConvertIdLabel
            // 
            this.ConvertIdLabel.Location = new System.Drawing.Point(13, 13);
            this.ConvertIdLabel.Name = "ConvertIdLabel";
            this.ConvertIdLabel.Size = new System.Drawing.Size(377, 44);
            this.ConvertIdLabel.TabIndex = 22;
            this.ConvertIdLabel.Text = "Convert an Id from one Exchange format to another using the ConvertId operation. " +
                " Select a source format and requested format for the source Id to be converted t" +
                "o.";
            // 
            // ReqFormatLabel
            // 
            this.ReqFormatLabel.AutoSize = true;
            this.ReqFormatLabel.Location = new System.Drawing.Point(13, 219);
            this.ReqFormatLabel.Name = "ReqFormatLabel";
            this.ReqFormatLabel.Size = new System.Drawing.Size(97, 13);
            this.ReqFormatLabel.TabIndex = 2;
            this.ReqFormatLabel.Text = "Requested Format:";
            // 
            // CvrtIdFormatText
            // 
            this.CvrtIdFormatText.Location = new System.Drawing.Point(118, 299);
            this.CvrtIdFormatText.Name = "CvrtIdFormatText";
            this.CvrtIdFormatText.ReadOnly = true;
            this.CvrtIdFormatText.Size = new System.Drawing.Size(272, 20);
            this.CvrtIdFormatText.TabIndex = 5;
            // 
            // CvrtIdMbxLabel
            // 
            this.CvrtIdMbxLabel.Location = new System.Drawing.Point(14, 435);
            this.CvrtIdMbxLabel.Name = "CvrtIdMbxLabel";
            this.CvrtIdMbxLabel.Size = new System.Drawing.Size(98, 17);
            this.CvrtIdMbxLabel.TabIndex = 28;
            this.CvrtIdMbxLabel.Text = "Identifier Mailbox:";
            // 
            // CvrtIdMbxText
            // 
            this.CvrtIdMbxText.Location = new System.Drawing.Point(118, 432);
            this.CvrtIdMbxText.Name = "CvrtIdMbxText";
            this.CvrtIdMbxText.ReadOnly = true;
            this.CvrtIdMbxText.Size = new System.Drawing.Size(272, 20);
            this.CvrtIdMbxText.TabIndex = 7;
            // 
            // CvrtIdLabel
            // 
            this.CvrtIdLabel.AutoSize = true;
            this.CvrtIdLabel.Location = new System.Drawing.Point(13, 332);
            this.CvrtIdLabel.Name = "CvrtIdLabel";
            this.CvrtIdLabel.Size = new System.Drawing.Size(102, 13);
            this.CvrtIdLabel.TabIndex = 27;
            this.CvrtIdLabel.Text = "Converted Identifier:";
            // 
            // CvrtIdFormatLabel
            // 
            this.CvrtIdFormatLabel.Location = new System.Drawing.Point(13, 302);
            this.CvrtIdFormatLabel.Name = "CvrtIdFormatLabel";
            this.CvrtIdFormatLabel.Size = new System.Drawing.Size(97, 17);
            this.CvrtIdFormatLabel.TabIndex = 26;
            this.CvrtIdFormatLabel.Text = "Converted Format:";
            // 
            // CvrtIdText
            // 
            this.CvrtIdText.Location = new System.Drawing.Point(118, 329);
            this.CvrtIdText.Multiline = true;
            this.CvrtIdText.Name = "CvrtIdText";
            this.CvrtIdText.ReadOnly = true;
            this.CvrtIdText.Size = new System.Drawing.Size(272, 97);
            this.CvrtIdText.TabIndex = 6;
            // 
            // SplitterGroup
            // 
            this.SplitterGroup.Location = new System.Drawing.Point(10, 279);
            this.SplitterGroup.Name = "SplitterGroup";
            this.SplitterGroup.Size = new System.Drawing.Size(395, 8);
            this.SplitterGroup.TabIndex = 29;
            this.SplitterGroup.TabStop = false;
            // 
            // ConvertIdForm
            // 
            this.AcceptButton = this.ConvertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(410, 476);
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
