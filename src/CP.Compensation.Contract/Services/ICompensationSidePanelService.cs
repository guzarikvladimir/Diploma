using System;
using CP.Compensation.Contract.Models;

namespace CP.Compensation.Contract.Services
{
    public interface ICompensationSidePanelService
    {
        CompensationSidePanelView Get(Guid employeeId);
    }
}