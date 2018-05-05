using System.Collections.Generic;
using CP.Shared.Contract.Compensation.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Compensation.SidePanel.Models
{
    public class CompensationSidePanelView
    {
        public EmployeeView Employee { get; set; }

        public IEnumerable<CompensationPromotionView> CompensationPromotions { get; set; }
    }
}