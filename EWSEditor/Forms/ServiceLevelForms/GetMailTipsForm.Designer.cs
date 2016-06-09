namespace EWSEditor
{
    partial class GetMailTipsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetMailTipsForm));
            this.TargetMailboxLabel = new System.Windows.Forms.Label();
            this.txtSendAsMailbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMailboxEmailAddressxtBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmboMailboxRoutingType = new System.Windows.Forms.ComboBox();
            this.cmboMailTipsRequested = new System.Windows.Forms.ComboBox();
            this.btnGetMailTips = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(12, 148);
            this.TargetMailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(112, 17);
            this.TargetMailboxLabel.TabIndex = 1;
            this.TargetMailboxLabel.Text = "SendAs Mailbox:";
            // 
            // txtSendAsMailbox
            // 
            this.txtSendAsMailbox.AcceptsReturn = true;
            this.txtSendAsMailbox.Location = new System.Drawing.Point(191, 144);
            this.txtSendAsMailbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSendAsMailbox.Name = "txtSendAsMailbox";
            this.txtSendAsMailbox.Size = new System.Drawing.Size(290, 22);
            this.txtSendAsMailbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mailbox Email Address:";
            // 
            // txtMailboxEmailAddressxtBox1
            // 
            this.txtMailboxEmailAddressxtBox1.AcceptsReturn = true;
            this.txtMailboxEmailAddressxtBox1.Location = new System.Drawing.Point(191, 174);
            this.txtMailboxEmailAddressxtBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMailboxEmailAddressxtBox1.Name = "txtMailboxEmailAddressxtBox1";
            this.txtMailboxEmailAddressxtBox1.Size = new System.Drawing.Size(290, 22);
            this.txtMailboxEmailAddressxtBox1.TabIndex = 4;
            this.txtMailboxEmailAddressxtBox1.TextChanged += new System.EventHandler(this.txtMailboxEmailAddressxtBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mailbox Routing Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mail Tips Requested:";
            // 
            // cmboMailboxRoutingType
            // 
            this.cmboMailboxRoutingType.FormattingEnabled = true;
            this.cmboMailboxRoutingType.Items.AddRange(new object[] {
            "SMTP",
            "EX"});
            this.cmboMailboxRoutingType.Location = new System.Drawing.Point(191, 204);
            this.cmboMailboxRoutingType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboMailboxRoutingType.Name = "cmboMailboxRoutingType";
            this.cmboMailboxRoutingType.Size = new System.Drawing.Size(195, 24);
            this.cmboMailboxRoutingType.TabIndex = 6;
            // 
            // cmboMailTipsRequested
            // 
            this.cmboMailTipsRequested.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboMailTipsRequested.FormattingEnabled = true;
            this.cmboMailTipsRequested.Items.AddRange(new object[] {
            "All",
            "OutOfOfficeMessage",
            "MailboxFullStatus",
            "CustomMailTip",
            "ExternalMemberCount",
            "TotalMemberCount",
            "MaxMessageSize",
            "DeliveryRestriction",
            "ModerationStatus",
            "InvalidRecipient"});
            this.cmboMailTipsRequested.Location = new System.Drawing.Point(191, 238);
            this.cmboMailTipsRequested.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboMailTipsRequested.Name = "cmboMailTipsRequested";
            this.cmboMailTipsRequested.Size = new System.Drawing.Size(195, 24);
            this.cmboMailTipsRequested.TabIndex = 8;
            this.cmboMailTipsRequested.SelectedIndexChanged += new System.EventHandler(this.cmboMailTipsRequested_SelectedIndexChanged);
            // 
            // btnGetMailTips
            // 
            this.btnGetMailTips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetMailTips.Location = new System.Drawing.Point(12, 276);
            this.btnGetMailTips.Name = "btnGetMailTips";
            this.btnGetMailTips.Size = new System.Drawing.Size(169, 31);
            this.btnGetMailTips.TabIndex = 9;
            this.btnGetMailTips.Text = "Get Mail Tips";
            this.btnGetMailTips.UseVisualStyleBackColor = true;
            this.btnGetMailTips.Click += new System.EventHandler(this.btnGetMailTips_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.AcceptsReturn = true;
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.Location = new System.Drawing.Point(0, 2);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(679, 170);
            this.txtResponse.TabIndex = 19;
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 312);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 202);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtResponse);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(685, 173);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Text View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(886, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "XML View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(5, 6);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(825, 168);
            this.webBrowser1.TabIndex = 21;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(11, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(693, 131);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // GetMailTipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(715, 523);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGetMailTips);
            this.Controls.Add(this.cmboMailTipsRequested);
            this.Controls.Add(this.cmboMailboxRoutingType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMailboxEmailAddressxtBox1);
            this.Controls.Add(this.TargetMailboxLabel);
            this.Controls.Add(this.txtSendAsMailbox);
            this.Name = "GetMailTipsForm";
            this.Text = "Get Mail Tips";
            this.Load += new System.EventHandler(this.GetMailTips_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TargetMailboxLabel;
        private System.Windows.Forms.TextBox txtSendAsMailbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMailboxEmailAddressxtBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmboMailboxRoutingType;
        private System.Windows.Forms.ComboBox cmboMailTipsRequested;
        private System.Windows.Forms.Button btnGetMailTips;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
    }
}