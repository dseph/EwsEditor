namespace EWSEditor.Forms
{
    partial class MailApps
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
            this.btnInstallApp = new System.Windows.Forms.Button();
            this.btsGetAppMarketplaceUrl = new System.Windows.Forms.Button();
            this.btnUninstallApp = new System.Windows.Forms.Button();
            this.btnGetAppsManifest = new System.Windows.Forms.Button();
            this.btnDisableApp = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblUninstallAppId = new System.Windows.Forms.Label();
            this.txtUninstallAppId = new System.Windows.Forms.TextBox();
            this.txtDisableAppId = new System.Windows.Forms.TextBox();
            this.lblDisableAppId = new System.Windows.Forms.Label();
            this.cmboDisableReason = new System.Windows.Forms.Label();
            this.cmboLegacyFreeBusyStatus = new System.Windows.Forms.ComboBox();
            this.txtAppMarketplaceUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnInstallApp
            // 
            this.btnInstallApp.Location = new System.Drawing.Point(3, 98);
            this.btnInstallApp.Name = "btnInstallApp";
            this.btnInstallApp.Size = new System.Drawing.Size(203, 23);
            this.btnInstallApp.TabIndex = 2;
            this.btnInstallApp.Text = "Install App";
            this.btnInstallApp.UseVisualStyleBackColor = true;
            this.btnInstallApp.Click += new System.EventHandler(this.btnInstallApp_Click);
            // 
            // btsGetAppMarketplaceUrl
            // 
            this.btsGetAppMarketplaceUrl.Location = new System.Drawing.Point(3, 12);
            this.btsGetAppMarketplaceUrl.Name = "btsGetAppMarketplaceUrl";
            this.btsGetAppMarketplaceUrl.Size = new System.Drawing.Size(203, 23);
            this.btsGetAppMarketplaceUrl.TabIndex = 0;
            this.btsGetAppMarketplaceUrl.Text = "Get App Marketplace Url";
            this.btsGetAppMarketplaceUrl.UseVisualStyleBackColor = true;
            this.btsGetAppMarketplaceUrl.Click += new System.EventHandler(this.btsGetAppMarketplaceUrl_Click);
            // 
            // btnUninstallApp
            // 
            this.btnUninstallApp.Location = new System.Drawing.Point(3, 127);
            this.btnUninstallApp.Name = "btnUninstallApp";
            this.btnUninstallApp.Size = new System.Drawing.Size(203, 23);
            this.btnUninstallApp.TabIndex = 3;
            this.btnUninstallApp.Text = "Uninstall App";
            this.btnUninstallApp.UseVisualStyleBackColor = true;
            this.btnUninstallApp.Click += new System.EventHandler(this.btnUninstallApp_Click);
            // 
            // btnGetAppsManifest
            // 
            this.btnGetAppsManifest.Location = new System.Drawing.Point(3, 195);
            this.btnGetAppsManifest.Name = "btnGetAppsManifest";
            this.btnGetAppsManifest.Size = new System.Drawing.Size(203, 23);
            this.btnGetAppsManifest.TabIndex = 11;
            this.btnGetAppsManifest.Text = "Get Apps Manifest";
            this.btnGetAppsManifest.UseVisualStyleBackColor = true;
            this.btnGetAppsManifest.Click += new System.EventHandler(this.btnGetAppsManifest_Click);
            // 
            // btnDisableApp
            // 
            this.btnDisableApp.Location = new System.Drawing.Point(3, 166);
            this.btnDisableApp.Name = "btnDisableApp";
            this.btnDisableApp.Size = new System.Drawing.Size(203, 23);
            this.btnDisableApp.TabIndex = 6;
            this.btnDisableApp.Text = "Disable App";
            this.btnDisableApp.UseVisualStyleBackColor = true;
            this.btnDisableApp.Click += new System.EventHandler(this.btnDisableApp_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(50, 224);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(814, 176);
            this.textBox1.TabIndex = 12;
            // 
            // lblUninstallAppId
            // 
            this.lblUninstallAppId.AutoSize = true;
            this.lblUninstallAppId.Location = new System.Drawing.Point(223, 136);
            this.lblUninstallAppId.Name = "lblUninstallAppId";
            this.lblUninstallAppId.Size = new System.Drawing.Size(38, 13);
            this.lblUninstallAppId.TabIndex = 4;
            this.lblUninstallAppId.Text = "AppId:";
            // 
            // txtUninstallAppId
            // 
            this.txtUninstallAppId.Location = new System.Drawing.Point(267, 129);
            this.txtUninstallAppId.Name = "txtUninstallAppId";
            this.txtUninstallAppId.Size = new System.Drawing.Size(289, 20);
            this.txtUninstallAppId.TabIndex = 5;
            // 
            // txtDisableAppId
            // 
            this.txtDisableAppId.Location = new System.Drawing.Point(267, 166);
            this.txtDisableAppId.Name = "txtDisableAppId";
            this.txtDisableAppId.Size = new System.Drawing.Size(289, 20);
            this.txtDisableAppId.TabIndex = 8;
            // 
            // lblDisableAppId
            // 
            this.lblDisableAppId.AutoSize = true;
            this.lblDisableAppId.Location = new System.Drawing.Point(223, 171);
            this.lblDisableAppId.Name = "lblDisableAppId";
            this.lblDisableAppId.Size = new System.Drawing.Size(38, 13);
            this.lblDisableAppId.TabIndex = 7;
            this.lblDisableAppId.Text = "AppId:";
            // 
            // cmboDisableReason
            // 
            this.cmboDisableReason.AutoSize = true;
            this.cmboDisableReason.Location = new System.Drawing.Point(571, 169);
            this.cmboDisableReason.Name = "cmboDisableReason";
            this.cmboDisableReason.Size = new System.Drawing.Size(47, 13);
            this.cmboDisableReason.TabIndex = 9;
            this.cmboDisableReason.Text = "Reason:";
            // 
            // cmboLegacyFreeBusyStatus
            // 
            this.cmboLegacyFreeBusyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboLegacyFreeBusyStatus.FormattingEnabled = true;
            this.cmboLegacyFreeBusyStatus.Items.AddRange(new object[] {
            "NoReason",
            "OutlookClientPerformance",
            "OWAClientPerformance",
            "MobileClientPerformance"});
            this.cmboLegacyFreeBusyStatus.Location = new System.Drawing.Point(619, 165);
            this.cmboLegacyFreeBusyStatus.Name = "cmboLegacyFreeBusyStatus";
            this.cmboLegacyFreeBusyStatus.Size = new System.Drawing.Size(223, 21);
            this.cmboLegacyFreeBusyStatus.TabIndex = 10;
            // 
            // txtAppMarketplaceUrl
            // 
            this.txtAppMarketplaceUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppMarketplaceUrl.Location = new System.Drawing.Point(226, 12);
            this.txtAppMarketplaceUrl.Multiline = true;
            this.txtAppMarketplaceUrl.Name = "txtAppMarketplaceUrl";
            this.txtAppMarketplaceUrl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAppMarketplaceUrl.Size = new System.Drawing.Size(638, 73);
            this.txtAppMarketplaceUrl.TabIndex = 1;
            // 
            // MailApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 412);
            this.Controls.Add(this.txtAppMarketplaceUrl);
            this.Controls.Add(this.cmboLegacyFreeBusyStatus);
            this.Controls.Add(this.cmboDisableReason);
            this.Controls.Add(this.txtDisableAppId);
            this.Controls.Add(this.lblDisableAppId);
            this.Controls.Add(this.txtUninstallAppId);
            this.Controls.Add(this.lblUninstallAppId);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDisableApp);
            this.Controls.Add(this.btnGetAppsManifest);
            this.Controls.Add(this.btnUninstallApp);
            this.Controls.Add(this.btsGetAppMarketplaceUrl);
            this.Controls.Add(this.btnInstallApp);
            this.Name = "MailApps";
            this.Text = "Apps";
            this.Load += new System.EventHandler(this.Apps_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInstallApp;
        private System.Windows.Forms.Button btsGetAppMarketplaceUrl;
        private System.Windows.Forms.Button btnUninstallApp;
        private System.Windows.Forms.Button btnGetAppsManifest;
        private System.Windows.Forms.Button btnDisableApp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUninstallAppId;
        private System.Windows.Forms.TextBox txtUninstallAppId;
        private System.Windows.Forms.TextBox txtDisableAppId;
        private System.Windows.Forms.Label lblDisableAppId;
        private System.Windows.Forms.Label cmboDisableReason;
        private System.Windows.Forms.ComboBox cmboLegacyFreeBusyStatus;
        private System.Windows.Forms.TextBox txtAppMarketplaceUrl;
    }
}