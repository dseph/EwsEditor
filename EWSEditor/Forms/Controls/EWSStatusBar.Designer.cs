namespace EWSEditor.Forms
{
    partial class EWSStatusBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sbStatus = new System.Windows.Forms.StatusStrip();
            this.prgStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuConnectedTo = new System.Windows.Forms.ToolStripMenuItem();
            this.ddbReqResp = new System.Windows.Forms.ToolStripDropDownButton();
            this.sbStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbStatus
            // 
            this.sbStatus.AllowMerge = false;
            this.sbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sbStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbReqResp,
            this.prgStatusBar,
            this.lblStatus});
            this.sbStatus.Location = new System.Drawing.Point(0, 0);
            this.sbStatus.Name = "sbStatus";
            this.sbStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sbStatus.Size = new System.Drawing.Size(539, 22);
            this.sbStatus.SizingGrip = false;
            this.sbStatus.TabIndex = 6;
            // 
            // prgStatusBar
            // 
            this.prgStatusBar.Name = "prgStatusBar";
            this.prgStatusBar.Size = new System.Drawing.Size(100, 16);
            this.prgStatusBar.Step = 1;
            this.prgStatusBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 17);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuConnectedTo
            // 
            this.mnuConnectedTo.Name = "mnuConnectedTo";
            this.mnuConnectedTo.Size = new System.Drawing.Size(152, 22);
            this.mnuConnectedTo.Text = "Connected to: ";
            this.mnuConnectedTo.Click += new System.EventHandler(this.mnuConnectedTo_Click);
            // 
            // ddbReqResp
            // 
            this.ddbReqResp.AutoSize = false;
            this.ddbReqResp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnectedTo});
            this.ddbReqResp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbReqResp.Name = "ddbReqResp";
            this.ddbReqResp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ddbReqResp.Size = new System.Drawing.Size(13, 20);
            // 
            // EWSStatusBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbStatus);
            this.Name = "EWSStatusBar";
            this.Size = new System.Drawing.Size(539, 22);
            this.sbStatus.ResumeLayout(false);
            this.sbStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sbStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar prgStatusBar;
        private System.Windows.Forms.ToolStripDropDownButton ddbReqResp;
        private System.Windows.Forms.ToolStripMenuItem mnuConnectedTo;
    }
}
