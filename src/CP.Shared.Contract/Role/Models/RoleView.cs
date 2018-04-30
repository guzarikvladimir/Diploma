using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Role.Models
{
    public class RoleView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}