using System;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Role.Models;

namespace CP.Shared.Contract.EmployeeRole.Models
{
    public class EmployeeRoleView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public EmployeeView Employee { get; set; }

        public RoleView Role { get; set; }
    }
}