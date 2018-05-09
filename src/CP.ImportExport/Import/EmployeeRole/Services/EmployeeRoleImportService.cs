using System;
using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.EmployeeRole.Contract;
using CP.ImportExport.Import.EmployeeRole.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.EmployeeRole.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Services;
using Ninject;

namespace CP.ImportExport.Import.EmployeeRole.Services
{
    public class EmployeeRoleImportService :
        ImportServiceBase<EmployeeRoleImportModel, EmployeeRoleModel>,
        IEmployeeRoleImportService
    {
        #region Injects

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        [Inject]
        IRoleRetrievingService RoleRetrievingService { get; set; }

        [Inject]
        IEmployeeRoleRetrievingService EmployeeRoleRetrievingService { get; set; }

        #endregion

        public override IEnumerable<EmployeeRoleModel> Parse(List<EmployeeRoleImportModel> importModels)
        {
            foreach (EmployeeRoleImportModel model in importModels)
            {
                yield return new EmployeeRoleModel()
                {
                    Employee = EmployeeRetrievingService.Get().First(e => e.Email == model.Employee).Id,
                    Role = RoleRetrievingService.Get().First(r => r.Name == model.Role).Id
                };
            }
        }

        public override void AddOrUpdate(List<EmployeeRoleModel> models)
        {
            foreach (EmployeeRoleModel model in models)
            {
                var existingModel = EmployeeRoleRetrievingService.Get()
                    .FirstOrDefault(er => er.Employee.Id == model.Employee && er.Role.Id == model.Role);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}