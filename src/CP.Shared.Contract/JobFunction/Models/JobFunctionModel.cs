using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.JobFunction.Models
{
    public class JobFunctionModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public Guid TitleId { get; set; }

        public Guid PositionId { get; set; }
    }
}