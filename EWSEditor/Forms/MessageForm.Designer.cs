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
            this.cmboMessageType = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(45, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(6, 13);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(58, 23);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(70, 13);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(58, 23);
            this.btnReply.TabIndex = 1;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnReplyAll
            // 
            this.btnReplyAll.Location = new System.Drawing.Point(134, 13);
            this.btnReplyAll.Name = "btnReplyAll";
            this.btnReplyAll.Size = new System.Drawing.Size(58, 23);
            this.btnReplyAll.TabIndex = 2;
            this.btnReplyAll.Text = "Reply All";
            this.btnReplyAll.UseVisualStyleBackColor = true;
            this.btnReplyAll.Click += new System.EventHandler(this.btnReplyAll_Click);
            // 
            // btnHeaders
            // 
            this.btnHeaders.Location = new System.Drawing.Point(723, 25);
            this.btnHeaders.Name = "btnHeaders";
            this.btnHeaders.Size = new System.Drawing.Size(75, 23);
            this.btnHeaders.TabIndex = 4;
            this.btnHeaders.Text = "Headers";
            this.btnHeaders.UseVisualStyleBackColor = true;
            this.btnHeaders.Click += new System.EventHandler(this.btnHeaders_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(63, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(58, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chkReadReceipt
            // 
            this.chkReadReceipt.AutoSize = true;
            this.chkReadReceipt.Location = new System.Drawing.Point(134, 18);
            this.chkReadReceipt.Name = "chkReadReceipt";
            this.chkReadReceipt.Size = new System.Drawing.Size(92, 17);
            this.chkReadReceipt.TabIndex = 1;
            this.chkReadReceipt.Text = "Read Receipt";
            this.chkReadReceipt.UseVisualStyleBackColor = true;
            // 
            // chkDeliveryReceipt
            // 
            this.chkDeliveryReceipt.AutoSize = true;
            this.chkDeliveryReceipt.Location = new System.Drawing.Point(24, 18);
            this.chkDeliveryReceipt.Name = "chkDeliveryReceipt";
            this.chkDeliveryReceipt.Size = new System.Drawing.Size(104, 17);
            this.chkDeliveryReceipt.TabIndex = 0;
            this.chkDeliveryReceipt.Text = "Delivery Receipt";
            this.chkDeliveryReceipt.UseVisualStyleBackColor = true;
            this.chkDeliveryReceipt.CheckedChanged += new System.EventHandler(this.chkDeliveryReceipt_CheckedChanged);
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(12, 51);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(80, 13);
            this.lblMessageType.TabIndex = 5;
            this.lblMessageType.Text = "Message Type:";
            // 
            // cmboMessageType
            // 
            this.cmboMessageType.FormattingEnabled = true;
            this.cmboMessageType.Items.AddRange(new object[] {
            "Text",
            "HTML"});
            this.cmboMessageType.Location = new System.Drawing.Point(98, 49);
            this.cmboMessageType.Name = "cmboMessageType";
            this.cmboMessageType.Size = new System.Drawing.Size(110, 21);
            this.cmboMessageType.TabIndex = 6;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(11, 97);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTo.Location = new System.Drawing.Point(58, 90);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(753, 20);
            this.txtTo.TabIndex = 8;
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(11, 123);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(24, 13);
            this.lblCC.TabIndex = 9;
            this.lblCC.Text = "CC:";
            // 
            // txtCC
            // 
            this.txtCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCC.Location = new System.Drawing.Point(58, 116);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(753, 20);
            this.txtCC.TabIndex = 10;
            // 
            // lblBCC
            // 
            this.lblBCC.AutoSize = true;
            this.lblBCC.Location = new System.Drawing.Point(11, 149);
            this.lblBCC.Name = "lblBCC";
            this.lblBCC.Size = new System.Drawing.Size(31, 13);
            this.lblBCC.TabIndex = 11;
            this.lblBCC.Text = "BCC:";
            // 
            // txtBCC
            // 
            this.txtBCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBCC.Location = new System.Drawing.Point(58, 142);
            this.txtBCC.Name = "txtBCC";
            this.txtBCC.Size = new System.Drawing.Size(753, 20);
            this.txtBCC.TabIndex = 12;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(11, 175);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(46, 13);
            this.lblSubject.TabIndex = 13;
            this.lblSubject.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(58, 168);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(753, 20);
            this.txtSubject.TabIndex = 14;
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(12, 194);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(799, 263);
            this.txtBody.TabIndex = 15;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReplyAll);
            this.groupBox1.Controls.Add(this.btnReply);
            this.groupBox1.Controls.Add(this.btnForward);
            this.groupBox1.Location = new System.Drawing.Point(483, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDeliveryReceipt);
            this.groupBox2.Controls.Add(this.chkReadReceipt);
            this.groupBox2.Location = new System.Drawing.Point(237, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 41);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.cmboMessageType);
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
            this.Controls.Add(this.btnSend);
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
        private System.Windows.Forms.ComboBox cmboMessageType;
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

    }
}