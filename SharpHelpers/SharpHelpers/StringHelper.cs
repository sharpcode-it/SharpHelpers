using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
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

        /// <summary>
        /// Returns a string from the left side with a fixed length of characters
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">The number of characters </param>
        public static string Left(this string str, int length)
        {
            if (length == 0 || str.Length == 0) return string.Empty;
            string result = str;
            if (length < str.Length)
            {
                result = str.Substring(0, length);
            }
            return result;
        }

        /// <summary>
        /// Returns a string from the right side with a fixed length of characters
        /// </summary>
        /// <param name="str"></param>
        ///<param name="length">The number of characters </param>
        public static string Right(this string str, int length)
        {
            if (length == 0 || str.Length == 0) return string.Empty;
            string result = str;
            if (length < str.Length)
            {
                result = str.Substring(str.Length - length);
            }
            return result;
        }

        /// <summary>
        /// Returns a object from Json
        /// </summary>
        /// <param name="strJson"></param>
        public static T JsonToObject<T>(this string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson,
                                new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        /// <summary>
        /// Returns true if the stirng is in the email address 
        /// </summary>
        /// <param name="str"></param>
        public static bool IsEmail(this string str)
        {
            return Regex.Match(str,
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.IgnoreCase).Success;
        }

        /// <summary>
        /// Returns true if the string is a numeric 
        /// </summary>
        /// <param name="str"></param>
        public static bool IsNumber(this string str)
        {
            return Regex.Match(str, @"^[0-9]\d{0,9}((\.|\,)\d{1,3})?%?$", RegexOptions.IgnoreCase).Success;
        }

        /// <summary>
        /// Returns true if the string is a Guid 
        /// </summary>
        /// <param name="str"></param>
        public static bool IsGuid(this string str)
        {
            return Regex.Match(str,
                @"^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$",
                RegexOptions.IgnoreCase).Success;
        }

        /// <summary>
        /// Count the specific word in a given string
        /// </summary>
        /// <param name="str"></param>
        public static int WordCount(this string str, string word)
        {
            return str.Contains(word) ? new Regex(word).Matches(str).Count : 0;
        }
    }
}
