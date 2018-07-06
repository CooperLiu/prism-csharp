using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Prism.Extensions
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Adds a char to beginning of given string if it does not starts with the char.
        /// </summary>
        public static string EnsureStartsWith(this string str, char c)
        {
            return EnsureStartsWith(str, c, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Adds a char to beginning of given string if it does not starts with the char.
        /// </summary>
        public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.StartsWith(c.ToString(CultureInfo.InvariantCulture), comparisonType))
            {
                return str;
            }

            return c + str;
        }

        /// <summary>
        /// Adds a char to beginning of given string if it does not starts with the char.
        /// </summary>
        public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.StartsWith(c.ToString(culture), ignoreCase, culture))
            {
                return str;
            }

            return c + str;
        }


        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c)
        {
            return EnsureEndsWith(str, c, StringComparison.InvariantCulture);
        }

        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.EndsWith(c.ToString(CultureInfo.InvariantCulture), comparisonType))
            {
                return str;
            }

            return str + c;
        }

        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }

            if (str.EndsWith(c.ToString(culture), ignoreCase, culture))
            {
                return str;
            }

            return str + c;
        }

        /// <summary>
        /// 字符串URL编码
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string UrlEncode(this string sourceStr)
        {
            var str = System.Net.WebUtility.UrlEncode(sourceStr) ?? sourceStr;

            var pattern = @"%\w{2}";
            var matchArray = Regex.Matches(str, pattern);

            foreach (var match in matchArray)
            {
                var matchStr = match.ToString();
                str = str.Replace(matchStr, matchStr.ToLower());
            }

            return str;
        }

        public static string UrlDecode(this string sourceStr)
        {
            return System.Net.WebUtility.UrlDecode(sourceStr);
        }

        /// <summary>
        /// 字符串Unicode解码
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string UnicodeDecode(this string sourceStr)
        {
            //最直接的方法Regex.Unescape(str);
            var reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            return reg.Replace(sourceStr, m => ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString());
        }
    }

}
