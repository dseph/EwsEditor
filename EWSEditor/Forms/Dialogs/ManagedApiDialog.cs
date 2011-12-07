using System;
using System.Drawing;
using System.Windows.Forms;
using EWSEditor.Resources;
using EWSEditor.Settings;

namespace EWSEditor.Forms
{
    public partial class ManagedApiDialog : Form
    {
        public ManagedApiDialog()
        {
            InitializeComponent();
        }

        public static new DialogResult ShowDialog()
        {
            ManagedApiDialog dialog = new ManagedApiDialog();
            return ((Form)dialog).ShowDialog();
        }

        private void ManagedApiDialog_Load(object sender, EventArgs e)
        {
            this.picError.Image = EWSEditor.Forms.FormsUtil.ConvertIconToImage(SystemIcons.Error);
            this.lnkDownload.Text = DisplayStrings.MSG_EWS_API_DOWNLOAD_LINK;
            this.lblText.Text = DisplayStrings.MSG_NO_EWS_API;
        }

        private void LnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(EnvironmentInfo.EwsManagedApiDownloadUrl);
        }
    }
}
