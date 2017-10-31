using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSEditor.Common.Security;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
 
namespace EWSEditor.Forms.ToolsForms
{
    public partial class CredentialCacheForm : Form
    {
        public CredentialCacheForm()
        {
            InitializeComponent();
        }

        private void CredentialCacheForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 

        }

        private void btnEnumerateCredentials_Click(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();

            int iCount = 0;
            string sPassword = string.Empty;
            string sHexPassword = string.Empty;

            IReadOnlyList<Credential> oList = CredentialManager.EnumerateCrendentials();
            foreach (Credential c in oList)
            {
                if (c.Password == null)
                {
                    sPassword = string.Empty;
                    sHexPassword = string.Empty;
                }
                else
                {
                    sPassword = c.Password.ToString().Replace("\0", string.Empty);
                    sHexPassword = EWSEditor.Common.StringHelper.UnicodeStringToHexString(c.Password);
                }

                oSB.AppendFormat("Application: {0}\r\nType: {1}\r\nUserName: {2}\r\n",
                    c.ApplicationName,
                    c.CredentialType.ToString(),
                    c.UserName) ;
                 

                if (chkShowPasswords.Checked == true)
                {
                    oSB.AppendFormat("Password (NULL stripped): {0}\r\nPassword(full hex): {1}\r\n",
                        sPassword,
                        sHexPassword);
                }
                oSB.AppendFormat("\r\n----\r\n\r\n");


                iCount++;
            }

            oSB.AppendFormat("Count {0}", iCount.ToString());
            // String s = oSB.ToString().Replace("\0", string.Empty);
            String s = oSB.ToString();
            txtCredentials.Text = s;
        }
    }
}
