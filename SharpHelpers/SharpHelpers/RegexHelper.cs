using System.Text.RegularExpressions;

namespace SharpCoding.SharpHelpers
{
    // (c) 2019 SharpCoding
    // This code is licensed under MIT license (see LICENSE.txt for details)
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
            var regex = new Regex(pattern);
            return (regex.IsMatch(value));
        }
    }
}
