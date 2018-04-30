using System;
using System.Collections.Generic;
using System.Web.Http;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using Ninject;

namespace CP.Compensation.Controllers
{
    [RoutePrefix("api/Compensations")]
    public class CompensationsController : ApiController
    {
        [Inject]
        ICompensationSerivce CompensationSerivce { get; set; }

        [Route("Table")]
        public IEnumerable<CompensationView> Get()
        {
            return CompensationSerivce.Get();
        }

        [Route("SidePanel/{employeeId}")]
        public CompensationView Get(Guid employeeId)
        {
            return CompensationSerivce.Get(employeeId);
        }
    }
}