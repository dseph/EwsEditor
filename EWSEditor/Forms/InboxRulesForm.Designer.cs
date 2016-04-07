namespace EWSEditor.Forms
{
    partial class InboxRulesForm
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
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSmtpAddress = new System.Windows.Forms.TextBox();
            this.btnGetInboxRules = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResults.Location = new System.Drawing.Point(13, 50);
            this.txtResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResults.MaxLength = 0;
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(786, 306);
            this.txtResults.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smtp Address:";
            // 
            // txtSmtpAddress
            // 
            this.txtSmtpAddress.Location = new System.Drawing.Point(119, 15);
            this.txtSmtpAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSmtpAddress.Name = "txtSmtpAddress";
            this.txtSmtpAddress.Size = new System.Drawing.Size(560, 22);
            this.txtSmtpAddress.TabIndex = 1;
            // 
            // btnGetInboxRules
            // 
            this.btnGetInboxRules.Location = new System.Drawing.Point(699, 12);
            this.btnGetInboxRules.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetInboxRules.Name = "btnGetInboxRules";
            this.btnGetInboxRules.Size = new System.Drawing.Size(100, 28);
            this.btnGetInboxRules.TabIndex = 2;
            this.btnGetInboxRules.Text = "Get Availability";
            this.btnGetInboxRules.UseVisualStyleBackColor = true;
            this.btnGetInboxRules.Click += new System.EventHandler(this.btnGetInboxRules_Click);
            // 
            // InboxRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSmtpAddress);
            this.Controls.Add(this.btnGetInboxRules);
            this.Controls.Add(this.txtResults);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InboxRulesForm";
            this.Text = "Inbox Rules";
            this.Load += new System.EventHandler(this.InboxRules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSmtpAddress;
        private System.Windows.Forms.Button btnGetInboxRules;
    }
}