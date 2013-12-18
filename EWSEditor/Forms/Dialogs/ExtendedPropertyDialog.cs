using System;
using System.Windows.Forms;
using EWSEditor.Common;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class ExtendedPropertyDialog : DialogForm
    {
        // The current loaded ExtendedPropertyDefinition from the control values
        private ExtendedPropertyDefinition currentDefinition = null;
        private EnumComboBox<MapiPropertyType> propertyTypeCombo = new EnumComboBox<MapiPropertyType>();
        private EnumComboBox<DefaultExtendedPropertySet> extendedPropertySetCombo = new EnumComboBox<DefaultExtendedPropertySet>();

        private ExtendedPropertyDialog()
        {
            InitializeComponent();
        }

        #region Properties

        private MapiPropertyType? CurrentMapiPropertyType
        {
            get
            {
                return this.propertyTypeCombo.SelectedItem;
            }
        }

        private DefaultExtendedPropertySet? CurrentDefaultExtendedPropertySet
        {
            get
            {
                return this.extendedPropertySetCombo.SelectedItem;
            }
        }

        private Guid? CurrentPropertySetGuid
        {
            get
            {
                Guid? propertySet = null;

                try
                {
                    propertySet = new Guid(this.extendedPropertySetCombo.Text);
                }
                catch (Exception ex)
                {
                    DebugLog.WriteVerbose("Handled exception and returned null", ex);
                    return null;
                }

                return propertySet;
            }
        }

        private int? CurrentPropertyTag
        {
            get
            {
                int? tag = null;

                if (this.IsPropertyTagThePropertyIdentifier() &&
                    !String.IsNullOrEmpty(this.PropTagText.Text))
                {
                    tag = this.GetPropNumFromString(PropTagText.Text);
                }

                return tag;
            }
        }

        private int? CurrentPropertyId
        {
            get
            {
                // If PropTag is selected identifier there is nothing to do
                if (this.IsPropertyTagThePropertyIdentifier()) 
                {
                    DebugLog.WriteVerbose("PropTag is the identifier, no need to get PropertyId");
                    return null;
                }

                int? id = null;

                // A valid Property Id would only contain numbers
                if (!String.IsNullOrEmpty(this.PropertyNameOrIdText.Text))
                {
                    id = this.GetPropNumFromString(PropertyNameOrIdText.Text);
                }

                return id;
            }
        }

        private string CurrentPropertyName
        {
            get
            {
                // If PropTag is selected identifier there is nothing to do
                if (this.IsPropertyTagThePropertyIdentifier()) 
                {
                    DebugLog.WriteVerbose("Property tag is the selected identifier, no need to get PropertyName");
                    return null; 
                }

                // If CurrentPropertyId has a value there is nothing to do
                if (this.CurrentPropertyId.HasValue) 
                {
                    DebugLog.WriteVerbose("CurrentPropertyId has a value, no need to get PropertyName");
                    return null; 
                }

                string name = null;

                if (!String.IsNullOrEmpty(this.PropertyNameOrIdText.Text) &&
                    !this.IsStringOnlyNumbers(this.PropertyNameOrIdText.Text))
                {
                    name = PropertyNameOrIdText.Text.Trim();
                }

                return name;
            }
        }

        #endregion

        #region Static Methods

        public static DialogResult ShowDialog(ref ExtendedPropertyDefinition propDef)
        {
            ExtendedPropertyDialog dialog = new ExtendedPropertyDialog();
            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                propDef = dialog.currentDefinition;
            }

            return res;
        }

        #endregion

        #region Event Methods

        private void ExtendedPropertyDialog_Load(object sender, EventArgs e)
        {
            this.propertyTypeCombo.TransformComboBox(this.TempPropertyTypeCombo);
            this.propertyTypeCombo.HasEmptyItem = true; 

            this.extendedPropertySetCombo.TransformComboBox(this.TempExtendedPropertySetComboBox);
            this.extendedPropertySetCombo.HasEmptyItem = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.currentDefinition = this.ConvertFormToExtendedPropDef();
            DialogResult = DialogResult.OK;
        }

        private void TagRadio_CheckedChanged(object sender, EventArgs e)
        {
            this.PropTagText.Enabled = this.TagRadio.Checked;

            if (this.TagRadio.Checked == false)
            {
                this.PropTagText.Text = string.Empty;
            }
        }

        private void NamedPropRadio_CheckedChanged(object sender, EventArgs e)
        {   
            this.PropertyNameOrIdText.Enabled = this.NamedPropRadio.Checked;
            this.extendedPropertySetCombo.Enabled = this.NamedPropRadio.Checked;

            if (this.NamedPropRadio.Checked == false)
            {
                this.PropertyNameOrIdText.Text = string.Empty;
            }
        }

        private void PropertyDefinitionControl_Leave(object sender, EventArgs e)
        {
            // If the current settings match a known property, select it in
            // the drop down list
            ExtendedPropertyDefinition propDef = this.ConvertFormToExtendedPropDef();

            if (propDef != null)
            {
                SetFormWithExtendedPropDef(propDef);
            }
        }

        private void KnownNameText_TextChanged(object sender, EventArgs e)
        {
            // Lookup the known name, if found set the form control values based on the
            // ExtendedPropertyDefinition.
            ExtendedPropertyDefinition propDef = KnownExtendedProperties.Instance().GetExtendedPropertyDefinition(
                this.KnownNameText.Text);

            // If we didn't find the property, bailout...
            if (propDef == null) 
            {
                DebugLog.WriteVerbose("Didn't find any property definition");
                return; 
            }

            SetFormWithExtendedPropDef(propDef);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Create an ExtendedPropertyDefinition from the form
        /// control's values.
        /// </summary>
        /// <returns>
        /// ExtendedPropertyDefinition created from form state
        /// </returns>
        private ExtendedPropertyDefinition ConvertFormToExtendedPropDef()
        {
            // To identify a property we need both the property
            // identifier and a type.  If the type is not specified
            // then we have nothing to do here...
            if (!this.CurrentMapiPropertyType.HasValue) 
            {
                DebugLog.WriteVerbose("CurrentMapiPropertyType has no value.");
                return null; 
            }

            if (this.IsPropertyTagThePropertyIdentifier())
            {
                // Build an ExtendedPropertyDefinition for a proptag
                if (this.CurrentPropertyTag.HasValue)
                {
                    return new ExtendedPropertyDefinition(
                                this.CurrentPropertyTag.Value,
                                this.CurrentMapiPropertyType.Value);
                }
            }
            else
            {
                if (this.CurrentDefaultExtendedPropertySet.HasValue)
                {
                    // Build an ExtendedPropertyDefinition for a named property
                    // in a default property set.
                    if (this.CurrentPropertyId.HasValue)
                    {
                        return new ExtendedPropertyDefinition(
                                    this.CurrentDefaultExtendedPropertySet.Value,
                                    this.CurrentPropertyId.Value,
                                    this.CurrentMapiPropertyType.Value);
                    }
                    else if (!String.IsNullOrEmpty(this.CurrentPropertyName))
                    {
                        return new ExtendedPropertyDefinition(
                                    this.CurrentDefaultExtendedPropertySet.Value,
                                    this.CurrentPropertyName,
                                    this.CurrentMapiPropertyType.Value);
                    }
                }
                else if (this.CurrentPropertySetGuid.HasValue)
                {
                    // Build an ExtendedPropertyDefinition for a named property
                    // in a specified property set.
                    if (this.CurrentPropertyId.HasValue)
                    {
                        return new ExtendedPropertyDefinition(
                                    this.CurrentPropertySetGuid.Value,
                                    this.CurrentPropertyId.Value,
                                    this.CurrentMapiPropertyType.Value);
                    }
                    else if (!String.IsNullOrEmpty(this.CurrentPropertyName))
                    {
                        return new ExtendedPropertyDefinition(
                                    this.CurrentPropertySetGuid.Value,
                                    this.CurrentPropertyName,
                                    this.CurrentMapiPropertyType.Value);
                    }
                }
            }

            return null;
        }

        private bool IsPropertyTagThePropertyIdentifier()
        {
            return TagRadio.Checked;
        }

        private int? GetPropNumFromString(string value)
        {
            // TODO: Is this a duplicate of ConversionHelper.GetIntFromBase16String()??

            int? i = null;

            // Guard against NULL or empty strings
            if (String.IsNullOrEmpty(value)) 
            {
                DebugLog.WriteVerbose("Input is null or empty, returning NULL");
                return null; 
            }

            try
            {
                if (value.Trim().StartsWith("0x"))
                {
                    // If the value is prefixed by "0x" then treat
                    // the number as hex and convert o integer
                    i = ConversionHelper.GetIntFromBase16String(value);
                }
                else
                {
                    // If the value is not prefixed by "0x" then
                    // assume it is binary
                    i = Convert.ToInt32(value);
                }
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception.", ex);

                // The conversions will fail if the value
                // is not numeric, if so return 0
                return i;
            }

            return i;
        }

        private void SetFormWithExtendedPropDef(ExtendedPropertyDefinition propDef)
        {
            if (propDef == null) { return; }

            if (propDef.Tag.HasValue)
            {
                this.TagRadio.Checked = true;
                this.NamedPropRadio.Checked = false;
                this.PropTagText.Text = string.Format("0x{0}", ConversionHelper.GetBase16(propDef.Tag.Value));
            }
            else if (propDef.Name != null && propDef.Name.Length > 0)
            {
                this.NamedPropRadio.Checked = true;
                this.TagRadio.Checked = false;

                this.PropertyNameOrIdText.Text = propDef.Name;
            }
            else if (propDef.Id.HasValue)
            {
                NamedPropRadio.Checked = true;
                TagRadio.Checked = false;

                PropertyNameOrIdText.Text = string.Format("0x{0}", ConversionHelper.GetBase16(propDef.Id.Value));
            }

            if (propDef.PropertySet.HasValue)
            {
                this.extendedPropertySetCombo.SelectedItem = propDef.PropertySet.Value;
            }
            else
            {
                if (propDef.PropertySetId.HasValue)
                {
                    this.extendedPropertySetCombo.Text = propDef.PropertySetId.Value.ToString();
                }
            }

            this.propertyTypeCombo.SelectedItem = propDef.MapiType;

            KnownExtendedPropertyInfo? info = KnownExtendedProperties.Instance().GetKnownExtendedPropertyInfo(propDef);
            if (info.HasValue)
            {
                if (info.Value.AlternateNames.Length > 0)
                {
                    this.txtKnownNames.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}, {1}", info.Value.CanonicalNames, info.Value.AlternateNames);
                }
                else
                {
                    this.txtKnownNames.Text = info.Value.CanonicalNames;
                }
            }
            else
            {
                this.txtKnownNames.Text = null;
            }
        }

        private bool IsStringOnlyNumbers(string input)
        {
            foreach (char c in input.Trim().ToCharArray())
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}