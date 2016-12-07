using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;
using System.IO;
using System.Windows.Forms;
 
namespace EWSEditor.Common.Exports
{
    public class AttachmentExport
    {

        public bool SaveAttachmentToFolder(ExchangeService oExchangeService, ItemId oItemId)
        {
            bool bRet = true;
            List<ItemId> oItemIds = new List<ItemId> { oItemId };
            SaveAttachmentsToFolder(oExchangeService, oItemIds);
            return bRet;
        }

        public bool SaveAttachmentsToFolder(ExchangeService oExchangeService, List<ItemId> oItemIds)
        {
            bool bRet = true;
            string sFolder = string.Empty;
            if (GetFolderPath(ref sFolder))
                EWSEditor.Common.Exports.AttachmentExport.SaveAttachmentsToFile(oExchangeService, oItemIds, sFolder);
            return bRet;
        }

        public static bool SaveAttachmentsToFile(ExchangeService oExchangeService, List<ItemId> oItemIds, string sFolder)
        {
            bool bRet = false;

            foreach (ItemId oItemId in oItemIds)
            {
                bRet = SaveAttachmentToFile(oExchangeService, oItemId, sFolder);
                if (bRet == false)
                    return false;
            }

            return bRet;
        }

        public static bool SaveAttachmentToFile(ExchangeService oExchangeService, ItemId oItemId, string sFolder)
        {
            bool bRet = true;
            bool bIsInline = false;

            Item oItem = Item.Bind(oExchangeService, oItemId);

            string sFilePath = string.Empty;
            string sContent = string.Empty;
            string sFileName = string.Empty;
            string sAttachentTableEntryPath = string.Empty;

            string sStorageFolder = sFolder + "\\Appointment";
            if (!Directory.Exists(sStorageFolder))
                Directory.CreateDirectory(sStorageFolder);

            int AttachmentCount = 0;

            // FileAttachment
            foreach (Attachment oAttachment in oItem.Attachments)
            {
                AttachmentCount++;

                oAttachment.Load();

                if (oAttachment is FileAttachment)
                {
                    sFileName = Path.GetTempFileName().Replace(".tmp", ".xml");
                    sFilePath = sStorageFolder + "\\" + sFileName;
                    sAttachentTableEntryPath = sStorageFolder + "\\" + "AttachmentTableEntry.xml";

                    FileAttachment oAttach = oAttachment as FileAttachment;
                    oAttachment.Load();
                    bIsInline = oAttach.ContentId.Length != 0;

                    // Save off attachment table

                    AttachmentTableEntryData oAttachmentTableEntry = new AttachmentTableEntryData();

                    oAttachmentTableEntry.ContentId = oAttach.ContentId;
                    oAttachmentTableEntry.ContentLocation = oAttach.ContentLocation;
                    oAttachmentTableEntry.ContentType = oAttach.ContentType;
                    oAttachmentTableEntry.Name = oAttach.Name;
                    oAttachmentTableEntry.FileName = oAttach.FileName;
                    oAttachmentTableEntry.IsContactPhoto = oAttach.IsContactPhoto.ToString();
                    oAttachmentTableEntry.IsInline = bIsInline.ToString();
                    try
                    {
                        oAttachmentTableEntry.Size = oAttach.Size.ToString();
                    }
                    catch (Exception ex)
                    {
                        oAttachmentTableEntry.Size = "";
                    }
                    try
                    {
                        oAttachmentTableEntry.LastModifiedTime = oAttach.LastModifiedTime.ToString();
                    }
                    catch (Exception ex)
                    {
                        oAttachmentTableEntry.LastModifiedTime = "";
                    }
                    sContent = SerialHelper.SerializeObjectToString<AttachmentTableEntryData>(oAttachmentTableEntry);
                    if (sContent != string.Empty)
                    {
                        try
                        {
                            System.IO.File.WriteAllText(sAttachentTableEntryPath, sContent);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Saving File");
                            return false;
                        }
                    }

                    // Save Attachment
                    FileAttachment fileAttach = oAttachment as FileAttachment;
                    try
                    {
                        sFilePath = sStorageFolder + "\\" + AttachmentCount.ToString() + "_" + fileAttach.FileName;
                        System.IO.File.WriteAllBytes(sFilePath, fileAttach.Content);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving Attachment");
                        return false;
                    }
                }

                if (oAttachment is FileAttachment)
                {
                    ItemAttachment oItemAttachment = oAttachment as ItemAttachment;
                    sFilePath = sStorageFolder + "\\" + AttachmentCount.ToString() + "_" + oItemAttachment.Name;
                    if (oItemAttachment != null)
                    {
                        try
                        {
                            EWSEditor.Common.DumpHelper.DumpXML(oItemAttachment.Item, sFilePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error Saving Attachment");
                            return false;
                        }
                    }
                }

            }
            return bRet;
        }

        public bool GetFolderPath(ref string sFolder)
        {
            bool bRet = false;
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the Attachment(s) to.";

            if (browser.ShowDialog() == DialogResult.OK)
            {
                sFolder = browser.SelectedPath;
                bRet = true;
            }
            else
                bRet = false;

            return bRet;
        }
    }
}
 
