using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSEditor.Common.Auth
{
    public  static class JwtHelper
    {


        public static string ParseJwtToken(string sJWT)
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
            oSB.AppendFormat("IssuedAt (UTC): {0}    In your timezone: {1}\r\n\r\n", x.IssuedAt.ToUniversalTime().ToString(), x.IssuedAt.ToLocalTime().ToString());
            oSB.AppendFormat("Issuer: {0}\r\n\r\n", x.Issuer.ToString());
            oSB.AppendFormat("Kid: {0}\r\n\r\n", x.Kid);

            oSB.AppendFormat("SecurityKey: {0}\r\n\r\n", x.SecurityKey);
            oSB.AppendFormat("SigningKey: {0}\r\n\r\n", x.SigningKey);
            oSB.AppendFormat("Subject: {0}\r\n\r\n", x.Subject);

            oSB.AppendFormat("Typ: {0}\r\n\r\n", x.Typ);
            oSB.AppendFormat("ValidFrom (UTC): {0}    In your timezone: {1}\r\n\r\n", x.ValidFrom.ToUniversalTime().ToString(), x.ValidFrom.ToLocalTime().ToString());
            oSB.AppendFormat("ValidTo (UTC): {0}    In your timezone: {1}\r\n\r\n", x.ValidTo.ToUniversalTime().ToString(), x.ValidTo.ToLocalTime().ToString());
            oSB.AppendFormat("X5t: {0}\r\n\r\n", x.X5t);
            oSB.AppendFormat("Zip: {0}\r\n\r\n", x.Zip);

            return oSB.ToString();

        }
    }
}
