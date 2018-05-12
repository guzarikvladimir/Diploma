namespace CP.Platform.Crud.Models
{
    public interface IEntityModel<TId>
    {
        TId Id { get; set; }
    }
}