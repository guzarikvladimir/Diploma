using System;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionTitile.Models;

namespace CP.Shared.Contract.JobFunction.Models
{
    public class JobFunctionView
    {
        public Guid Id { get; set; }

        public JobFunctionTitleView JobFunctionTitle { get; set; }

        public JobFunctionPositionView JobFunctionPosition { get; set; }
    }
}