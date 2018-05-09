using System;
using CP.Repository.Contract;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.JobFunctionPosition.Models
{
    public class JobFunctionPositionModel : IModelWithId<Guid?>
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }
}