namespace CP.Repository.Contract
{
    public interface IEntityWithId<TId>
    {
        TId Id { get; set; }
    }
}