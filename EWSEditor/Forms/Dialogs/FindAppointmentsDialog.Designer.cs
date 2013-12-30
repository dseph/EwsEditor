namespace EWSEditor.Forms
{
    partial class FindAppointmentsDialog
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
        private new void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFolderId = new System.Windows.Forms.Button();
            this.lblFolderId = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(170, 158);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(251, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnFolderId
            // 
            this.btnFolderId.Location = new System.Drawing.Point(298, 42);
            this.btnFolderId.Name = "btnFolderId";
            this.btnFolderId.Size = new System.Drawing.Size(25, 20);
            this.btnFolderId.TabIndex = 0;
            this.btnFolderId.Text = "...";
            this.btnFolderId.UseVisualStyleBackColor = true;
            this.btnFolderId.Click += new System.EventHandler(this.btnFolderId_Click);
            // 
            // lblFolderId
            // 
            this.lblFolderId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFolderId.Location = new System.Drawing.Point(12, 42);
            this.lblFolderId.Name = "lblFolderId";
            this.lblFolderId.Size = new System.Drawing.Size(280, 18);
            this.lblFolderId.TabIndex = 8;
            // 
            // lblEnd
            // 
            this.lblEnd.Location = new System.Drawing.Point(12, 122);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(71, 23);
            this.lblEnd.TabIndex = 13;
            this.lblEnd.Text = "End Time:";
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(97, 119);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(198, 20);
            this.txtEndTime.TabIndex = 2;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(12, 99);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(79, 23);
            this.lblStart.TabIndex = 11;
            this.lblStart.Text = "Start Time:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(97, 96);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(198, 20);
            this.txtStartTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Select a calendar folder to search in:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Specify a date range to search:";
            // 
            // FindAppointmentsDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(339, 193);
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
            this.Name = "FindAppointmentsDialog";
            this.Text = "FindAppointments";
            this.Load += new System.EventHandler(this.FindAppointmentsDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFolderId;
        private System.Windows.Forms.Label lblFolderId;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}