namespace EWSEditor.Forms
{
    partial class TimeZonesForm
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
            this.btnServerTimeZone = new System.Windows.Forms.Button();
            this.cmboTimeZoneIds = new System.Windows.Forms.ComboBox();
            this.TimeZoneByIdString = new System.Windows.Forms.Button();
            this.btnListTimezones = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtServerTimezoneResults = new System.Windows.Forms.TextBox();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.tabTimeZones = new System.Windows.Forms.TabControl();
            this.tabExchangeServerTimeZone = new System.Windows.Forms.TabPage();
            this.tabClientTimeZones = new System.Windows.Forms.TabPage();
            this.lvMachineTimeZones = new System.Windows.Forms.ListView();
            this.tabClientTimezoneLookup = new System.Windows.Forms.TabPage();
            this.txtTimeZoneLookupResults = new System.Windows.Forms.TextBox();
            this.tabClientCurrentTimeZone = new System.Windows.Forms.TabPage();
            this.txtClientCurrentTimezone = new System.Windows.Forms.TextBox();
            this.btnClientCurrentTimeZone = new System.Windows.Forms.Button();
            this.tabTimeZones.SuspendLayout();
            this.tabExchangeServerTimeZone.SuspendLayout();
            this.tabClientTimeZones.SuspendLayout();
            this.tabClientTimezoneLookup.SuspendLayout();
            this.tabClientCurrentTimeZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServerTimeZone
            // 
            this.btnServerTimeZone.Location = new System.Drawing.Point(3, 3);
            this.btnServerTimeZone.Name = "btnServerTimeZone";
            this.btnServerTimeZone.Size = new System.Drawing.Size(156, 27);
            this.btnServerTimeZone.TabIndex = 34;
            this.btnServerTimeZone.Text = "Exchange Server TimeZone";
            this.btnServerTimeZone.UseVisualStyleBackColor = true;
            this.btnServerTimeZone.Click += new System.EventHandler(this.btnServerTimeZone_Click);
            // 
            // cmboTimeZoneIds
            // 
            this.cmboTimeZoneIds.FormattingEnabled = true;
            this.cmboTimeZoneIds.Location = new System.Drawing.Point(152, 12);
            this.cmboTimeZoneIds.Name = "cmboTimeZoneIds";
            this.cmboTimeZoneIds.Size = new System.Drawing.Size(380, 23);
            this.cmboTimeZoneIds.TabIndex = 33;
            this.cmboTimeZoneIds.SelectedIndexChanged += new System.EventHandler(this.cmboTimeZoneIds_SelectedIndexChanged);
            // 
            // TimeZoneByIdString
            // 
            this.TimeZoneByIdString.Location = new System.Drawing.Point(6, 6);
            this.TimeZoneByIdString.Name = "TimeZoneByIdString";
            this.TimeZoneByIdString.Size = new System.Drawing.Size(140, 27);
            this.TimeZoneByIdString.TabIndex = 32;
            this.TimeZoneByIdString.Text = "Find Timezone by ID string";
            this.TimeZoneByIdString.UseVisualStyleBackColor = true;
            this.TimeZoneByIdString.Click += new System.EventHandler(this.TimeZoneByIdString_Click);
            // 
            // btnListTimezones
            // 
            this.btnListTimezones.Location = new System.Drawing.Point(3, 3);
            this.btnListTimezones.Name = "btnListTimezones";
            this.btnListTimezones.Size = new System.Drawing.Size(156, 27);
            this.btnListTimezones.TabIndex = 31;
            this.btnListTimezones.Text = "List ";
            this.btnListTimezones.UseVisualStyleBackColor = true;
            this.btnListTimezones.Click += new System.EventHandler(this.btnListTimezones_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(538, 13);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtStartDate.TabIndex = 35;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // txtServerTimezoneResults
            // 
            this.txtServerTimezoneResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerTimezoneResults.Location = new System.Drawing.Point(3, 36);
            this.txtServerTimezoneResults.Multiline = true;
            this.txtServerTimezoneResults.Name = "txtServerTimezoneResults";
            this.txtServerTimezoneResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtServerTimezoneResults.Size = new System.Drawing.Size(884, 404);
            this.txtServerTimezoneResults.TabIndex = 36;
            this.txtServerTimezoneResults.WordWrap = false;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStartTime.Location = new System.Drawing.Point(744, 13);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(135, 22);
            this.dtStartTime.TabIndex = 37;
            this.dtStartTime.ValueChanged += new System.EventHandler(this.dtStartTime_ValueChanged);
            // 
            // tabTimeZones
            // 
            this.tabTimeZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTimeZones.Controls.Add(this.tabExchangeServerTimeZone);
            this.tabTimeZones.Controls.Add(this.tabClientTimeZones);
            this.tabTimeZones.Controls.Add(this.tabClientTimezoneLookup);
            this.tabTimeZones.Controls.Add(this.tabClientCurrentTimeZone);
            this.tabTimeZones.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.tabTimeZones.Location = new System.Drawing.Point(7, 12);
            this.tabTimeZones.Name = "tabTimeZones";
            this.tabTimeZones.SelectedIndex = 0;
            this.tabTimeZones.Size = new System.Drawing.Size(898, 471);
            this.tabTimeZones.TabIndex = 38;
            // 
            // tabExchangeServerTimeZone
            // 
            this.tabExchangeServerTimeZone.Controls.Add(this.btnServerTimeZone);
            this.tabExchangeServerTimeZone.Controls.Add(this.txtServerTimezoneResults);
            this.tabExchangeServerTimeZone.Location = new System.Drawing.Point(4, 24);
            this.tabExchangeServerTimeZone.Name = "tabExchangeServerTimeZone";
            this.tabExchangeServerTimeZone.Size = new System.Drawing.Size(890, 443);
            this.tabExchangeServerTimeZone.TabIndex = 2;
            this.tabExchangeServerTimeZone.Text = "Exchange Server TimeZone";
            this.tabExchangeServerTimeZone.UseVisualStyleBackColor = true;
            // 
            // tabClientTimeZones
            // 
            this.tabClientTimeZones.Controls.Add(this.lvMachineTimeZones);
            this.tabClientTimeZones.Controls.Add(this.btnListTimezones);
            this.tabClientTimeZones.Location = new System.Drawing.Point(4, 24);
            this.tabClientTimeZones.Name = "tabClientTimeZones";
            this.tabClientTimeZones.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientTimeZones.Size = new System.Drawing.Size(890, 443);
            this.tabClientTimeZones.TabIndex = 0;
            this.tabClientTimeZones.Text = "Client TimeZones";
            this.tabClientTimeZones.UseVisualStyleBackColor = true;
            // 
            // lvMachineTimeZones
            // 
            this.lvMachineTimeZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMachineTimeZones.Location = new System.Drawing.Point(0, 36);
            this.lvMachineTimeZones.Name = "lvMachineTimeZones";
            this.lvMachineTimeZones.Size = new System.Drawing.Size(884, 401);
            this.lvMachineTimeZones.TabIndex = 32;
            this.lvMachineTimeZones.UseCompatibleStateImageBehavior = false;
            // 
            // tabClientTimezoneLookup
            // 
            this.tabClientTimezoneLookup.Controls.Add(this.txtTimeZoneLookupResults);
            this.tabClientTimezoneLookup.Controls.Add(this.TimeZoneByIdString);
            this.tabClientTimezoneLookup.Controls.Add(this.dtStartTime);
            this.tabClientTimezoneLookup.Controls.Add(this.cmboTimeZoneIds);
            this.tabClientTimezoneLookup.Controls.Add(this.dtStartDate);
            this.tabClientTimezoneLookup.Location = new System.Drawing.Point(4, 24);
            this.tabClientTimezoneLookup.Name = "tabClientTimezoneLookup";
            this.tabClientTimezoneLookup.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientTimezoneLookup.Size = new System.Drawing.Size(890, 443);
            this.tabClientTimezoneLookup.TabIndex = 1;
            this.tabClientTimezoneLookup.Text = "Client Timezone Lookup";
            this.tabClientTimezoneLookup.UseVisualStyleBackColor = true;
            // 
            // txtTimeZoneLookupResults
            // 
            this.txtTimeZoneLookupResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeZoneLookupResults.Location = new System.Drawing.Point(0, 39);
            this.txtTimeZoneLookupResults.Multiline = true;
            this.txtTimeZoneLookupResults.Name = "txtTimeZoneLookupResults";
            this.txtTimeZoneLookupResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTimeZoneLookupResults.Size = new System.Drawing.Size(887, 401);
            this.txtTimeZoneLookupResults.TabIndex = 38;
            this.txtTimeZoneLookupResults.WordWrap = false;
            // 
            // tabClientCurrentTimeZone
            // 
            this.tabClientCurrentTimeZone.Controls.Add(this.txtClientCurrentTimezone);
            this.tabClientCurrentTimeZone.Controls.Add(this.btnClientCurrentTimeZone);
            this.tabClientCurrentTimeZone.Location = new System.Drawing.Point(4, 22);
            this.tabClientCurrentTimeZone.Name = "tabClientCurrentTimeZone";
            this.tabClientCurrentTimeZone.Size = new System.Drawing.Size(890, 445);
            this.tabClientCurrentTimeZone.TabIndex = 3;
            this.tabClientCurrentTimeZone.Text = "Client Current TimeZone";
            this.tabClientCurrentTimeZone.UseVisualStyleBackColor = true;
            // 
            // txtClientCurrentTimezone
            // 
            this.txtClientCurrentTimezone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientCurrentTimezone.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientCurrentTimezone.Location = new System.Drawing.Point(3, 36);
            this.txtClientCurrentTimezone.Multiline = true;
            this.txtClientCurrentTimezone.Name = "txtClientCurrentTimezone";
            this.txtClientCurrentTimezone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtClientCurrentTimezone.Size = new System.Drawing.Size(884, 389);
            this.txtClientCurrentTimezone.TabIndex = 37;
            this.txtClientCurrentTimezone.WordWrap = false;
            // 
            // btnClientCurrentTimeZone
            // 
            this.btnClientCurrentTimeZone.Location = new System.Drawing.Point(3, 3);
            this.btnClientCurrentTimeZone.Name = "btnClientCurrentTimeZone";
            this.btnClientCurrentTimeZone.Size = new System.Drawing.Size(156, 27);
            this.btnClientCurrentTimeZone.TabIndex = 35;
            this.btnClientCurrentTimeZone.Text = "Details";
            this.btnClientCurrentTimeZone.UseVisualStyleBackColor = true;
            this.btnClientCurrentTimeZone.Click += new System.EventHandler(this.btnClientCurrentTimeZone_Click);
            // 
            // TimeZonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 495);
            this.Controls.Add(this.tabTimeZones);
            this.Name = "TimeZonesForm";
            this.Text = "Time Zones ";
            this.Load += new System.EventHandler(this.TimeZonesForm_Load);
            this.tabTimeZones.ResumeLayout(false);
            this.tabExchangeServerTimeZone.ResumeLayout(false);
            this.tabExchangeServerTimeZone.PerformLayout();
            this.tabClientTimeZones.ResumeLayout(false);
            this.tabClientTimezoneLookup.ResumeLayout(false);
            this.tabClientTimezoneLookup.PerformLayout();
            this.tabClientCurrentTimeZone.ResumeLayout(false);
            this.tabClientCurrentTimeZone.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnServerTimeZone;
        private System.Windows.Forms.ComboBox cmboTimeZoneIds;
        private System.Windows.Forms.Button TimeZoneByIdString;
        private System.Windows.Forms.Button btnListTimezones;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.TextBox txtServerTimezoneResults;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.TabControl tabTimeZones;
        private System.Windows.Forms.TabPage tabClientTimeZones;
        private System.Windows.Forms.TabPage tabClientTimezoneLookup;
        private System.Windows.Forms.TabPage tabExchangeServerTimeZone;
        private System.Windows.Forms.ListView lvMachineTimeZones;
        private System.Windows.Forms.TextBox txtTimeZoneLookupResults;
        private System.Windows.Forms.TabPage tabClientCurrentTimeZone;
        private System.Windows.Forms.TextBox txtClientCurrentTimezone;
        private System.Windows.Forms.Button btnClientCurrentTimeZone;
    }
}