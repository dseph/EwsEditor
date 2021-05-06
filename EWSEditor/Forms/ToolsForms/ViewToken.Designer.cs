
namespace EWSEditor.Forms.ToolsForms
{
    partial class ViewToken
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
            this.btnLoadCurrentSessionToken = new System.Windows.Forms.Button();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoadCurrentSessionToken
            // 
            this.btnLoadCurrentSessionToken.Location = new System.Drawing.Point(12, 21);
            this.btnLoadCurrentSessionToken.Name = "btnLoadCurrentSessionToken";
            this.btnLoadCurrentSessionToken.Size = new System.Drawing.Size(331, 51);
            this.btnLoadCurrentSessionToken.TabIndex = 0;
            this.btnLoadCurrentSessionToken.Text = "Load Current Session Token";
            this.btnLoadCurrentSessionToken.UseVisualStyleBackColor = true;
            this.btnLoadCurrentSessionToken.Click += new System.EventHandler(this.btnLoadCurrentSessionToken_Click);
            // 
            // txtToken
            // 
            this.txtToken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToken.Location = new System.Drawing.Point(12, 91);
            this.txtToken.MaxLength = 0;
            this.txtToken.Multiline = true;
            this.txtToken.Name = "txtToken";
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtToken.Size = new System.Drawing.Size(1620, 415);
            this.txtToken.TabIndex = 1;
            // 
            // ViewToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 533);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.btnLoadCurrentSessionToken);
            this.Name = "ViewToken";
            this.Text = "View Token";
            this.Load += new System.EventHandler(this.ViewToken_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadCurrentSessionToken;
        private System.Windows.Forms.TextBox txtToken;
    }
}