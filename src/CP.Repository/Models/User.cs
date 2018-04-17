using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class User : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Password { get; set; }
    }
}