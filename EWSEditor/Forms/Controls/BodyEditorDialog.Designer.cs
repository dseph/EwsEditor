namespace EWSEditor.Forms.Controls
{
    partial class BodyEditorDialog
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
            this.btnOk = new System.Windows.Forms.Button();
            this.grpBody = new System.Windows.Forms.GroupBox();
            this.htmlViewer = new System.Windows.Forms.WebBrowser();
            this.rtfViewer = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(517, 516);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // grpBody
            // 
            this.grpBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBody.Controls.Add(this.htmlViewer);
            this.grpBody.Controls.Add(this.rtfViewer);
            this.grpBody.Location = new System.Drawing.Point(13, 12);
            this.grpBody.Name = "grpBody";
            this.grpBody.Size = new System.Drawing.Size(579, 491);
            this.grpBody.TabIndex = 2;
            this.grpBody.TabStop = false;
            this.grpBody.Text = "Body Content";
            // 
            // htmlViewer
            // 
            this.htmlViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlViewer.Location = new System.Drawing.Point(3, 16);
            this.htmlViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.htmlViewer.Name = "htmlViewer";
            this.htmlViewer.Size = new System.Drawing.Size(573, 472);
            this.htmlViewer.TabIndex = 3;
            // 
            // rtfViewer
            // 
            this.rtfViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfViewer.Location = new System.Drawing.Point(3, 16);
            this.rtfViewer.Name = "rtfViewer";
            this.rtfViewer.ReadOnly = true;
            this.rtfViewer.Size = new System.Drawing.Size(573, 472);
            this.rtfViewer.TabIndex = 4;
            this.rtfViewer.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // BodyEditorDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBody);
            this.Controls.Add(this.btnOk);
            this.Name = "BodyEditorDialog";
            this.Text = "EWS Editor - Body";
            this.grpBody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpBody;
        private System.Windows.Forms.RichTextBox rtfViewer;
        private System.Windows.Forms.WebBrowser htmlViewer;
        private System.Windows.Forms.Label label1;
    }
}