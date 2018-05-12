namespace CP.Platform.Crud.Models
{
    public interface IEntityView<TId>
    {
        TId Id { get; set; }
    }
}