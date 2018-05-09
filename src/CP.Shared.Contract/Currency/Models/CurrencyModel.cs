using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Currency.Models
{
    public class CurrencyModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}