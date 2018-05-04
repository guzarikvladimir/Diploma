using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.LegalEntity.Models;
using LegalEntityEntity = CP.Repository.Models.LegalEntity;

namespace CP.Shared.LegalEntity.Mappers
{
    public class LegalEntityMapper :
        IEntityMapper<LegalEntityEntity, LegalEntityView>,
        IEntityModifyingMapper<LegalEnityModel, LegalEntityEntity>
    {
        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<LegalEntityEntity, LegalEntityView>();
            config.CreateMap<LegalEnityModel, LegalEntityEntity>();
        }

        public LegalEntityView Map(LegalEntityEntity model)
        {
            return Mapper.Map<LegalEntityView>(model);
        }

        public void Map(LegalEnityModel viewModel, LegalEntityEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public LegalEntityEntity Map(LegalEnityModel viewModel)
        {
            return Mapper.Map<LegalEntityEntity>(viewModel);
        }
    }
}