using System;

namespace CP.Platform.Period.Helpers
{
    public static class PeriodExtensions
    {
        public static Models.Period ToPeriod(this DateTime dateTime)
        {
            return new Models.Period(dateTime.Year, dateTime.Month);
        }

        public static DateTime ToDateTime(this Models.Period period)
        {
            return new DateTime(period.Year, period.Month, 1);
        }
    }
}