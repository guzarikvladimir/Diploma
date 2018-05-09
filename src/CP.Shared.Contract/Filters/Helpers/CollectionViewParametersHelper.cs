using System;

namespace CP.Shared.Contract.Filters.Helpers
{
    public static class CollectionViewParametersHelper
    {
        public static int ToDefaultYear(this int? year)
        {
            return year ?? DateTime.Now.Year;
        }

        public static int ToDefaultPage(this int? page)
        {
            return page ?? 1;
        }
    }
}