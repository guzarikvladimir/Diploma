using System;
using System.Web;
using CP.ImportExport.Import.Core.Contract;
using CP.ImportExport.Import.Core.Models;
using CP.ImportExport.Import.Currency.Contract;
using CP.ImportExport.Import.CurrencyRate.Contract;
using CP.ImportExport.Import.Employee.Contract;
using CP.ImportExport.Import.EmployeeLegalEntity.Contract;
using CP.ImportExport.Import.EmployeeRole.Contract;
using CP.ImportExport.Import.EmployeeStatus.Contract;
using CP.ImportExport.Import.JobFunction.Contract;
using CP.ImportExport.Import.LegalEntity.Contract;
using CP.ImportExport.Import.Location.Contract;
using CP.ImportExport.Import.Roles.Contract;
using Ninject;

namespace CP.ImportExport.Import.Core.Services
{
    public class ImportResolverService : IImportResolverService
    {
        #region Injects

        [Inject]
        ICurrencyImportService CurrencyImportService { get; set; }

        [Inject]
        IRoleImportService RoleImportService { get; set; }

        [Inject]
        IJobFunctionImportService JobFunctionImportService { get; set; }

        [Inject]
        ILocationImportService LocationImportService { get; set; }

        [Inject]
        IEmployeeStatusImportService EmployeeStatusImportService { get; set; }

        [Inject]
        IEmployeeImportService EmployeeImportService { get; set; }

        [Inject]
        IEmployeeRoleImportService EmployeeRoleImportService { get; set; }

        [Inject]
        ILegalEntityImportService LegalEntityImportService { get; set; }

        [Inject]
        IEmployeeLegalEntityImportService EmployeeLegalEntityImportService { get; set; }

        [Inject]
        ICurrencyRateImportService CurrencyRateImportService { get; set; }

        #endregion

        public void Resolve(ImportOption importOption, HttpPostedFileBase file)
        {
            switch (importOption)
            {
                case ImportOption.Currency:
                    CurrencyImportService.Upload(file);
                    break;
                case ImportOption.Role:
                    RoleImportService.Upload(file);
                    break;
                case ImportOption.JobFunction:
                    JobFunctionImportService.Upload(file);
                    break;
                case ImportOption.Location:
                    LocationImportService.Upload(file);
                    break;
                case ImportOption.EmployeeStatus:
                    EmployeeStatusImportService.Upload(file);
                    break;
                case ImportOption.Employee:
                    EmployeeImportService.Upload(file);
                    break;
                case ImportOption.EmployeeRole:
                    EmployeeRoleImportService.Upload(file);
                    break;
                case ImportOption.CurrencyRate:
                    CurrencyRateImportService.Upload(file);
                    break;
                case ImportOption.LegalEntity:
                    LegalEntityImportService.Upload(file);
                    break;
                case ImportOption.EmployeeLegalEntity:
                    EmployeeLegalEntityImportService.Upload(file);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(importOption), importOption, null);
            }
        }

        public TemplateModel GenerateTemplate(ImportOption importOption)
        {
            switch (importOption)
            {
                case ImportOption.Employee:
                    return EmployeeImportService.GenerateTemplate();
                case ImportOption.Role:
                    return RoleImportService.GenerateTemplate();
                case ImportOption.EmployeeRole:
                    return EmployeeRoleImportService.GenerateTemplate();
                case ImportOption.Currency:
                    return CurrencyImportService.GenerateTemplate();
                case ImportOption.CurrencyRate:
                    return CurrencyRateImportService.GenerateTemplate();
                case ImportOption.LegalEntity:
                    return LegalEntityImportService.GenerateTemplate();
                case ImportOption.EmployeeLegalEntity:
                    return EmployeeLegalEntityImportService.GenerateTemplate();
                case ImportOption.Location:
                    return LocationImportService.GenerateTemplate();
                case ImportOption.JobFunction:
                    return JobFunctionImportService.GenerateTemplate();
                case ImportOption.EmployeeStatus:
                    return EmployeeStatusImportService.GenerateTemplate();
                default:
                    throw new ArgumentOutOfRangeException(nameof(importOption), importOption, null);
            }
        }
    }
}