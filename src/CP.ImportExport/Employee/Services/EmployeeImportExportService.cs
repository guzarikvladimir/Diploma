using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.Employee.Contract;
using CP.ImportExport.Employee.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Contract.Location.Services;
using Ninject;

namespace CP.ImportExport.Employee.Services
{
    public class EmployeeImportExportService :
        ImportExportServiceBase<EmployeeImportExportModel, EmployeeModel, EmployeeView>,
        IEmployeeImportExportService
    {
        #region Injects

        [Inject]
        IEmployeeStatusRetrievingService EmployeeStatusRetrievingService { get; set; }

        [Inject]
        ILocationRetrievingService LocationRetrievingService { get; set; }

        [Inject]
        IJobFunctionRetrievingService JobFunctionRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "Employees";
        }

        public override IEnumerable<EmployeeModel> Parse(List<EmployeeImportExportModel> importModels)
        {
            foreach (EmployeeImportExportModel model in importModels)
            {
                yield return new EmployeeModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    Name = model.Name,
                    Email = model.Email,
                    StatusId = EmployeeStatusRetrievingService.Get().First(s => s.Name == model.Status).Id,
                    LocationId = LocationRetrievingService.Get()
                        .First(l => l.Country.Name == model.Country && l.Name == model.Location).Id,
                    JobFunctionId = JobFunctionRetrievingService.Get()
                        .First(jf => jf.Position.Name == model.Position && jf.Title.Name == model.Title).Id
                };
            }
        }

        public override IEnumerable<EmployeeImportExportModel> GetExportModels()
        {
            IEnumerable<EmployeeView> models = SimpleRetrievingService.Get();
            foreach (EmployeeView model in models)
            {
                yield return new EmployeeImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Name = model.Name,
                    Email = model.Email,
                    Status = model.EmployeeStatus.Name,
                    Location = model.Location.Name,
                    Country = model.Location.Country.Name,
                    Title = model.JobFunction.Title.Name,
                    Position = model.JobFunction.Position.Name
                };
            }
        }
    }
}