namespace EWSEditor.PropertyInformation
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Xml;

    using Microsoft.Exchange.WebServices.Data;

    using EWSEditor.Common;
    using EWSEditor.Diagnostics;
    using EWSEditor.PropertyInformation.TypeValues;
    using EWSEditor.PropertyInformation.SmartViews;

    /// <summary>
    /// This class defines the full property interpretation
    /// available for first class properties and extended
    /// properties.
    /// </summary>
    public class PropertyInterpretation
    {
        public readonly string Name = string.Empty;
        public readonly string Value = string.Empty;
        public readonly string SmartView = string.Empty;
        public readonly string TypeName = string.Empty;
        public readonly string AlternateNames = string.Empty;
        public readonly string Comments = string.Empty;

        #region Constructors

        private PropertyInterpretation() { }

        /// <summary>
        /// Get property information for a first class property using
        /// Reflection.
        /// </summary>
        /// <remarks>
        /// This is an old interpretation style using Reflection which
        /// is currently only used by the ExchangeService display in the
        /// FolderTreeForm.  It would be nice to special case that logic and
        /// remove this constructor from this class so we don't continue
        /// to use Reflection.
        /// </remarks>
        /// <param name="ownerInstance">An instance of the owner type of the
        /// property.</param>
        /// <param name="prop">Property on the ownerInstance which we will
        /// pull type and value information from.</param>
        public PropertyInterpretation(object ownerInstance, PropertyInfo propInfo)
        {
            Name = GetPropertyName(propInfo);
            Value = GetPropertyValue(ownerInstance, propInfo, out TypeName);
        }

        /// <summary>
        /// Get property information for a schema property or extended property
        /// using a ServiceObject and a PropertyDefinitionBase.
        /// </summary>
        /// <param name="owner">The ServiceObject whose owns the property to interpret.</param>
        /// <param name="propDef">Property definition used to get type and value information
        /// from.</param>
        public PropertyInterpretation(ServiceObject owner, PropertyDefinitionBase propDef)
        {
            Name = GetPropertyName(propDef);
            Value = GetPropertyValue(owner, propDef, out TypeName);
            SmartView = GetSmartView(owner, propDef);

            ExtendedPropertyDefinition exPropDef = propDef as ExtendedPropertyDefinition;
            if (exPropDef != null)
            {
                KnownExtendedPropertyInfo? propInfo = KnownExtendedProperties.Instance().GetKnownExtendedPropertyInfo(
                    exPropDef);

                if (propInfo.HasValue)
                {
                    AlternateNames = GetAlternateNames(propInfo.Value);
                    Comments = GetComments(propInfo.Value);
                }
            }
        }

        #endregion

        #region Public Methods

        public XmlNode ToXML(XmlDocument xmlDoc)
        {
            XmlNode property = xmlDoc.CreateNode(XmlNodeType.Element, "Property", "");

            XmlNode propName = xmlDoc.CreateNode(XmlNodeType.Element, "PropertyName", "");
            propName.InnerText = Name;
            property.AppendChild(propName);

            XmlNode propType = xmlDoc.CreateNode(XmlNodeType.Element, "PropertyType", "");
            propType.InnerText = TypeName;
            property.AppendChild(propType);

            if (Value.Length > 0)
            {
                XmlNode propValue = xmlDoc.CreateNode(XmlNodeType.Element, "PropertyValue", "");
                XmlNode propValueData = xmlDoc.CreateNode(XmlNodeType.CDATA, "", "");
                propValueData.InnerText = Value;
                propValue.AppendChild(propValueData);
                property.AppendChild(propValue);
            }

            if (SmartView.Length > 0)
            {
                XmlNode propSmartView = xmlDoc.CreateNode(XmlNodeType.Element, "SmartView", "");
                propSmartView.InnerText = SmartView;
                property.AppendChild(propSmartView);
            }

            if (AlternateNames.Length > 0)
            {
                XmlNode propKnownNames = xmlDoc.CreateNode(XmlNodeType.Element, "KnownNames", "");
                propKnownNames.InnerText = AlternateNames;
                property.AppendChild(propKnownNames);
            }

            if (Comments.Length > 0)
            {
                XmlNode propComments = xmlDoc.CreateNode(XmlNodeType.Element, "Comments", "");
                propComments.InnerText = Comments;
                property.AppendChild(propComments);
            }

            return property;
        }

        #endregion

        /// Static Methods

        #region GetPropertyName

        /// <summary>
        /// Return text to describe the property name of a FirstClass property.
        /// </summary>
        /// <param name="prop">The PropertyInfo used to formulate the name.</param>
        /// <returns>The name to be displayed in EWSEditor for this property.</returns>
        public static string GetPropertyName(PropertyInfo prop)
        {
            return prop.Name;
        }

        /// <summary>
        /// Return text to describe a PropertyDefinitionBase object, whether a
        /// PropertyDefinition or ExtendedPropertyDefinition.  If a PropertyDefintion
        /// return the Name.  If an ExtendedPropertyDefinition, call use the same
        /// logic in GetPropertyName(ExtendedPropertyDefintion)
        /// </summary>
        /// <param name="exPropDef">Property defintion to examine</param>
        /// <returns>
        /// Name for a PropertyDefinition.  See the GetPropertyName() overloads
        /// for ExtendedPropertyDefinition format.
        /// </returns>
        public static string GetPropertyName(PropertyDefinitionBase propDefBase)
        {
            if (propDefBase == null) { return null; }

            ExtendedPropertyDefinition exPropDef;
            PropertyDefinition propDef;

            if (null != (exPropDef = propDefBase as ExtendedPropertyDefinition))
            {
                return GetPropertyName(exPropDef);
            }
            else if (null != (propDef = propDefBase as PropertyDefinition))
            {
                return (propDef as PropertyDefinition).Name;
            }

            return propDefBase.ToString();
        }

        /// <summary>
        /// Return text to describe the property name of an 
        /// ExtendedPropertyDefiniton based on the type of MAPI property defined.
        /// <remarks>
        /// This is *not* the same as a "well known" name.  This is the name 
        /// of the raw property definition to be displayed along side any 
        /// other, more descriptive names.
        /// </remarks>
        /// </summary>
        /// <param name="exPropDef">Property defintion to examine</param>
        /// <returns>
        /// PidTags display as - "Tag: 0x0000"
        /// PidLids display as - "Id: 0x0000 PropSet: [known set name or GUID]"
        /// PidNames display as - "Name: 0x0000 PropSet: [known set name or GUID]"
        /// </returns>
        public static string GetPropertyName(ExtendedPropertyDefinition exPropDef)
        {
            string name = string.Empty;

            if (exPropDef.Tag != null)
            {
                name = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[Tag:] 0x{0}, 0n{1}", 
                    Convert.ToString(Convert.ToInt32(exPropDef.Tag), 16), 
                    Convert.ToString(exPropDef.Tag));
            }
            else
            {
                if (exPropDef.Name != null)
                {
                    if (exPropDef.PropertySetId != null)
                    {
                        name = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[Name:] {0} \n[PropSet:] {1}",
                            exPropDef.Name,
                            exPropDef.PropertySetId.ToString());
                    }
                    else
                    {
                        name = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[Name:] {0} \n[PropSet:] {1}",
                            exPropDef.Name,
                            exPropDef.PropertySet.ToString());
                    }
                }
                else
                {
                    if (exPropDef.PropertySetId != null)
                    {
                        name = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[PropId:] 0x{0}, 0n{1} \n[PropSet:] {2}",
                            Convert.ToString(Convert.ToInt32(exPropDef.Id), 16),
                            Convert.ToString(exPropDef.Id),
                            exPropDef.PropertySetId.ToString());
                    }
                    else
                    {
                        name = string.Format(System.Globalization.CultureInfo.CurrentCulture, "[PropId:] 0x{0}, 0n{1} \n[PropSet:] {2}",
                            Convert.ToString(Convert.ToInt32(exPropDef.Id), 16),
                            Convert.ToString(exPropDef.Id),
                            exPropDef.PropertySet.ToString());
                    }
                }
            }

            return name;
        }

        #endregion

        #region GetPropertyType
        /// <summary>
        /// Return the type name for the given PropertyDefinitionBase, if an
        /// ExtendedPropertyDefinition use the same logic in 
        /// GetPropertyType(ExtendedPropertyDefinition).  If a PropertyDefinition
        /// return the type FullName.
        /// </summary>
        /// <param name="exPropDef">Property defintion to examine</param>
        /// <returns>
        /// FullName of Type for a PropertyDefinition.  See the GetPropertyType() 
        /// overloads for ExtendedPropertyDefinition format.
        /// </returns>
        public static string GetPropertyType(PropertyDefinitionBase propDef)
        {
            ExtendedPropertyDefinition exPropDef = propDef as ExtendedPropertyDefinition;
            if (exPropDef != null)
            {
                return GetPropertyType(exPropDef);
            }
            
            return propDef.GetType().Name;
        }

        /// <summary>
        /// Return the MapiType enumeration name of the ExtendedPropertyDefintion.
        /// </summary>
        /// <param name="exPropDef">Property defintion to examine</param>
        /// <returns>
        /// The name of the specified MapiType for the given exPropDef
        /// </returns>
        public static string GetPropertyType(ExtendedPropertyDefinition exPropDef)
        {
            return exPropDef.MapiType.ToString();
        }
        #endregion

        #region GetPropertyValue
        /// <summary>
        /// Return text to describe a property value based on special formatting 
        /// rules for displaying MapiType values.
        /// </summary>
        /// <remarks>
        /// 1.3 - Only distinction made is between array types and non-array types.
        /// </remarks>
        /// <param name="exProp">Property to examine</param>
        /// <returns>
        /// Value property of a type of ExtendedProperty is already a string for non-array
        /// types that string is simply returned. For array types, values are printed on 
        /// seperate lines.
        /// </returns>
        public static string GetPropertyValue(ExtendedProperty exProp)
        {

            switch (exProp.PropertyDefinition.MapiType)
            {
                case MapiPropertyType.ApplicationTimeArray:
                case MapiPropertyType.BinaryArray:
                case MapiPropertyType.CLSIDArray:
                case MapiPropertyType.CurrencyArray:
                case MapiPropertyType.DoubleArray:
                case MapiPropertyType.FloatArray:
                case MapiPropertyType.IntegerArray:
                case MapiPropertyType.LongArray:
                case MapiPropertyType.ObjectArray:
                case MapiPropertyType.ShortArray:
                case MapiPropertyType.StringArray:
                case MapiPropertyType.SystemTimeArray:
                    if (exProp.Value is string)
                    {
                        return exProp.Value as string;
                    }
                    else if (exProp.Value is string[])
                    {
                        string propValues = string.Empty;
                        string[] values = exProp.Value as string[];
                        foreach (string propValue in values)
                        {
                            propValues = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}\n{1}",
                                propValues,
                                propValue);
                        }
                        return propValues;
                    }
                    break;
            }

            return exProp.Value.ToString();
        }

        /// <summary>
        /// Return text representation of a property value.  Some property types have
        /// specialized logic, if so then dispatch to the appropriate method for
        /// translation.
        /// </summary>
        /// <param name="ownerInstance">Property owner instance to pull the value from.</param>
        /// <param name="propInfo">Property to pull from the owner</param>
        /// <returns>
        /// Text representation of a property value.
        /// </returns>
        public static string GetPropertyValue(object ownerInstance, PropertyInfo propInfo)
        {
            string dummy;
            return GetPropertyValue(ownerInstance, propInfo, out dummy);
        }

        /// <summary>
        /// Return text representation of a property value.  Some property types have
        /// specialized logic, if so then dispatch to the appropriate method for
        /// translation.  Also return the type name of the property.
        /// </summary>
        /// <param name="ownerInstance">Property owner instance to pull the value from.</param>
        /// <param name="propInfo">Property to pull from the owner</param>
        /// <param name="typeName">Text representing the type of the property.</param>
        /// <returns>
        /// Text representation of a property value.
        /// </returns>
        public static string GetPropertyValue(object ownerInstance, PropertyInfo propInfo, out string typeName)
        {
            string value = string.Empty;

            try
            {
                typeName = propInfo.PropertyType.FullName;    

                // See if we have any special type interpreters for this
                // type.
                ITypeValue interpreter = TypeValueFinder.GetTypeInterpreter(propInfo.PropertyType);
                if (interpreter != null)
                {
                    value = interpreter.GetValue(ownerInstance, propInfo);
                }
                else
                {
                    // If no interpreters are found, simply return the
                    // ToString() value of the object.
                    if (propInfo.GetValue(ownerInstance, null) != null)
                    {
                        value = propInfo.GetValue(ownerInstance, null).ToString();
                    }
                }
            }
            catch (TargetInvocationException tie)
            {
                // Special handling for this exception because
                // the inner exception text is nice
                typeName = tie.InnerException.GetType().Name;
                value = tie.InnerException.Message;

                TraceHelper.WriteVerbose(tie);
            }
            catch (Exception ex)
            {
                typeName = ex.GetType().Name;
                value = ex.Message;

                TraceHelper.WriteVerbose(ex);
            }

            return value;
        }

        /// <summary>
        /// Get text representation of a property value and the property value's type. Some
        /// property types have specialized logic, if so then dispatch to the appropriate method
        /// for translation.
        /// </summary>
        /// <param name="owner">ServiceObject which is the owner of the property</param>
        /// <param name="propDef">Definition of the property</param>
        /// <param name="typeName">Output: The type name of the property value.</param>
        /// <returns>
        /// Text representation of a property value and the property value's type.  If 
        /// TryGetProperty() fails for this property, no values is returned.
        /// </returns>
        public static string GetPropertyValue(ServiceObject owner, PropertyDefinitionBase propDef, out string typeName)
        {
            object value = null;
            typeName = string.Empty;

            if (owner.TryGetProperty(propDef, out value))
            {
                ExtendedPropertyDefinition extProp = propDef as ExtendedPropertyDefinition;
                if (extProp != null)
                {
                    typeName = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}.{1}", 
                        extProp.MapiType.GetType().FullName, 
                        extProp.MapiType.ToString());
                }
                else
                {
                    typeName = value.GetType().FullName;
                }

                // See if we have any special type interpreters for this type.
                if (value != null)
                {
                    ITypeValue interpreter = TypeValueFinder.GetTypeInterpreter(value.GetType());
                    if (interpreter != null)
                    {
                        return interpreter.GetValue(value);
                    }
                    else
                    {
                        // If no interpreters are found, simply return the
                        // ToString() value of the object.
                        return value.ToString();
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Return text respresentation of the object.
        /// </summary>
        /// <param name="rawValue">Object to get value from.</param>
        /// <returns>
        /// Text representation of the object and object's properties.
        /// </returns>
        public static string GetPropertyValue(object rawValue)
        {
            string value = string.Empty;

            try
            {
                // See if we have any special type interpreters for this
                // type.
                ITypeValue interpreter = TypeValueFinder.GetTypeInterpreter(rawValue.GetType());
                if (interpreter != null)
                {
                    value = interpreter.GetValue(rawValue);
                }
                else
                {
                    // If no interpreters are found, simply return the
                    // ToString() value of the object.
                    value = rawValue.ToString();
                }
            }
            catch (TargetInvocationException tie)
            {
                // Special handling for this exception because
                // the inner exception text is nice
                value = tie.InnerException.Message;
                TraceHelper.WriteVerbose(tie);
            }
            catch (Exception ex)
            {
                value = ex.Message;
                TraceHelper.WriteVerbose(ex);
            }

            return value;
        }

        #endregion

        #region GetAlternateNames
        public static string GetAlternateNames(PropertyDefinitionBase propDef)
        {
            ExtendedPropertyDefinition exPropDef = propDef as ExtendedPropertyDefinition;
            if (exPropDef != null)
            {
                return GetAlternateNames(KnownExtendedProperties.Instance().GetKnownExtendedPropertyInfo(
                    exPropDef));
            }

            return string.Empty;
        }

        private static string GetAlternateNames(KnownExtendedPropertyInfo? propInfo)
        {
            // Bail out if we don't have info.
            if (!propInfo.HasValue) return string.Empty;

            if (propInfo.Value.AlternateNames.Length == 0)
            {
                return propInfo.Value.CanonicalNames;
            }

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}, {1}",
                propInfo.Value.CanonicalNames,
                propInfo.Value.AlternateNames);
        }
        #endregion

        #region GetSmartView

        public static string GetSmartView(ServiceObject owner, PropertyDefinitionBase propDef)
        {
            ExtendedPropertyDefinition exPropDef = propDef as ExtendedPropertyDefinition;
            if (exPropDef != null)
            {
                object value = null;

                if (owner.TryGetProperty(propDef, out value))
                {
                    // See if we have any SmartViews for this property.
                    if (value != null)
                    {
                        ISmartView smartView = SmartViewFinder.GetSmartView(exPropDef);
                        if (smartView != null)
                        {
                            return smartView.GetSmartView(value);
                        }
                    }
                }
            }

            return string.Empty;
        }

        #endregion

        #region GetComments

        public static string GetComments(ServiceObject owner, PropertyDefinitionBase propDef)
        {
            ExtendedPropertyDefinition exPropDef = propDef as ExtendedPropertyDefinition;
            if (exPropDef != null)
            {
                return GetComments(KnownExtendedProperties.Instance().GetKnownExtendedPropertyInfo(
                    exPropDef));
            }

            return string.Empty;
        }

        private static string GetComments(KnownExtendedPropertyInfo? propInfo)
        {
            // Bail out if we don't have info.
            if (!propInfo.HasValue) return string.Empty;

            StringBuilder output = new StringBuilder();

            if (propInfo.Value.Areas.Length > 0)
            {
                output.Append("Areas: ");
                output.AppendLine(propInfo.Value.Areas);
            }

            if (propInfo.Value.References.Length > 0)
            {
                if (output.ToString().Length > 0)
                {
                    output.AppendLine();
                }

                output.Append("References: ");
                output.AppendLine(propInfo.Value.References);
            }

            return output.ToString();
        }
        #endregion

    }
}
