using System;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class EmployeeLegalEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid LegalEntityId { get; set; }

        public bool IsPrimary { get; set; }
    }
}