using AutoMapper;
using CP.Authorization.Contract.Models;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.User.Models;

namespace CP.Authorization.Mappers
{
    public class AuthorizationMapper : IEntityMapper<RegisterView, UserModel>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<RegisterView, UserModel>();
        }

        public UserModel Map(RegisterView model)
        {
            return Mapper.Map<UserModel>(model);
        }
    }
}