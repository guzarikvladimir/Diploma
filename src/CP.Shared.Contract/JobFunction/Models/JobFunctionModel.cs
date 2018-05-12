using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.JobFunction.Models
{
    public class JobFunctionModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid TitleId { get; set; }

        public Guid PositionId { get; set; }
    }
}