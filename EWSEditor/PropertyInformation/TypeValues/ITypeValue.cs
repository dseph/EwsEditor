using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EWSEditor.PropertyInformation.TypeValues
{
    internal interface ITypeValue
    {
        Type[] SupportedTypes { get; }
        string GetValue(object rawValue);
        string GetValue(object ownerInstance, PropertyInfo propInfo);
    }
}
