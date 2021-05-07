using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;

namespace EWSEditor.Forms
{
    //////////////////////
    // BaseDialog
    /////////////////////
    // This base class ensures that the dialogs
    // in EWSEditor are consistent
    public partial class DialogForm : BaseForm
    {
        public DialogForm()
        {
            InitializeComponent();
        }

        private void BaseDialogForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}