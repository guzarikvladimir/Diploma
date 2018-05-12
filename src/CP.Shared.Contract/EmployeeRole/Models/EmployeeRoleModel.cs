using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.EmployeeRole.Models
{
    public class EmployeeRoleModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid RoleId { get; set; }
    }
}