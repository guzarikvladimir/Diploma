using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Currency.Services;
using CP.Shared.Contract.LegalEntity.Models;
using Ninject;
using LegalEntityEntity = CP.Repository.Models.LegalEntity;

namespace CP.Shared.LegalEntity.Mappers
{
    public class LegalEntityMapper :
        IEntityMapper<LegalEntityEntity, LegalEntityView>,
        IEntityModifyingMapper<LegalEnityModel, LegalEntityEntity>
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<LegalEntityEntity, LegalEntityView>();
            config.CreateMap<LegalEnityModel, LegalEntityEntity>();
        }

        public LegalEntityView Map(LegalEntityEntity model)
        {
            LegalEntityView view = Mapper.Map<LegalEntityView>(model);
            view.Currency = CurrencyRetrievingService.GetById(model.CurrencyId);

            return view;
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