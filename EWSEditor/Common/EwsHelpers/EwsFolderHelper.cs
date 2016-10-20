using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;


namespace EWSEditor.Common
{
    public class EwsFolderHelper
    {
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path


        public static bool GetFolderPath(Folder oFolder, ref string sFolderPath)
        {
 
            Object fpPath = null;
            bool bRet = false;
            if (oFolder.TryGetProperty(Prop_PR_FOLDER_PATH, out fpPath))
            {

                String fpPathString =
                    Encoding.Unicode.GetString(HexStringToByteArray(
                    BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes((String)fpPath)).Replace("FE-FF", "5C-00").Replace("-", "")));

                sFolderPath = fpPathString;
                bRet = true;
            }
            else
            {
                sFolderPath = "";
                bRet = false;
            }

            return bRet;
        }

        private static Byte[] HexStringToByteArray(String HexString)
        {
            // http://gsexdev.blogspot.com/2011/03/using-prfolderpath-property-in-exchange.html#!/2011/03/using-prfolderpath-property-in-exchange.html

            Byte[] ByteArray = new Byte[HexString.Length / 2];
            for (int i = 0; i < HexString.Length; i += 2)
            {
                ByteArray[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return ByteArray;
        }

    }

}
