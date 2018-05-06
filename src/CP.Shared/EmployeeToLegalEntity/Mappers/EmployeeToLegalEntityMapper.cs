using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;
using EmployeeToLegalEntityEntity = CP.Repository.Models.EmployeeToLegalEntity;

namespace CP.Shared.EmployeeToLegalEntity.Mappers
{
    public class EmployeeToLegalEntityMapper :
        IEntityMapper<EmployeeToLegalEntityEntity, EmployeeToLegalEntityView>,
        IEntityModifyingMapper<EmployeeToLegalEntityModel, EmployeeToLegalEntityEntity>
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<EmployeeToLegalEntityEntity, EmployeeToLegalEntityView>()
                .ForMember(dst => dst.Employee, cfg => cfg.AllowNull())
                .ForMember(dst => dst.LegalEntity, cfg => cfg.AllowNull());
            config.CreateMap<EmployeeToLegalEntityModel, EmployeeToLegalEntityEntity>();
        }

        public EmployeeToLegalEntityView Map(EmployeeToLegalEntityEntity model)
        {
            //EmployeeToLegalEntityView view = Mapper.Map<EmployeeToLegalEntityView>(model);
            EmployeeToLegalEntityView view = new EmployeeToLegalEntityView();
            view.Id = model.Id;
            view.IsPrimary = model.IsPrimary;
            view.Employee = EmployeeRetrievingService.GetById(model.EmployeeId);
            view.LegalEntity = LegalEntityRetrievingService.GetById(model.LegalEntityId);

            return view;
        }

        public void Map(EmployeeToLegalEntityModel viewModel, EmployeeToLegalEntityEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public EmployeeToLegalEntityEntity Map(EmployeeToLegalEntityModel viewModel)
        {
            return Mapper.Map<EmployeeToLegalEntityEntity>(viewModel);
        }
    }
}