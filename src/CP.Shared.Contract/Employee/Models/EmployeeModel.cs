using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Employee.Models
{
    public class EmployeeModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Guid StatusId { get; set; }

        public Guid LocationId { get; set; }

        public Guid JobFunctionId { get; set; }
    }
}