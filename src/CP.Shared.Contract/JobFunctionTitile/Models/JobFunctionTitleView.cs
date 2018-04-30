using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.JobFunctionTitile.Models
{
    public class JobFunctionTitleView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}