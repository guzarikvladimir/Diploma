using System.Collections.Generic;
using System.Web.Http;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using Ninject;

namespace CP.Compensation.Controllers
{
    public class CompensationsController : ApiController
    {
        [Inject]
        ICompensationSerivce CompensationSerivce { get; set; }

        public IEnumerable<CompensationView> Get()
        {
            return CompensationSerivce.Get();
        }
    }
}