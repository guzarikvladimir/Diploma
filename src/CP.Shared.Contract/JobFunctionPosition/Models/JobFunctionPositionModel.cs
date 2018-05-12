using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.JobFunctionPosition.Models
{
    public class JobFunctionPositionModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}