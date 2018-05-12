using System;
using CP.Platform.Crud.Models;
using CP.Shared.Contract.EmployeeStatus.Models;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.Location.Models;

namespace CP.Shared.Contract.Employee.Models
{
    public class EmployeeView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public EmployeeStatusView EmployeeStatus { get; set; }

        public LocationView Location { get; set; }

        public JobFunctionView JobFunction { get; set; }
    }
}