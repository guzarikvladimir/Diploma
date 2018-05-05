using System;
using System.Linq;
using CP.Platform.Db.Contract;
using CP.Platform.Mappers.Contract;
using CP.Repository.Contract;
using CP.Shared.Contract.Core.Models;
using CP.Shared.Contract.Core.Services;
using Ninject;

namespace CP.Shared.Core.Services
{
    public class SimpleModifyingService<TEntity, TModel> : ISimpleModifyingService<TModel>
        where TModel : class, IModelWithId<Guid?>
        where TEntity : class, IEntityWithId<Guid>
    {
        #region Injects

        [Inject]
        protected IEntityModifyingMapper<TModel, TEntity> ModifyingMapper { get; set; }

        [Inject]
        protected IDbFactory DbFactory { get; set; }

        #endregion

        public void Add(TModel model)
        {
            if (!model.Id.HasValue)
            {
                model.Id = Guid.NewGuid();
            }

            TEntity entity = ModifyingMapper.Map(model);
            using (var scope = DbFactory.Create())
            {
                scope.Set<TEntity>().Add(entity);

                scope.SaveChanges();
            }
        }

        public void Update(TModel model)
        {
            using (var scope = DbFactory.Create())
            {
                TEntity entity = scope.Set<TEntity>().Single(e => e.Id == model.Id);
                ModifyingMapper.Map(model, entity);

                scope.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var scope = DbFactory.Create())
            {
                TEntity entity = scope.Set<TEntity>().Single(e => e.Id == id);
                scope.Set<TEntity>().Remove(entity);

                scope.SaveChanges();
            }
        }
    }
}