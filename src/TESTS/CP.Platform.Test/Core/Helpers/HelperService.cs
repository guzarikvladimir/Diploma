using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CP.Platform.Test.Core.Helpers
{
    public static class HelperService
    {
        public static DateTime? ParseNullableDate(string value)
        {
            return !IsNull(value) ? ParseDate(value) : (DateTime?)null;
        }

        public static DateTime ParseDate(string value)
        {
            return DateTime.Parse(value, new CultureInfo("en-US"), DateTimeStyles.None);
        }

        public static decimal? ParseNullableDecimal(string value)
        {
            return !IsNull(value) ? decimal.Parse(value) : (decimal?)null;
        }

        public static long? ParseNullableLong(string value)
        {
            return !IsNull(value) ? long.Parse(value) : (long?)null;
        }

        public static bool AreEqual(string s1, string s2, bool ignoreCase = true)
        {
            return ignoreCase
                ? string.Equals(s1, s2, StringComparison.CurrentCultureIgnoreCase)
                : string.Equals(s1, s2, StringComparison.CurrentCulture);
        }

        public static bool IsNull(string value)
        {
            return string.IsNullOrWhiteSpace(value) ||
                string.Equals(value, "NULL", StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsTrue(string value)
        {
            return string.Equals(value, "TRUE", StringComparison.CurrentCultureIgnoreCase);
        }

        public static T ParseEnum<T>(string value) where T : struct
        {
            return (T) Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        public static bool ParseBool(string value)
        {
            return bool.Parse(value);
        }

        public static List<string> GetCommaSeparatedValues(string value)
        {
            return value.Split(',').Select(s => s.Trim()).ToList();
        }

        public static decimal? Round(decimal? value)
        {
            return value.HasValue
                ? Math.Round(value.Value)
                : (decimal?)null;
        }

        public static string GetStringOrDefault(string value)
        {
            return IsNull(value) ? null : value;
        }
    }
}
