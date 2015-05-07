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
            this.SuspendLayout();
            // 
            // TargetMailboxLabel
            // 
            this.TargetMailboxLabel.AutoSize = true;
            this.TargetMailboxLabel.Location = new System.Drawing.Point(13, 26);
            this.TargetMailboxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TargetMailboxLabel.Name = "TargetMailboxLabel";
            this.TargetMailboxLabel.Size = new System.Drawing.Size(112, 17);
            this.TargetMailboxLabel.TabIndex = 7;
            this.TargetMailboxLabel.Text = "SendAs Mailbox:";
            // 
            // txtSendAsMailbox
            // 
            this.txtSendAsMailbox.AcceptsReturn = true;
            this.txtSendAsMailbox.Location = new System.Drawing.Point(192, 22);
            this.txtSendAsMailbox.Margin = new System.Windows.Forms.Padding(4);
            this.txtSendAsMailbox.Name = "txtSendAsMailbox";
            this.txtSendAsMailbox.Size = new System.Drawing.Size(290, 22);
            this.txtSendAsMailbox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mailbox Email Address:";
            // 
            // txtMailboxEmailAddressxtBox1
            // 
            this.txtMailboxEmailAddressxtBox1.AcceptsReturn = true;
            this.txtMailboxEmailAddressxtBox1.Location = new System.Drawing.Point(192, 52);
            this.txtMailboxEmailAddressxtBox1.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailboxEmailAddressxtBox1.Name = "txtMailboxEmailAddressxtBox1";
            this.txtMailboxEmailAddressxtBox1.Size = new System.Drawing.Size(290, 22);
            this.txtMailboxEmailAddressxtBox1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mailbox Routing Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mail Tips Requested:";
            // 
            // cmboMailboxRoutingType
            // 
            this.cmboMailboxRoutingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboMailboxRoutingType.FormattingEnabled = true;
            this.cmboMailboxRoutingType.Items.AddRange(new object[] {
            "SMTP"});
            this.cmboMailboxRoutingType.Location = new System.Drawing.Point(192, 88);
            this.cmboMailboxRoutingType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboMailboxRoutingType.Name = "cmboMailboxRoutingType";
            this.cmboMailboxRoutingType.Size = new System.Drawing.Size(195, 24);
            this.cmboMailboxRoutingType.TabIndex = 16;
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
            this.cmboMailTipsRequested.Location = new System.Drawing.Point(192, 125);
            this.cmboMailTipsRequested.Margin = new System.Windows.Forms.Padding(4);
            this.cmboMailTipsRequested.Name = "cmboMailTipsRequested";
            this.cmboMailTipsRequested.Size = new System.Drawing.Size(195, 24);
            this.cmboMailTipsRequested.TabIndex = 17;
            this.cmboMailTipsRequested.SelectedIndexChanged += new System.EventHandler(this.cmboMailTipsRequested_SelectedIndexChanged);
            // 
            // btnGetMailTips
            // 
            this.btnGetMailTips.Location = new System.Drawing.Point(626, 12);
            this.btnGetMailTips.Name = "btnGetMailTips";
            this.btnGetMailTips.Size = new System.Drawing.Size(169, 31);
            this.btnGetMailTips.TabIndex = 18;
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
            this.txtResponse.Location = new System.Drawing.Point(16, 174);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(4);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponse.Size = new System.Drawing.Size(779, 190);
            this.txtResponse.TabIndex = 19;
            this.txtResponse.TextChanged += new System.EventHandler(this.txtResponse_TextChanged);
            // 
            // GetMailTipsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 377);
            this.Controls.Add(this.txtResponse);
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
    }
}