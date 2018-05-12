namespace CP.Repository.Contract
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}