using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.JobFunctionTitile.Models
{
    public class JobFunctionTitleView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}