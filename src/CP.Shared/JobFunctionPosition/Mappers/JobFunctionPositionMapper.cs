using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunctionPosition.Models;
using JobFunctionPositionEntity = CP.Repository.Models.JobFunctionPosition;

namespace CP.Shared.JobFunctionPosition.Mappers
{
    public class JobFunctionPositionMapper :
        IEntityMapper<JobFunctionPositionEntity, JobFunctionPositionView>,
        IEntityModifyingMapper<JobFunctionPositionModel, JobFunctionPositionEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<JobFunctionPositionEntity, JobFunctionPositionView>();
            config.CreateMap<JobFunctionPositionModel, JobFunctionPositionEntity>();
        }

        public JobFunctionPositionView Map(JobFunctionPositionEntity model)
        {
            return Mapper.Map<JobFunctionPositionView>(model);
        }

        public void Map(JobFunctionPositionModel viewModel, JobFunctionPositionEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public JobFunctionPositionEntity Map(JobFunctionPositionModel viewModel)
        {
            return Mapper.Map<JobFunctionPositionEntity>(viewModel);
        }
    }
}