using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.JobFunctionPosition.Models
{
    public class JobFunctionPositionView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}