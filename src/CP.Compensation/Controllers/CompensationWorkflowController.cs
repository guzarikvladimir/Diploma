using System.Web.Http;
using CP.Compensation.Contract.Services;
using CP.Shared.Contract.CompensationPromotion.Models;
using Ninject;

namespace CP.Compensation.Controllers
{
    public class CompensationWorkflowController : ApiController
    {
        [Inject]
        ICompensationWorkflowService CompensationWorkflowService { get; set; }

        [HttpPost]
        public void Create([FromBody] CompensationPromotionModel model)
        {
            CompensationWorkflowService.Create(model);
        }
    }
}