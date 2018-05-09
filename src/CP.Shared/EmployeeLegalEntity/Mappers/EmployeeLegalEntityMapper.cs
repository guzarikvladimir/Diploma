using AutoMapper;
using CP.Platform.Mappers.Contract;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;

namespace CP.Shared.EmployeeLegalEntity.Mappers
{
    public class EmployeeLegalEntityMapper :
        IEntityMapper<Repository.Models.EmployeeLegalEntity, EmployeeLegalEntityView>,
        IEntityModifyingMapper<EmployeeLegalEntityModel, Repository.Models.EmployeeLegalEntity>
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        #endregion

        public static void Register(IMapperConfigurationExpression config)
        {
            config.CreateMap<Repository.Models.EmployeeLegalEntity, EmployeeLegalEntityView>()
                .ForMember(dst => dst.Employee, cfg => cfg.AllowNull())
                .ForMember(dst => dst.LegalEntity, cfg => cfg.AllowNull());
            config.CreateMap<EmployeeLegalEntityModel, Repository.Models.EmployeeLegalEntity>();
        }

        public EmployeeLegalEntityView Map(Repository.Models.EmployeeLegalEntity model)
        {
            EmployeeLegalEntityView view = new EmployeeLegalEntityView();
            view.Id = model.Id;
            view.IsPrimary = model.IsPrimary;
            view.Employee = EmployeeRetrievingService.GetById(model.EmployeeId);
            view.LegalEntity = LegalEntityRetrievingService.GetById(model.LegalEntityId);

            return view;
        }

        public void Map(EmployeeLegalEntityModel viewModel, Repository.Models.EmployeeLegalEntity entityModel)
        {
            Mapper.Map(viewModel, entityModel);
        }

        public Repository.Models.EmployeeLegalEntity Map(EmployeeLegalEntityModel viewModel)
        {
            return Mapper.Map<Repository.Models.EmployeeLegalEntity>(viewModel);
        }
    }
}