namespace EWSEditor.Forms
{
    partial class ErrorDialog
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
            this.btnOK = new System.Windows.Forms.Button();
            this.ExceptionDetailBox = new System.Windows.Forms.RichTextBox();
            this.Header = new System.Windows.Forms.Panel();
            this.lblHResultHex = new System.Windows.Forms.Label();
            this.txtHResultHex = new System.Windows.Forms.TextBox();
            this.lblHResult = new System.Windows.Forms.Label();
            this.txtHResult = new System.Windows.Forms.TextBox();
            this.ExceptionMessage = new System.Windows.Forms.TextBox();
            this.ErrorIcon = new System.Windows.Forms.PictureBox();
            this.FromWhere = new System.Windows.Forms.TextBox();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(907, 579);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ExceptionDetailBox
            // 
            this.ExceptionDetailBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExceptionDetailBox.BackColor = System.Drawing.SystemColors.Control;
            this.ExceptionDetailBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExceptionDetailBox.HideSelection = false;
            this.ExceptionDetailBox.Location = new System.Drawing.Point(5, 186);
            this.ExceptionDetailBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExceptionDetailBox.Name = "ExceptionDetailBox";
            this.ExceptionDetailBox.ReadOnly = true;
            this.ExceptionDetailBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ExceptionDetailBox.Size = new System.Drawing.Size(1006, 386);
            this.ExceptionDetailBox.TabIndex = 1;
            this.ExceptionDetailBox.Text = "[ExceptionDetails]";
            this.ExceptionDetailBox.WordWrap = false;
            this.ExceptionDetailBox.TextChanged += new System.EventHandler(this.ExceptionDetailBox_TextChanged);
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Header.Controls.Add(this.lblHResultHex);
            this.Header.Controls.Add(this.txtHResultHex);
            this.Header.Controls.Add(this.lblHResult);
            this.Header.Controls.Add(this.txtHResult);
            this.Header.Controls.Add(this.ExceptionMessage);
            this.Header.Controls.Add(this.ErrorIcon);
            this.Header.Controls.Add(this.FromWhere);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1018, 178);
            this.Header.TabIndex = 2;
            this.Header.Paint += new System.Windows.Forms.PaintEventHandler(this.Header_Paint);
            // 
            // lblHResultHex
            // 
            this.lblHResultHex.AutoSize = true;
            this.lblHResultHex.Location = new System.Drawing.Point(471, 149);
            this.lblHResultHex.Name = "lblHResultHex";
            this.lblHResultHex.Size = new System.Drawing.Size(100, 17);
            this.lblHResultHex.TabIndex = 16;
            this.lblHResultHex.Text = "HResult (Hex):";
            // 
            // txtHResultHex
            // 
            this.txtHResultHex.Location = new System.Drawing.Point(577, 144);
            this.txtHResultHex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHResultHex.Name = "txtHResultHex";
            this.txtHResultHex.ReadOnly = true;
            this.txtHResultHex.Size = new System.Drawing.Size(271, 22);
            this.txtHResultHex.TabIndex = 15;
            // 
            // lblHResult
            // 
            this.lblHResult.AutoSize = true;
            this.lblHResult.Location = new System.Drawing.Point(100, 150);
            this.lblHResult.Name = "lblHResult";
            this.lblHResult.Size = new System.Drawing.Size(62, 17);
            this.lblHResult.TabIndex = 14;
            this.lblHResult.Text = "HResult:";
            // 
            // txtHResult
            // 
            this.txtHResult.Location = new System.Drawing.Point(169, 146);
            this.txtHResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHResult.Name = "txtHResult";
            this.txtHResult.ReadOnly = true;
            this.txtHResult.Size = new System.Drawing.Size(271, 22);
            this.txtHResult.TabIndex = 13;
            // 
            // ExceptionMessage
            // 
            this.ExceptionMessage.AllowDrop = true;
            this.ExceptionMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExceptionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ExceptionMessage.HideSelection = false;
            this.ExceptionMessage.Location = new System.Drawing.Point(104, 14);
            this.ExceptionMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExceptionMessage.Multiline = true;
            this.ExceptionMessage.Name = "ExceptionMessage";
            this.ExceptionMessage.ReadOnly = true;
            this.ExceptionMessage.Size = new System.Drawing.Size(907, 70);
            this.ExceptionMessage.TabIndex = 3;
            // 
            // ErrorIcon
            // 
            this.ErrorIcon.Location = new System.Drawing.Point(16, 14);
            this.ErrorIcon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ErrorIcon.Name = "ErrorIcon";
            this.ErrorIcon.Size = new System.Drawing.Size(69, 64);
            this.ErrorIcon.TabIndex = 12;
            this.ErrorIcon.TabStop = false;
            // 
            // FromWhere
            // 
            this.FromWhere.AllowDrop = true;
            this.FromWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromWhere.HideSelection = false;
            this.FromWhere.Location = new System.Drawing.Point(104, 88);
            this.FromWhere.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FromWhere.Multiline = true;
            this.FromWhere.Name = "FromWhere";
            this.FromWhere.ReadOnly = true;
            this.FromWhere.Size = new System.Drawing.Size(907, 54);
            this.FromWhere.TabIndex = 3;
            // 
            // ErrorDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1018, 618);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.ExceptionDetailBox);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ErrorDialog";
            this.ShowIcon = false;
            this.Text = "";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ErrorDialog_Load);
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox ExceptionDetailBox;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.PictureBox ErrorIcon;
        private System.Windows.Forms.TextBox FromWhere;
        private System.Windows.Forms.TextBox ExceptionMessage;
        private System.Windows.Forms.Label lblHResult;
        private System.Windows.Forms.TextBox txtHResult;
        private System.Windows.Forms.Label lblHResultHex;
        private System.Windows.Forms.TextBox txtHResultHex;
    }
}
