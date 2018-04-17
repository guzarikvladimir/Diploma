using AutoMapper;
using CP.Platform.Mappers.Contract;

namespace CP.Platform.Mappers.Services
{
    public class SimpleEntityMapper<TFrom, TTo> : IEntityMapper<TFrom, TTo>
    {
        public TTo Map(TFrom model)
        {
            return Mapper.Map<TFrom, TTo>(model);
        }
    }
}