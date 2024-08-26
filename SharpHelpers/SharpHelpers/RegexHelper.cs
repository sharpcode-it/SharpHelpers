// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Text.RegularExpressions;

namespace SharpCoding.SharpHelpers
{
   public static class RegexHelper
    {
        /// <summary>
        /// Return true if the value match the Regex pattern
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatchRegex(this string value, string pattern)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));

            var regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Retrieves the first match found in the input string.
        /// </summary>
        /// <param name="input">The input string to search.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <returns>The first match found, or null if no match is found.</returns>
        public static string Match(this string input, string pattern)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));

            var match = Regex.Match(input, pattern);
            return match.Success ? match.Value : null;
        }

        /// <summary>
        /// Replaces all occurrences of a pattern with a replacement string.
        /// </summary>
        /// <param name="input">The input string to modify.</param>
        /// <param name="pattern">The regular expression pattern.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns>A new string with all occurrences replaced.</returns>
        public static string Replace(this string input, string pattern, string replacement)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));
            if (replacement == null) throw new ArgumentNullException(nameof(replacement));

            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// Splits a string into an array of substrings using a regex pattern as a delimiter.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="pattern">The regular expression pattern to use as a delimiter.</param>
        /// <returns>An array of substrings.</returns>
        public static string[] Split(this string input, string pattern)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));

            return Regex.Split(input, pattern);
        }
    }
}
