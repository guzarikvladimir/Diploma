namespace CP.Shared.Contract.Core.Models
{
    public interface IEntityView<TId>
    {
        TId Id { get; set; }
    }
}