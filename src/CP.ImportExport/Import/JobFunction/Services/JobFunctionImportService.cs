using System;
using System.Collections.Generic;
using System.Linq;
using CP.ImportExport.Import.Core.Services;
using CP.ImportExport.Import.JobFunction.Contract;
using CP.ImportExport.Import.JobFunction.Models;
using CP.Shared.Contract.JobFunction.Models;
using CP.Shared.Contract.JobFunction.Services;
using CP.Shared.Contract.JobFunctionPosition.Models;
using CP.Shared.Contract.JobFunctionPosition.Services;
using CP.Shared.Contract.JobFunctionTitile.Models;
using CP.Shared.Contract.JobFunctionTitile.Services;
using Ninject;

namespace CP.ImportExport.Import.JobFunction.Services
{
    public class JobFunctionImportService :
        ImportServiceBase<JobFunctionImportModel, JobFunctionModel>,
        IJobFunctionImportService
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

        [Inject]
        IJobFunctionRetrievingService JobFunctionRetrievingService { get; set; }

        #endregion

        public override string GetTemplateName()
        {
            return "JobFunctions";
        }

        public override IEnumerable<JobFunctionModel> Parse(List<JobFunctionImportModel> importModels)
        {
            AddOrUpdateTitle(importModels);
            AddOrUpdatePosition(importModels);

            foreach (JobFunctionImportModel model in importModels)
            {
                yield return new JobFunctionModel()
                {
                    TitleId = JobFunctionTitleRetrievingService.Get().First(m => m.Name == model.Title).Id,
                    PositionId = JobFunctionPositionRetrievingService.Get().First(m => m.Name == model.Position).Id
                };
            }
        }

        public override void AddOrUpdate(List<JobFunctionModel> models)
        {
            foreach (JobFunctionModel model in models)
            {
                var existingModel = JobFunctionRetrievingService.Get()
                    .FirstOrDefault(jf => jf.Position.Id == model.PositionId && jf.Title.Id == model.TitleId);
                if (existingModel != null)
                {
                    continue;
                }

                SimpleModifyingService.Add(model);
            }
        }

        private void AddOrUpdateTitle(List<JobFunctionImportModel> importModels)
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

                    JobFunctionTitleModifyingService.Add(new JobFunctionTitleModel() { Name = title });
                }

                scope.SaveChanges();
            }
        }

        private void AddOrUpdatePosition(List<JobFunctionImportModel> importModels)
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

                    JobFunctionPositionModifyingService.Add(new JobFunctionPositionModel() { Name = position });
                }

                scope.SaveChanges();
            }
        }
    }
}