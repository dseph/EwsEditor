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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmboFrom
            // 
            this.cmboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboFrom.FormattingEnabled = true;
            this.cmboFrom.Location = new System.Drawing.Point(3, 15);
            this.cmboFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboFrom.Name = "cmboFrom";
            this.cmboFrom.Size = new System.Drawing.Size(796, 24);
            this.cmboFrom.TabIndex = 0;
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(0, 0);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFrom.MaxLength = 0;
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFrom.Size = new System.Drawing.Size(867, 240);
            this.txtFrom.TabIndex = 1;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(807, 11);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(55, 31);
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
            this.txtTo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(4, 4);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTo.MaxLength = 0;
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTo.Size = new System.Drawing.Size(864, 259);
            this.txtTo.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 44);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtFrom);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTo);
            this.splitContainer1.Size = new System.Drawing.Size(872, 516);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // EncodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(877, 558);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.cmboFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EncodeForm";
            this.Text = "Encoding Helper";
            this.Load += new System.EventHandler(this.EncodeForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboFrom;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}