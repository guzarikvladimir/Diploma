using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Currency.Models
{
    public class CurrencyModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}