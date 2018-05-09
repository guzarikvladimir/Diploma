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
        IEntityModifyingMapper<LegalEntityModel, LegalEntityEntity>
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<LegalEntityEntity, LegalEntityView>();
            config.CreateMap<LegalEntityModel, LegalEntityEntity>();
        }

        public LegalEntityView Map(LegalEntityEntity model)
        {
            LegalEntityView view = Mapper.Map<LegalEntityView>(model);
            view.Currency = CurrencyRetrievingService.GetById(model.CurrencyId);

            return view;
        }

        public void Map(LegalEntityModel viewModel, LegalEntityEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public LegalEntityEntity Map(LegalEntityModel viewModel)
        {
            return Mapper.Map<LegalEntityEntity>(viewModel);
        }
    }
}