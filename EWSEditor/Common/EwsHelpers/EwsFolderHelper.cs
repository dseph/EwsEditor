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
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_ATTR_HIDDEN = new ExtendedPropertyDefinition(0x10F4, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_ATTR_READONLY = new ExtendedPropertyDefinition(0x10F6, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_ATTR_SYSTEM = new ExtendedPropertyDefinition(0x10F5, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_CHILD_COUNT = new ExtendedPropertyDefinition(0x6638, MapiPropertyType.Long);
        private static ExtendedPropertyDefinition Prop_PR_CONTENT_COUNT = new ExtendedPropertyDefinition(0x3602, MapiPropertyType.Integer);
        private static ExtendedPropertyDefinition Prop_PR_CONTENT_UNREAD = new ExtendedPropertyDefinition(0x3603, MapiPropertyType.Integer);       //  PT_LONG  PidTagContentUnreadCount
        private static ExtendedPropertyDefinition Prop_PR_CONTAINER_CLASS = new ExtendedPropertyDefinition(0x3610, MapiPropertyType.String);
        private static ExtendedPropertyDefinition Prop_PR_COMMENT = new ExtendedPropertyDefinition(0x3004, MapiPropertyType.String);
        private static ExtendedPropertyDefinition Prop_PR_CREATION_TIME = new ExtendedPropertyDefinition(0x300, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition Prop_PR_LAST_MODIFICATION_TIME = new ExtendedPropertyDefinition(0x3008, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition Prop_PR_HAS_RULES = new ExtendedPropertyDefinition(0x663A, MapiPropertyType.Boolean);

        private static ExtendedPropertyDefinition PR_MESSAGE_SIZE_EXTENDED = new ExtendedPropertyDefinition(0x0E08, MapiPropertyType.Long);
        private static ExtendedPropertyDefinition PR_DELETED_MESSAGE_SIZE_EXTENDED = new ExtendedPropertyDefinition(0x669B, MapiPropertyType.Long);
        private static ExtendedPropertyDefinition PR_DELETED_MSG_COUNT = new ExtendedPropertyDefinition(0x6640, MapiPropertyType.Integer);

        private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.SystemTime);   
   
 
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);   // PR_RETENTION_FLAGS 0x301D   
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);  // PR_RETENTION_PERIOD 0x301A    
        private static ExtendedPropertyDefinition Prop_PR_RETENTION_DATE = new ExtendedPropertyDefinition(0x301C, MapiPropertyType.SystemTime); // Prop_PR_RETENTION_DATE 0x301C    

  
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_PERIOD = new ExtendedPropertyDefinition(0x301E, MapiPropertyType.Integer); // Prop_PR_RETENTION_DATE 0x301C    
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_DATE = new ExtendedPropertyDefinition(0x301F, MapiPropertyType.SystemTime);  
 
       // private static ExtendedPropertyDefinition Prop_PR_START_DATE_ETC = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.String); // PR_START_DATE_ETC  GUID 0x30190102

        private static ExtendedPropertyDefinition Prop_PR_ENTRYID = new ExtendedPropertyDefinition(0x0FFF, MapiPropertyType.Binary);  // PidTagEntryId, PidTagMemberEntryId, ptagEntryId
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FB0, MapiPropertyType.Binary);  // PidTagStoreEntryId
        private static ExtendedPropertyDefinition Prop_PR_EXTENDED_FOLDER_FLAGS = new ExtendedPropertyDefinition(0x36DA, MapiPropertyType.Binary);  // PidTagExtendedFolderFlags, ptagExtendedFolderFlags

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)

        public static bool GetFolderPath(ExchangeService oExchangeService, FolderId oFolderId, ref string sFolderPath)
        {
            bool bRet = false;
            Folder oFolder = null;

            PropertySet oPropertySet = new PropertySet(BasePropertySet.IdOnly, Prop_PR_FOLDER_PATH);

            oFolder = Folder.Bind(oExchangeService, oFolderId, oPropertySet);

            bRet = GetFolderPath(oFolder, ref sFolderPath);

            return bRet;
        }

        public static bool GetFolderPath(Folder oFolder, ref string sFolderPath)
        {
 
            Object fpPath = null;
            bool bRet = false;
            if (oFolder.TryGetProperty(Prop_PR_FOLDER_PATH, out fpPath))
            {

                String fpPathString =
                    Encoding.Unicode.GetString(ConversionHelper.HexStringToByteArray(
                    BitConverter.ToString(UnicodeEncoding.Unicode.GetBytes((String)fpPath)).Replace("FE-FF", "5C-00").Replace("-", "")));

                sFolderPath = fpPathString;
                bRet = true;
            }
            else
            {
                sFolderPath = "";
                bRet = false;
            }
            System.Web.Services.Protocols.SoapHttpClientProtocol x;
           
            return bRet;
        }

        public static Folder GetFolderDetails(Folder oFolder)
        {
            PropertySet folderPropertySet = new PropertySet
            (
                BasePropertySet.FirstClassProperties,
                new PropertyDefinitionBase[] 
                { 
                    FolderSchema.DisplayName, 
                    FolderSchema.ChildFolderCount,
 
                    FolderSchema.FolderClass, 
                    FolderSchema.ManagedFolderInformation,  
    
                    FolderSchema.TotalCount,  
                    FolderSchema.UnreadCount,  
                    FolderSchema.Permissions,
                    FolderSchema.EffectiveRights,

                    FolderSchema.Permissions,
                    FolderSchema.ChildFolderCount,
                    FolderSchema.TotalCount,  
                    FolderSchema.UnreadCount,  
                    FolderSchema.ParentFolderId,
 

                    // FolderSchema.DisplayName, 
                    //FolderSchema.WellKnownFolderName,

                    //FolderSchema.FolderClass, 
     
                    //FolderSchema.ChildFolderCount,
                    //FolderSchema.TotalCount,  
                    //FolderSchema.UnreadCount,  
                    //FolderSchema.Permissions,
                    //FolderSchema.EffectiveRights,

                    //FolderSchema.ManagedFolderInformation,  
                    //FolderSchema.PolicyTag,
                    //FolderSchema.ParentFolderId,
                    //FolderSchema.ArchiveTag,
 

 
                    Prop_PR_IS_HIDDEN,
                    Prop_PR_FOLDER_PATH,
                    Prop_PR_CREATION_TIME,
                    Prop_PR_COMMENT,
                    Prop_PR_CREATION_TIME, 
                    Prop_PR_LAST_MODIFICATION_TIME,
                     
                    Prop_PR_HAS_RULES,
                    Prop_PR_FOLDER_TYPE,

                    Prop_PR_START_DATE_ETC,

                    Prop_PR_RETENTION_DATE,
                    Prop_PR_RETENTION_PERIOD,
                    Prop_PR_RETENTION_FLAGS,

                    Prop_PR_POLICY_TAG,

                    Prop_PR_ARCHIVE_TAG ,
                    Prop_PR_ARCHIVE_PERIOD,
                    Prop_PR_ARCHIVE_DATE,

                
                    Prop_PR_ATTR_HIDDEN,
                    Prop_PR_ATTR_READONLY,
                    Prop_PR_ATTR_SYSTEM,
                    Prop_PR_FOLDER_CHILD_COUNT,
             
                    Prop_PR_CONTENT_UNREAD,
                    Prop_PR_CONTENT_COUNT,
     
                    Prop_PR_CONTAINER_CLASS, 
                    Prop_PR_ENTRYID,
                    Prop_PR_STORE_ENTRYID, 
                    Prop_PR_EXTENDED_FOLDER_FLAGS 

                }
            );

            oFolder.Load(folderPropertySet);

            return oFolder;
        } 

        //private static Byte[] HexStringToByteArray(String HexString)
        //{
        //    // http://gsexdev.blogspot.com/2011/03/using-prfolderpath-property-in-exchange.html#!/2011/03/using-prfolderpath-property-in-exchange.html

        //    Byte[] ByteArray = new Byte[HexString.Length / 2];
        //    for (int i = 0; i < HexString.Length; i += 2)
        //    {
        //        ByteArray[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
        //    }
        //    return ByteArray;
        //} 

    }

}
