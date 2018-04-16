namespace CP.Platform.Mappers.Contract
{
    public interface IEntityMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom model);
    }
}