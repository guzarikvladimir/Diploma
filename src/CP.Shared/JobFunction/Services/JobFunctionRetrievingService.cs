using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Core.Services;
using JobFunctionEntity = CP.Repository.Models.JobFunction;

namespace CP.Shared.JobFunction.Services
{
    public class JobFunctionRetrievingService :
        SimpleRetrievingService<JobFunctionEntity, JobFunctionView>,
        IJobFunctionRetrievingService
    {
    }
}