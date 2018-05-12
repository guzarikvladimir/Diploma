using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class Country : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}