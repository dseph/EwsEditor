using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class InboxRulesForm : Form
    {
        private ExchangeService _CurrentService = null;

        public InboxRulesForm()
        {
            InitializeComponent();
        }

        public InboxRulesForm(ExchangeService oExchangeService)
        {
            InitializeComponent();
            _CurrentService = oExchangeService;
            ClearForm();
        }


        private void InboxRules_Load(object sender, EventArgs e)
        {

        }

 
        private void ClearForm()
        {
            txtResults.Text = string.Empty;
 
        }

        private void btnGetInboxRules_Click(object sender, EventArgs e)
        {

           

            string sReturn = string.Empty;
            string sXML = string.Empty;
            RuleCollection oRuleCollection = null;

            string sSmtpAddress = txtSmtpAddress.Text.Trim();

            try
            {

                if (sSmtpAddress.Length == 0)
                    oRuleCollection = _CurrentService.GetInboxRules();
                else
                    oRuleCollection = _CurrentService.GetInboxRules(sSmtpAddress);

                //sXML = SerializeObjectToString(oRuleCollection);
                //txtResults.Text = sXML;

                foreach (Microsoft.Exchange.WebServices.Data.Rule oRule in oRuleCollection)
                {
                    sReturn += "DisplayName: " + oRule.DisplayName + "\r\n";
                    sReturn += "ID: " + oRule.Id + "\r\n";
                    sReturn += "IsEnabled: " + oRule.IsEnabled.ToString() + "\r\n";
                    sReturn += "IsInError: " + oRule.IsInError.ToString() + "\r\n";
                    sReturn += "IsNotSupported: " + oRule.IsNotSupported.ToString() + "\r\n";
                    sReturn += "Priority: " + oRule.Priority.ToString() + "\r\n";
                    sReturn += "Actions: \r\n";
                    sReturn += "    AssignCategories: \r\n";

                    foreach (String s in oRule.Actions.AssignCategories)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    CopyToFolder: \r\n";
                    if (oRule.Actions.CopyToFolder != null)
                    {
                        sReturn += "        UniqueId: " + oRule.Actions.CopyToFolder.UniqueId + "\r\n";
                        sReturn += "        ChangeKey: " + oRule.Actions.CopyToFolder.ChangeKey + "\r\n";
                        sReturn += "        FolderName: " + oRule.Actions.CopyToFolder.FolderName + "\r\n";
                        sReturn += "        Mailbox: \r\n";
                        sReturn += "            Address: " + oRule.Actions.CopyToFolder.Mailbox.Address + "\r\n";
                        sReturn += "            IsValid: " + oRule.Actions.CopyToFolder.Mailbox.IsValid.ToString() + "\r\n";
                        sReturn += "            RoutingType: " + oRule.Actions.CopyToFolder.Mailbox.RoutingType + "\r\n";
                    }
                    sReturn += "    Delete: " + oRule.Actions.Delete.ToString() + "\r\n";

                    sReturn += "    ForwardAsAttachmentToRecipients:  \r\n";
                    foreach (EmailAddress oAddress in oRule.Actions.ForwardAsAttachmentToRecipients)
                    {
                        sReturn += "        Id:  \r\n";
                        if (oAddress.Id != null)
                        {
                            sReturn += "            UniqueId: " + oAddress.Id.UniqueId + "\r\n";
                            sReturn += "            ChangeKey: " + oAddress.Id.ChangeKey + "\r\n";
                        }
                        sReturn += "        Name: " + oAddress.Name + "\r\n";
                        sReturn += "        RoutingType: " + oAddress.Address + "\r\n";
                        sReturn += "        Address: " + oAddress.RoutingType + "\r\n";
                        if (oAddress.MailboxType.HasValue)
                            sReturn += "        MailboxType: " + oAddress.MailboxType.Value.ToString() + "\r\n";

                    }

                    sReturn += "    ForwardToRecipients:  \r\n";
                    foreach (EmailAddress oAddress in oRule.Actions.ForwardToRecipients)
                    {
                        sReturn += "        Id:  \r\n";
                        if (oAddress.Id != null)
                        {
                            sReturn += "            UniqueId: " + oAddress.Id.UniqueId + "\r\n";
                            sReturn += "            ChangeKey: " + oAddress.Id.ChangeKey + "\r\n";
                        }
                        sReturn += "        Name: " + oAddress.Name + "\r\n";
                        sReturn += "        RoutingType: " + oAddress.Address + "\r\n";
                        sReturn += "        Address: " + oAddress.RoutingType + "\r\n";
                        if (oAddress.MailboxType.HasValue)
                            sReturn += "        MailboxType: " + oAddress.MailboxType.Value.ToString() + "\r\n";

                    }
                    sReturn += "    MarkAsRead: " + oRule.Actions.MarkAsRead.ToString() + "\r\n";
                    sReturn += "    MarkImportance: " + oRule.Actions.MarkImportance.ToString() + "\r\n";
                    sReturn += "    MoveToFolder:  \r\n";
                    if (oRule.Actions.MoveToFolder != null)
                    {
                        sReturn += "        Address: " + oRule.Actions.MoveToFolder.FolderName + "\r\n";
                        sReturn += "        UniqueId: " + oRule.Actions.MoveToFolder.UniqueId + "\r\n";
                        sReturn += "        ChangeKey: " + oRule.Actions.MoveToFolder.ChangeKey + "\r\n";
                        sReturn += "        Mailbox:  \r\n";
                        if (oRule.Actions.MoveToFolder.Mailbox != null)
                        {
                            sReturn += "            Address: " + oRule.Actions.MoveToFolder.Mailbox.Address + "\r\n";
                            sReturn += "            Address: " + oRule.Actions.MoveToFolder.Mailbox.RoutingType + "\r\n";
                            sReturn += "            Address: " + oRule.Actions.MoveToFolder.Mailbox.IsValid.ToString() + "\r\n";
                        }
                    }
                    sReturn += "    PermanentDelete: " + oRule.Actions.PermanentDelete.ToString() + "\r\n";
                    sReturn += "    RedirectToRecipients: \r\n";
                    foreach (EmailAddress oAddress in oRule.Actions.RedirectToRecipients)
                    {
                        sReturn += "        Id:  \r\n";
                        if (oAddress.Id != null)
                        {
                            sReturn += "            UniqueId: " + oAddress.Id.UniqueId + "\r\n";
                            sReturn += "            ChangeKey: " + oAddress.Id.ChangeKey + "\r\n";
                        }
                        sReturn += "        Name: " + oAddress.Name + "\r\n";
                        sReturn += "        RoutingType: " + oAddress.Address + "\r\n";
                        sReturn += "        Address: " + oAddress.RoutingType + "\r\n";
                        if (oAddress.MailboxType.HasValue)
                            sReturn += "        MailboxType: " + oAddress.MailboxType.Value.ToString() + "\r\n";

                        // Enum.GetName(MailboxType, oAddress.MailboxType.Value);


                    }

                    sReturn += "    SendSMSAlertToRecipients: \r\n";
                    foreach (MobilePhone oMobilePhone in oRule.Actions.SendSMSAlertToRecipients)
                    {
                        sReturn += "        Address: " + oMobilePhone.Name + "\r\n";
                        sReturn += "        PhoneNumber: " + oMobilePhone.PhoneNumber + "\r\n";
                    }

                    sReturn += "    ServerReplyWithMessage:  \r\n";
                    if (oRule.Actions.ServerReplyWithMessage != null)
                    {
                        sReturn += "        UniqueId: " + oRule.Actions.ServerReplyWithMessage.UniqueId + "\r\n";
                        sReturn += "        ChangeKey: " + oRule.Actions.ServerReplyWithMessage.ChangeKey + "\r\n";
                    }
                    sReturn += "    StopProcessingRules: " + oRule.Actions.StopProcessingRules.ToString() + "\r\n";

                    sReturn += "Conditions: \r\n";

                    sReturn += "    Categories: \r\n";
                    foreach (String s in oRule.Conditions.Categories)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    ContainsBodyStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsBodyStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    ContainsHeaderStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsHeaderStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    ContainsRecipientStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsRecipientStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    ContainsSenderStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsSenderStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }

                    sReturn += "    ContainsSubjectOrBodyStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsSubjectOrBodyStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    ContainsSubjectStrings: \r\n";
                    foreach (String s in oRule.Conditions.ContainsSubjectStrings)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }

                    if (oRule.Conditions.FlaggedForAction.HasValue)
                        sReturn += "    FlaggedForAction: " + oRule.Conditions.FlaggedForAction.Value.ToString() + "\r\n";

                    

                    sReturn += "    FromAddresses: \r\n";
                    foreach (EmailAddress oAddress in oRule.Conditions.FromAddresses)
                    {
                        sReturn += "        Id:  \r\n";
                        if (oAddress.Id != null)
                        {
                            sReturn += "            UniqueId: " + oAddress.Id.UniqueId + "\r\n";
                            sReturn += "            ChangeKey: " + oAddress.Id.ChangeKey + "\r\n";
                        }
                        sReturn += "        Name: " + oAddress.Name + "\r\n";
                        sReturn += "        RoutingType: " + oAddress.Address + "\r\n";
                        sReturn += "        Address: " + oAddress.RoutingType + "\r\n";
                        if (oAddress.MailboxType.HasValue)
                            sReturn += "        MailboxType: " + oAddress.MailboxType.Value.ToString() + "\r\n";

                    }

                    sReturn += "    FromConnectedAccounts: \r\n";
                    foreach (String s in oRule.Conditions.FromConnectedAccounts)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    UniqueId: " + oRule.Conditions.HasAttachments + "\r\n";

                    if (oRule.Conditions.Importance.HasValue)
                        sReturn += "    Importance: " + oRule.Conditions.Importance.Value.ToString() + "\r\n";
                    sReturn += "    IsApprovalRequest: " + oRule.Conditions.IsApprovalRequest.ToString() + "\r\n";
                    sReturn += "    IsAutomaticForward: " + oRule.Conditions.IsAutomaticForward.ToString() + "\r\n";
                    sReturn += "    IsAutomaticReply: " + oRule.Conditions.IsAutomaticReply.ToString() + "\r\n";
                    sReturn += "    IsEncrypted: " + oRule.Conditions.IsEncrypted.ToString() + "\r\n";
                    sReturn += "    IsMeetingRequest: " + oRule.Conditions.IsMeetingRequest.ToString() + "\r\n";
                    sReturn += "    IsMeetingResponse: " + oRule.Conditions.IsMeetingResponse.ToString() + "\r\n";
                    sReturn += "    IsNonDeliveryReport: " + oRule.Conditions.IsNonDeliveryReport.ToString() + "\r\n";
                    sReturn += "    IsPermissionControlled: " + oRule.Conditions.IsPermissionControlled.ToString() + "\r\n";
                    sReturn += "    IsReadReceipt: " + oRule.Conditions.IsReadReceipt.ToString() + "\r\n";
                    sReturn += "    IsSigned: " + oRule.Conditions.IsSigned.ToString() + "\r\n";
                    sReturn += "    IsVoicemail: " + oRule.Conditions.IsVoicemail.ToString() + "\r\n";

                    sReturn += "    ItemClasses:  \r\n";
                    foreach (String s in oRule.Conditions.ItemClasses)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    MessageClassifications:  \r\n";
                    foreach (String s in oRule.Conditions.MessageClassifications)
                    {
                        sReturn += "        : " + s + "\r\n";
                    }
                    sReturn += "    IsVoicemail: " + oRule.Conditions.NotSentToMe.ToString() + "\r\n";
                    if (oRule.Conditions.Sensitivity.HasValue)
                        sReturn += "    Importance: " + oRule.Conditions.Sensitivity.Value.ToString() + "\r\n";
                    sReturn += "    SentOnlyToMe: " + oRule.Conditions.SentOnlyToMe.ToString() + "\r\n";

                    sReturn += "    SentToAddresses: \r\n";
                    foreach (EmailAddress oAddress in oRule.Conditions.SentToAddresses)
                    {
                        sReturn += "        Id:  \r\n";
                        if (oAddress.Id != null)
                        {
                            sReturn += "            UniqueId: " + oAddress.Id.UniqueId + "\r\n";
                            sReturn += "            ChangeKey: " + oAddress.Id.ChangeKey + "\r\n";
                        }
                        sReturn += "        Name: " + oAddress.Name + "\r\n";
                        sReturn += "        RoutingType: " + oAddress.Address + "\r\n";
                        sReturn += "        Address: " + oAddress.RoutingType + "\r\n";
                        if (oAddress.MailboxType.HasValue)
                            sReturn += "        MailboxType: " + oAddress.MailboxType.Value.ToString() + "\r\n";

                    }
                    sReturn += "    SentToMe: " + oRule.Conditions.SentToMe.ToString() + "\r\n";
                    sReturn += "    SentToOrCcMe: " + oRule.Conditions.SentToOrCcMe.ToString() + "\r\n";
                    sReturn += "    WithinDateRange:  \r\n";
                    if (oRule.Conditions.WithinDateRange.Start.HasValue)
                        sReturn += "        Start: " + oRule.Conditions.WithinDateRange.Start.Value.ToString() + "\r\n";
                    if (oRule.Conditions.WithinDateRange.End.HasValue)
                        sReturn += "        End: " + oRule.Conditions.WithinDateRange.End.Value.ToString() + "\r\n";

                    sReturn += "    WithinSizeRange:  \r\n";
                    if (oRule.Conditions.WithinSizeRange.MinimumSize.HasValue)
                        sReturn += "        MinimumSize: " + oRule.Conditions.WithinSizeRange.MinimumSize.Value.ToString() + "\r\n";
                    if (oRule.Conditions.WithinSizeRange.MaximumSize.HasValue)
                        sReturn += "        MaximumSize: " + oRule.Conditions.WithinSizeRange.MaximumSize.Value.ToString() + "\r\n";

 
                     
                    // oRule.Actions 
 
    
                    sReturn += "------------------------------------------------------------------\r\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error retrieving inbox rules");
            }

            txtResults.Text = sReturn;
        }

 
 
    }
}
