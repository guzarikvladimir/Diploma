using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.Role.Models
{
    public class RoleModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}