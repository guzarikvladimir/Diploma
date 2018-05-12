using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.EmployeeStatus.Contract;
using CP.ImportExport.Import.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using Ninject;

namespace CP.ImportExport.Import.EmployeeStatus.Services
{
    public class EmployeeStatusImportService :
        ImportServiceBase<EmployeeStatusImportModel, EmployeeStatusModel>,
        IEmployeeStatusImportService
    {
        [Inject]
        IEmployeeStatusRetrievingService EmployeeStatusRetrievingService { get; set; }

        public override string GetTemplateName()
        {
            return "EmployeeStatuses";
        }

        public override IEnumerable<EmployeeStatusModel> Parse(List<EmployeeStatusImportModel> importModels)
        {
            foreach (EmployeeStatusImportModel model in importModels)
            {
                yield return new EmployeeStatusModel()
                {
                    Name = model.Name
                };
            }
        }

        public override void AddOrUpdate(List<EmployeeStatusModel> models)
        {
            foreach (EmployeeStatusModel model in models)
            {
                var existingModel = EmployeeStatusRetrievingService.Get()
                    .FirstOrDefault(s => s.Name == model.Name);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}