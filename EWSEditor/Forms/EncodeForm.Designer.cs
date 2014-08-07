namespace EWSEditor.Forms
{
    partial class EncodeForm
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
            this.cmboFrom = new System.Windows.Forms.ComboBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmboFrom
            // 
            this.cmboFrom.FormattingEnabled = true;
            this.cmboFrom.Location = new System.Drawing.Point(2, 12);
            this.cmboFrom.Name = "cmboFrom";
            this.cmboFrom.Size = new System.Drawing.Size(663, 21);
            this.cmboFrom.TabIndex = 0;
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Font = new System.Drawing.Font("Courier New", 7.8F);
            this.txtFrom.Location = new System.Drawing.Point(2, 38);
            this.txtFrom.MaxLength = 0;
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFrom.Size = new System.Drawing.Size(709, 218);
            this.txtFrom.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(671, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(41, 25);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtTo.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(2, 262);
            this.txtTo.MaxLength = 0;
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTo.Size = new System.Drawing.Size(709, 263);
            this.txtTo.TabIndex = 3;
            // 
            // EncodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(719, 537);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.cmboFrom);
            this.Name = "EncodeForm";
            this.Text = "Encoding Helper";
            this.Load += new System.EventHandler(this.EncodeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboFrom;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtTo;
    }
}