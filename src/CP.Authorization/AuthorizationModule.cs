using AutoMapper;
using CP.Authorization.Contract.Models;
using CP.Authorization.Contract.Services;
using CP.Authorization.Mappers;
using CP.Authorization.Services;
using CP.Platform.DependencyResolvers.Services;
using CP.Platform.Mappers.Contract;
using CP.Platform.Mappers.Services;
using CP.Shared.Contract.User.Models;
using Ninject;
using Ninject.Web.Common;

namespace CP.Authorization
{
    public class AuthorizationModule : Module
    {
        public override void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            kernel.Bind<IEntityMapper<RegisterView, UserModel>>()
                .To<AuthorizationMapper>()
                .InRequestScope();
        }

        public override void RegisterMappers(IMapperConfigurationExpression config)
        {
            AuthorizationMapper.Register(config);
        }
    }
}