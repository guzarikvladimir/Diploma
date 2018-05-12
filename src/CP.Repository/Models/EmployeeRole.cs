using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class EmployeeRole : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid RoleId { get; set; }
    }
}