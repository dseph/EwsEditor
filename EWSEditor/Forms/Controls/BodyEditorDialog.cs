using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Forms;
using EWSEditor.Common;

namespace EWSEditor.Forms.Controls
{
    public partial class BodyEditorDialog : DialogForm
    {
        public BodyEditorDialog()
        {
            InitializeComponent();
        }

        public static DialogResult Show(MessageBody body)
        {
            BodyEditorDialog ibd = new BodyEditorDialog();

            // If the body is HTML, save to a temp file
            // and display in an IE control
            if (body.BodyType == BodyType.HTML)
            {
                ibd.grpBody.Text = "Body Content Type: HTML";
                string tempFile = FileHelper.WriteDataToTempHTML(body.Text);
                ibd.htmlViewer.Navigate(tempFile);
                ibd.htmlViewer.Visible = true;
                ibd.rtfViewer.Visible = false;
            }
            // Otherwise display in a text box
            else
            {
                ibd.grpBody.Text = "Body Content Type: Text";
                ibd.rtfViewer.Text = body.Text;
                ibd.htmlViewer.Visible = false;
                ibd.rtfViewer.Visible = true;
            }
            
            ibd.ShowDialog();

            return DialogResult.OK;
        }
    }
}
