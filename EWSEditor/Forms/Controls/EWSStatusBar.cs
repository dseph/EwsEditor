using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class EWSStatusBar : UserControl
    {
        private ExchangeVersion CurrentRequestedVersion;
        private ExchangeServerInfo CurrentConnectedServer = null;

        private Timer timer = new Timer();

        public ExchangeServerInfo ConnectedServer
        {
            get
            {
                return CurrentConnectedServer;
            }
            set
            {
                if (value != null)
                {
                    this.CurrentConnectedServer = value;
                    this.mnuConnectedTo.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Connected to {0}...", value.VersionString);
                }
            }
        }

        public ExchangeVersion RequestedVersion
        {
            get
            {
                return CurrentRequestedVersion;
            }
            set
            {
                this.CurrentRequestedVersion = value;
            }
        }

        public EWSStatusBar()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(ProgressBarClear_Tick);
        }

        private void mnuConnectedTo_Click(object sender, EventArgs e)
        {
            string serverInfo = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Connected Server Information...\n\nVersionString: {0}\nMajorBuildNumber: {1}\nMajorVersion: {2}\nMinorBuildNumber: {3}\nMinorVersion: {4}\n\nRequestVersion: {5}",
                CurrentConnectedServer.VersionString,
                CurrentConnectedServer.MajorBuildNumber,
                CurrentConnectedServer.MajorVersion,
                CurrentConnectedServer.MinorBuildNumber,
                CurrentConnectedServer.MinorVersion,
                CurrentRequestedVersion.ToString());

            MessageBox.Show(serverInfo, "EWSEditor - Exchange Server Info");
        }

        /// <summary>
        /// Update the text box and progress bar with status from the
        /// caller.  Calculate the percent complete to properly set
        /// the status bar.
        /// </summary>
        /// <param name="text">Text to display in the text box</param>
        /// <param name="complete">Number of "things" complete so far</param>
        /// <param name="total">Total number of "things" to do before 100% complete</param>
        public void UpdateActivity(string text, int complete, int total)
        {
            // If the progress equals the total, we are done
            if (complete == total)
            {
                BeginProgressBarClear();
            }

            // Set the status text
            this.lblStatus.Text = text;

            // Find the percentage complete and increment the progress bar
            float percent = ((float)complete) / ((float)total);
            this.prgStatusBar.Value = Convert.ToInt32(percent * 100);

            //HACK: I don't think we should have to do this but the UI won't
            // update any other way. - mstehle
            this.Refresh();
        }

        /// <summary>
        /// Initiate an asynchronous clearing of the text box
        /// and progress bar after a delay
        /// </summary>
        private void BeginProgressBarClear()
        {
            timer.Interval = 1000;
            timer.Start();
        }

        /// <summary>
        /// Clear the status progress bar and text box
        /// </summary>
        private void ProgressBarClear_Tick(object sender, EventArgs e)
        {
            this.lblStatus.Text = "";
            this.prgStatusBar.Value = 0;
            timer.Stop();
        }
    }
}
