using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Country.Models
{
    public class CountryView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}