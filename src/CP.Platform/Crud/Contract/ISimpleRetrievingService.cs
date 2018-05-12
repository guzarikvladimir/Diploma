using System;
using System.Collections.Generic;

namespace CP.Platform.Crud.Contract
{
    public interface ISimpleRetrievingService<out TView>
        where TView : class
    {
        IEnumerable<TView> Get();

        TView GetById(Guid id);
    }
}