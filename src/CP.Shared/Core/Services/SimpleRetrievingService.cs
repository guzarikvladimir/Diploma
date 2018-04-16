using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Db.Contract;
using CP.Platform.Mappers.Contract;
using CP.Repository.Contract;
using CP.Repository.Services;
using CP.Shared.Contract.Core.Services;
using Ninject;

namespace CP.Shared.Core.Services
{
    public class SimpleRetrievingService<TEntity, TView> : 
        ISimpleRetrievingService<TView>
        where TEntity : class, IEntityWithId<Guid>
        where TView : class
    {
        #region Injects

        [Inject]
        protected IEntityMapper<TEntity, TView> Mapper { get; set; }

        [Inject]
        protected IDbFactory DbFactory { get; set; }

        #endregion

        public IEnumerable<TView> Get()
        {
            List<TEntity> models;
            using (var scope = new ApplicationContext())
            {
                models = scope.Set<TEntity>().ToList();
            }

            return models.Select(e => Mapper.Map(e));
        }

        public TView GetById(Guid id)
        {
            TEntity model;
            using (var scope = DbFactory.Create())
            {
                model = scope.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            }

            return Mapper.Map(model);
        }
    }
}