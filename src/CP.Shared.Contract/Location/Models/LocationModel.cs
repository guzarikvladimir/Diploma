using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Location.Models
{
    public class LocationModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}