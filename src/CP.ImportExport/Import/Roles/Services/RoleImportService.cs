using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.Roles.Contract;
using CP.ImportExport.Import.Roles.Models;
using CP.Shared.Contract.Role.Models;
using CP.Shared.Contract.Role.Services;
using Ninject;

namespace CP.ImportExport.Import.Roles.Services
{
    public class RoleImportService :
        ImportServiceBase<RoleImportModel, RoleModel>,
        IRoleImportService
    {
        [Inject]
        IRoleRetrievingService RoleRetrievingService { get; set; }

        public override IEnumerable<RoleModel> Parse(List<RoleImportModel> importModels)
        {
            foreach (RoleImportModel model in importModels)
            {
                yield return new RoleModel()
                {
                    Name = model.Name
                };
            }
        }

        public override void AddOrUpdate(List<RoleModel> models)
        {
            foreach (RoleModel model in models)
            {
                var existingModel = RoleRetrievingService.Get().FirstOrDefault(r => r.Name == model.Name);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }
    }
}