using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class EmployeeRole : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid RoleId { get; set; }
    }
}