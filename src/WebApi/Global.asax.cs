using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;
using AutoMapper;
using CP.Platform.Crud.Services;
using Ninject;
using Module = CP.Platform.DependencyResolvers.Services.Module;

namespace WebApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            IKernel kernel = NinjectWebCommon.Bootstrapper.Kernel;
            RegisterServices(kernel);
            //WarmUp(kernel);

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBoundles(BundleTable.Bundles);
        }

        void RegisterServices(IKernel kernel)
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

        void WarmUp(IKernel kernel)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("CP"));
            foreach (Assembly assembly in assemblies)
            {
                IEnumerable<Type> types = assembly.GetTypes()
                    .Where(t => !t.IsInterface && t.IsSubclassOf(typeof(SimpleRetrievingService<,>)));
                foreach (Type type in types)
                {
                    var service = kernel.Get(type);
                    MethodInfo methodInfo = type.GetMethod("Get");
                    methodInfo.Invoke(service, null);
                }
            }
        }
    }
}