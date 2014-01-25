using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;

namespace EWSEditor.Forms
{
    public partial class SystemNetMainForm : Form
    {
        public string hdrName, hdrValue;
        bool ContinueTimerRun = false;

        public SystemNetMainForm()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            this.txtBoxErrorLog.Text = string.Empty;

            if (ValidateForm())
                SendEmail();
        }

        private bool ValidateForm()
        {
            bool bRet = true;
            StringBuilder oSB = new System.Text.StringBuilder();

            if (txtPassword.Text.Trim() == "")
            {
                oSB.AppendFormat("Password is required.\r\n");
                bRet = false;
            }

            if (txtBoxTo.Text.Trim() == "")
            {
                oSB.AppendFormat("To: is a required field.\r\n");
                bRet = false;
            }

            if (txtBoxTo.Text.Trim() != "")
            {
                bRet = CheckEmailAddress(txtBoxTo.Text);
                if (bRet == false)
                    oSB.AppendFormat("To address is not valid. \r\n");
            }


            if (txtBoxCC.Text.Trim() != "")
            {
                bRet = CheckEmailAddress(txtBoxCC.Text);
                if (bRet == false)
                    oSB.AppendFormat("CC address is not valid. \r\n");
            }

            if (txtBoxBCC.Text.Trim() != "")
            {
                bRet = CheckEmailAddress(txtBoxBCC.Text);
                if (bRet == false)
                    oSB.AppendFormat("BCC address is not valid. \r\n");
            }
            txtBoxErrorLog.AppendText(oSB.ToString());

            return bRet;
        }

        public bool CheckEmailAddress(string input)
        {
            bool bRet = true;

            try
            {
                Regex r = new Regex(@"^((?:(?:(?:[a-zA-Z0-9][\.\-\+_]?)*)[a-zA-Z0-9])+)\@((?:(?:(?:[a-zA-Z0-9][\.\-_]?){0,62})[a-zA-Z0-9])+)\.([a-zA-Z0-9]{2,6})$");
                input.TrimStart(' ');
                input.TrimEnd(' ');
                if (r.Match(input).Success)
                    return bRet = true;
                else
                    bRet = false;

            }
            catch (Exception ex)
            {
                bRet = false;
            }
            return bRet;
        }

        private bool SendEmail()
        {
            bool bRet = false;

            try
            {
                txtBoxErrorLog.AppendText(string.Format("Sending message. {0}\r\n", DateTime.Now));

                // create the mail message
                MailMessage mail = new MailMessage();


                if (txtUser.Text.Trim() != "")
                    mail.From = new MailAddress(this.txtUser.Text.Trim());

                if (txtBoxTo.Text.Trim() != "")
                    mail.To.Add(new MailAddress(this.txtBoxTo.Text.Trim()));

                if (this.txtBoxCC.Text.Trim() != "")
                    mail.CC.Add(new MailAddress(this.txtBoxCC.Text.Trim()));

                if (this.txtBoxBCC.Text.Trim() != "")
                    mail.Bcc.Add(new MailAddress(this.txtBoxBCC.Text.Trim()));

                // set the content
                mail.Subject = txtBoxSubject.Text;
                mail.Body = richTxtBody.Text;
                mail.IsBodyHtml = chkIsHtml.Checked;

                // set priority for the message
                if (rdoNormalPri.Checked) { mail.Priority = MailPriority.Normal; }
                else if (rdoHighPri.Checked) { mail.Priority = MailPriority.High; }
                else { mail.Priority = MailPriority.Low; }

                //mail.BodyTransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
                //mail.SubjectEncoding = Encoding.UTF8;
                //mail.HeadersEncoding = Encoding.UTF8;
                //mail.BodyEncoding = Encoding.UTF8;

                // add custom headers
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        mail.Headers.Add(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                    }
                }

                // add attachements
                if (chkListAttachments.Items.Count > 0)
                {
                    // get the current list count and add each path as an attachment
                    int count = chkListAttachments.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        mail.Attachments.Add(new Attachment(chkListAttachments.Items[i].ToString()));
                    }
                }

                // smtp client setup
                SmtpClient smtp = new SmtpClient(cboServer.Text);

                // Send by pickup folder?
                if (chkSendByPort.Checked == true)
                {

                    string sUser = txtUser.Text.Trim();
                    string sPassword = txtPassword.Text.Trim();
                    string sDomain = txtDomain.Text.Trim();

                    if (sUser.Length != 0)
                    {
                        if (sDomain.Length != 0)
                            smtp.Credentials = new NetworkCredential(sUser, sPassword);
                        else
                            smtp.Credentials = new NetworkCredential(sUser, sPassword, sDomain);

                    }
                    smtp.EnableSsl = chkEnableSSL.Checked;
                    smtp.Port = Int32.Parse(cboPort.Text.Trim());
                }

