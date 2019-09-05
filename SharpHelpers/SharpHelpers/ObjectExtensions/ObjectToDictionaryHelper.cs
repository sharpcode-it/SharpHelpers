// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace SharpCoding.SharpHelpers.ObjectExtensions
{
    public static class ObjectToDictionaryHelper
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
        /// This method maps the collection to dictionary
        /// </summary>
        /// <param name="nvc"></param>
        /// <returns></returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            if ((nvc == null) || !nvc.AllKeys.Any()) return new Dictionary<string, string>();

            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
    }
}
