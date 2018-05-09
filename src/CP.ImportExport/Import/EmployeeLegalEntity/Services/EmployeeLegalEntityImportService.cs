using System;
using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.EmployeeLegalEntity.Contract;
using CP.ImportExport.Import.EmployeeLegalEntity.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;

namespace CP.ImportExport.Import.EmployeeLegalEntity.Services
{
    public class EmployeeLegalEntityImportService :
        ImportServiceBase<EmployeeLegalEntityImportModel, EmployeeLegalEntityModel>,
        IEmployeeLegalEntityImportService
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        [Inject]
        IEmployeeLegalEntityRetrievingService EmployeeLegalEntityRetrievingService { get; set; }

        #endregion

        public override IEnumerable<EmployeeLegalEntityModel> Parse(List<EmployeeLegalEntityImportModel> importModels)
        {
            foreach (EmployeeLegalEntityImportModel model in importModels)
            {
                yield return new EmployeeLegalEntityModel()
                {
                    EmployeeId = EmployeeRetrievingService.Get().First(e => e.Email == model.Employee).Id,
                    LegalEntityId = LegalEntityRetrievingService.Get().First(le => le.Name == model.LegalEntity).Id,
                    IsPrimary = bool.Parse(model.IsPrimary)
                };
            }
        }

        public override void AddOrUpdate(List<EmployeeLegalEntityModel> models)
        {
            foreach (EmployeeLegalEntityModel model in models)
            {
                var existingModel = EmployeeLegalEntityRetrievingService.Get()
                    .FirstOrDefault(ele => ele.Employee.Id == model.EmployeeId 
                                           && ele.LegalEntity.Id == model.LegalEntityId);
                if (existingModel != null && existingModel.IsPrimary != model.IsPrimary)
                {
                    model.Id = existingModel.Id;
                    SimpleModifyingService.Update(model);

                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}