using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Password { get; set; }
    }
}