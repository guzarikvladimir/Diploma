using System;
using CP.Compensation.SidePanel.Models;

namespace CP.Compensation.SidePanel.Contract
{
    public interface ICompensationSidePanelService
    {
        CompensationSidePanelView Get(Guid employeeId);
    }
}