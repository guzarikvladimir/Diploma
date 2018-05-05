using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Core.Services
{
    public interface ISimpleModifyingService<in TModel>
        where TModel : class, IModelWithId<Guid?>
    {
        void Add(TModel model);

        void Update(TModel model);

        void Delete(Guid id);
    }
}