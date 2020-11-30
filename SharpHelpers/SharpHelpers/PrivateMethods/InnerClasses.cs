// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)

using System.Linq;
using System.Text.RegularExpressions;

namespace SharpCoding.SharpHelpers.PrivateMethods
{
    public static class InnerClassesExtension
    {
        //internal static string StripHtml(this string input)
        //{
        //    return string.IsNullOrEmpty(input)
        //        ? string.Empty
        //        : Regex.Replace(input, "<.*?>", string.Empty);
        //}

        internal static string StripHtml(this string input, params string[] allowedTags)
        {
            if (string.IsNullOrEmpty(input)) return input;

            MatchEvaluator evaluator = m => string.Empty;
            input = Regex.Replace(input, @"<%[^>]+?\/?%>", evaluator);

            if (allowedTags != null && allowedTags.Length > 0)
            {
                Regex reAllowed = new Regex(string.Format(@"^<(?:{0})\b|\/(?:{0})>$", string.Join("|", allowedTags.Select(x => Regex.Escape(x)).ToArray())));
                evaluator = m => reAllowed.IsMatch(m.Value) ? m.Value : string.Empty;
            }

            return Regex.Replace(Regex.Replace(input, @"<[^>]+?\/?>", evaluator), @"[\s\r\n]+", " ");
        }

        internal static string RemoveScriptTag(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            return rRemScript.Replace(input, string.Empty);
        }
    }
}
