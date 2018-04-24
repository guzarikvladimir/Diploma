using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CP.Platform.DependencyResolvers.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using WebApi;
using Module = CP.Platform.DependencyResolvers.Services.Module;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace WebApi
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings() { InjectNonPublic = true, AllowNullInjection = true };
            var kernel = new StandardKernel(settings);
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

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
