using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Role.Models
{
    public class RoleModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}