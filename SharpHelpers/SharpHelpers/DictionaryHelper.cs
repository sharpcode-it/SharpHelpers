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

        /// <summary>
        /// Tries to add a key-value pair to the dictionary. If the key already exists, it updates the value.
        /// </summary>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key to add or update.</param>
        /// <param name="value">The value to associate with the key.</param>
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Removes the entry with the specified key if it exists in the dictionary, and returns a boolean indicating success.
        /// </summary>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key to remove.</param>
        /// <returns>True if the key was found and removed, otherwise false.</returns>
        public static bool RemoveIfExists<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.Remove(key);
        }

        /// <summary>
        /// Merges the entries from another dictionary into the current dictionary. If a key already exists, its value is updated.
        /// </summary>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="otherDictionary">The dictionary to merge from.</param>
        public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> otherDictionary)
        {
            foreach (var kvp in otherDictionary)
            {
                dictionary.AddOrUpdate(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Converts the dictionary into a readable string format, useful for debugging.
        /// </summary>
        /// <param name="dictionary">The dictionary to convert to a string.</param>
        /// <returns>A string representation of the dictionary.</returns>
        public static string ToReadableString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            var entries = new List<string>();
            foreach (var kvp in dictionary)
            {
                entries.Add($"{kvp.Key}: {kvp.Value}");
            }
            return "{" + string.Join(", ", entries) + "}";
        }

        /// <summary>
        /// Returns the value associated with the specified key, or the default value if the key does not exist.
        /// </summary>
        /// <param name="dictionary">The dictionary to query.</param>
        /// <param name="key">The key to look for.</param>
        /// <returns>The value associated with the key, or default if not found.</returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, out var value) ? value : default;
        }

        /// <summary>
        /// Checks whether all specified keys exist in the dictionary.
        /// </summary>
        /// <param name="dictionary">The dictionary to check.</param>
        /// <param name="keys">The keys to check for existence.</param>
        /// <returns>True if all keys exist; otherwise, false.</returns>
        public static bool ContainsAllKeys<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            return keys.All(k => dictionary.ContainsKey(k));
        }

        /// <summary>
        /// Tries to get the value associated with the key and cast it to the specified type.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The stored value type.</typeparam>
        /// <typeparam name="TResult">The desired result type.</typeparam>
        /// <param name="dictionary">The dictionary to query.</param>
        /// <param name="key">The key to retrieve.</param>
        /// <param name="result">The casted result if successful; otherwise, default.</param>
        /// <returns>True if the cast was successful; otherwise, false.</returns>
        public static bool TryGetValueAs<TKey, TValue, TResult>(this IDictionary<TKey, TValue> dictionary, TKey key, out TResult result)
        {
            result = default;
            if (dictionary.TryGetValue(key, out var value) && value is TResult casted)
            {
                result = casted;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Increments the value associated with the specified key by a given amount. If the key does not exist, it is added with the amount as its value.
        /// </summary>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key whose value to increment.</param>
        /// <param name="amount">The amount to increment by.</param>
        public static void IncrementValue<TKey>(this IDictionary<TKey, int> dictionary, TKey key, int amount = 1)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] += amount;
            else
                dictionary[key] = amount;
        }

        /// <summary>
        /// Adds multiple key-value pairs to the dictionary. If a key already exists, it is updated with the new value.
        /// </summary>
        /// <param name="dictionary">The dictionary to update.</param>
        /// <param name="items">The key-value pairs to add or update.</param>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var kvp in items)
            {
                dictionary[kvp.Key] = kvp.Value;
            }
        }
    }
}
