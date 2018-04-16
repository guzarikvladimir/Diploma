using System;
using System.Collections.Generic;
using CP.Platform.DependencyResolvers.Contract;
using Ninject;

namespace CP.Platform.DependencyResolvers.Services
{
    public class ServiceAccessor : IServiceAccessor
    {
        private readonly IKernel kernel;

        public ServiceAccessor(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type service)
        {
            return kernel.Get(service);
        }

        public T GetService<T>()
        {
            return kernel.Get<T>();
        }

        public IEnumerable<object> GetServices(Type service)
        {
            return kernel.GetAll(service);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return kernel.GetAll<T>();
        }
    }
}