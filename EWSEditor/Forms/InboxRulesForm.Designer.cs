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
            this.txtResults.Location = new System.Drawing.Point(2, 41);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(739, 440);
            this.txtResults.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Smtp Address:";
            // 
            // txtSmtpAddress
            // 
            this.txtSmtpAddress.Location = new System.Drawing.Point(89, 12);
            this.txtSmtpAddress.Name = "txtSmtpAddress";
            this.txtSmtpAddress.Size = new System.Drawing.Size(421, 20);
            this.txtSmtpAddress.TabIndex = 18;
            // 
            // btnGetInboxRules
            // 
            this.btnGetInboxRules.Location = new System.Drawing.Point(649, 12);
            this.btnGetInboxRules.Name = "btnGetInboxRules";
            this.btnGetInboxRules.Size = new System.Drawing.Size(75, 23);
            this.btnGetInboxRules.TabIndex = 17;
            this.btnGetInboxRules.Text = "Get Availability";
            this.btnGetInboxRules.UseVisualStyleBackColor = true;
            this.btnGetInboxRules.Click += new System.EventHandler(this.btnGetInboxRules_Click);
            // 
            // InboxRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 484);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSmtpAddress);
            this.Controls.Add(this.btnGetInboxRules);
            this.Controls.Add(this.txtResults);
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