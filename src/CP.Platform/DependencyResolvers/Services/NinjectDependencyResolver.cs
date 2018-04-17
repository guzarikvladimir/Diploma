using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Ninject;

namespace CP.Platform.DependencyResolvers.Services
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            RegisterFromModules();
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

        private void RegisterFromModules()
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("CP"));
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                foreach (Assembly assembly in assemblies)
                {
                    IEnumerable<Type> modules = assembly.GetTypes()
                        .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Module)));
                    foreach (Type type in modules)
                    {
                        Module module = Activator.CreateInstance(type) as Module;
                        if (module != null)
                        {
                            module.RegisterServices(kernel);
                            module.RegisterMappers(cfg);
                        }
                    }
                }
            });
        }
    }
}