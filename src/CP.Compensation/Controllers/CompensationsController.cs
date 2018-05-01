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
        #region Injects

        [Inject]
        ICompensationTableSerivce CompensationTableSerivce { get; set; }

        [Inject]
        ICompensationSidePanelService CompensationSidePanelService { get; set; }

        #endregion

        [Route("Table")]
        public IEnumerable<CompensationTableView> Get()
        {
            return CompensationTableSerivce.Get();
        }

        [Route("SidePanel/{employeeId}")]
        public CompensationSidePanelView Get(Guid employeeId)
        {
            return CompensationSidePanelService.Get(employeeId);
        }
    }
}