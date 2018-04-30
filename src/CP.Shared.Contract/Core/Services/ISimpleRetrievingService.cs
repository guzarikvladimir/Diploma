using System;
using System.Collections.Generic;

namespace CP.Shared.Contract.Core.Services
{
    public interface ISimpleRetrievingService<TView>
        where TView : class
    {
        List<TView> Get();

        TView GetById(Guid id);
    }
}