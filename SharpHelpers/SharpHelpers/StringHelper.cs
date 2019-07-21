using System.Linq;
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
    }
}