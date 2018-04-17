namespace CP.Platform.Mappers.Contract
{
    public interface IEntityModifyingMapper<in TModel, TEntity>
    {
        void Map(TModel viewModel, TEntity entityModel);

        TEntity Map(TModel viewModel);
    }
}