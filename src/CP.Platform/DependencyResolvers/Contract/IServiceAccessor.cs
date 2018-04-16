using System;
using System.Collections.Generic;

namespace CP.Platform.DependencyResolvers.Contract
{
    public interface IServiceAccessor
    {
        object GetService(Type service);

        T GetService<T>();

        IEnumerable<object> GetServices(Type service);

        IEnumerable<T> GetServices<T>();
    }
}