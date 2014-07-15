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
            this.tabConvertTime = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboConversionKind = new System.Windows.Forms.ComboBox();
            this.cmboToTimeZone = new System.Windows.Forms.ComboBox();
            this.cmboFromTimeZone = new System.Windows.Forms.ComboBox();
            this.lblToTZ = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFromTZ = new System.Windows.Forms.Label();
            this.btnConvertTimezone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoConvertByNow = new System.Windows.Forms.RadioButton();
            this.dtConvertStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtTicks = new System.Windows.Forms.TextBox();
            this.dtConvertStartTime = new System.Windows.Forms.DateTimePicker();
            this.rdoConvertByTicks = new System.Windows.Forms.RadioButton();
            this.rdoConvertByDateTime = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConversionDateInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConversionResult = new System.Windows.Forms.Label();
            this.txtConversionResults = new System.Windows.Forms.TextBox();
            this.txtToTimeZone = new System.Windows.Forms.TextBox();
            this.txtFromTimeZone = new System.Windows.Forms.TextBox();
            this.txtMachineTimeZones = new System.Windows.Forms.TextBox();
            this.scMachineTimezones = new System.Windows.Forms.SplitContainer();
            this.lblTicksTime = new System.Windows.Forms.Label();
            this.txtTicksTime = new System.Windows.Forms.TextBox();
            this.tabTimeZones.SuspendLayout();
            this.tabExchangeServerTimeZone.SuspendLayout();
            this.tabClientTimeZones.SuspendLayout();
            this.tabClientTimezoneLookup.SuspendLayout();
            this.tabClientCurrentTimeZone.SuspendLayout();
            this.tabConvertTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMachineTimezones)).BeginInit();
            this.scMachineTimezones.Panel1.SuspendLayout();
            this.scMachineTimezones.Panel2.SuspendLayout();
            this.scMachineTimezones.SuspendLayout();
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
            this.txtServerTimezoneResults.Size = new System.Drawing.Size(960, 526);
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
            this.tabTimeZones.Controls.Add(this.tabConvertTime);
            this.tabTimeZones.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.tabTimeZones.Location = new System.Drawing.Point(7, 12);
            this.tabTimeZones.Name = "tabTimeZones";
            this.tabTimeZones.SelectedIndex = 0;
            this.tabTimeZones.Size = new System.Drawing.Size(974, 593);
            this.tabTimeZones.TabIndex = 38;
            // 
            // tabExchangeServerTimeZone
            // 
            this.tabExchangeServerTimeZone.Controls.Add(this.btnServerTimeZone);
            this.tabExchangeServerTimeZone.Controls.Add(this.txtServerTimezoneResults);
            this.tabExchangeServerTimeZone.Location = new System.Drawing.Point(4, 24);
            this.tabExchangeServerTimeZone.Name = "tabExchangeServerTimeZone";
            this.tabExchangeServerTimeZone.Size = new System.Drawing.Size(966, 565);
            this.tabExchangeServerTimeZone.TabIndex = 2;
            this.tabExchangeServerTimeZone.Text = "Exchange Server TimeZone";
            this.tabExchangeServerTimeZone.UseVisualStyleBackColor = true;
            // 
            // tabClientTimeZones
            // 
            this.tabClientTimeZones.Controls.Add(this.scMachineTimezones);
            this.tabClientTimeZones.Controls.Add(this.btnListTimezones);
            this.tabClientTimeZones.Location = new System.Drawing.Point(4, 24);
            this.tabClientTimeZones.Name = "tabClientTimeZones";
            this.tabClientTimeZones.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientTimeZones.Size = new System.Drawing.Size(966, 565);
            this.tabClientTimeZones.TabIndex = 0;
            this.tabClientTimeZones.Text = "Client TimeZones";
            this.tabClientTimeZones.UseVisualStyleBackColor = true;
            // 
            // lvMachineTimeZones
            // 
            this.lvMachineTimeZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMachineTimeZones.Location = new System.Drawing.Point(3, 3);
            this.lvMachineTimeZones.Name = "lvMachineTimeZones";
            this.lvMachineTimeZones.Size = new System.Drawing.Size(957, 258);
            this.lvMachineTimeZones.TabIndex = 32;
            this.lvMachineTimeZones.UseCompatibleStateImageBehavior = false;
            this.lvMachineTimeZones.SelectedIndexChanged += new System.EventHandler(this.lvMachineTimeZones_SelectedIndexChanged);
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
            this.tabClientTimezoneLookup.Size = new System.Drawing.Size(966, 565);
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
            this.txtTimeZoneLookupResults.Size = new System.Drawing.Size(960, 520);
            this.txtTimeZoneLookupResults.TabIndex = 38;
            this.txtTimeZoneLookupResults.WordWrap = false;
            // 
            // tabClientCurrentTimeZone
            // 
            this.tabClientCurrentTimeZone.Controls.Add(this.txtClientCurrentTimezone);
            this.tabClientCurrentTimeZone.Controls.Add(this.btnClientCurrentTimeZone);
            this.tabClientCurrentTimeZone.Location = new System.Drawing.Point(4, 24);
            this.tabClientCurrentTimeZone.Name = "tabClientCurrentTimeZone";
            this.tabClientCurrentTimeZone.Size = new System.Drawing.Size(966, 565);
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
            this.txtClientCurrentTimezone.Size = new System.Drawing.Size(960, 526);
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
            // tabConvertTime
            // 
            this.tabConvertTime.Controls.Add(this.groupBox1);
            this.tabConvertTime.Controls.Add(this.label5);
            this.tabConvertTime.Controls.Add(this.txtConversionDateInfo);
            this.tabConvertTime.Controls.Add(this.label3);
            this.tabConvertTime.Controls.Add(this.label2);
            this.tabConvertTime.Controls.Add(this.lblConversionResult);
            this.tabConvertTime.Controls.Add(this.txtConversionResults);
            this.tabConvertTime.Controls.Add(this.txtToTimeZone);
            this.tabConvertTime.Controls.Add(this.txtFromTimeZone);
            this.tabConvertTime.Location = new System.Drawing.Point(4, 24);
            this.tabConvertTime.Name = "tabConvertTime";
            this.tabConvertTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertTime.Size = new System.Drawing.Size(966, 565);
            this.tabConvertTime.TabIndex = 4;
            this.tabConvertTime.Text = "Convert Time";
            this.tabConvertTime.UseVisualStyleBackColor = true;
            this.tabConvertTime.Click += new System.EventHandler(this.tabConvertTime_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtTicksTime);
            this.groupBox1.Controls.Add(this.lblTicksTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmboConversionKind);
            this.groupBox1.Controls.Add(this.cmboToTimeZone);
            this.groupBox1.Controls.Add(this.cmboFromTimeZone);
            this.groupBox1.Controls.Add(this.lblToTZ);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblFromTZ);
            this.groupBox1.Controls.Add(this.btnConvertTimezone);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoConvertByNow);
            this.groupBox1.Controls.Add(this.dtConvertStartDate);
            this.groupBox1.Controls.Add(this.txtTicks);
            this.groupBox1.Controls.Add(this.dtConvertStartTime);
            this.groupBox1.Controls.Add(this.rdoConvertByTicks);
            this.groupBox1.Controls.Add(this.rdoConvertByDateTime);
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(951, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Kind:";
            // 
            // cmboConversionKind
            // 
            this.cmboConversionKind.FormattingEnabled = true;
            this.cmboConversionKind.Items.AddRange(new object[] {
            "Unspecified",
            "Local",
            "Utc"});
            this.cmboConversionKind.Location = new System.Drawing.Point(231, 88);
            this.cmboConversionKind.Name = "cmboConversionKind";
            this.cmboConversionKind.Size = new System.Drawing.Size(134, 23);
            this.cmboConversionKind.TabIndex = 10;
            this.cmboConversionKind.Text = "Unspecified";
            // 
            // cmboToTimeZone
            // 
            this.cmboToTimeZone.FormattingEnabled = true;
            this.cmboToTimeZone.Location = new System.Drawing.Point(587, 125);
            this.cmboToTimeZone.Name = "cmboToTimeZone";
            this.cmboToTimeZone.Size = new System.Drawing.Size(326, 23);
            this.cmboToTimeZone.TabIndex = 14;
            this.cmboToTimeZone.SelectedIndexChanged += new System.EventHandler(this.ToTimeZone_SelectedIndexChanged);
            // 
            // cmboFromTimeZone
            // 
            this.cmboFromTimeZone.FormattingEnabled = true;
            this.cmboFromTimeZone.Location = new System.Drawing.Point(125, 125);
            this.cmboFromTimeZone.Name = "cmboFromTimeZone";
            this.cmboFromTimeZone.Size = new System.Drawing.Size(326, 23);
            this.cmboFromTimeZone.TabIndex = 12;
            // 
            // lblToTZ
            // 
            this.lblToTZ.AutoSize = true;
            this.lblToTZ.Location = new System.Drawing.Point(500, 128);
            this.lblToTZ.Name = "lblToTZ";
            this.lblToTZ.Size = new System.Drawing.Size(81, 15);
            this.lblToTZ.TabIndex = 13;
            this.lblToTZ.Text = "To TimeZone:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Date for conversion:";
            // 
            // lblFromTZ
            // 
            this.lblFromTZ.AutoSize = true;
            this.lblFromTZ.Location = new System.Drawing.Point(9, 128);
            this.lblFromTZ.Name = "lblFromTZ";
            this.lblFromTZ.Size = new System.Drawing.Size(94, 15);
            this.lblFromTZ.TabIndex = 11;
            this.lblFromTZ.Text = "From TimeZone:";
            // 
            // btnConvertTimezone
            // 
            this.btnConvertTimezone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertTimezone.Location = new System.Drawing.Point(805, 9);
            this.btnConvertTimezone.Name = "btnConvertTimezone";
            this.btnConvertTimezone.Size = new System.Drawing.Size(140, 27);
            this.btnConvertTimezone.TabIndex = 0;
            this.btnConvertTimezone.Text = "Convert Time";
            this.btnConvertTimezone.UseVisualStyleBackColor = true;
            this.btnConvertTimezone.Click += new System.EventHandler(this.btnConvertTimezone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date/Time:";
            // 
            // rdoConvertByNow
            // 
            this.rdoConvertByNow.AutoSize = true;
            this.rdoConvertByNow.Location = new System.Drawing.Point(31, 89);
            this.rdoConvertByNow.Name = "rdoConvertByNow";
            this.rdoConvertByNow.Size = new System.Drawing.Size(144, 19);
            this.rdoConvertByNow.TabIndex = 8;
            this.rdoConvertByNow.Text = "Current Machine Time";
            this.rdoConvertByNow.UseVisualStyleBackColor = true;
            this.rdoConvertByNow.CheckedChanged += new System.EventHandler(this.rdoNow_CheckedChanged);
            // 
            // dtConvertStartDate
            // 
            this.dtConvertStartDate.Location = new System.Drawing.Point(265, 33);
            this.dtConvertStartDate.Name = "dtConvertStartDate";
            this.dtConvertStartDate.Size = new System.Drawing.Size(200, 22);
            this.dtConvertStartDate.TabIndex = 4;
            // 
            // txtTicks
            // 
            this.txtTicks.Location = new System.Drawing.Point(192, 61);
            this.txtTicks.Name = "txtTicks";
            this.txtTicks.Size = new System.Drawing.Size(414, 22);
            this.txtTicks.TabIndex = 7;
            this.txtTicks.TextChanged += new System.EventHandler(this.txtTicks_TextChanged);
            // 
            // dtConvertStartTime
            // 
            this.dtConvertStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtConvertStartTime.Location = new System.Drawing.Point(471, 33);
            this.dtConvertStartTime.Name = "dtConvertStartTime";
            this.dtConvertStartTime.Size = new System.Drawing.Size(135, 22);
            this.dtConvertStartTime.TabIndex = 5;
            // 
            // rdoConvertByTicks
            // 
            this.rdoConvertByTicks.AutoSize = true;
            this.rdoConvertByTicks.Location = new System.Drawing.Point(31, 64);
            this.rdoConvertByTicks.Name = "rdoConvertByTicks";
            this.rdoConvertByTicks.Size = new System.Drawing.Size(118, 19);
            this.rdoConvertByTicks.TabIndex = 6;
            this.rdoConvertByTicks.Text = "Convert By Ticks";
            this.rdoConvertByTicks.UseVisualStyleBackColor = true;
            this.rdoConvertByTicks.CheckedChanged += new System.EventHandler(this.rdoConvertByTicks_CheckedChanged);
            // 
            // rdoConvertByDateTime
            // 
            this.rdoConvertByDateTime.AutoSize = true;
            this.rdoConvertByDateTime.Checked = true;
            this.rdoConvertByDateTime.Location = new System.Drawing.Point(31, 37);
            this.rdoConvertByDateTime.Name = "rdoConvertByDateTime";
            this.rdoConvertByDateTime.Size = new System.Drawing.Size(140, 19);
            this.rdoConvertByDateTime.TabIndex = 2;
            this.rdoConvertByDateTime.TabStop = true;
            this.rdoConvertByDateTime.Text = "Convert By DateTime";
            this.rdoConvertByDateTime.UseVisualStyleBackColor = true;
            this.rdoConvertByDateTime.CheckedChanged += new System.EventHandler(this.rdoConvertByDateTime_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Converstion Date Info:";
            // 
            // txtConversionDateInfo
            // 
            this.txtConversionDateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversionDateInfo.Location = new System.Drawing.Point(25, 187);
            this.txtConversionDateInfo.Multiline = true;
            this.txtConversionDateInfo.Name = "txtConversionDateInfo";
            this.txtConversionDateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConversionDateInfo.Size = new System.Drawing.Size(935, 52);
            this.txtConversionDateInfo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Timezone Info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Timezone Info:";
            // 
            // lblConversionResult
            // 
            this.lblConversionResult.AutoSize = true;
            this.lblConversionResult.Location = new System.Drawing.Point(9, 410);
            this.lblConversionResult.Name = "lblConversionResult";
            this.lblConversionResult.Size = new System.Drawing.Size(41, 15);
            this.lblConversionResult.TabIndex = 6;
            this.lblConversionResult.Text = "Result";
            // 
            // txtConversionResults
            // 
            this.txtConversionResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversionResults.Location = new System.Drawing.Point(25, 428);
            this.txtConversionResults.Multiline = true;
            this.txtConversionResults.Name = "txtConversionResults";
            this.txtConversionResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConversionResults.Size = new System.Drawing.Size(935, 131);
            this.txtConversionResults.TabIndex = 7;
            // 
            // txtToTimeZone
            // 
            this.txtToTimeZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTimeZone.Location = new System.Drawing.Point(25, 337);
            this.txtToTimeZone.Multiline = true;
            this.txtToTimeZone.Name = "txtToTimeZone";
            this.txtToTimeZone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtToTimeZone.Size = new System.Drawing.Size(935, 70);
            this.txtToTimeZone.TabIndex = 5;
            // 
            // txtFromTimeZone
            // 
            this.txtFromTimeZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTimeZone.Location = new System.Drawing.Point(25, 258);
            this.txtFromTimeZone.Multiline = true;
            this.txtFromTimeZone.Name = "txtFromTimeZone";
            this.txtFromTimeZone.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFromTimeZone.Size = new System.Drawing.Size(935, 58);
            this.txtFromTimeZone.TabIndex = 3;
            // 
            // txtMachineTimeZones
            // 
            this.txtMachineTimeZones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMachineTimeZones.Location = new System.Drawing.Point(1, 3);
            this.txtMachineTimeZones.Multiline = true;
            this.txtMachineTimeZones.Name = "txtMachineTimeZones";
            this.txtMachineTimeZones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMachineTimeZones.Size = new System.Drawing.Size(962, 252);
            this.txtMachineTimeZones.TabIndex = 37;
            this.txtMachineTimeZones.WordWrap = false;
            this.txtMachineTimeZones.TextChanged += new System.EventHandler(this.txtMachineTimeZones_TextChanged);
            // 
            // scMachineTimezones
            // 
            this.scMachineTimezones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMachineTimezones.Location = new System.Drawing.Point(0, 36);
            this.scMachineTimezones.Name = "scMachineTimezones";
            this.scMachineTimezones.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMachineTimezones.Panel1
            // 
            this.scMachineTimezones.Panel1.Controls.Add(this.lvMachineTimeZones);
            // 
            // scMachineTimezones.Panel2
            // 
            this.scMachineTimezones.Panel2.Controls.Add(this.txtMachineTimeZones);
            this.scMachineTimezones.Size = new System.Drawing.Size(966, 529);
            this.scMachineTimezones.SplitterDistance = 264;
            this.scMachineTimezones.TabIndex = 38;
            // 
            // lblTicksTime
            // 
            this.lblTicksTime.AutoSize = true;
            this.lblTicksTime.Location = new System.Drawing.Point(612, 66);
            this.lblTicksTime.Name = "lblTicksTime";
            this.lblTicksTime.Size = new System.Drawing.Size(68, 15);
            this.lblTicksTime.TabIndex = 15;
            this.lblTicksTime.Text = "Ticks Time:";
            // 
            // txtTicksTime
            // 
            this.txtTicksTime.Location = new System.Drawing.Point(686, 61);
            this.txtTicksTime.Name = "txtTicksTime";
            this.txtTicksTime.ReadOnly = true;
            this.txtTicksTime.Size = new System.Drawing.Size(250, 22);
            this.txtTicksTime.TabIndex = 16;
            // 
            // TimeZonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 617);
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
            this.tabConvertTime.ResumeLayout(false);
            this.tabConvertTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.scMachineTimezones.Panel1.ResumeLayout(false);
            this.scMachineTimezones.Panel2.ResumeLayout(false);
            this.scMachineTimezones.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMachineTimezones)).EndInit();
            this.scMachineTimezones.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabConvertTime;
        private System.Windows.Forms.Label lblFromTZ;
        private System.Windows.Forms.Label lblToTZ;
        private System.Windows.Forms.ComboBox cmboToTimeZone;
        private System.Windows.Forms.DateTimePicker dtConvertStartTime;
        private System.Windows.Forms.ComboBox cmboFromTimeZone;
        private System.Windows.Forms.DateTimePicker dtConvertStartDate;
        private System.Windows.Forms.Button btnConvertTimezone;
        private System.Windows.Forms.TextBox txtToTimeZone;
        private System.Windows.Forms.TextBox txtFromTimeZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConversionResult;
        private System.Windows.Forms.TextBox txtConversionResults;
        private System.Windows.Forms.RadioButton rdoConvertByTicks;
        private System.Windows.Forms.RadioButton rdoConvertByDateTime;
        private System.Windows.Forms.TextBox txtTicks;
        private System.Windows.Forms.RadioButton rdoConvertByNow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConversionDateInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmboConversionKind;
        private System.Windows.Forms.SplitContainer scMachineTimezones;
        private System.Windows.Forms.TextBox txtMachineTimeZones;
        private System.Windows.Forms.TextBox txtTicksTime;
        private System.Windows.Forms.Label lblTicksTime;
    }
}