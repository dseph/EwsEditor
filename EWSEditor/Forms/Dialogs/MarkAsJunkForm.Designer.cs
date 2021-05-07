namespace EWSEditor.Forms
{
    partial class MarkAsJunkForm
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
            this.txtHelp = new System.Windows.Forms.TextBox();
            this.chkIsJunk = new System.Windows.Forms.CheckBox();
            this.chkMoveItem = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHelp
            // 
            this.txtHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHelp.Location = new System.Drawing.Point(12, 180);
            this.txtHelp.Multiline = true;
            this.txtHelp.Name = "txtHelp";
            this.txtHelp.ReadOnly = true;
            this.txtHelp.Size = new System.Drawing.Size(741, 306);
            this.txtHelp.TabIndex = 1;
            this.txtHelp.TabStop = false;
            // 
            // chkIsJunk
            // 
            this.chkIsJunk.AutoSize = true;
            this.chkIsJunk.Location = new System.Drawing.Point(12, 45);
            this.chkIsJunk.Name = "chkIsJunk";
            this.chkIsJunk.Size = new System.Drawing.Size(82, 24);
            this.chkIsJunk.TabIndex = 2;
            this.chkIsJunk.Text = "IsJunk";
            this.chkIsJunk.UseVisualStyleBackColor = true;
            this.chkIsJunk.CheckedChanged += new System.EventHandler(this.chkIsJunk_CheckedChanged);
            // 
            // chkMoveItem
            // 
            this.chkMoveItem.AutoSize = true;
            this.chkMoveItem.Location = new System.Drawing.Point(166, 45);
            this.chkMoveItem.Name = "chkMoveItem";
            this.chkMoveItem.Size = new System.Drawing.Size(105, 24);
            this.chkMoveItem.TabIndex = 3;
            this.chkMoveItem.Text = "MoveItem";
            this.chkMoveItem.UseVisualStyleBackColor = true;
            this.chkMoveItem.CheckedChanged += new System.EventHandler(this.chkMoveItem_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(572, 21);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(181, 34);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Mark As Junk";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Below Checked means True and unchecked means False.";
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.Location = new System.Drawing.Point(12, 75);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(741, 68);
            this.txtInfo.TabIndex = 6;
            this.txtInfo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Help:";
            // 
            // MarkAsJunkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.chkMoveItem);
            this.Controls.Add(this.chkIsJunk);
            this.Controls.Add(this.txtHelp);
            this.Name = "MarkAsJunkForm";
            this.Text = "Mark As Junk Form";
            this.Load += new System.EventHandler(this.MarkAsJunkForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHelp;
        private System.Windows.Forms.CheckBox chkIsJunk;
        private System.Windows.Forms.CheckBox chkMoveItem;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label2;
    }
}