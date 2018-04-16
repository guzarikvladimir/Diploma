using AutoMapper;
using CP.Platform.Mappers.Contract;

namespace CP.Platform.Mappers.Services
{
    public class SimpleEntityMapper<TFrom, TTo> : IEntityMapper<TFrom, TTo>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<TFrom, TTo>();
        }

        public TTo Map(TFrom model)
        {
            return Mapper.Map<TTo>(model);
        }
    }
}