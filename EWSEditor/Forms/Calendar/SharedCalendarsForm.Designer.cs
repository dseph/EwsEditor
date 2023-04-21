namespace EWSEditor.Forms.Calendar
{
    partial class SharedCalendarsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMailboxSmtp = new System.Windows.Forms.TextBox();
            this.lblMailbox = new System.Windows.Forms.Label();
            this.lvSharedCalendars = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLinkGroupName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1016, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(344, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Shared Calendars";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMailboxSmtp
            // 
            this.txtMailboxSmtp.Location = new System.Drawing.Point(292, 42);
            this.txtMailboxSmtp.Name = "txtMailboxSmtp";
            this.txtMailboxSmtp.Size = new System.Drawing.Size(599, 31);
            this.txtMailboxSmtp.TabIndex = 1;
            // 
            // lblMailbox
            // 
            this.lblMailbox.AutoSize = true;
            this.lblMailbox.Location = new System.Drawing.Point(30, 42);
            this.lblMailbox.Name = "lblMailbox";
            this.lblMailbox.Size = new System.Drawing.Size(243, 25);
            this.lblMailbox.TabIndex = 2;
            this.lblMailbox.Text = "Mailbox SMTP Address:";
            // 
            // lvSharedCalendars
            // 
            this.lvSharedCalendars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSharedCalendars.HideSelection = false;
            this.lvSharedCalendars.Location = new System.Drawing.Point(23, 201);
            this.lvSharedCalendars.Name = "lvSharedCalendars";
            this.lvSharedCalendars.Size = new System.Drawing.Size(1337, 513);
            this.lvSharedCalendars.TabIndex = 3;
            this.lvSharedCalendars.UseCompatibleStateImageBehavior = false;
            this.lvSharedCalendars.SelectedIndexChanged += new System.EventHandler(this.lvSharedCalendars_SelectedIndexChanged);
            this.lvSharedCalendars.DoubleClick += new System.EventHandler(this.lvSharedCalendars_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Group Name:";
            // 
            // txtLinkGroupName
            // 
            this.txtLinkGroupName.Location = new System.Drawing.Point(292, 96);
            this.txtLinkGroupName.Name = "txtLinkGroupName";
            this.txtLinkGroupName.Size = new System.Drawing.Size(599, 31);
            this.txtLinkGroupName.TabIndex = 5;
            this.txtLinkGroupName.Text = "My Calendars";
            // 
            // SharedCalendarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 744);
            this.Controls.Add(this.txtLinkGroupName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvSharedCalendars);
            this.Controls.Add(this.lblMailbox);
            this.Controls.Add(this.txtMailboxSmtp);
            this.Controls.Add(this.button1);
            this.Name = "SharedCalendarsForm";
            this.Text = "SharedCalendars";
            this.Load += new System.EventHandler(this.SharedCalendars_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMailboxSmtp;
        private System.Windows.Forms.Label lblMailbox;
        private System.Windows.Forms.ListView lvSharedCalendars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLinkGroupName;
    }
}