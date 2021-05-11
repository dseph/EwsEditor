using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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

        private void btnParseToken_Click_1(object sender, EventArgs e)
        {
            
        }

        private string ParseJwtToken(string sJWT)
        {
            Microsoft.IdentityModel.JsonWebTokens.JsonWebToken x = new JsonWebToken(sJWT);

            StringBuilder oSB = new StringBuilder();
            string s = string.Empty;

            oSB.AppendFormat("Actor: {0}\r\n\r\n", x.Actor);
            oSB.AppendFormat("Alg: {0}\r\n\r\n", x.Alg);

            oSB.Append("Audiences:\r\n");
            foreach (var aud in x.Audiences)
            {
                oSB.AppendFormat("   {0}\r\n", aud.ToString());

            }
            oSB.Append("\r\n");

            oSB.AppendFormat("AuthenticationTag: {0}\r\n\r\n", x.AuthenticationTag);
            oSB.AppendFormat("Ciphertext: {0}\r\n\r\n", x.Ciphertext);

            oSB.Append("Claims:\r\n");
            foreach (var claim in x.Claims)
            {
                oSB.AppendFormat("    {0}\r\n", claim.Type);
                oSB.AppendFormat("        Value: {0}\r\n", claim.Value);
                oSB.AppendFormat("        OriginalIssuer: {0}\r\n", claim.OriginalIssuer);
                oSB.AppendFormat("        Issuer: {0}\r\n", claim.Issuer);
                oSB.AppendFormat("        Subject: {0}\r\n", claim.Subject);
            }
            oSB.Append("\r\n");

            oSB.AppendFormat("Cty: {0}\r\n\r\n", x.Cty);
            oSB.AppendFormat("Enc: {0}\r\n\r\n", x.Enc);

            oSB.AppendFormat("EncodedHeader: {0}\r\n\r\n", x.EncodedHeader);
            oSB.AppendFormat("EncodedPayload: {0}\r\n\r\n", x.EncodedPayload);
            oSB.AppendFormat("EncodedSignature: {0}\r\n\r\n", x.EncodedSignature);
            oSB.AppendFormat("EncodedToken: {0}\r\n\r\n", x.EncodedToken);
            oSB.AppendFormat("EncryptedKey: {0}\r\n\r\n", x.EncryptedKey);

            oSB.AppendFormat("Id: {0}\r\n\r\n", x.Id);
            oSB.AppendFormat("InitializationVector: {0}\r\n\r\n", x.InitializationVector);
            oSB.AppendFormat("IssuedAt: {0}\r\n\r\n", x.IssuedAt.ToString());
            oSB.AppendFormat("Issuer: {0}\r\n\r\n", x.Issuer.ToString());
            oSB.AppendFormat("Kid {0}\r\n\r\n", x.Kid);

            oSB.AppendFormat("SecurityKey: {0}\r\n\r\n", x.SecurityKey);
            oSB.AppendFormat("SigningKey: {0}\r\n\r\n", x.SigningKey);
            oSB.AppendFormat("Subject: {0}\r\n\r\n", x.Subject);

            oSB.AppendFormat("Typ: {0}\r\n\r\n", x.Typ);
            oSB.AppendFormat("ValidFrom: {0}\r\n\r\n", x.ValidFrom);
            oSB.AppendFormat("ValidTo: {0}\r\n\r\n", x.ValidTo);
            oSB.AppendFormat("X5t: {0}\r\n\r\n", x.X5t);
            oSB.AppendFormat("Zip: {0}\r\n\r\n", x.Zip);

            return oSB.ToString();

        }

        private void btnViewTokenParts_Click(object sender, EventArgs e)
        {
            string s = txtToken.Text.Trim();
            if (s == "")
                MessageBox.Show("There is no bearer token being used.", "Bearer Token Required");
            else
            {
                if (s.ToLower().StartsWith("bearer"))
                    MessageBox.Show("The word bearer needs to be removed.", "Only enter the token value.");
                else

                    txtParsedToken.Text = ParseJwtToken(txtToken.Text.Trim());
            }
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
