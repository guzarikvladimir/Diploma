using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Repository.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Salary.Models;
using Ninject;

namespace CP.Shared.Salary.Mappers
{
    public class SalaryPromotionMapper : 
        IEntityMapper<SalaryPromotion, SalaryPromotionView>,
        IEntityModifyingMapper<SalaryPromotionModel, SalaryPromotion>
    {
        [Inject]
        ICompensationPromotionRetrievingService CompensationPromotionRetrievingService { get; set; }

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<SalaryPromotionModel, SalaryPromotion>();
            config.CreateMap<SalaryPromotion, SalaryPromotionView>();
            config.CreateMap<CompensationPromotionView, SalaryPromotionView>();
        }

        public SalaryPromotionView Map(SalaryPromotion model)
        {
            CompensationPromotionView compensation = CompensationPromotionRetrievingService.GetById(model.Id);
            SalaryPromotionView salary = Mapper.Map<SalaryPromotionView>(compensation);

            return Mapper.Map(model, salary);
        }

        public void Map(SalaryPromotionModel viewModel, SalaryPromotion entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public SalaryPromotion Map(SalaryPromotionModel viewModel)
        {
            return Mapper.Map<SalaryPromotion>(viewModel);
        }
    }
}