                // use pickup directory?
                if (rdoSendByPickupFolder.Checked == true)
                {
                    if (this.chkSpecifyPickupFolder.Checked)
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtp.PickupDirectoryLocation = txtPickupFolder.Text.Trim();
                    }
                    else
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    }
                }

                // send email
                smtp.Send(mail);



                // cleanup
                mail.Dispose();
                mail = null;
                smtp.Dispose();  // Only in 4.0 and later.  This will force the connection closed instead of leaving it open.
                smtp = null;

                txtBoxErrorLog.AppendText(string.Format("Message sent successfully.  {0}\r\n", DateTime.Now));

                bRet = true;
            }
            catch (Exception ex)
            {
                txtBoxErrorLog.Text = ex.Message + "\r\n" + "\r\n" + "StackTrace: " + "\r\n" + ex.StackTrace;
                bRet = false;
            }

            return bRet;
        }


        private void WaitLoop(int iSeconds)
        {
            DateTime oStart = DateTime.Now;

            for (int iSecondsLoop = 0; iSecondsLoop < iSeconds; iSecondsLoop++)
            {
                for (int Loop1 = 0; Loop1 < 10; Loop1++)
                {


                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();

                    if (ContinueTimerRun == false)
                        break;
                }


                if (ContinueTimerRun == false)
                    break;
            }

            DateTime oEnd = DateTime.Now;
        }


        private void btnAddHeaders_Click(object sender, EventArgs e)
        {
            MailHeadersForm oForm = new MailHeadersForm();
  
            oForm.ShowDialog(this);
            if (oForm.bChoseSave == true)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = oForm.txtName;
                dataGridView1.Rows[n].Cells[1].Value = oForm.txtValue;
            }
            oForm = null;
        }

        private void btnDeleteHeader_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) { dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index); }
 
        }

        private void btnInsertAttachment_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    chkListAttachments.Items.Add(file);
                    txtBoxErrorLog.Text = "Attachment size = " + size + " bytes." + "\r\n" + "Result: " + result;
                }
                catch (IOException ioe)
                {
                    txtBoxErrorLog.Text = "Error: " + ioe.Message + "\r\n" + "\r\n" + "StackTrace: " + "\r\n" + ioe.StackTrace;
                }
            }
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (chkListAttachments.CheckedItems.Count != 0)
            {
                while (chkListAttachments.CheckedIndices.Count > 0)
                {
                    chkListAttachments.Items.RemoveAt(chkListAttachments.CheckedIndices[0]);
                }
            }
        }

        private void chkSpecifyPickupFolder_CheckedChanged(object sender, EventArgs e)
        {
            this.txtPickupFolder.Enabled = chkSpecifyPickupFolder.Checked;
        }

        private void SystemNetMainForm_Load(object sender, EventArgs e)
        {
           
            SetSendByEnablement();
        }

        private void btnTimedSendStart_Click(object sender, EventArgs e)
        {
            this.txtBoxErrorLog.Text = string.Empty;
            Decimal iMessageCount = 0;
            ContinueTimerRun = true;
            //int iSecondsToSleep = (int)numericUpDownResendSeconds.Value * 1000;




            if (ValidateForm())
            {
                txtBoxErrorLog.AppendText(string.Format("Started sending email loop.\r\n"));

                while (ContinueTimerRun == true)
                {
                    iMessageCount++;
                    txtBoxErrorLog.AppendText(string.Format("Message {0}...\r\n", iMessageCount));

                    SendEmail();

                    WaitLoop((int)numericUpDownResendSeconds.Value);


                }

                txtBoxErrorLog.AppendText(string.Format("Finished sending email loop.\r\n"));

            }
        }

        private void btnTimedSendEnd_Click(object sender, EventArgs e)
        {
            ContinueTimerRun = false;
            txtBoxErrorLog.AppendText(string.Format("User chose to stop email loop.\r\n"));
        }

        private void chkSendByPort_CheckedChanged(object sender, EventArgs e)
        {
            SetSendByEnablement();
        }

        private void rdoSendByPickupFolder_CheckedChanged(object sender, EventArgs e)
        {
            SetSendByEnablement();
        }

        private void SetSendByEnablement()
        {
            this.cboServer.Enabled = chkSendByPort.Checked;
            this.cboPort.Enabled = chkSendByPort.Checked;
            this.chkEnableSSL.Enabled = chkSendByPort.Checked;
            this.txtUser.Enabled = chkSendByPort.Checked;
            this.txtPassword.Enabled = chkSendByPort.Checked;
            this.txtDomain.Enabled = chkSendByPort.Checked;

            this.txtPickupFolder.Enabled = rdoSendByPickupFolder.Checked;
            this.chkSpecifyPickupFolder.Enabled = rdoSendByPickupFolder.Checked;
 
        }

        private void grpSmtpSettings_Enter(object sender, EventArgs e)
        {

        }

        private void grpMailMessage_Enter(object sender, EventArgs e)
        {

        }
    }
}
