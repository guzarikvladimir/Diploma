using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.JobFunctionPosition.Models
{
    public class JobFunctionPositionView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}