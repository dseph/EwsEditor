namespace EWSEditor.Forms
{
    partial class DeveloperItemTestForm
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
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1155, 213);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "This windows is to be used by develpers with EWSEditor source in order that they " +
    "may test their EWS Managed API code  to work on a selected item.";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 270);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(194, 58);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // DeveloperItemTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 482);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.textBox1);
            this.Name = "DeveloperItemTestForm";
            this.Text = "Developer Item Test Window";
            this.Load += new System.EventHandler(this.DeveloperItemTestWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTest;
    }
}