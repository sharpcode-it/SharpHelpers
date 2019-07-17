using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace SharpCoding.SharpHelpers.ObjectExtensions
{
    public static class ObjectToDictionaryHelper
    {
        public static IDictionary<string, object> ToDictionary(this object source)
        {
            var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (source == null) return dictionary;

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(source))
            {
                var obj = descriptor.GetValue(source);
                dictionary.Add(descriptor.Name, obj);
            }

            return dictionary;
        }

        public static IDictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            if ((nvc == null) || !nvc.AllKeys.Any()) return new Dictionary<string, string>();

            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }
}
