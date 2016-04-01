namespace EWSEditor.Forms
{
    partial class ViewInBrowser
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnCreatePageAndView = new System.Windows.Forms.Button();
            this.btnViewInExternalIE = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmboFileExtension = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(1, 103);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1224, 220);
            this.textBox1.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(1, 345);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1214, 334);
            this.webBrowser1.TabIndex = 5;
            // 
            // btnCreatePageAndView
            // 
            this.btnCreatePageAndView.Location = new System.Drawing.Point(586, 10);
            this.btnCreatePageAndView.Name = "btnCreatePageAndView";
            this.btnCreatePageAndView.Size = new System.Drawing.Size(309, 26);
            this.btnCreatePageAndView.TabIndex = 3;
            this.btnCreatePageAndView.Text = "Place content HTML page and view.";
            this.btnCreatePageAndView.UseVisualStyleBackColor = true;
            this.btnCreatePageAndView.Click += new System.EventHandler(this.btnCreatePageAndView_Click);
            // 
            // btnViewInExternalIE
            // 
            this.btnViewInExternalIE.Location = new System.Drawing.Point(395, 10);
            this.btnViewInExternalIE.Name = "btnViewInExternalIE";
            this.btnViewInExternalIE.Size = new System.Drawing.Size(163, 26);
            this.btnViewInExternalIE.TabIndex = 2;
            this.btnViewInExternalIE.Text = "View In External IE";
            this.btnViewInExternalIE.UseVisualStyleBackColor = true;
            this.btnViewInExternalIE.Click += new System.EventHandler(this.btnViewInExternalIE_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(264, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(109, 26);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Web Control:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source:";
            // 
            // cmboFileExtension
            // 
            this.cmboFileExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmboFileExtension.FormattingEnabled = true;
            this.cmboFileExtension.Items.AddRange(new object[] {
            "HTML",
            "XML",
            "TXT"});
            this.cmboFileExtension.Location = new System.Drawing.Point(116, 13);
            this.cmboFileExtension.Name = "cmboFileExtension";
            this.cmboFileExtension.Size = new System.Drawing.Size(121, 24);
            this.cmboFileExtension.TabIndex = 7;
            this.cmboFileExtension.Text = "HTML";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Content Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1063, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Note:   Change <?xml version=\"1.0\" encoding=\"utf-16\"?> to  <?xml version=\"1.0\" en" +
    "coding=\"utf-8\"?> as there are issues with the web control rendering utf8-16 cont" +
    "ent..";
            // 
            // ViewInBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1227, 690);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmboFileExtension);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnViewInExternalIE);
            this.Controls.Add(this.btnCreatePageAndView);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBox1);
            this.Name = "ViewInBrowser";
            this.Text = "View in Browser";
            this.Load += new System.EventHandler(this.ViewInBrowser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnCreatePageAndView;
        private System.Windows.Forms.Button btnViewInExternalIE;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmboFileExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}