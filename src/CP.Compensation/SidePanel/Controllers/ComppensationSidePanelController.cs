using System;
using System.Web.Http;
using CP.Compensation.SidePanel.Contract;
using CP.Compensation.SidePanel.Models;
using Ninject;

namespace CP.Compensation.SidePanel.Controllers
{
    [RoutePrefix("api/Compensations")]
    public class ComppensationSidePanelController : ApiController
    {
        [Inject]
        ICompensationSidePanelService CompensationSidePanelService { get; set; }

        [Route("SidePanel/{employeeId}")]
        public CompensationSidePanelView Get(Guid employeeId)
        {
            return CompensationSidePanelService.Get(employeeId);
        }
    }
}