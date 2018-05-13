using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Common.Helpers;
using CP.ImportExport.Common.Services;
using CP.ImportExport.JobFunction.Contract;
using CP.ImportExport.JobFunction.Models;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.Contract.JobFunctionTitile.Models;
using CP.Shared.Contract.JobFunctionTitile.Services;
using Ninject;

namespace CP.ImportExport.JobFunction.Services
{
    public class JobFunctionImportExportService :
        ImportExportServiceBase<JobFunctionImportExportModel, JobFunctionModel, JobFunctionView>,
        IJobFunctionImportExportService
    {
        #region Injects

        [Inject]
        IJobFunctionTitleRetrievingService JobFunctionTitleRetrievingService { get; set; }

        [Inject]
        IJobFunctionTitleModifyingService JobFunctionTitleModifyingService { get; set; }

        [Inject]
        IJobFunctionPositionRetrievingService JobFunctionPositionRetrievingService { get; set; }

        [Inject]
        IJobFunctionPositionModifyingService JobFunctionPositionModifyingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "JobFunctions";
        }

        public override IEnumerable<JobFunctionModel> Parse(List<JobFunctionImportExportModel> importModels)
        {
            AddOrUpdateTitle(importModels);
            AddOrUpdatePosition(importModels);

            foreach (JobFunctionImportExportModel model in importModels)
            {
                yield return new JobFunctionModel()
                {
                    Id = ImportExportHelper.ParseId(model.Id),
                    TitleId = JobFunctionTitleRetrievingService.Get().First(m => m.Name == model.Title).Id,
                    PositionId = JobFunctionPositionRetrievingService.Get().First(m => m.Name == model.Position).Id
                };
            }
        }

        public override IEnumerable<JobFunctionImportExportModel> GetExportModels()
        {
            IEnumerable<JobFunctionView> models = SimpleRetrievingService.Get();
            foreach (JobFunctionView model in models)
            {
                yield return new JobFunctionImportExportModel()
                {
                    Id = model.Id.ToString(),
                    Title = model.Title.Name,
                    Position = model.Position.Name
                };
            }
        }

        private void AddOrUpdateTitle(List<JobFunctionImportExportModel> importModels)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (string title in importModels.Select(m => m.Title).Distinct())
                {
                    var existingModel = JobFunctionTitleRetrievingService.Get().FirstOrDefault(t => t.Name == title);
                    if (existingModel != null)
                    {
                        continue;
                    }

                    JobFunctionTitleModifyingService.AddOrUpdate(new JobFunctionTitleModel() { Name = title });
                }

                scope.SaveChanges();
            }
        }

        private void AddOrUpdatePosition(List<JobFunctionImportExportModel> importModels)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (string position in importModels.Select(m => m.Position).Distinct())
                {
                    var existingModel = JobFunctionPositionRetrievingService.Get().FirstOrDefault(p => p.Name == position);
                    if (existingModel != null)
                    {
                        continue;
                    }

                    JobFunctionPositionModifyingService.AddOrUpdate(new JobFunctionPositionModel() { Name = position });
                }

                scope.SaveChanges();
            }
        }
    }
}