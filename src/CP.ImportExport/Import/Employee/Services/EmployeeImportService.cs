using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.Employee.Contract;
using CP.ImportExport.Import.Employee.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeStatus.Services;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Contract.Location.Services;
using Ninject;

namespace CP.ImportExport.Import.Employee.Services
{
    public class EmployeeImportService :
        ImportServiceBase<EmployeeImportModel, EmployeeModel>,
        IEmployeeImportService
    {
        #region Injects

        [Inject]
        IEmployeeStatusRetrievingService EmployeeStatusRetrievingService { get; set; }

        [Inject]
        ILocationRetrievingService LocationRetrievingService { get; set; }

        [Inject]
        IJobFunctionRetrievingService JobFunctionRetrievingService { get; set; }

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "Employees";
        }

        public override IEnumerable<EmployeeModel> Parse(List<EmployeeImportModel> importModels)
        {
            foreach (EmployeeImportModel model in importModels)
            {
                yield return new EmployeeModel()
                {
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

        public override void AddOrUpdate(List<EmployeeModel> models)
        {
            foreach (EmployeeModel model in models)
            {
                var existingModel = EmployeeRetrievingService.Get().FirstOrDefault(e => e.Email == model.Email);
                if (existingModel != null)
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