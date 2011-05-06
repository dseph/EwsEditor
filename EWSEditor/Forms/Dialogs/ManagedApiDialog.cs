namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Resources;

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
            System.Diagnostics.Process.Start(Constants.EwsManagedApiDownloadUrl);
        }
    }
}
