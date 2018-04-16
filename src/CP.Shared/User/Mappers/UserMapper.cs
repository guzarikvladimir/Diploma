using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.User.Models;

namespace CP.Shared.User.Mappers
{
    public class UserMapper : IEntityMapper<Repository.Models.User, UserView>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.User, UserView>();
        }

        public UserView Map(Repository.Models.User model)
        {
            return Mapper.Map<UserView>(model);
        }
    }
}