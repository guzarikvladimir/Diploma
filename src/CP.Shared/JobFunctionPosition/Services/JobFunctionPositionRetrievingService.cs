using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.Core.Services;
using JobFunctionPositionEntity = CP.Repository.Models.JobFunctionPosition;

namespace CP.Shared.JobFunctionPosition.Services
{
    public class JobFunctionPositionRetrievingService : 
        SimpleRetrievingService<JobFunctionPositionEntity, JobFunctionPositionView>,
        IJobFunctionPositionRetrievingService
    {
    }
}