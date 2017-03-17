using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;
using EWSEditor.Forms;
using EWSEditor.PropertyInformation;

namespace EWSEditor.Forms
{
    public partial class PropertyEditorDialog : DialogForm
    {
        private ServiceObject CurrentServiceObejct = null;
        private PropertyDefinitionBase CurrentProperty = null;

        private bool IsReadOnly = false;
        private bool IsDirty = false;

        private PropertyEditorDialog()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(ServiceObject owner, PropertyDefinitionBase propDef, bool isReadOnly)
        {
            PropertyEditorDialog editor = new PropertyEditorDialog();
            editor.CurrentProperty = propDef;
            editor.CurrentServiceObejct = owner;
            editor.IsReadOnly = isReadOnly;
            return editor.ShowDialog();
        }

        public static DialogResult ShowDialog(
            string propertyName, 
            string typeName, 
            string knownNames, 
            string value,
            string smartView)
        {
            PropertyEditorDialog editor = new PropertyEditorDialog();
            editor.IsReadOnly = true;

            editor.txtName.Text = propertyName;
            editor.txtType.Text = typeName;
            editor.txtKnownNames.Text = knownNames;
            editor.AddPropertyValueControls(value, typeName);
            editor.txtSmartView.Text = smartView;

            return editor.ShowDialog();
        }

