using System;
using System.ComponentModel.DataAnnotations.Schema;
using CP.Repository.Contract;

namespace CP.Repository.Models
{
    public class Employee : IEntityWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("EmployeeStatus")]
        public Guid StatusId { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }

        public Guid LocationId { get; set; }

        public Guid JobFunctionId { get; set; }
    }
}