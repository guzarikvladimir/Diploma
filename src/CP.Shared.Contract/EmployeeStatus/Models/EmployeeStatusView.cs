using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.EmployeeStatus.Models
{
    public class EmployeeStatusView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}