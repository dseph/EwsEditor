namespace EWSEditor.Forms
{
    partial class MessageForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnReplyAll = new System.Windows.Forms.Button();
            this.btnHeaders = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.chkReadReceipt = new System.Windows.Forms.CheckBox();
            this.chkDeliveryReceipt = new System.Windows.Forms.CheckBox();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.cmboBodyType = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblCC = new System.Windows.Forms.Label();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.lblBCC = new System.Windows.Forms.Label();
            this.txtBCC = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(79, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(211, 16);
            this.btnForward.Margin = new System.Windows.Forms.Padding(4);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(77, 28);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(296, 16);
            this.btnReply.Margin = new System.Windows.Forms.Padding(4);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(77, 28);
            this.btnReply.TabIndex = 3;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnReplyAll
            // 
            this.btnReplyAll.Location = new System.Drawing.Point(381, 16);
            this.btnReplyAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnReplyAll.Name = "btnReplyAll";
            this.btnReplyAll.Size = new System.Drawing.Size(77, 28);
            this.btnReplyAll.TabIndex = 4;
            this.btnReplyAll.Text = "Reply All";
            this.btnReplyAll.UseVisualStyleBackColor = true;
            this.btnReplyAll.Click += new System.EventHandler(this.btnReplyAll_Click);
            // 
            // btnHeaders
            // 
            this.btnHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHeaders.Location = new System.Drawing.Point(871, 18);
            this.btnHeaders.Margin = new System.Windows.Forms.Padding(4);
            this.btnHeaders.Name = "btnHeaders";
            this.btnHeaders.Size = new System.Drawing.Size(209, 28);
            this.btnHeaders.TabIndex = 0;
            this.btnHeaders.Text = "Internet Message Headers";
            this.btnHeaders.UseVisualStyleBackColor = true;
            this.btnHeaders.Click += new System.EventHandler(this.btnHeaders_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(95, 16);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(85, 28);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chkReadReceipt
            // 
            this.chkReadReceipt.AutoSize = true;
            this.chkReadReceipt.Location = new System.Drawing.Point(179, 22);
            this.chkReadReceipt.Margin = new System.Windows.Forms.Padding(4);
            this.chkReadReceipt.Name = "chkReadReceipt";
            this.chkReadReceipt.Size = new System.Drawing.Size(116, 21);
            this.chkReadReceipt.TabIndex = 1;
            this.chkReadReceipt.Text = "Read Receipt";
            this.chkReadReceipt.UseVisualStyleBackColor = true;
            // 
            // chkDeliveryReceipt
            // 
            this.chkDeliveryReceipt.AutoSize = true;
            this.chkDeliveryReceipt.Location = new System.Drawing.Point(32, 22);
            this.chkDeliveryReceipt.Margin = new System.Windows.Forms.Padding(4);
            this.chkDeliveryReceipt.Name = "chkDeliveryReceipt";
            this.chkDeliveryReceipt.Size = new System.Drawing.Size(133, 21);
            this.chkDeliveryReceipt.TabIndex = 0;
            this.chkDeliveryReceipt.Text = "Delivery Receipt";
            this.chkDeliveryReceipt.UseVisualStyleBackColor = true;
            this.chkDeliveryReceipt.CheckedChanged += new System.EventHandler(this.chkDeliveryReceipt_CheckedChanged);
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(15, 303);
            this.lblMessageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(80, 17);
            this.lblMessageType.TabIndex = 11;
            this.lblMessageType.Text = "Body Type:";
            // 
            // cmboBodyType
            // 
            this.cmboBodyType.FormattingEnabled = true;
            this.cmboBodyType.Items.AddRange(new object[] {
            "Text",
            "HTML"});
            this.cmboBodyType.Location = new System.Drawing.Point(103, 295);
            this.cmboBodyType.Margin = new System.Windows.Forms.Padding(4);
            this.cmboBodyType.Name = "cmboBodyType";
            this.cmboBodyType.Size = new System.Drawing.Size(145, 24);
            this.cmboBodyType.TabIndex = 12;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(15, 175);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(29, 17);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Location = new System.Drawing.Point(77, 166);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(1012, 22);
            this.txtTo.TabIndex = 5;
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(15, 207);
            this.lblCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(30, 17);
            this.lblCC.TabIndex = 6;
            this.lblCC.Text = "CC:";
            // 
            // txtCC
            // 
            this.txtCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCC.Location = new System.Drawing.Point(77, 198);
            this.txtCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(1012, 22);
            this.txtCC.TabIndex = 7;
            // 
            // lblBCC
            // 
            this.lblBCC.AutoSize = true;
            this.lblBCC.Location = new System.Drawing.Point(15, 239);
            this.lblBCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBCC.Name = "lblBCC";
            this.lblBCC.Size = new System.Drawing.Size(39, 17);
            this.lblBCC.TabIndex = 8;
            this.lblBCC.Text = "BCC:";
            // 
            // txtBCC
            // 
            this.txtBCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBCC.Location = new System.Drawing.Point(77, 230);
            this.txtBCC.Margin = new System.Windows.Forms.Padding(4);
            this.txtBCC.Name = "txtBCC";
            this.txtBCC.Size = new System.Drawing.Size(1012, 22);
            this.txtBCC.TabIndex = 8;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(15, 271);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(59, 17);
            this.lblSubject.TabIndex = 9;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(77, 262);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(1012, 22);
            this.txtSubject.TabIndex = 10;
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(16, 329);
            this.txtBody.Margin = new System.Windows.Forms.Padding(4);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(1085, 430);
            this.txtBody.TabIndex = 13;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnReplyAll);
            this.groupBox1.Controls.Add(this.btnReply);
            this.groupBox1.Controls.Add(this.btnForward);
            this.groupBox1.Location = new System.Drawing.Point(20, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(465, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeliveryReceipt);
            this.groupBox2.Controls.Add(this.chkReadReceipt);
            this.groupBox2.Location = new System.Drawing.Point(20, 62);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(320, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "From:";
            // 
            // txtFrom
            // 
            this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFrom.Enabled = false;
            this.txtFrom.Location = new System.Drawing.Point(77, 135);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(1012, 22);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            // 
            // btnAttachments
            // 
            this.btnAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachments.Location = new System.Drawing.Point(871, 54);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(209, 28);
            this.btnAttachments.TabIndex = 1;
            this.btnAttachments.Tag = "";
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 774);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.cmboBodyType);
            this.Controls.Add(this.btnHeaders);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtBCC);
            this.Controls.Add(this.lblBCC);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MessageForm";
            this.Text = "MessageForm";
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnReplyAll;
        private System.Windows.Forms.Button btnHeaders;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox chkReadReceipt;
        private System.Windows.Forms.CheckBox chkDeliveryReceipt;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.ComboBox cmboBodyType;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label lblBCC;
        private System.Windows.Forms.TextBox txtBCC;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Button btnAttachments;

    }
}