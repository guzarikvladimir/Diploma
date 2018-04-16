using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Models;

namespace CP.Shared.Employee.Mappers
{
    public class EmployeeMapper : IEntityMapper<Repository.Models.Employee, EmployeeView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.Employee, EmployeeView>();
        }

        public EmployeeView Map(Repository.Models.Employee model)
        {
            return Mapper.Map<EmployeeView>(model);
        }
    }
}