﻿using System;
using System.Collections.Generic;
using CP.Compensation.SidePanel.Contract;
using CP.Compensation.SidePanel.Models;
using CP.Shared.Contract.CompensationPromotion.Models;
using CP.Shared.Contract.CompensationPromotion.Services;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.Employee.Services;
using Ninject;

namespace CP.Compensation.SidePanel.Services
{
    public class CompensationSidePanelService : ICompensationSidePanelService
    {
        #region Injects

        [Inject]
        ICompensationPromotionService CompensationPromotionService { get; set; }

        [Inject]
        IEmployeeRetrievingService EmployeeRetrievingService { get; set; }

        #endregion

        public CompensationSidePanelView Get(Guid employeeId)
        {
            EmployeeView employee = EmployeeRetrievingService.GetById(employeeId);
            List<CompensationPromotionView> compensations = CompensationPromotionService.Get(employeeId);

            return new CompensationSidePanelView()
            {
                Employee = employee,
                CompensationPromotions = compensations
            };
        }
    }
}