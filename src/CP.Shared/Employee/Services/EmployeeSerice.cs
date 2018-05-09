using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using CP.Shared.Contract.Filters.Helpers;
using CP.Shared.Contract.Filters.Model;
using Ninject;

namespace CP.Shared.Employee.Services
{
    public class EmployeeSerice : IEmployeeSerice
    {
        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        public List<EmployeeView> Get(CollectionViewParameters parameters)
        {
            int page = parameters.Page.ToDefaultPage();

            return EmployeeRetrievingService.Get()
                .Skip(page - 1)
                .Take(parameters.PageCount)
                .ToList();
        }
    }
}