using System;
using CP.Platform.Crud.Models;

namespace CP.Platform.Crud.Contract
{
    public interface ISimpleModifyingService<in TModel>
        where TModel : class, IEntityModel<Guid?>
    {
        void AddOrUpdate(TModel model);

        //void Update(TModel model);
    }
}