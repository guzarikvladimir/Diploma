using AutoMapper;
using Ninject;

namespace CP.Platform.DependencyResolvers.Services
{
    public abstract class Module
    {
        public abstract void RegisterServices(IKernel kernel);

        public virtual void RegisterMappers(IMapperConfigurationExpression config)
        {
        }
    }
}