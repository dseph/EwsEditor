namespace EWSEditor.Forms.Dialogs
{
    partial class CharactersetConversionForm
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.cmboTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmboFrom
            // 
            this.cmboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboFrom.FormattingEnabled = true;
            this.cmboFrom.Location = new System.Drawing.Point(140, 27);
            this.cmboFrom.Margin = new System.Windows.Forms.Padding(7);
            this.cmboFrom.Name = "cmboFrom";
            this.cmboFrom.Size = new System.Drawing.Size(465, 33);
            this.cmboFrom.TabIndex = 1;
            this.cmboFrom.SelectedIndexChanged += new System.EventHandler(this.cmboFrom_SelectedIndexChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(1285, 21);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(156, 43);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cmboTo
            // 
            this.cmboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboTo.FormattingEnabled = true;
            this.cmboTo.Location = new System.Drawing.Point(710, 27);
            this.cmboTo.Margin = new System.Windows.Forms.Padding(7);
            this.cmboTo.Name = "cmboTo";
            this.cmboTo.Size = new System.Drawing.Size(503, 33);
            this.cmboTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtTo.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(16, 450);
            this.txtTo.Margin = new System.Windows.Forms.Padding(7);
            this.txtTo.MaxLength = 0;
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTo.Size = new System.Drawing.Size(1443, 307);
            this.txtTo.TabIndex = 6;
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(16, 188);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(7);
            this.txtFrom.MaxLength = 0;
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFrom.Size = new System.Drawing.Size(1443, 248);
            this.txtFrom.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(593, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 50);
            this.label3.TabIndex = 7;
            this.label3.Text = "<< Test form >>";
            // 
            // CharactersetConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 791);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmboTo);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.cmboFrom);
            this.Name = "CharactersetConversionForm";
            this.Text = "Characterset Conversion ";
            this.Load += new System.EventHandler(this.CharactersetConversionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboFrom;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cmboTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label3;
    }
}