using System;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class ConvertIdForm : EWSEditor.Forms.CountedForm
    {
        private EnumComboBox<IdFormat> srcFormatCombo = new EnumComboBox<IdFormat>();
        private EnumComboBox<IdFormat> reqFormatCombo = new EnumComboBox<IdFormat>();

        public ConvertIdForm()
        {
            InitializeComponent();
        }

        public static void Show(Form parent, ExchangeService service)
        {
            ConvertIdForm form = new ConvertIdForm();
            form.CurrentService = service;
            form.Show();
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if (this.srcFormatCombo.SelectedItem.HasValue == false &&
                this.reqFormatCombo.SelectedItem.HasValue == false)
            {
                if (this.srcFormatCombo.SelectedItem.HasValue == false) DebugLog.WriteVerbose("srcFormatCombo has no value");
                if (this.reqFormatCombo.SelectedItem.HasValue == false) DebugLog.WriteVerbose("reqFormatCombo has no value");

                ErrorDialog.ShowWarning("Select a source and requested ID format before converting.");
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                AlternateId srcId = new AlternateId(
                   this.srcFormatCombo.SelectedItem.Value,
                    this.SrcIdText.Text,
                    this.SrcMbxText.Text);

                AlternateId cvrtId = (AlternateId)this.CurrentService.ConvertId(srcId, this.reqFormatCombo.SelectedItem.Value);

                this.CvrtIdText.Text = System.Enum.GetName(typeof(IdFormat), cvrtId.Format);
                this.CvrtIdMbxText.Text = cvrtId.Mailbox;
                this.CvrtIdText.Text = cvrtId.UniqueId;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConvertIdForm_Load(object sender, EventArgs e)
        {
            this.srcFormatCombo.TransformComboBox(this.TempSrcFormatCombo);
            this.reqFormatCombo.TransformComboBox(this.TempReqFormatCombo);
            this.srcFormatCombo.HasEmptyItem = true;
            this.reqFormatCombo.HasEmptyItem = true;
        }
    }
}
