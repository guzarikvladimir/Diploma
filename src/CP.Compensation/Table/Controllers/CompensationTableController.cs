using System.Collections.Generic;
using System.Web.Http;
using CP.Compensation.Contract.Models;
using CP.Compensation.Contract.Services;
using Ninject;

namespace CP.Compensation.Table.Controllers
{
    [RoutePrefix("api/Compensations")]
    public class CompensationTableController : ApiController
    {
        [Inject]
        ICompensationTableSerivce CompensationTableSerivce { get; set; }

        [Route("Table")]
        public IEnumerable<CompensationTableView> Get()
        {
            return CompensationTableSerivce.Get();
        }
    }
}