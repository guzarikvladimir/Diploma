using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;

namespace CP.Platform.Crud.Services
{
    public class MemoryStorage<TView> : IMemoryStorage<TView>
        where TView : class, IEntityView<Guid>
    {
        private readonly List<TView> entities = new List<TView>();

        public bool Updated { get; set; }

        public MemoryStorage()
        {
            Updated = false;
        }

        public List<TView> Get()
        {
            return entities;
        }

        public void AddOrUpdate(TView entity)
        {
            TView oldEntity = entities.FirstOrDefault(e => e.Id == entity.Id);
            if (oldEntity != null)
            {
                entities.Remove(oldEntity);
            }

            entities.Add(entity);
        }
    }
}