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
            this.btnInstallApp.Location = new System.Drawing.Point(8, 155);
            this.btnInstallApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInstallApp.Name = "btnInstallApp";
            this.btnInstallApp.Size = new System.Drawing.Size(271, 28);
            this.btnInstallApp.TabIndex = 2;
            this.btnInstallApp.Text = "Install App";
            this.btnInstallApp.UseVisualStyleBackColor = true;
            this.btnInstallApp.Click += new System.EventHandler(this.btnInstallApp_Click);
            // 
            // btsGetAppMarketplaceUrl
            // 
            this.btsGetAppMarketplaceUrl.Location = new System.Drawing.Point(4, 15);
            this.btsGetAppMarketplaceUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btsGetAppMarketplaceUrl.Name = "btsGetAppMarketplaceUrl";
            this.btsGetAppMarketplaceUrl.Size = new System.Drawing.Size(271, 28);
            this.btsGetAppMarketplaceUrl.TabIndex = 0;
            this.btsGetAppMarketplaceUrl.Text = "Get App Marketplace Url";
            this.btsGetAppMarketplaceUrl.UseVisualStyleBackColor = true;
            this.btsGetAppMarketplaceUrl.Click += new System.EventHandler(this.btsGetAppMarketplaceUrl_Click);
            // 
            // btnUninstallApp
            // 
            this.btnUninstallApp.Location = new System.Drawing.Point(8, 190);
            this.btnUninstallApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUninstallApp.Name = "btnUninstallApp";
            this.btnUninstallApp.Size = new System.Drawing.Size(271, 28);
            this.btnUninstallApp.TabIndex = 3;
            this.btnUninstallApp.Text = "Uninstall App";
            this.btnUninstallApp.UseVisualStyleBackColor = true;
            this.btnUninstallApp.Click += new System.EventHandler(this.btnUninstallApp_Click);
            // 
            // btnGetAppsManifest
            // 
            this.btnGetAppsManifest.Location = new System.Drawing.Point(8, 274);
            this.btnGetAppsManifest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetAppsManifest.Name = "btnGetAppsManifest";
            this.btnGetAppsManifest.Size = new System.Drawing.Size(271, 28);
            this.btnGetAppsManifest.TabIndex = 11;
            this.btnGetAppsManifest.Text = "Get Apps Manifest";
            this.btnGetAppsManifest.UseVisualStyleBackColor = true;
            this.btnGetAppsManifest.Click += new System.EventHandler(this.btnGetAppsManifest_Click);
            // 
            // btnDisableApp
            // 
            this.btnDisableApp.Location = new System.Drawing.Point(8, 238);
            this.btnDisableApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDisableApp.Name = "btnDisableApp";
            this.btnDisableApp.Size = new System.Drawing.Size(271, 28);
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
            this.textBox1.Location = new System.Drawing.Point(34, 310);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1103, 184);
            this.textBox1.TabIndex = 12;
            // 
            // lblUninstallAppId
            // 
            this.lblUninstallAppId.AutoSize = true;
            this.lblUninstallAppId.Location = new System.Drawing.Point(301, 201);
            this.lblUninstallAppId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUninstallAppId.Name = "lblUninstallAppId";
            this.lblUninstallAppId.Size = new System.Drawing.Size(48, 17);
            this.lblUninstallAppId.TabIndex = 4;
            this.lblUninstallAppId.Text = "AppId:";
            // 
            // txtUninstallAppId
            // 
            this.txtUninstallAppId.Location = new System.Drawing.Point(360, 193);
            this.txtUninstallAppId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUninstallAppId.Name = "txtUninstallAppId";
            this.txtUninstallAppId.Size = new System.Drawing.Size(384, 22);
            this.txtUninstallAppId.TabIndex = 5;
            // 
            // txtDisableAppId
            // 
            this.txtDisableAppId.Location = new System.Drawing.Point(360, 238);
            this.txtDisableAppId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDisableAppId.Name = "txtDisableAppId";
            this.txtDisableAppId.Size = new System.Drawing.Size(384, 22);
            this.txtDisableAppId.TabIndex = 8;
            // 
            // lblDisableAppId
            // 
            this.lblDisableAppId.AutoSize = true;
            this.lblDisableAppId.Location = new System.Drawing.Point(301, 244);
            this.lblDisableAppId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisableAppId.Name = "lblDisableAppId";
            this.lblDisableAppId.Size = new System.Drawing.Size(48, 17);
            this.lblDisableAppId.TabIndex = 7;
            this.lblDisableAppId.Text = "AppId:";
            // 
            // cmboDisableReason
            // 
            this.cmboDisableReason.AutoSize = true;
            this.cmboDisableReason.Location = new System.Drawing.Point(765, 242);
            this.cmboDisableReason.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cmboDisableReason.Name = "cmboDisableReason";
            this.cmboDisableReason.Size = new System.Drawing.Size(61, 17);
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
            this.cmboLegacyFreeBusyStatus.Location = new System.Drawing.Point(829, 237);
            this.cmboLegacyFreeBusyStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmboLegacyFreeBusyStatus.Name = "cmboLegacyFreeBusyStatus";
            this.cmboLegacyFreeBusyStatus.Size = new System.Drawing.Size(296, 24);
            this.cmboLegacyFreeBusyStatus.TabIndex = 10;
            // 
            // txtAppMarketplaceUrl
            // 
            this.txtAppMarketplaceUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAppMarketplaceUrl.Location = new System.Drawing.Point(34, 51);
            this.txtAppMarketplaceUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAppMarketplaceUrl.Multiline = true;
            this.txtAppMarketplaceUrl.Name = "txtAppMarketplaceUrl";
            this.txtAppMarketplaceUrl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAppMarketplaceUrl.Size = new System.Drawing.Size(1103, 89);
            this.txtAppMarketplaceUrl.TabIndex = 1;
            // 
            // MailApps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 507);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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