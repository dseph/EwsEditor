namespace EWSEditor.Forms
{
    partial class TaskForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblMessageType = new System.Windows.Forms.Label();
            this.cmboBodyType = new System.Windows.Forms.ComboBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmboStatus = new System.Windows.Forms.ComboBox();
            this.lblImportance = new System.Windows.Forms.Label();
            this.cmboImportance = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastModifiedDate = new System.Windows.Forms.TextBox();
            this.txtLastModifiedName = new System.Windows.Forms.TextBox();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.btnEditInLargerWindow = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(14, 4);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(136, 66);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(9, 20);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(100, 102);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(954, 26);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Location = new System.Drawing.Point(14, 105);
            this.lblSubject.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(67, 20);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "Subject:";
            // 
            // txtBody
            // 
            this.txtBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBody.Location = new System.Drawing.Point(17, 255);
            this.txtBody.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBody.MaxLength = 0;
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBody.Size = new System.Drawing.Size(1048, 209);
            this.txtBody.TabIndex = 14;
            this.txtBody.TextChanged += new System.EventHandler(this.txtBody_TextChanged);
            // 
            // lblMessageType
            // 
            this.lblMessageType.AutoSize = true;
            this.lblMessageType.Location = new System.Drawing.Point(10, 218);
            this.lblMessageType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageType.Name = "lblMessageType";
            this.lblMessageType.Size = new System.Drawing.Size(87, 20);
            this.lblMessageType.TabIndex = 11;
            this.lblMessageType.Text = "Body Type:";
            // 
            // cmboBodyType
            // 
            this.cmboBodyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboBodyType.FormattingEnabled = true;
            this.cmboBodyType.Items.AddRange(new object[] {
            "Text",
            "HTML"});
            this.cmboBodyType.Location = new System.Drawing.Point(109, 218);
            this.cmboBodyType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmboBodyType.Name = "cmboBodyType";
            this.cmboBodyType.Size = new System.Drawing.Size(163, 28);
            this.cmboBodyType.TabIndex = 12;
            this.cmboBodyType.SelectedIndexChanged += new System.EventHandler(this.cmboBodyType_SelectedIndexChanged);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(119, 138);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(294, 26);
            this.dtStartDate.TabIndex = 4;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Due Date:";
            // 
            // dtDueDate
            // 
            this.dtDueDate.Location = new System.Drawing.Point(119, 171);
            this.dtDueDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(294, 26);
            this.dtDueDate.TabIndex = 8;
            this.dtDueDate.ValueChanged += new System.EventHandler(this.dtDueDate_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(472, 139);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status:";
            // 
            // cmboStatus
            // 
            this.cmboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboStatus.FormattingEnabled = true;
            this.cmboStatus.Items.AddRange(new object[] {
            "NotStarted",
            "InProgress",
            "Completed",
            "WaitingOnOthers",
            "Deferred"});
            this.cmboStatus.Location = new System.Drawing.Point(572, 139);
            this.cmboStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmboStatus.Name = "cmboStatus";
            this.cmboStatus.Size = new System.Drawing.Size(163, 28);
            this.cmboStatus.TabIndex = 6;
            this.cmboStatus.SelectedIndexChanged += new System.EventHandler(this.cmboStatus_SelectedIndexChanged);
            // 
            // lblImportance
            // 
            this.lblImportance.AutoSize = true;
            this.lblImportance.Location = new System.Drawing.Point(472, 178);
            this.lblImportance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImportance.Name = "lblImportance";
            this.lblImportance.Size = new System.Drawing.Size(60, 20);
            this.lblImportance.TabIndex = 9;
            this.lblImportance.Text = "Priority:";
            this.lblImportance.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmboImportance
            // 
            this.cmboImportance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboImportance.FormattingEnabled = true;
            this.cmboImportance.Items.AddRange(new object[] {
            "Low",
            "Normal",
            "High"});
            this.cmboImportance.Location = new System.Drawing.Point(572, 174);
            this.cmboImportance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmboImportance.Name = "cmboImportance";
            this.cmboImportance.Size = new System.Drawing.Size(163, 28);
            this.cmboImportance.TabIndex = 10;
            this.cmboImportance.SelectedIndexChanged += new System.EventHandler(this.cmboImportance_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 480);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Last Modified Name:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 480);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Last Modified Date:";
            // 
            // txtLastModifiedDate
            // 
            this.txtLastModifiedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastModifiedDate.Location = new System.Drawing.Point(168, 478);
            this.txtLastModifiedDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastModifiedDate.Name = "txtLastModifiedDate";
            this.txtLastModifiedDate.ReadOnly = true;
            this.txtLastModifiedDate.Size = new System.Drawing.Size(332, 26);
            this.txtLastModifiedDate.TabIndex = 17;
            // 
            // txtLastModifiedName
            // 
            this.txtLastModifiedName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLastModifiedName.Location = new System.Drawing.Point(682, 474);
            this.txtLastModifiedName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLastModifiedName.Name = "txtLastModifiedName";
            this.txtLastModifiedName.ReadOnly = true;
            this.txtLastModifiedName.Size = new System.Drawing.Size(372, 26);
            this.txtLastModifiedName.TabIndex = 19;
            // 
            // btnAttachments
            // 
            this.btnAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachments.Location = new System.Drawing.Point(819, 35);
            this.btnAttachments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(235, 35);
            this.btnAttachments.TabIndex = 0;
            this.btnAttachments.Tag = "";
            this.btnAttachments.Text = "Attachments";
            this.btnAttachments.UseVisualStyleBackColor = true;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // btnEditInLargerWindow
            // 
            this.btnEditInLargerWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditInLargerWindow.Location = new System.Drawing.Point(890, 210);
            this.btnEditInLargerWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditInLargerWindow.Name = "btnEditInLargerWindow";
            this.btnEditInLargerWindow.Size = new System.Drawing.Size(171, 35);
            this.btnEditInLargerWindow.TabIndex = 13;
            this.btnEditInLargerWindow.Text = "Edit in larger window";
            this.btnEditInLargerWindow.UseVisualStyleBackColor = true;
            this.btnEditInLargerWindow.Click += new System.EventHandler(this.btnEditInLargerWindow_Click);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 514);
            this.Controls.Add(this.btnEditInLargerWindow);
            this.Controls.Add(this.btnAttachments);
            this.Controls.Add(this.txtLastModifiedName);
            this.Controls.Add(this.txtLastModifiedDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmboImportance);
            this.Controls.Add(this.lblImportance);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmboStatus);
            this.Controls.Add(this.dtDueDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.lblMessageType);
            this.Controls.Add(this.cmboBodyType);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblSubject);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.Load += new System.EventHandler(this.TaskForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblMessageType;
        private System.Windows.Forms.ComboBox cmboBodyType;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmboStatus;
        private System.Windows.Forms.Label lblImportance;
        private System.Windows.Forms.ComboBox cmboImportance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLastModifiedDate;
        private System.Windows.Forms.TextBox txtLastModifiedName;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.Button btnEditInLargerWindow;
    }
}