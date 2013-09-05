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
            this.lvRoomLists.Location = new System.Drawing.Point(3, 55);
            this.lvRoomLists.Name = "lvRoomLists";
            this.lvRoomLists.Size = new System.Drawing.Size(692, 178);
            this.lvRoomLists.TabIndex = 2;
            this.lvRoomLists.UseCompatibleStateImageBehavior = false;
            this.lvRoomLists.SelectedIndexChanged += new System.EventHandler(this.lvRoomLists_SelectedIndexChanged);
            this.lvRoomLists.Click += new System.EventHandler(this.lvRoomLists_Click);
            // 
            // btnRoomLists
            // 
            this.btnRoomLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoomLists.Location = new System.Drawing.Point(3, 13);
            this.btnRoomLists.Name = "btnRoomLists";
            this.btnRoomLists.Size = new System.Drawing.Size(126, 23);
            this.btnRoomLists.TabIndex = 0;
            this.btnRoomLists.Text = "Room Lists";
            this.btnRoomLists.UseVisualStyleBackColor = true;
            this.btnRoomLists.Click += new System.EventHandler(this.btnRoomLists_Click);
            // 
            // lblRoomLists
            // 
            this.lblRoomLists.AutoSize = true;
            this.lblRoomLists.Location = new System.Drawing.Point(1, 39);
            this.lblRoomLists.Name = "lblRoomLists";
            this.lblRoomLists.Size = new System.Drawing.Size(59, 13);
            this.lblRoomLists.TabIndex = 1;
            this.lblRoomLists.Text = "RoomLists:";
            // 
            // lblGetRooms
            // 
            this.lblGetRooms.AutoSize = true;
            this.lblGetRooms.Location = new System.Drawing.Point(3, 271);
            this.lblGetRooms.Name = "lblGetRooms";
            this.lblGetRooms.Size = new System.Drawing.Size(60, 13);
            this.lblGetRooms.TabIndex = 6;
            this.lblGetRooms.Text = "GetRooms:";
            // 
            // btnGetRooms
            // 
            this.btnGetRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetRooms.Location = new System.Drawing.Point(549, 239);
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
            this.lvRooms.Location = new System.Drawing.Point(6, 287);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(680, 124);
            this.lvRooms.TabIndex = 7;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.SelectedIndexChanged += new System.EventHandler(this.lvRooms_SelectedIndexChanged);
            // 
            // txtListSmtp
            // 
            this.txtListSmtp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListSmtp.Location = new System.Drawing.Point(116, 242);
            this.txtListSmtp.Name = "txtListSmtp";
            this.txtListSmtp.Size = new System.Drawing.Size(425, 20);
            this.txtListSmtp.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "List SMTP Address:";
            // 
            // RoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 420);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtListSmtp);
            this.Controls.Add(this.lblGetRooms);
            this.Controls.Add(this.btnGetRooms);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.lblRoomLists);
            this.Controls.Add(this.btnRoomLists);
            this.Controls.Add(this.lvRoomLists);
            this.Name = "RoomsForm";
            this.Text = "Rooms ";
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