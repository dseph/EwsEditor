using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using Microsoft.Exchange.WebServices.Data;
 

namespace EWSEditor.Forms.ToolsForms
{
    public partial class ViewToken : Form
    {
        string _BearerToken = string.Empty;

        public ViewToken()
        {
            InitializeComponent();
        }

        public ViewToken(string sBearerToken)
        {
            InitializeComponent();

            _BearerToken = sBearerToken;
        }

         

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ViewToken_Load(object sender, EventArgs e)
        {

        }

        private void btnParseToken_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.exchange.webservices.auth.validation.authtoken.parse?view=exchange-ews-api
 
        }

        private void btnLoadCurrentSessionToken_Click(object sender, EventArgs e)
        {
            if (_BearerToken == string.Empty)
                MessageBox.Show("There is no bearer token being used.", "No Bearer Token");  
            else
                txtToken.Text = _BearerToken;
        }
    }
}
