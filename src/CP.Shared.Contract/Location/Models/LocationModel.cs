using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Location.Models
{
    public class LocationModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }
    }
}