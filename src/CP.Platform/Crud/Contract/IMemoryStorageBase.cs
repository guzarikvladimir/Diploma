using System.Collections.Generic;

namespace CP.Platform.Crud.Contract
{
    public interface IMemoryStorageBase<TView>
    {
        List<TView> GetInternal();

        void AddInternal(TView entity);

        void UpdateInternal(TView entity);

        bool Updated { get; set; }
    }
}