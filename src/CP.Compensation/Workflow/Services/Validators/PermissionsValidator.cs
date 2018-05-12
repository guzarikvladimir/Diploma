using CP.Compensation.Workflow.Contract;
using CP.Core.Contract.Permission.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.EmployeeRole.Services;
using CP.Shared.Contract.Role.Models;
using Ninject;

namespace CP.Compensation.Workflow.Services.Validators
{
    public class PermissionsValidator : ICompensationPromotionWorkflowValidator
    {
        [Inject]
        IEmployeeRoleService EmployeeRoleService { get; set; }

        public void Validate(CompensationPromotionModel model)
        {
            if (!EmployeeRoleService.IsInRole(RoleView.CompensationManagers))
            {
                throw new AccessDeniedException();
            }
        }
    }
}