using System;
using System.Web;
using System.Web.Mvc;
using CP.Platform.DependencyResolvers.Services;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using WebApi;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace WebApi
{
    public static class NinjectWebCommon
    {
        public static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
        }
    }
}
