using CP.Platform.Crud.Services;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using JobFunctionPositionEntity = CP.Repository.Models.JobFunctionPosition;

namespace CP.Shared.JobFunctionPosition.Services
{
    public class JobFunctionPositionModifyingService :
        SimpleModifyingService<JobFunctionPositionEntity, JobFunctionPositionModel, JobFunctionPositionView>,
        IJobFunctionPositionModifyingService
    {
    }
}