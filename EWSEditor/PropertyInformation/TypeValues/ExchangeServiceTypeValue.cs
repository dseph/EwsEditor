using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;
using EWSEditor.Common.Extensions;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class ExchangeServiceTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[]{typeof(ExchangeService)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as ExchangeService, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            ExchangeService service = propInfo.GetValue(ownerInstance, null) as ExchangeService;

            return GetValue(service, false);
        }

        /// <summary>
        /// Return the name of the ExchangeService in the form of
        /// "SERVERNAME - USERNAME [as IMPERSONATEDUSERNAME]"
        /// </summary>
        /// <param name="service">ExchangeService to get the value from.</param>
        /// <returns>Text to describe the object's value.</returns>
        internal static string GetValue(ExchangeService service, bool singleLine)
        {
            string text = string.Empty;

            // If the ExchangeService is setup for impersonation display the
            // act as account.
            if (service.ImpersonatedUserId != null)
            {
                text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0} AS {1}",
                    service.GetServiceAccountName(), 
                    service.ImpersonatedUserId.Id);
            }
            else
            {
                text = string.Format(service.GetServiceAccountName());
            }

            if (singleLine)
            {
                return text.Replace("\n", "");
            }

            return text;
        }
    }
}
