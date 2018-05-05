using System.Collections.Generic;
using System.Web.Http;
using CP.Compensation.Table.Contract;
using CP.Compensation.Table.Models;
using Ninject;

namespace CP.Compensation.Table.Controllers
{
    [RoutePrefix("api/Compensations")]
    public class CompensationTableController : ApiController
    {
        [Inject]
        ICompensationTableSerivce CompensationTableSerivce { get; set; }

        [Route("Table")]
        public CompensationTableView Get([FromUri] CompensationTableParameters parameters)
        {
            if (parameters == null)
            {
                parameters = new CompensationTableParameters();
            }

            return CompensationTableSerivce.Get(parameters);
        }
    }
}