namespace EWSEditor.Forms
{
    partial class RoomsForm
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
            this.lvRoomLists = new System.Windows.Forms.ListView();
            this.btnRoomLists = new System.Windows.Forms.Button();
            this.btnGetRooms = new System.Windows.Forms.Button();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.txtListSmtp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalLists = new System.Windows.Forms.Label();
            this.lblTotalRooms = new System.Windows.Forms.Label();
            this.chkAutoPopulate = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvRoomLists
            // 
            this.lvRoomLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRoomLists.Location = new System.Drawing.Point(14, 40);
            this.lvRoomLists.Name = "lvRoomLists";
            this.lvRoomLists.Size = new System.Drawing.Size(684, 142);
            this.lvRoomLists.TabIndex = 2;
            this.lvRoomLists.UseCompatibleStateImageBehavior = false;
            this.lvRoomLists.SelectedIndexChanged += new System.EventHandler(this.lvRoomLists_SelectedIndexChanged);
            this.lvRoomLists.Click += new System.EventHandler(this.lvRoomLists_Click);
            // 
            // btnRoomLists
            // 
            this.btnRoomLists.Location = new System.Drawing.Point(3, 11);
            this.btnRoomLists.Name = "btnRoomLists";
            this.btnRoomLists.Size = new System.Drawing.Size(126, 23);
            this.btnRoomLists.TabIndex = 0;
            this.btnRoomLists.Text = "Call GetRooomLists";
            this.btnRoomLists.UseVisualStyleBackColor = true;
            this.btnRoomLists.Click += new System.EventHandler(this.btnRoomLists_Click);
            // 
            // btnGetRooms
            // 
            this.btnGetRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRooms.Location = new System.Drawing.Point(572, 206);
            this.btnGetRooms.Name = "btnGetRooms";
            this.btnGetRooms.Size = new System.Drawing.Size(126, 23);
            this.btnGetRooms.TabIndex = 5;
            this.btnGetRooms.Text = "Call GetRooms";
            this.btnGetRooms.UseVisualStyleBackColor = true;
            this.btnGetRooms.Click += new System.EventHandler(this.btnGetRooms_Click);
            // 
            // lvRooms
            // 
            this.lvRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRooms.Location = new System.Drawing.Point(7, 234);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(691, 179);
            this.lvRooms.TabIndex = 7;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.SelectedIndexChanged += new System.EventHandler(this.lvRooms_SelectedIndexChanged);
            // 
            // txtListSmtp
            // 
            this.txtListSmtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListSmtp.Location = new System.Drawing.Point(119, 208);
            this.txtListSmtp.Name = "txtListSmtp";
            this.txtListSmtp.Size = new System.Drawing.Size(447, 20);
            this.txtListSmtp.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "List SMTP Address:";
            // 
            // lblTotalLists
            // 
            this.lblTotalLists.AutoSize = true;
            this.lblTotalLists.Location = new System.Drawing.Point(4, 185);
            this.lblTotalLists.Name = "lblTotalLists";
            this.lblTotalLists.Size = new System.Drawing.Size(72, 15);
            this.lblTotalLists.TabIndex = 8;
            this.lblTotalLists.Text = "lblTotalLists";
            // 
            // lblTotalRooms
            // 
            this.lblTotalRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRooms.AutoSize = true;
            this.lblTotalRooms.Location = new System.Drawing.Point(4, 416);
            this.lblTotalRooms.Name = "lblTotalRooms";
            this.lblTotalRooms.Size = new System.Drawing.Size(87, 15);
            this.lblTotalRooms.TabIndex = 9;
            this.lblTotalRooms.Text = "lblTotalRooms";
            // 
            // chkAutoPopulate
            // 
            this.chkAutoPopulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoPopulate.AutoSize = true;
            this.chkAutoPopulate.Location = new System.Drawing.Point(517, 14);
            this.chkAutoPopulate.Name = "chkAutoPopulate";
            this.chkAutoPopulate.Size = new System.Drawing.Size(181, 19);
            this.chkAutoPopulate.TabIndex = 10;
            this.chkAutoPopulate.Text = "Auto-poplulate rooms for list";
            this.chkAutoPopulate.UseVisualStyleBackColor = true;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(353, 416);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(345, 15);
            this.lblWarning.TabIndex = 11;
            this.lblWarning.Text = "Warning: This list may be over the 100 room limit per room list.";
            // 
            // RoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 440);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.chkAutoPopulate);
            this.Controls.Add(this.lblTotalRooms);
            this.Controls.Add(this.lblTotalLists);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtListSmtp);
            this.Controls.Add(this.btnGetRooms);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.btnRoomLists);
            this.Controls.Add(this.lvRoomLists);
            this.Name = "RoomsForm";
            this.Text = "Meeting Rooms";
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRoomLists;
        private System.Windows.Forms.Button btnRoomLists;
        private System.Windows.Forms.Button btnGetRooms;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.TextBox txtListSmtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalLists;
        private System.Windows.Forms.Label lblTotalRooms;
        private System.Windows.Forms.CheckBox chkAutoPopulate;
        private System.Windows.Forms.Label lblWarning;
    }
}