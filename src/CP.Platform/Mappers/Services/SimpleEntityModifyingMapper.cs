using AutoMapper;
using CP.Platform.Mappers.Contract;

namespace CP.Platform.Mappers.Services
{
    public class SimpleEntityModifyingMapper<TFrom, TTo> : IEntityModifyingMapper<TFrom, TTo>
    {
        public void Map(TFrom viewModel, TTo entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public TTo Map(TFrom viewModel)
        {
            return Mapper.Map<TTo>(viewModel);
        }
    }
}