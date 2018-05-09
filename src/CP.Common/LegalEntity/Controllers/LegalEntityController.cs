using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using Ninject;

namespace CP.Common.LegalEntity.Controllers
{
    public class LegalEntityController : ApiController
    {
        #region Injects

        [Inject]
        ILegalEntityRetrievingService LegalEntityRetrievingService { get; set; }

        [Inject]
        IEmployeeLegalEntityRetrievingService EmployeeLegalEntityRetrievingService { get; set; }

        #endregion

        public IEnumerable<LegalEntityView> Get()
        {
            return LegalEntityRetrievingService.Get().OrderBy(le => le.Name);
        }
        
        public IEnumerable<LegalEntityView> Get(Guid employeeId)
        {
            List<LegalEntityView> employeeLegalEntities = EmployeeLegalEntityRetrievingService.Get()
                .Where(ele => ele.Employee.Id == employeeId)
                .Select(ele => ele.LegalEntity)
                .ToList();

            return employeeLegalEntities;
        }
    }
}