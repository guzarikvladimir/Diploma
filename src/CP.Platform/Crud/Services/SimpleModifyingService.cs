using System;
using System.Data.Entity.Migrations;
using System.Linq;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;
using CP.Platform.Db.Contract;
using CP.Platform.Mappers.Contract;
using CP.Repository.Contract;
using Ninject;

namespace CP.Platform.Crud.Services
{
    public class SimpleModifyingService<TEntity, TModel, TView> : 
        MemoryStorageBase<TView>,
        ISimpleModifyingService<TModel>
        where TModel : class, IEntityModel<Guid?>
        where TEntity : class, IEntity<Guid>
        where TView : class, IEntityView<Guid>
    {
        #region Injects

        [Inject]
        protected IEntityModifyingMapper<TModel, TEntity> ModifyingMapper { get; set; }

        [Inject]
        protected IEntityMapper<TEntity, TView> Mapper { get; set; }

        #endregion

        public void AddOrUpdate(TModel model)
        {
            if (!model.Id.HasValue)
            {
                model.Id = Guid.NewGuid();
            }

            TEntity entity = ModifyingMapper.Map(model);
            AddOrUpdateInternal(Mapper.Map(entity));
            using (var scope = DbContextScopeFactory.Create())
            {
                scope.Set<TEntity>().AddOrUpdate(entity);

                scope.SaveChanges();
            }
        }

        //public void Update(TModel model)
        //{
        //    using (var scope = DbContextScopeFactory.Create())
        //    {
        //        TEntity entity = scope.Set<TEntity>().Single(e => e.Id == model.Id);
        //        ModifyingMapper.Map(model, entity);
        //        AddOrUpdateInternal(Mapper.Map(entity));

        //        scope.SaveChanges();
        //    }
        //}
    }
}