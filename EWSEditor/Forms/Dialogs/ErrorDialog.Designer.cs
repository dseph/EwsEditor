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
            this.FromWhere = new System.Windows.Forms.Label();
            this.ErrorIcon = new System.Windows.Forms.PictureBox();
            this.ExceptionMessage = new System.Windows.Forms.Label();
            this.Header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(429, 423);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
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
            this.ExceptionDetailBox.Location = new System.Drawing.Point(4, 86);
            this.ExceptionDetailBox.Name = "ExceptionDetailBox";
            this.ExceptionDetailBox.ReadOnly = true;
            this.ExceptionDetailBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ExceptionDetailBox.Size = new System.Drawing.Size(508, 324);
            this.ExceptionDetailBox.TabIndex = 1;
            this.ExceptionDetailBox.Text = "[ExceptionDetails]";
            this.ExceptionDetailBox.WordWrap = false;
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Header.Controls.Add(this.FromWhere);
            this.Header.Controls.Add(this.ErrorIcon);
            this.Header.Controls.Add(this.ExceptionMessage);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(516, 80);
            this.Header.TabIndex = 2;
            // 
            // FromWhere
            // 
            this.FromWhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FromWhere.Location = new System.Drawing.Point(73, 41);
            this.FromWhere.Name = "FromWhere";
            this.FromWhere.Size = new System.Drawing.Size(439, 23);
            this.FromWhere.TabIndex = 1;
            this.FromWhere.Text = "[FromWhere]";
            // 
            // ErrorIcon
            // 
            this.ErrorIcon.Location = new System.Drawing.Point(12, 12);
            this.ErrorIcon.Name = "ErrorIcon";
            this.ErrorIcon.Size = new System.Drawing.Size(52, 52);
            this.ErrorIcon.TabIndex = 12;
            this.ErrorIcon.TabStop = false;
            // 
            // ExceptionMessage
            // 
            this.ExceptionMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExceptionMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExceptionMessage.Location = new System.Drawing.Point(72, 12);
            this.ExceptionMessage.Name = "ExceptionMessage";
            this.ExceptionMessage.Size = new System.Drawing.Size(440, 20);
            this.ExceptionMessage.TabIndex = 0;
            this.ExceptionMessage.Text = "[ExceptionMessage]";
            // 
            // ErrorDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(516, 458);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.ExceptionDetailBox);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ErrorDialog";
            this.ShowIcon = false;
            this.Text = "";
            this.TopMost = true;
            this.Header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RichTextBox ExceptionDetailBox;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Label FromWhere;
        private System.Windows.Forms.PictureBox ErrorIcon;
        private System.Windows.Forms.Label ExceptionMessage;
    }
}
