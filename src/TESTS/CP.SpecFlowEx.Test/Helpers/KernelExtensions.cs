using System;
using System.Linq;
using CP.SpecFlowEx.Test.Models;
using Moq;
using Ninject;

namespace CP.SpecFlowEx.Test.Helpers
{
    public static class KernelExtensions
    {
        public static Mock<TInterface> Mock<TInterface>(this IBaseTestData data)
            where TInterface : class
        {
            return data.Kernel.Mock<TInterface>();
        }

        public static Mock<TInterface> Mock<TInterface>(this IKernel kernel)
            where TInterface : class
        {
            if (kernel.GetBindings(typeof(TInterface)).Any())
            {
                return kernel.Get<Mock<TInterface>>();
            }

            var mock = new Mock<TInterface>();
            kernel.Bind<TInterface>().ToConstant(mock.Object).InSingletonScope();
            kernel.Bind<Mock<TInterface>>().ToConstant(mock).InSingletonScope();

            return mock;
        }

        public static Mock<TBaseRealisation> Mock<TInterface, TBaseRealisation>(this IKernel kernel)
            where TInterface : class
            where TBaseRealisation : class, TInterface
        {
            if (kernel.GetBindings(typeof(Mock<TInterface>)).Any())
            {
                throw new Exception("There are already mock for interface");
            }

            if (kernel.GetBindings(typeof(TInterface)).Any())
            {
                return kernel.Get<Mock<TBaseRealisation>>();
            }

            var mock = new Mock<TBaseRealisation> { CallBase = true };
            kernel.Bind<TInterface>().ToConstant(mock.Object).InSingletonScope();
            kernel.Bind<Mock<TBaseRealisation>>().ToConstant(mock).InSingletonScope();

            return mock;
        }
    }
}
