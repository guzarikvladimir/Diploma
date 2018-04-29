using System;
using CP.Shared.Contract.Country.Models;

namespace CP.Shared.Contract.Location.Models
{
    public class LocationView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CountryView Country { get; set; }
    }
}