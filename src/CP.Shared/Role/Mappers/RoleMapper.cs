using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Role.Models;

namespace CP.Shared.Role.Mappers
{
    public class RoleMapper : IEntityMapper<Repository.Models.Role, RoleView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.Role, RoleView>();
        }

        public RoleView Map(Repository.Models.Role model)
        {
            return Mapper.Map<RoleView>(model);
        }
    }
}