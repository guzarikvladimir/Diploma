namespace CP.Shared.Contract.Core.Models
{
    public interface IViewWithId<TId>
    {
        TId Id { get; set; }
    }
}