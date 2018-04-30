using System;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionTitile.Models;

namespace CP.Shared.Contract.JobFunction.Models
{
    public class JobFunctionView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public JobFunctionTitleView JobFunctionTitle { get; set; }

        public JobFunctionPositionView JobFunctionPosition { get; set; }
    }
}