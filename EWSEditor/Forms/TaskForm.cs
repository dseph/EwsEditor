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
 
            ItemView oView = new ItemView(9999);
            //PropertySet oPropertySet = new PropertySet(EmailMessageSchema.ExtendedProperties);
            PropertySet oPropertySet = new PropertySet(
                BasePropertySet.IdOnly,
                TaskSchema.Subject,
                TaskSchema.Body,
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
                TaskSchema.StatusDescription 
                );

 
            Task oTask = Task.Bind(CurrentService, oItemId, oPropertySet);
 
            return oTask;
        }


        private bool SetTaskFromForm(ref Task oTask)
        {
            bool bRet = false;

            oTask.Subject = txtSubject.Text;
            oTask.Body = txtBody.Text;

            bRet = true;
            return bRet;
        }

        private void ClearForm()
        {
            txtSubject.Text = string.Empty;
            txtBody.Text = string.Empty;
        }

        private bool SetFormFromTask(Task oTask)
        {
            bool bRet = false;
            ClearForm();

            txtSubject.Text = oTask.Subject;
            txtBody.Text = oTask.Body;
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
    }
}
