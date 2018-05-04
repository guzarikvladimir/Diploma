using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.EmployeeToLegalEntity.Models
{
    public class EmployeeToLegalEntityModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid LegalEntityId { get; set; }

        public bool IsPrimary { get; set; }
    }
}