using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Country.Models
{
    public class CountryModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}