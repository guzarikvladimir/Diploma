using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.EmployeeStatus.Models;
using EmployeeStatusEntity = CP.Repository.Models.EmployeeStatus;

namespace CP.Shared.EmployeeStatus.Mappers
{
    public class EmployeeStatusMapper : IEntityMapper<EmployeeStatusEntity, EmployeeStatusView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<EmployeeStatusEntity, EmployeeStatusView>();
        }

        public EmployeeStatusView Map(EmployeeStatusEntity model)
        {
            return Mapper.Map<EmployeeStatusView>(model);
        }
    }
}