namespace EwsClient
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvRoomLists
            // 
            this.lvRoomLists.Location = new System.Drawing.Point(51, 31);
            this.lvRoomLists.Name = "lvRoomLists";
            this.lvRoomLists.Size = new System.Drawing.Size(468, 124);
            this.lvRoomLists.TabIndex = 0;
            this.lvRoomLists.UseCompatibleStateImageBehavior = false;
            // 
            // btnRoomLists
            // 
            this.btnRoomLists.Location = new System.Drawing.Point(393, 161);
            this.btnRoomLists.Name = "btnRoomLists";
            this.btnRoomLists.Size = new System.Drawing.Size(126, 23);
            this.btnRoomLists.TabIndex = 1;
            this.btnRoomLists.Text = "Call RoomLists";
            this.btnRoomLists.UseVisualStyleBackColor = true;
            this.btnRoomLists.Click += new System.EventHandler(this.btnRoomLists_Click);
            // 
            // lblRoomLists
            // 
            this.lblRoomLists.AutoSize = true;
            this.lblRoomLists.Location = new System.Drawing.Point(12, 15);
            this.lblRoomLists.Name = "lblRoomLists";
            this.lblRoomLists.Size = new System.Drawing.Size(59, 13);
            this.lblRoomLists.TabIndex = 2;
            this.lblRoomLists.Text = "RoomLists:";
            // 
            // lblGetRooms
            // 
            this.lblGetRooms.AutoSize = true;
            this.lblGetRooms.Location = new System.Drawing.Point(11, 198);
            this.lblGetRooms.Name = "lblGetRooms";
            this.lblGetRooms.Size = new System.Drawing.Size(60, 13);
            this.lblGetRooms.TabIndex = 5;
            this.lblGetRooms.Text = "GetRooms:";
            // 
            // btnGetRooms
            // 
            this.btnGetRooms.Location = new System.Drawing.Point(393, 344);
            this.btnGetRooms.Name = "btnGetRooms";
            this.btnGetRooms.Size = new System.Drawing.Size(126, 23);
            this.btnGetRooms.TabIndex = 4;
            this.btnGetRooms.Text = "Call GetRooms";
            this.btnGetRooms.UseVisualStyleBackColor = true;
            this.btnGetRooms.Click += new System.EventHandler(this.btnGetRooms_Click);
            // 
            // lvRooms
            // 
            this.lvRooms.Location = new System.Drawing.Point(51, 214);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(468, 124);
            this.lvRooms.TabIndex = 3;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 347);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ListSmtp";
            // 
            // RoomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 394);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}