// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpCoding.SharpHelpers
{
    public static class DictionaryHelper
    {
        /// <summary>
        /// This method add the TKey with the specific format
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="formatString"></param>
        /// <param name="argList"></param>
        public static void AddFormat<TKey>(this Dictionary<TKey, string> dictionary,
            TKey key,
            string formatString,
            params object[] argList)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            dictionary.Add(key, string.Format(formatString, argList));
        }

        /// <summary>
        /// This method remove items by the specific predicate
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="condition"></param>
        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dictionary,
            Func<KeyValuePair<TKey, TValue>, bool> condition)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            foreach (var cur in dictionary.Where(condition).ToList())
            {
                dictionary.Remove(cur.Key);
            }
        }

        /// <summary>
        /// This method get or create the value related to the specific key
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key) where TValue : new()
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            if (!dictionary.TryGetValue(key, out TValue ret))
            {
                ret = new TValue();
                dictionary[key] = ret;
            }
            return ret;
        }
    }
}
