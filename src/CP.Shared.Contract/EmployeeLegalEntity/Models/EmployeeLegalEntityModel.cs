using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.EmployeeLegalEntity.Models
{
    public class EmployeeLegalEntityModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid LegalEntityId { get; set; }

        public bool IsPrimary { get; set; }
    }
}