        /// <summary>
        /// Display the property name, type, and value
        /// </summary>
        private void PropertyEditorDialog_Load(object sender, EventArgs e)
        {
            if (this.CurrentServiceObejct == null || this.CurrentProperty == null) { return; }

            PropertyInterpretation propInter = new PropertyInterpretation(
                this.CurrentServiceObejct,
                this.CurrentProperty);

            txtName.Text = propInter.Name;
            txtType.Text = propInter.TypeName;
            txtSmartView.Text = propInter.SmartView;
            txtComments.Text = propInter.Comments;
            txtKnownNames.Text = propInter.AlternateNames;

            AddPropertyValueControls(propInter.Value, propInter.TypeName);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // If the form was readonly then don't return OK and
                // don't update the item...
                if (this.IsReadOnly)
                {
                    this.DialogResult = DialogResult.Ignore;
                    return;
                }

                if (this.CurrentServiceObejct is Folder)
                {
                    Folder folder = (Folder)this.CurrentServiceObejct;

                    if (this.CurrentProperty is PropertyDefinition)
                    {
                        UpdateFirstClassProperty(folder);
                    }
                    else
                    {
                        UpdateExtendedProperty(folder.ExtendedProperties);
                    }

                    folder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                    folder.Update();
                }
                else if (this.CurrentServiceObejct is Item)
                {
                    Item item = (Item)this.CurrentServiceObejct;

                    if (this.CurrentProperty is PropertyDefinition)
                    {
                        UpdateFirstClassProperty(item);
                    }
                    else
                    {
                        UpdateExtendedProperty(item.ExtendedProperties);
                    }

                    Appointment appt = item as Appointment;
                    if (appt != null)
                    {
                        // TODO: Let the user choose these options before calling Update()
                        appt.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                        appt.Update(ConflictResolutionMode.AutoResolve,
                            SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy);
                    }
                    else
                    {
                        // TODO: Let the user choose these options before calling Update()
                        item.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                        item.Update(ConflictResolutionMode.AutoResolve);
                    }
                    
                }

                // Only send DialogResult.OK if we changed something
                if (!this.IsDirty)
                {
                    this.DialogResult = DialogResult.Ignore;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (System.ArgumentException aEx)
            {
                // Give the user a little better information about what happened
                if (aEx.Message.Equals("Property set method not found."))
                {
                    ApplicationException ex = new ApplicationException("This property is read only.", aEx);
                    throw ex;
                }

                throw;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void UpdateFirstClassProperty(object obj)
        {
            // Find the first class property and update it...
            foreach (PropertyInfo propInfo in obj.GetType().GetProperties())
            {
                if (propInfo.Name == this.CurrentProperty.ToString())
                {
                    // Determine if the property value was changed.
                    object origPropValue = propInfo.GetValue(obj, null);
                    object currPropValue = GetCurrentPropertyValue(txtType.Text);

                    if (!origPropValue.Equals(currPropValue))
                    {
                        propInfo.SetValue(obj, currPropValue, null);
                        this.IsDirty = true;
                    }

                    // There should only be one property to update so we can exit.
                    return;
                }
            }
        }

        private void UpdateExtendedProperty(ExtendedPropertyCollection exProps)
        {
            object origPropValue = null;
            if (this.CurrentServiceObejct.TryGetProperty(this.CurrentProperty, out origPropValue))
            {
                object currPropValue = GetCurrentPropertyValue(txtType.Text);

                if (origPropValue == null ^ currPropValue == null ||
                    !origPropValue.Equals(currPropValue))
                {
                    if (this.CurrentServiceObejct is Item)
                    {
                        (this.CurrentServiceObejct as Item).SetExtendedProperty(
                            this.CurrentProperty as ExtendedPropertyDefinition,
                            currPropValue);

                        this.IsDirty = true;
                    }
                    else if (this.CurrentServiceObejct is Folder)
                    {
                        (this.CurrentServiceObejct as Folder).SetExtendedProperty(
                            this.CurrentProperty as ExtendedPropertyDefinition,
                            currPropValue);

                        this.IsDirty = true;
                    }
                }
            }
        }

        /// <summary>
        /// Load and fill the controls used to display
        /// the property value.
        /// </summary>
        private void AddPropertyValueControls(string value, string typeName)
        {
            switch (typeName)
            {
                case "System.Byte[]":
                case "System.String":
                case "System.Int32":
                case "System.DateTime":
                case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.Binary":
                case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer":
                case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.String":
                case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.SystemTime":
                    TextBox txtStringValue = new TextBox();
                    txtStringValue.Dock = DockStyle.Fill;
                    txtStringValue.Multiline = true;
                    txtStringValue.Text = value;
                    txtStringValue.ReadOnly = this.IsReadOnly;

                    tbpDefault.Controls.Add(txtStringValue);
                    break;
                case "System.Boolean":
                case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.Boolean":
                    CheckBox chkBoolValue = new CheckBox();
                    chkBoolValue.Checked = Convert.ToBoolean(value);
                    chkBoolValue.Enabled = !this.IsReadOnly;
                    chkBoolValue.Text = "Boolean";

                    tbpDefault.Controls.Add(chkBoolValue);
                    break;
                default:
                    // By default, display a text box and make the
                    // field read only.
                    RichTextBox txtDefaultValue = new RichTextBox();
                    txtDefaultValue.Dock = DockStyle.Fill;
                    txtDefaultValue.Multiline = true;
                    txtDefaultValue.Text = value;

                    this.IsReadOnly = true;
                    txtDefaultValue.ReadOnly = true;

                    tbpDefault.Controls.Add(txtDefaultValue);
                    break;
            }
        }

        /// <summary>
        /// Gets the value of the property based on the
        /// control state on the form.
        /// </summary>
        /// <returns></returns>
        private object GetCurrentPropertyValue(string typeName)
        {
            string propValue = string.Empty;

            if (tbpDefault.Controls.Count == 1)
            {
                if (tbpDefault.Controls[0] is TextBox)
                {
                    switch (typeName)
                    {
                        case "System.Int32":
                        case "Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer":
                            return Convert.ToInt32(tbpDefault.Controls[0].Text);
                        case "System.DateTime":
                            return Convert.ToDateTime(tbpDefault.Controls[0].Text);
                        default:
                            return tbpDefault.Controls[0].Text;
                    }
                }
                else if (tbpDefault.Controls[0] is CheckBox)
                {
                    return ((CheckBox)tbpDefault.Controls[0]).Checked;
                }
            }



            return null;
        }
    }
}
