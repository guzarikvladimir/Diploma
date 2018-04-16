using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.Role.Services;
using Ninject;

namespace CP.Shared.EmployeeRole.Mappers
{
    public class EmployeeRoleMapper : IEntityMapper<Repository.Models.EmployeeRole, EmployeeRoleView>
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IRoleRetrievingService RoleRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.EmployeeRole, EmployeeRoleView>();
        }

        public EmployeeRoleView Map(Repository.Models.EmployeeRole model)
        {
            EmployeeRoleView result = Mapper.Map<EmployeeRoleView>(model);
            result.Employee = EmployeeRetrievingService.GetById(model.EmployeeId);
            result.Role = RoleRetrievingService.GetById(model.RoleId);

            return result;
        }
    }
}