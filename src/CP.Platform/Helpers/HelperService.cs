using System;
using System.Globalization;

namespace CP.Platform.Helpers
{
    public static class HelperService
    {
        public static DateTime ParseDate(string value)
        {
            return DateTime.Parse(value, new CultureInfo("en-US"), DateTimeStyles.None);
        }

        public static T ParseEnum<T>(string value) where T : struct
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }
    }
}