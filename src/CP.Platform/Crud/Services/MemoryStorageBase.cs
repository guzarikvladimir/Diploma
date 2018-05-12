using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Crud.Contract;
using CP.Platform.Crud.Models;

namespace CP.Platform.Crud.Services
{
    public class MemoryStorageBase<TView> : IMemoryStorageBase<TView>
        where TView : class, IEntityView<Guid>
    {
        private readonly List<TView> entities = new List<TView>();

        public bool Updated { get; set; } = false;

        public List<TView> GetInternal()
        {
            return entities;
        }

        public void AddInternal(TView entity)
        {
            entities.Add(entity);
        }

        public void UpdateInternal(TView entity)
        {
            TView oldEntity = entities.First(e => e.Id == entity.Id);
            entities.Remove(oldEntity);
            entities.Add(entity);
        }
    }
}
