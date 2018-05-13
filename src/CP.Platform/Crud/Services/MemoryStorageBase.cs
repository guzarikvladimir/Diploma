using System;
using System.Collections.Generic;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;
using CP.Platform.Db.Contract;
using Ninject;

namespace CP.Platform.Crud.Services
{
    public abstract class MemoryStorageBase<TView>
        where TView : class, IEntityView<Guid>
    {
        #region Injects

        [Inject]
        protected IMemoryStorage<TView> MemoryStorage { get; set; }

        [Inject]
        protected IDbContextScopeFactory DbContextScopeFactory { get; set; }

        #endregion

        public virtual List<TView> GetInternal()
        {
            return MemoryStorage.Get();
        }

        public virtual void AddOrUpdateInternal(TView entity)
        {
            MemoryStorage.AddOrUpdate(entity);
        }
    }
}
