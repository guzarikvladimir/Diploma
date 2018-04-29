using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunctionPosition.Models;
using JobFunctionPositionEntity = CP.Repository.Models.JobFunctionPosition;

namespace CP.Shared.JobFunctionPosition.Mappers
{
    public class JobFunctionPositionMapper : IEntityMapper<JobFunctionPositionEntity, JobFunctionPositionView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<JobFunctionPositionEntity, JobFunctionPositionView>();
        }

        public JobFunctionPositionView Map(JobFunctionPositionEntity model)
        {
            return Mapper.Map<JobFunctionPositionView>(model);
        }
    }
}