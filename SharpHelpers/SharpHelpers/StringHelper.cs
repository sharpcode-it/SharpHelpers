﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SharpCoding.SharpHelpers
{
    public static class StringHelper
    {
        public static string Replace(this string istance, string[] toReplace, string replaceWith)
        {
            return string.IsNullOrEmpty(istance)
                ? string.Empty
                : toReplace.Aggregate(istance, (current, str) => current.Replace(str, replaceWith));
        }

        /// <summary>
        ///  This method clears string to avoid SQLInjection
        /// </summary>
        /// <param name="stringValue"></param>
        /// <returns></returns>
        public static string SqlInjectionSanitize(this string stringValue)
        {
            if (null == stringValue)
                return string.Empty;
            return stringValue.RegexReplace("-{2,}", "-") // transforms multiple --- in - use to comment in sql scripts
                .RegexReplace(@"[*/]+", string.Empty) // removes / and * used also to comment in sql scripts
                .RegexReplace(
                    @"(;|\s)(exec|execute|select|insert|update|delete|create|alter|drop|rename|truncate|backup|restore)\s",
                    string.Empty, RegexOptions.IgnoreCase).Trim();
        }


        private static string RegexReplace(this string stringValue, string matchPattern, string toReplaceWith)
        {
            return Regex.Replace(stringValue, matchPattern, toReplaceWith);
        }

        private static string RegexReplace(this string stringValue, string matchPattern, string toReplaceWith, RegexOptions regexOptions)
        {
            return Regex.Replace(stringValue, matchPattern, toReplaceWith, regexOptions);
        }

        /// <summary>
        /// This method return the last substring after the string split 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LastAfter(this string stringToSplit, char separator)
        {
            return ((IEnumerable<string>)stringToSplit.Split(separator)).Last<string>();
        }

        /// <summary>
        /// This method executes equals operation between two strings with no case sensitive 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        public static bool IsDBEqual(this string s, string comparand)
        {
            return string.Equals(s, comparand, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// This method executes not equals operation between two strings with no case sensitive 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="comparand"></param>
        /// <returns></returns>
        public static bool IsNotDBEqual(this string s, string comparand)
        {
            return !IsDBEqual(s, comparand);
        }

        /// <summary>
        /// Given a list of strings, the method check if the instance is contained in the collection, ignoring case
        /// </summary>
        /// <param name="s"></param>
        /// <param name="comparands"></param>
        /// <returns></returns>
        public static bool IsInDB(this string s, params string[] comparands)
        {
            return ((IEnumerable<string>)comparands).Any<string>((Func<string, bool>)(x => IsDBEqual(x, s)));
        }

        /// <summary>
        /// The method returns the substring of the instance
        /// </summary>
        /// <param name="s"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string SafeSubstringByLength(this string s, int maxLength)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= maxLength || maxLength <= 0)
                return s;
            return s.Substring(0, maxLength);

        }
       /// <summary>
       /// The method truncates the instance and check if the substring result is shorter than the original string
       /// </summary>
       /// <param name="s"></param>
       /// <param name="maxLength"></param>
       /// <param name="truncated"></param>
       /// <returns></returns>
        public static string Truncate(this string s, int maxLength, out bool truncated)
        {
            truncated = false;
          
            string str = SafeSubstringByLength(s, maxLength);
            int? length1 = str?.Length;
            int? length2 = s?.Length;
            if ((length1.GetValueOrDefault() == length2.GetValueOrDefault()))
                return str;
            truncated = true;
            return str;
        }

        /// <summary>
        /// The method parses the instance to a nullable int
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToNullableInt(this string s)
        {
            int result;
            if (int.TryParse(s, out result))
                return new int?(result);
            return null;
        }
        /// <summary>
        /// Convertion from string to base64
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToBase64(this string s)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(s), Base64FormattingOptions.None);
        }

        /// <summary>
        /// Convertion from base64 to string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FromBase64(this string s)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(s));
        }

    }
}
