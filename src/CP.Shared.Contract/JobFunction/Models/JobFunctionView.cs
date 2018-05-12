using System;
using CP.Platform.Crud.Models;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionTitile.Models;

namespace CP.Shared.Contract.JobFunction.Models
{
    public class JobFunctionView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public JobFunctionTitleView Title { get; set; }

        public JobFunctionPositionView Position { get; set; }
    }
}