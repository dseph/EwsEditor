namespace EWSEditor.Forms
{
    partial class AutodiscoverViewerForm
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
            this.grdDetails = new EWSEditor.Forms.Controls.PropertyDetialsGrid();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grdDetails
            // 
            this.grdDetails.Location = new System.Drawing.Point(12, 190);
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.Size = new System.Drawing.Size(760, 431);
            this.grdDetails.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(13, 13);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // AutodiscoverViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(910, 643);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.grdDetails);
            this.Name = "AutodiscoverViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private EWSEditor.Forms.Controls.PropertyDetialsGrid grdDetails;
        private System.Windows.Forms.Button btnGo;

    }
}
