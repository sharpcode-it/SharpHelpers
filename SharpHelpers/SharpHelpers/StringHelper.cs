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

    public static string StringCharRepeate(int count, string inputChr, int charRepeate)
        {
            if (inputChr.Length == 0)
                return string.Empty;
            return new string(inputChr[charRepeate], count);
        }

        public static string LastAfter(this string s, char c )
        {
            return ((IEnumerable<string>)s.Split(c)).Last<string>();
        }

        public static bool IsDB(string s, string comparand)
        {
            return string.Equals(s, comparand, StringComparison.Ordinal);
        }

        public static bool IsNotDB(string s, string comparand)
        {
            return ! IsDB( s, comparand);
        }

        public static bool IsInDB(string s, params string[] comparands)
        {
            return ((IEnumerable<string>)comparands).Any<string>((Func<string, bool>)(x => IsDB(x, s)));
        }

        public static string MaxLength(string s, int maxLength)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= maxLength)
                return s;
            return s.Substring(0, maxLength);
        }

        public static string Truncate(string s, int maxLength)
        {
            string str = MaxLength(s, maxLength);
            int? length1 = str?.Length;
            int? length2 = s?.Length;
            if (length1.GetValueOrDefault() == length2.GetValueOrDefault() & length1.HasValue == length2.HasValue)
                return str;
            return str + " ...TRUNCATED";
        }


        public static int? ToNullableInt(string s)
        {
            int result;
            if (int.TryParse(s, out result))
                return new int?(result);
            return null;
        }

        public static string ToBase64(string s)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(s), Base64FormattingOptions.None);
        }

        public static string FromBase64(string s)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(s));
        }

    }
}
