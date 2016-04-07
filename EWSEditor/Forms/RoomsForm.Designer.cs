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
            this.lblRoomLists = new System.Windows.Forms.Label();
            this.lblGetRooms = new System.Windows.Forms.Label();
            this.btnGetRooms = new System.Windows.Forms.Button();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.txtListSmtp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvRoomLists
            // 
            this.lvRoomLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRoomLists.Location = new System.Drawing.Point(30, 68);
            this.lvRoomLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvRoomLists.Name = "lvRoomLists";
            this.lvRoomLists.Size = new System.Drawing.Size(908, 218);
            this.lvRoomLists.TabIndex = 2;
            this.lvRoomLists.UseCompatibleStateImageBehavior = false;
            this.lvRoomLists.SelectedIndexChanged += new System.EventHandler(this.lvRoomLists_SelectedIndexChanged);
            this.lvRoomLists.Click += new System.EventHandler(this.lvRoomLists_Click);
            // 
            // btnRoomLists
            // 
            this.btnRoomLists.Location = new System.Drawing.Point(4, 13);
            this.btnRoomLists.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRoomLists.Name = "btnRoomLists";
            this.btnRoomLists.Size = new System.Drawing.Size(168, 28);
            this.btnRoomLists.TabIndex = 0;
            this.btnRoomLists.Text = "Room Lists";
            this.btnRoomLists.UseVisualStyleBackColor = true;
            this.btnRoomLists.Click += new System.EventHandler(this.btnRoomLists_Click);
            // 
            // lblRoomLists
            // 
            this.lblRoomLists.AutoSize = true;
            this.lblRoomLists.Location = new System.Drawing.Point(1, 48);
            this.lblRoomLists.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoomLists.Name = "lblRoomLists";
            this.lblRoomLists.Size = new System.Drawing.Size(78, 17);
            this.lblRoomLists.TabIndex = 1;
            this.lblRoomLists.Text = "RoomLists:";
            // 
            // lblGetRooms
            // 
            this.lblGetRooms.AutoSize = true;
            this.lblGetRooms.Location = new System.Drawing.Point(5, 333);
            this.lblGetRooms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGetRooms.Name = "lblGetRooms";
            this.lblGetRooms.Size = new System.Drawing.Size(79, 17);
            this.lblGetRooms.TabIndex = 6;
            this.lblGetRooms.Text = "GetRooms:";
            // 
            // btnGetRooms
            // 
            this.btnGetRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRooms.Location = new System.Drawing.Point(758, 295);
            this.btnGetRooms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetRooms.Name = "btnGetRooms";
            this.btnGetRooms.Size = new System.Drawing.Size(168, 28);
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
            this.lvRooms.Location = new System.Drawing.Point(41, 354);
            this.lvRooms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(885, 170);
            this.lvRooms.TabIndex = 7;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.SelectedIndexChanged += new System.EventHandler(this.lvRooms_SelectedIndexChanged);
            // 
            // txtListSmtp
            // 
            this.txtListSmtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListSmtp.Location = new System.Drawing.Point(155, 298);
            this.txtListSmtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtListSmtp.Name = "txtListSmtp";
            this.txtListSmtp.Size = new System.Drawing.Size(578, 22);
            this.txtListSmtp.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "List SMTP Address:";
            // 
            // RoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 537);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtListSmtp);
            this.Controls.Add(this.lblGetRooms);
            this.Controls.Add(this.btnGetRooms);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.lblRoomLists);
            this.Controls.Add(this.btnRoomLists);
            this.Controls.Add(this.lvRoomLists);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RoomsForm";
            this.Text = "Meeting Rooms";
            this.Load += new System.EventHandler(this.RoomsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRoomLists;
        private System.Windows.Forms.Button btnRoomLists;
        private System.Windows.Forms.Label lblRoomLists;
        private System.Windows.Forms.Label lblGetRooms;
        private System.Windows.Forms.Button btnGetRooms;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.TextBox txtListSmtp;
        private System.Windows.Forms.Label label1;
    }
}