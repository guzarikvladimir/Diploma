using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.EmployeeRole.Models
{
    public class EmployeeRoleModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid RoleId { get; set; }
    }
}