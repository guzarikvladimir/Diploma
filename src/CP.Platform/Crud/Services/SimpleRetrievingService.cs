using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;
using CP.Platform.Mappers.Contract;
using CP.Repository.Contract;
using Ninject;

namespace CP.Platform.Crud.Services
{
    public abstract class SimpleRetrievingService<TEntity, TView> :
        MemoryStorageBase<TView>,
        ISimpleRetrievingService<TView>
        where TEntity : class, IEntity<Guid>
        where TView : class, IEntityView<Guid>
    {
        [Inject]
        protected IEntityMapper<TEntity, TView> Mapper { get; set; }

        public virtual IEnumerable<TView> Get()
        {
            if (MemoryStorage.Updated)
            {
                return GetInternal();
            }

            List<TEntity> models;
            using (var scope = DbContextScopeFactory.Create())
            {
                models = scope.Set<TEntity>().ToList();
            }

            foreach (TView view in models.Select(e => Mapper.Map(e)))
            {
                AddOrUpdateInternal(view);
            }

            MemoryStorage.Updated = true;

            return GetInternal();
        }

        public virtual TView GetById(Guid id)
        {
            return Get().FirstOrDefault(e => e.Id == id);
        }
    }
}