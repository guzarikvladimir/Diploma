using System;

namespace CP.Platform.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime ToUpperDate(this DateTime date)
        {
            DateTime newDate = new DateTime(date.Year, date.Month + 1, 1);

            return newDate.AddTicks(-1);
        }

        public static DateTime ToLowerDate(this DateTime date)
        {
            DateTime newDate = new DateTime(date.Year, date.Month, 1);

            return newDate;
        }
    }
}