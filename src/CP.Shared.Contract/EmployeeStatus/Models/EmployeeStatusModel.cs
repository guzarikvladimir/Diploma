using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.EmployeeStatus.Models
{
    public class EmployeeStatusModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}