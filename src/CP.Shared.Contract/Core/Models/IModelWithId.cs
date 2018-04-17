namespace CP.Shared.Contract.Core.Models
{
    public interface IModelWithId<TId>
    {
        TId Id { get; set; }
    }
}