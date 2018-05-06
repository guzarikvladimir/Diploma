using System;
using System.Collections.Generic;
using System.Linq;
using CP.Shared.Contract.EmployeeToLegalEntity.Models;
using CP.Shared.Contract.EmployeeToLegalEntity.Services;
using CP.Shared.Core.Services;
using EmployeeToLegalEntityEntity = CP.Repository.Models.EmployeeToLegalEntity;

namespace CP.Shared.EmployeeToLegalEntity.Services
{
    public class EmployeeToLegalEntityRetrievingService : 
        SimpleRetrievingService<EmployeeToLegalEntityEntity, EmployeeToLegalEntityView>,
        IEmployeeToLegalEntityRetrievingService
    {
        public IEnumerable<EmployeeToLegalEntityView> Get(Guid employeeId, bool isActive = true)
        {
            return Get().Where(el => el.Employee.Id == employeeId);
        }
    }
}