using System;
using System.Collections.Generic;

namespace CP.Shared.Contract.Core.Services
{
    public interface ISimpleRetrievingService<out TView>
        where TView : class
    {
        IEnumerable<TView> Get();

        TView GetById(Guid id);
    }
}