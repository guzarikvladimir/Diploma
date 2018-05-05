using System;

namespace CP.Shared.Contract.Filters.Model
{
    public class CollectionViewParameters
    {
        public int? Page { get; set; }

        public int PageCount { get; set; }

        public int? Year { get; set; }

        public Guid? CurrencyId { get; set; }

        public CollectionViewParameters()
        {
            PageCount = 20;
        }
    }
}