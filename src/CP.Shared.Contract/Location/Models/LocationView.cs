using System;
using CP.Platform.Crud.Models;
using CP.Shared.Contract.Country.Models;

namespace CP.Shared.Contract.Location.Models
{
    public class LocationView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CountryView Country { get; set; }
    }
}