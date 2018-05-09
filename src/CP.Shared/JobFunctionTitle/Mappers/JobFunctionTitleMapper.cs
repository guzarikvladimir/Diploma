using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.JobFunctionTitile.Models;
using JobFunctionTitleEntity = CP.Repository.Models.JobFunctionTitle;

namespace CP.Shared.JobFunctionTitle.Mappers
{
    public class JobFunctionTitleMapper : 
        IEntityMapper<JobFunctionTitleEntity, JobFunctionTitleView>,
        IEntityModifyingMapper<JobFunctionTitleModel, JobFunctionTitleEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<JobFunctionTitleEntity, JobFunctionTitleView>();
            config.CreateMap<JobFunctionTitleModel, JobFunctionTitleEntity>();
        }

        public JobFunctionTitleView Map(JobFunctionTitleEntity model)
        {
            return Mapper.Map<JobFunctionTitleView>(model);
        }

        public void Map(JobFunctionTitleModel viewModel, JobFunctionTitleEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public JobFunctionTitleEntity Map(JobFunctionTitleModel viewModel)
        {
            return Mapper.Map<JobFunctionTitleEntity>(viewModel);
        }
    }
}