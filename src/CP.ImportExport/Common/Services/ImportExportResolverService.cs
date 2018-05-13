using System;
using System.Web;
using CP.ImportExport.Common.Contract;
using CP.ImportExport.Common.Models;
using CP.ImportExport.Currency.Contract;
using CP.ImportExport.CurrencyRate.Contract;
using CP.ImportExport.Employee.Contract;
using CP.ImportExport.EmployeeLegalEntity.Contract;
using CP.ImportExport.EmployeeRole.Contract;
using CP.ImportExport.EmployeeStatus.Contract;
using CP.ImportExport.JobFunction.Contract;
using CP.ImportExport.LegalEntity.Contract;
using CP.ImportExport.Location.Contract;
using CP.ImportExport.Roles.Contract;
using Ninject;

namespace CP.ImportExport.Common.Services
{
    public class ImportExportResolverService : IImportExportResolverService
    {
        #region Injects

        [Inject]
        ICurrencyImportExportService CurrencyImportExportService { get; set; }

        [Inject]
        IRoleImportExportService RoleImportExportService { get; set; }

        [Inject]
        IJobFunctionImportExportService JobFunctionImportExportService { get; set; }

        [Inject]
        ILocationImportExportService LocationImportExportService { get; set; }

        [Inject]
        IEmployeeStatusImportExportService EmployeeStatusImportExportService { get; set; }

        [Inject]
        IEmployeeImportExportService EmployeeImportExportService { get; set; }

        [Inject]
        IEmployeeRoleImportExportService EmployeeRoleImportExportService { get; set; }

        [Inject]
        ILegalEntityImportExportService LegalEntityImportExportService { get; set; }

        [Inject]
        IEmployeeLegalEntityImportExportService EmployeeLegalEntityImportExportService { get; set; }

        [Inject]
        ICurrencyRateImportExportService CurrencyRateImportExportService { get; set; }

        #endregion

        public void ResolveImport(ImportExportOption importOption, HttpPostedFileBase file)
        {
            switch (importOption)
            {
                case ImportExportOption.Currency:
                    CurrencyImportExportService.Upload(file);
                    break;
                case ImportExportOption.Role:
                    RoleImportExportService.Upload(file);
                    break;
                case ImportExportOption.JobFunction:
                    JobFunctionImportExportService.Upload(file);
                    break;
                case ImportExportOption.Location:
                    LocationImportExportService.Upload(file);
                    break;
                case ImportExportOption.EmployeeStatus:
                    EmployeeStatusImportExportService.Upload(file);
                    break;
                case ImportExportOption.Employee:
                    EmployeeImportExportService.Upload(file);
                    break;
                case ImportExportOption.EmployeeRole:
                    EmployeeRoleImportExportService.Upload(file);
                    break;
                case ImportExportOption.CurrencyRate:
                    CurrencyRateImportExportService.Upload(file);
                    break;
                case ImportExportOption.LegalEntity:
                    LegalEntityImportExportService.Upload(file);
                    break;
                case ImportExportOption.EmployeeLegalEntity:
                    EmployeeLegalEntityImportExportService.Upload(file);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(importOption), importOption, null);
            }
        }

        public TemplateModel ResolveExport(ImportExportOption exportOption)
        {
            switch (exportOption)
            {
                case ImportExportOption.Employee:
                    return EmployeeImportExportService.Export();
                case ImportExportOption.Role:
                    return RoleImportExportService.Export();
                case ImportExportOption.EmployeeRole:
                    return EmployeeRoleImportExportService.Export();
                case ImportExportOption.Currency:
                    return CurrencyImportExportService.Export();
                case ImportExportOption.CurrencyRate:
                    return CurrencyRateImportExportService.Export();
                case ImportExportOption.LegalEntity:
                    return LegalEntityImportExportService.Export();
                case ImportExportOption.EmployeeLegalEntity:
                    return EmployeeLegalEntityImportExportService.Export();
                case ImportExportOption.Location:
                    return LocationImportExportService.Export();
                case ImportExportOption.JobFunction:
                    return JobFunctionImportExportService.Export();
                case ImportExportOption.EmployeeStatus:
                    return EmployeeStatusImportExportService.Export();
                default:
                    throw new ArgumentOutOfRangeException(nameof(exportOption), exportOption, null);
            }
        }

        public TemplateModel GenerateTemplate(ImportExportOption importOption)
        {
            switch (importOption)
            {
                case ImportExportOption.Employee:
                    return EmployeeImportExportService.GenerateTemplate();
                case ImportExportOption.Role:
                    return RoleImportExportService.GenerateTemplate();
                case ImportExportOption.EmployeeRole:
                    return EmployeeRoleImportExportService.GenerateTemplate();
                case ImportExportOption.Currency:
                    return CurrencyImportExportService.GenerateTemplate();
                case ImportExportOption.CurrencyRate:
                    return CurrencyRateImportExportService.GenerateTemplate();
                case ImportExportOption.LegalEntity:
                    return LegalEntityImportExportService.GenerateTemplate();
                case ImportExportOption.EmployeeLegalEntity:
                    return EmployeeLegalEntityImportExportService.GenerateTemplate();
                case ImportExportOption.Location:
                    return LocationImportExportService.GenerateTemplate();
                case ImportExportOption.JobFunction:
                    return JobFunctionImportExportService.GenerateTemplate();
                case ImportExportOption.EmployeeStatus:
                    return EmployeeStatusImportExportService.GenerateTemplate();
                default:
                    throw new ArgumentOutOfRangeException(nameof(importOption), importOption, null);
            }
        }
    }
}