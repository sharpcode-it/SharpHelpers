using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace SharpCoding.SharpHelpers
{
    public static class CollectionHelper
    {
        /// <summary>
        /// This method maps the object to dictionary
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This method maps the a NameValueCollection <paramref name="nvc"/> to dictionary
        /// </summary>
        /// <param name="nvc">A NameValueCollection istance</param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            if ((nvc == null) || !nvc.AllKeys.Any()) return new Dictionary<string, string>();

            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }
}
