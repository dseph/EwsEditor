namespace EWSEditor.Forms
{
    partial class ShowTextDocument
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
            this.txtEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtEntry
            // 
            this.txtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntry.Location = new System.Drawing.Point(1, 2);
            this.txtEntry.MaxLength = 0;
            this.txtEntry.Multiline = true;
            this.txtEntry.Name = "txtEntry";
            this.txtEntry.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEntry.Size = new System.Drawing.Size(1188, 638);
            this.txtEntry.TabIndex = 17;
            this.txtEntry.TextChanged += new System.EventHandler(this.txtEntry_TextChanged);
            this.txtEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEntry_KeyDown);
            // 
            // ShowTextDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 640);
            this.Controls.Add(this.txtEntry);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ShowTextDocument";
            this.Text = "ShowTextDocument";
            this.Load += new System.EventHandler(this.ShowTextDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtEntry;
    }
}