using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.EmployeeStatus.Models;
using EmployeeStatusEntity = CP.Repository.Models.EmployeeStatus;

namespace CP.Shared.EmployeeStatus.Mappers
{
    public class EmployeeStatusMapper : 
        IEntityMapper<EmployeeStatusEntity, EmployeeStatusView>,
        IEntityModifyingMapper<EmployeeStatusModel, EmployeeStatusEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<EmployeeStatusEntity, EmployeeStatusView>();
            config.CreateMap<EmployeeStatusModel, EmployeeStatusEntity>();
        }

        public EmployeeStatusView Map(EmployeeStatusEntity model)
        {
            return Mapper.Map<EmployeeStatusView>(model);
        }

        public void Map(EmployeeStatusModel viewModel, EmployeeStatusEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public EmployeeStatusEntity Map(EmployeeStatusModel viewModel)
        {
            return Mapper.Map<EmployeeStatusEntity>(viewModel);
        }
    }
}