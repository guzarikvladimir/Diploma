using System.Web.Http;
using CP.Compensation.Contract.Services;
using CP.Shared.Contract.Bonus.Models;
using CP.Shared.Contract.Salary.Models;
using Ninject;

namespace CP.Compensation.Workflow.Controllers
{
    [RoutePrefix("api/Compensations")]
    public class CompensationWorkflowController : ApiController
    {
        [Inject]
        ICompensationWorkflowService CompensationWorkflowService { get; set; }

        [Route("Salary/Create")]
        [HttpPost]
        public void CreateSalary([FromBody] SalaryPromotionModel model)
        {
            CompensationWorkflowService.Create(model);
        }

        [Route("Bonus/Create")]
        [HttpPost]
        public void CreateBonus([FromBody] BonusPromotionModel model)
        {
            CompensationWorkflowService.Create(model);
        }
    }
}