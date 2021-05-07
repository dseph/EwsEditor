using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;
 

namespace EWSEditor.Forms
{
    public partial class BaseForm : Form
    {
        /// <summary>
        /// Make sure the form title is prefixed by the verison
        /// number of the build in all forms.
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = GetFormTitle(value);
            }
        }

        ExchangeService _service = null;
        public ExchangeService CurrentService
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value;
            }
        }

        EWSEditor.Common.EwsEditorAppSettings _CurrentAppSettings = null;
        public EWSEditor.Common.EwsEditorAppSettings CurrentAppSettings
        {
            get
            {
                return _CurrentAppSettings;
            }
            set
            {
                _CurrentAppSettings = value;
            }
        }

        EWSEditor.Common.EwsSession _CurrentEwsSessionSettings = null;
        public EWSEditor.Common.EwsSession CurrentEwsSessionSettings
        {
            get
            {
                return _CurrentEwsSessionSettings;
            }

            set
            {
                _CurrentEwsSessionSettings = value;
            }
        }

        public BaseForm()
        {
            InitializeComponent();
        }

        public static string GetFormTitle(string suffix)
        {
            // In design mode, the form text will be set to Visual Studio's
            // product name and version if we don't do this if-block.
            if (Application.ProductName.Contains("EWSEditor"))
            {
                if (suffix.Length > 0)
                {
                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} {1} - {2}",
                        Application.ProductName,
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                        suffix);
                }
                else
                {

                    return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} {1}",
                        Application.ProductName,
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                }
            }

            return suffix;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {

        }


    }
}
