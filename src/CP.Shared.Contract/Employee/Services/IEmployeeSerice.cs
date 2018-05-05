using System.Collections.Generic;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Filters.Model;

namespace CP.Shared.Contract.Employee.Services
{
    public interface IEmployeeSerice
    {
        List<EmployeeView> Get(CollectionViewParameters parameters);
    }
}