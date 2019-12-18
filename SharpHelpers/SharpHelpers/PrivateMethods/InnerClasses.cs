using System.Text.RegularExpressions;

namespace SharpCoding.SharpHelpers.PrivateMethods
{
    public static class InnerClassesExtension
    {
        internal static string StripHtml(this string input)
        {
            return string.IsNullOrEmpty(input)
                ? string.Empty
                : Regex.Replace(input, "<.*?>", string.Empty);
        }

        internal static string RemoveScriptTag(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            return rRemScript.Replace(input, string.Empty);
        }
    }
}
