using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Country.Models
{
    public class CountryModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}