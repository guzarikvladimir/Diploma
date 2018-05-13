using System.Collections.Generic;

namespace CP.Platform.Crud.Contract
{
    public interface IMemoryStorage<TView>
    {
        bool Updated { get; set; }

        List<TView> Get();

        void AddOrUpdate(TView entity);
    }
}