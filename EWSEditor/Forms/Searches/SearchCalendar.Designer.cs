namespace EWSEditor.Forms
{
    partial class SearchCalendar
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.btnFolderId = new System.Windows.Forms.Button();
            this.lblFolderId = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.chkSearchSubject = new System.Windows.Forms.CheckBox();
            this.chkSearchBody = new System.Windows.Forms.CheckBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.chkSearchCCAttendee = new System.Windows.Forms.CheckBox();
            this.txtCCAttendee = new System.Windows.Forms.TextBox();
            this.chkSearchToAttendee = new System.Windows.Forms.CheckBox();
            this.txtToAttendee = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Specify a date range to search:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a calendar folder to search in:";
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(431, 107);
            this.lblEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(95, 28);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "End Time:";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(533, 107);
            this.txtEndTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(263, 22);
            this.txtEndTime.TabIndex = 6;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(16, 111);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(105, 28);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start Time:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(143, 107);
            this.txtStartTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(263, 22);
            this.txtStartTime.TabIndex = 4;
            // 
            // btnFolderId
            // 
            this.btnFolderId.Location = new System.Drawing.Point(764, 41);
            this.btnFolderId.Margin = new System.Windows.Forms.Padding(4);
            this.btnFolderId.Name = "btnFolderId";
            this.btnFolderId.Size = new System.Drawing.Size(33, 25);
            this.btnFolderId.TabIndex = 16;
            this.btnFolderId.Text = "...";
            this.btnFolderId.UseVisualStyleBackColor = true;
            this.btnFolderId.Click += new System.EventHandler(this.btnFolderId_Click);
            // 
            // lblFolderId
            // 
            this.lblFolderId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFolderId.Location = new System.Drawing.Point(16, 41);
            this.lblFolderId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFolderId.Name = "lblFolderId";
            this.lblFolderId.Size = new System.Drawing.Size(740, 22);
            this.lblFolderId.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(732, 377);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(604, 377);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(143, 153);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(636, 22);
            this.txtSubject.TabIndex = 8;
            // 
            // chkSearchSubject
            // 
            this.chkSearchSubject.AutoSize = true;
            this.chkSearchSubject.Location = new System.Drawing.Point(20, 153);
            this.chkSearchSubject.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchSubject.Name = "chkSearchSubject";
            this.chkSearchSubject.Size = new System.Drawing.Size(81, 21);
            this.chkSearchSubject.TabIndex = 7;
            this.chkSearchSubject.Text = "Subject:";
            this.chkSearchSubject.UseVisualStyleBackColor = true;
            // 
            // chkSearchBody
            // 
            this.chkSearchBody.AutoSize = true;
            this.chkSearchBody.Location = new System.Drawing.Point(20, 185);
            this.chkSearchBody.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchBody.Name = "chkSearchBody";
            this.chkSearchBody.Size = new System.Drawing.Size(66, 21);
            this.chkSearchBody.TabIndex = 9;
            this.chkSearchBody.Text = "Body:";
            this.chkSearchBody.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(143, 185);
            this.txtBody.Margin = new System.Windows.Forms.Padding(4);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(636, 22);
            this.txtBody.TabIndex = 10;
            // 
            // chkSearchCCAttendee
            // 
            this.chkSearchCCAttendee.AutoSize = true;
            this.chkSearchCCAttendee.Location = new System.Drawing.Point(20, 247);
            this.chkSearchCCAttendee.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchCCAttendee.Name = "chkSearchCCAttendee";
            this.chkSearchCCAttendee.Size = new System.Drawing.Size(113, 21);
            this.chkSearchCCAttendee.TabIndex = 13;
            this.chkSearchCCAttendee.Text = "CC Attendee:";
            this.chkSearchCCAttendee.UseVisualStyleBackColor = true;
            // 
            // txtCCAttendee
            // 
            this.txtCCAttendee.Location = new System.Drawing.Point(143, 247);
            this.txtCCAttendee.Margin = new System.Windows.Forms.Padding(4);
            this.txtCCAttendee.Name = "txtCCAttendee";
            this.txtCCAttendee.Size = new System.Drawing.Size(636, 22);
            this.txtCCAttendee.TabIndex = 14;
            // 
            // chkSearchToAttendee
            // 
            this.chkSearchToAttendee.AutoSize = true;
            this.chkSearchToAttendee.Location = new System.Drawing.Point(20, 215);
            this.chkSearchToAttendee.Margin = new System.Windows.Forms.Padding(4);
            this.chkSearchToAttendee.Name = "chkSearchToAttendee";
            this.chkSearchToAttendee.Size = new System.Drawing.Size(112, 21);
            this.chkSearchToAttendee.TabIndex = 11;
            this.chkSearchToAttendee.Text = "To Attendee:";
            this.chkSearchToAttendee.UseVisualStyleBackColor = true;
            // 
            // txtToAttendee
            // 
            this.txtToAttendee.Location = new System.Drawing.Point(143, 215);
            this.txtToAttendee.Margin = new System.Windows.Forms.Padding(4);
            this.txtToAttendee.Name = "txtToAttendee";
            this.txtToAttendee.Size = new System.Drawing.Size(636, 22);
            this.txtToAttendee.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(553, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Note: This uses FindItems instead of FindAppointments.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(16, 297);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(553, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "TODO: Finish";
            // 
            // SearchCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 420);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSearchCCAttendee);
            this.Controls.Add(this.txtCCAttendee);
            this.Controls.Add(this.chkSearchToAttendee);
            this.Controls.Add(this.txtToAttendee);
            this.Controls.Add(this.chkSearchBody);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.chkSearchSubject);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.btnFolderId);
            this.Controls.Add(this.lblFolderId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchCalendar";
            this.Text = "SearchCalendar";
            this.Load += new System.EventHandler(this.SearchCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Button btnFolderId;
        private System.Windows.Forms.Label lblFolderId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.CheckBox chkSearchSubject;
        private System.Windows.Forms.CheckBox chkSearchBody;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.CheckBox chkSearchCCAttendee;
        private System.Windows.Forms.TextBox txtCCAttendee;
        private System.Windows.Forms.CheckBox chkSearchToAttendee;
        private System.Windows.Forms.TextBox txtToAttendee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}