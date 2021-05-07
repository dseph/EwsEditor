using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
//using Microsoft.Exchange.WebServices.Data;
//using System.IdentityModel.Tokens;

//using System.Collections.Specialized;
//using System.Web;
//using System.Xml;
//using System.Buffers;
//using System.Security.Cryptography.Xml;
//using Microsoft.TeamFoundation.Client;
//using System.IdentityModel.Tokens.SecurityToken;
//using System.IdentityModel;
//using System.IdentityModel.Claims;
//using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Protocols;

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
            // https://docs.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.securitytokenhandler.readtoken?view=netframework-4.8

        }

        private void btnLoadCurrentSessionToken_Click(object sender, EventArgs e)
        {
            if (_BearerToken == string.Empty)
                MessageBox.Show("There is no bearer token being used.", "No Bearer Token");  
            else
                txtToken.Text = _BearerToken;
        }

        ////trying to get the code below to work so the token can be parsed.It comes from // https://docs.microsoft.com/en-us/dotnet/api/system.identitymodel.tokens.securitytokenhandler.readtoken?view=netframework-4.8


        ///// <summary>
        ///// Reads a serialized token and converts it into a <see cref="SecurityToken"/>.
        ///// </summary>
        ///// <param name="reader">An XML reader positioned at the token's start element.</param>
        ///// <returns>The parsed form of the token.</returns>
        //public override SecurityToken ReadToken(XmlReader reader)
        //{
        //    if (reader == null)
        //    {
        //        throw new ArgumentNullException("reader");
        //    }

        //    XmlDictionaryReader dictionaryReader = XmlDictionaryReader.CreateDictionaryReader(reader);

        //    byte[] binaryData;
        //    string encoding = dictionaryReader.GetAttribute(EncodingType);
        //    if (encoding == null || encoding == Base64EncodingType)
        //    {
        //        dictionaryReader.Read();
        //        binaryData = dictionaryReader.ReadContentAsBase64();
        //    }
        //    else
        //    {
        //        throw new SecurityTokenException(
        //            "Cannot read SecurityToken as its encoding is" + encoding + ". Expected a BinarySecurityToken with base64 encoding.");
        //    }

        //    string serializedToken = Encoding.UTF8.GetString(binaryData);

        //    return ReadSecurityTokenFromString(serializedToken);
        //}

        ///// <summary>
        ///// Parse the string token and generates a <see cref="SecurityToken"/>.
        ///// </summary>
        ///// <param name="serializedToken">The serialized form of the token received.</param>
        ///// <returns>The parsed form of the token.</returns>
        //protected SecurityToken ReadSecurityTokenFromString(string serializedToken)
        //{
        //    if (String.IsNullOrEmpty(serializedToken))
        //    {
        //        throw new ArgumentException("The parameter 'serializedToken' cannot be null or empty string.");
        //    }

        //    // Create a collection of SWT name value pairs
        //    NameValueCollection properties = ParseToken(serializedToken);
        //    SimpleWebToken swt = new SimpleWebToken(properties, serializedToken);

        //    return swt;
        //}
        ///// <summary>
        ///// Parses the token into a collection.
        ///// </summary>
        ///// <param name="encodedToken">The serialized token.</param>
        ///// <returns>A colleciton of all name-value pairs from the token.</returns>
        //NameValueCollection ParseToken(string encodedToken)
        //{
        //    if (String.IsNullOrEmpty(encodedToken))
        //    {
        //        throw new ArgumentException("The parameter 'encodedToken' cannot be null or empty string.");
        //    }

        //    NameValueCollection keyValuePairs = new NameValueCollection();
        //    foreach (string nameValue in encodedToken.Split(ParameterSeparator))
        //    {
        //        string[] keyValueArray = nameValue.Split('=');

        //        if ((keyValueArray.Length < 2) || String.IsNullOrEmpty(keyValueArray[0]))
        //        {
        //            throw new SecurityTokenException("The incoming token was not in an expected format.");
        //        }

        //        // Names must be decoded for the claim type case
        //        string key = HttpUtility.UrlDecode(keyValueArray[0].Trim());

        //        // remove any unwanted "
        //        string value = HttpUtility.UrlDecode(keyValueArray[1].Trim().Trim('"'));
        //        keyValuePairs.Add(key, value);
        //    }

        //    return keyValuePairs;
        //}


    }
}
