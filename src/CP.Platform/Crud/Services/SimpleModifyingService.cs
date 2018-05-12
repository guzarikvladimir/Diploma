using System;
using System.Linq;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;
using CP.Platform.Db.Contract;
using CP.Platform.Mappers.Contract;
using CP.Repository.Contract;
using Ninject;

namespace CP.Platform.Crud.Services
{
    public class SimpleModifyingService<TEntity, TModel> : ISimpleModifyingService<TModel>
        where TModel : class, IEntityModel<Guid?>
        where TEntity : class, IEntity<Guid>
    {
        #region Injects

        [Inject]
        protected IEntityModifyingMapper<TModel, TEntity> ModifyingMapper { get; set; }

        [Inject]
        protected IDbContextScopeFactory DbContextScopeFactory { get; set; }

        #endregion

        public void Add(TModel model)
        {
            if (!model.Id.HasValue)
            {
                model.Id = Guid.NewGuid();
            }

            TEntity entity = ModifyingMapper.Map(model);
            using (var scope = DbContextScopeFactory.Create())
            {
                scope.Set<TEntity>().Add(entity);

                scope.SaveChanges();
            }
        }

        public void Update(TModel model)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                TEntity entity = scope.Set<TEntity>().Single(e => e.Id == model.Id);
                ModifyingMapper.Map(model, entity);

                scope.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                TEntity entity = scope.Set<TEntity>().Single(e => e.Id == id);
                scope.Set<TEntity>().Remove(entity);

                scope.SaveChanges();
            }
        }
    }
}