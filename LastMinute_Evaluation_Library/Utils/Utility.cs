using System;
using System.Globalization;
using System.Text;

namespace LastMinute_Evaluation_Library.Utils
{
    internal static class Utility
    {
        public const string At = "at";
        public const string WhiteSpace = " ";
        public const string QuantityMultiplier = "x";

        public static bool IsBlank(string s) => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);

        public static bool IsNotBlank(string s) => !IsBlank(s);

        public static string AddWhiteSpaceIfNotBlank(string prefix, string str)
        {
            return IsNotBlank(str)
                    ? AddWhiteSpaceIfNotBlank(true, prefix, str) 
                    : string.Empty;
        }

        public static string AddWhiteSpaceIfNotBlank(string prefix, string str, string suffix)
        {
            return IsNotBlank(str)
                    ? AddWhiteSpaceIfNotBlank(true, prefix, str, suffix)
                    : string.Empty;
        }

        public static StringBuilder AddWhiteSpaceIfNotBlank(StringBuilder builder, bool addWhiteSpaceAfterLast = false, params string[] str)
        {
            int i = 0;
            foreach (string s in str)
            {
                i++;
                if (IsNotBlank(s))
                {
                    builder.Append(s);
                    if (str.Length != i || addWhiteSpaceAfterLast)
                    {
                        builder.Append(WhiteSpace);
                    }
                }
                else if (str.Length==i && !addWhiteSpaceAfterLast)
                {
                    builder.Remove(builder.Length - 1, 1);
                }
            }
            return builder;
        }

        public static string AddWhiteSpaceIfNotBlank(bool addWhiteSpaceAfterLast, params string[] str)
        {
            return AddWhiteSpaceIfNotBlank(new StringBuilder(), addWhiteSpaceAfterLast, str).ToString();
        }

        public static string AddWhiteSpaceIfNotBlank(StringBuilder builder, params string[] str)
        {
            return AddWhiteSpaceIfNotBlank(builder, false, str).ToString();
        }

        public static string DateTimeFormatter(DateTime? dateTime)
        {
            return dateTime.HasValue
                    ? dateTime.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    : string.Empty;
        }
    }
}
