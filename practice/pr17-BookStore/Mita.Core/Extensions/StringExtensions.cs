using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mita.Core
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parse int from string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Integer value, if NaN returns <paramref name="defaultValue"/></returns>
        public static int ToInt(this string str, int defaultValue)
        {
            int i;
            if (!int.TryParse(str, out i))
                return defaultValue;
            return i;
        }

        /// <summary>
        /// Parse int from string
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Integer value, if NaN returns 0</returns>
        public static int ToInt(this string str)
        {
            int i = str.ToInt(default(int));
            return i;
        }

        public static long ToLong(this string str, long defaultValue = default(long))
        {
            long i;
            if (!long.TryParse(str, out i))
                return defaultValue;
            return i;
        }

        public static double ToDouble(this string str, double defaultValue)
        {
            double d;
            if (!double.TryParse(str, out d))
                return defaultValue;
            return d;
        }

        public static double ToDouble(this string str)
        {
            double d = str.ToDouble(default(double));
            return d;
        }

        public static string Wrap(this string str, string startWrapper, string endWrapper = null)
        {
            Check.NotNullOrEmpty(startWrapper, "startWrapper");

            return string.Concat(startWrapper, str, (endWrapper ?? startWrapper));
        }

        public static string WrapByTag(this string source, string tag)
        {
            string tagged = string.Format("<{0}>{1}</{0}>", tag, source);
            return tagged;
        }

        public static string WrapByTag(this string source, string tag, IDictionary<string, string> attrs)
        {
            var sb = new StringBuilder();
            sb.Append("<" + tag);

            foreach (var attr in attrs)
                sb.AppendFormat(" {0}='{1}'", attr.Key, attr.Value);

            sb.AppendFormat(">{0}</{1}>", source, tag);
            return sb.ToString();
        }

        public static bool Contains(this string source, string value, bool ignoreCase)
        {
            if (ignoreCase)
            {
                source = source.ToUpper();
                value = value.ToUpper();
            }

            return source.Contains(value);
        }

        public static string Replace(this string source, string oldValue, string newValue, bool ignoreCase)
        {
            var regex = new Regex(oldValue, RegexOptions.IgnoreCase);
            var newSentence = regex.Replace(source, newValue);
            return newSentence;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string[] Split(this string str, string delimeter, StringSplitOptions options = StringSplitOptions.None)
        {
            string[] parts = str.Split(new[] { delimeter }, options);
            return parts;
        }

        public static string[] Split(this string str, char delimeter, StringSplitOptions options = StringSplitOptions.None)
        {
            string[] parts = str.Split(new[] { delimeter }, options);
            return parts;
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string FormatWith(this string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        public static string FormatWith(this string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        public static string FormatWith(this string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        public static string TrimSafe(this string str)
        {
            return (str ?? string.Empty).Trim();
        }

        /// <summary>
        ///     Replace <paramref name="value"/> with empty string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Remove(this string str, string value)
        {
            return str.Replace(value, string.Empty);
        }

        /// <summary>
        /// Converts string to bytes array without using Encoding.
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <returns>Bytes array representation of string.</returns>
        public static byte[] GetBytes(this string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string FirstLetterToLower(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToLower(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static bool StartsWithLetter(this string str)
        {
            return !str.IsNullOrEmpty() && Char.IsLetter(str[0]);
        }

        public static string SubstringSafe(this string str, int startIndex, int length)
        {
            if (str.IsNullOrEmpty() || startIndex >= str.Length || length <= 0)
            {
                return string.Empty;
            }

            length = Math.Min(length, str.Length - startIndex);

            return str.Substring(startIndex, length);
        }
    }
}
