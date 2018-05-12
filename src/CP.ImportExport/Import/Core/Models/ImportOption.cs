using System.ComponentModel.DataAnnotations;

namespace CP.ImportExport.Import.Core.Models
{
    public enum ImportOption
    {
        [Display(Name = "Employees")]
        Employee,
        [Display(Name = "Roles")]
        Role,
        [Display(Name = "Employees Roles")]
        EmployeeRole,
        [Display(Name = "Currencies")]
        Currency,
        [Display(Name = "Currency Rates")]
        CurrencyRate,
        [Display(Name = "Legal Entities")]
        LegalEntity,
        [Display(Name = "Employees Legal Entities")]
        EmployeeLegalEntity,
        [Display(Name = "Locations")]
        Location,
        [Display(Name = "Job Functions")]
        JobFunction,
        [Display(Name = "Employee Statuses")]
        EmployeeStatus
    }
}