using System;
using System.Drawing;
using System.Windows.Forms;
using EWSEditor.Common;
using EWSEditor.Logging;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public class FormsUtil
    {
        public enum TriStateBool
        {
            True,
            False
        }

        public static string GetFolderPathFromDialog(string dialogDescription)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            // Get the folder to save the output files to, if the user
            // cancels this dialog bail out
            dialog.Description = "Pick an output folder to save the MIME files to.";
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK)
            { 
                DebugLog.WriteVerbose("Leave: User closed dialog with result, {0}." + result);
                return string.Empty; 
            }

            return dialog.SelectedPath;
        }

        public static void DumpMimeContents(ExchangeService service, Folder folder)
        {
            if (folder != null)
            {
                string outputPath = FormsUtil.GetFolderPathFromDialog("Pick a folder to save the MIME files in.");

                DumpHelper.DumpMIME(
                    folder,
                    ItemTraversal.Shallow,
                    outputPath,
                    service);
            }
        }

        public static void DumpXmlContents(ExchangeService service, Folder folder)
        {
            if (folder != null)
            {
                string outputPath = FormsUtil.GetFolderPathFromDialog("Pick a folder to save the XML files in.");

                DumpHelper.DumpXML(
                    folder,
                    ItemTraversal.Shallow,
                    new PropertySet(BasePropertySet.FirstClassProperties),
                    outputPath,
                    service);
            }
        }

        public static Image ConvertIconToImage(Icon icon)
        {
            IconConverter convert = new IconConverter();
            object output = convert.ConvertTo(icon, typeof(Image));

            if (output == null)
            {
                return null;
            }

            return output as Image;
        }

        /// <summary>
        /// Standardize the interaction for a retrying a ServiceObject.Load() call,
        /// removing bad properties until the call succeeds.
        /// </summary>
        /// <param name="service">ExchangeService to make calls with</param>
        /// <param name="id">ItemId to bind to</param>
        /// <param name="propSet">PropertySet to load for the object</param>
        /// <returns>Returns the Item that was bound</returns>
        public static Item PerformRetryableItemBind(ExchangeService service, ItemId id, PropertySet propSet)
        {
            Item item = null;
            while (true)
            {
                try
                {
                    service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                    item = Item.Bind(service, id, propSet);
                    return item;
                }
                catch (ServiceResponseException srex)
                {
                    DebugLog.WriteVerbose("Handled exception when retrieving property", srex);

                    // Give the user the option of removing the bad properites from the request
                    // and retrying.
                    if (ErrorDialog.ShowServiceExceptionMsgBox(srex, true, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Remove the bad properties from the PropertySet and try again.
                        foreach (PropertyDefinitionBase propDef in srex.Response.ErrorProperties)
                        {
                            propSet.Remove(propDef);
                        }
                    }
                    else
                    {
                        return item;
                    }
                }
                // mstehle - 11/15/2011 - This code makes little sense, commenting out for now...
                //catch (Exception ex)
                //{
                //    DebugLog.WriteVerbose(ex);

                //    if (ex.Message.Length > 0)
                //    {
                //        throw;
                //    }
                //}
            }
        }

        /// <summary>
        /// Standardize the interaction for a retrying a ServiceObject.Load() call,
        /// removing bad properties until the call succeeds.
        /// </summary>
        /// <param name="obj">Object to load</param>
        /// <param name="propSet">PropertySet to load for the object</param>
        public static void PerformRetryableLoad(ServiceObject obj, PropertySet propSet)
        {
            bool retry = true;
            while (retry)
            {
                try
                {
                    obj.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                    obj.Load(propSet);
                    retry = false;
                }
                catch (ServiceResponseException srex)
                {
                    DebugLog.WriteVerbose("Handled exception when retrieving property", srex);

                    // Give the user the option of removing the bad properites from the request
                    // and retrying.
                    if (ErrorDialog.ShowServiceExceptionMsgBox(srex, true, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Remove the bad properties from the PropertySet and try again.
                        foreach (PropertyDefinitionBase propDef in srex.Response.ErrorProperties)
                        {
                            propSet.Remove(propDef);
                        }

                        retry = true;
                    }
                    else
                    {
                        retry = false;
                    }
                }
            }
        }

    }
}
