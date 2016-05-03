using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
 
namespace EWSEditor.Forms
{
    public partial class TaskForm : Form
    {
        private bool _IsExistingTask = false;
        private ExchangeService _CurrentService = null;
        private Task _Task = null;
        private bool _TaskWasSaved = false;
         
        private bool _isDirty = false;
 
        private FolderId _FolderId = null;

        public TaskForm()
        {
            InitializeComponent();
        }

        // New Contact.
        public TaskForm(ExchangeService CurrentService, FolderId oFolderId)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
            _Task = new Task(CurrentService);
            _IsExistingTask = false;
            _FolderId = oFolderId;
            ClearForm();
            if (_TaskWasSaved == false)
                _TaskWasSaved = false;
 
        }

        // Existing Contact.
        public TaskForm(ExchangeService CurrentService, ItemId oItemId)
        {
            InitializeComponent();
            _CurrentService = CurrentService;

            _Task = LoadTaskForEdit(CurrentService, oItemId);
            _IsExistingTask = true;
            SetFormFromTask(_Task);
            if (_TaskWasSaved == false)
                _TaskWasSaved = false;

  
        }

        public TaskForm(ExchangeService CurrentService, ref Task oTask)
        {
            InitializeComponent();
            _CurrentService = CurrentService;
            _Task = oTask;
            _IsExistingTask = true;
            SetFormFromTask(oTask);
            if (_TaskWasSaved == false)
                _TaskWasSaved = false;
        }


        private void TaskForm_Load(object sender, EventArgs e)
        {

        }

        private Task LoadTaskForEdit(ExchangeService CurrentService, ItemId oItemId)
        {
            // Task properties:  https://msdn.microsoft.com/en-us/library/office/microsoft.exchange.webservices.data.task_properties(v=exchg.80).aspx

            ItemView oView = new ItemView(9999);
            //PropertySet oPropertySet = new PropertySet(EmailMessageSchema.ExtendedProperties);
            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                TaskSchema.Subject,
                TaskSchema.Body,
                TaskSchema.ReminderDueBy,
                TaskSchema.PercentComplete,
                TaskSchema.CompleteDate,
                TaskSchema.DueDate,
                TaskSchema.Importance,
                TaskSchema.IsDraft,
                TaskSchema.IsRecurring,
                TaskSchema.IsReminderSet,
                TaskSchema.Recurrence,
                TaskSchema.Sensitivity,
                TaskSchema.StartDate,
                TaskSchema.Status,
                TaskSchema.StatusDescription,
                TaskSchema.Importance,
                TaskSchema.LastModifiedName,
                TaskSchema.LastModifiedTime, 
                TaskSchema.Attachments
                 
                );

            // Be sure to select the type of body to retrieve.
            oPropertySet.RequestedBodyType = BodyType.HTML;     // Choose the HTML body.
            //oPropertySet.RequestedBodyType = BodyType.Text;   // Choose the Text body.
    
            Task oTask = Task.Bind(CurrentService, oItemId, oPropertySet);
            
            //// Versions of bodies which can be retrieved as of 4/2016
            ////  https://msdn.microsoft.com/en-us/library/office/dn600367(v=exchg.150).aspx
            //string s = string.Empty;
            //s = StringHelper.DeNullString(oTask.Body);            // Read-write.  Inherited from Item
            //s = StringHelper.DeNullString(oTask.TextBody);        // Read only. Exchange Online & 2013
            //s = StringHelper.DeNullString(oTask.NormalizedBody);  // Read only. Exchange Online & 2013
            //s = StringHelper.DeNullString(oTask.UniqueBody);      // Read only. Inherited from Item.  2010 and later.
 
            return oTask;
        }


        private bool SetTaskFromForm(ref Task oTask)
        {
            bool bRet = false;
             

            oTask.Subject = txtSubject.Text;
            if (cmboBodyType.Text == "HTML")
                oTask.Body = new MessageBody(BodyType.HTML, txtBody.Text);
            else
                oTask.Body = new MessageBody(BodyType.Text, txtBody.Text);

            oTask.StartDate  = dtStartDate.Value;
            oTask.DueDate = dtDueDate.Value;

            switch (cmboStatus.Text)
            {
                case "Completed":
                    oTask.Status = TaskStatus.Completed;
                    break;
                case "Deferred":
                    oTask.Status = TaskStatus.Deferred;
                    break;
                case "InProgress":
                    oTask.Status = TaskStatus.InProgress;
                    break;
                case "NotStarted":
                    oTask.Status = TaskStatus.NotStarted;
                    break;
                case "WaitingOnOthers":
                    oTask.Status = TaskStatus.WaitingOnOthers;
                    break;
            }

            switch (cmboImportance.Text)
            {
                case "Low":
                    oTask.Importance = Importance.Low;
                    break;
                case "Normal":
                    oTask.Importance = Importance.Normal;
                    break;
                case "High":
                    oTask.Importance = Importance.High;
                    break;
            }
 
            bRet = true;
            return bRet;
        }

        private void ClearForm()
        {
            txtSubject.Text = string.Empty;
            txtBody.Text = string.Empty;

            dtStartDate.Value = DateTime.Now;
            dtDueDate.Value = DateTime.Now;  
            cmboBodyType.Text = "HTML";  // Start with HTML
            cmboImportance.Text = "Normal";
            cmboStatus.Text = "NotStarted";
            txtLastModifiedDate.Text = "";
            txtLastModifiedName.Text = "";
        }

        private bool SetFormFromTask(Task oTask)
        {
            bool bRet = false;
            ClearForm();

            txtSubject.Text = oTask.Subject;
            txtBody.Text = oTask.Body;

            if (oTask.StartDate  == null)
                dtStartDate.Value = DateTime.Now;
            else
                dtStartDate.Value = oTask.StartDate.Value;

            if (oTask.DueDate  == null)
                dtDueDate.Value = DateTime.Now;
            else
                dtDueDate.Value = oTask.DueDate.Value;
       
            cmboBodyType.Text = "HTML";  // Alwasy pull back html
            cmboImportance.Text = oTask.Importance.ToString();
            cmboStatus.Text = oTask.Status.ToString();
            txtLastModifiedDate.Text = oTask.LastModifiedTime.ToString();
            txtLastModifiedName.Text = oTask.LastModifiedName;
            _isDirty = false;

            bRet = true;
            
            return bRet;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text.Trim().Length != 0)
            {
                try
                {

                    SetTaskFromForm(ref _Task);
                    if (_IsExistingTask == true)
                    {
                        _Task.Update(ConflictResolutionMode.AlwaysOverwrite);
                    }
                    else
                    {
                        _Task.Save(_FolderId);
                    }
                    _TaskWasSaved = true;
                    this.Close();
                }
                catch (Exception ex3)
                {
                    MessageBox.Show(ex3.InnerException.ToString(), "Error Saving");
                }

            }
            else
            {
                MessageBox.Show("Subject needs to be set.", "Missing information");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            Item oItem = (Item)_Task;
            AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, true);
            oAddRemoveAttachments.ShowDialog();
            if (oAddRemoveAttachments.IsDirty == true)
                _isDirty = true;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDueDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboImportance_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }   
    }
}
