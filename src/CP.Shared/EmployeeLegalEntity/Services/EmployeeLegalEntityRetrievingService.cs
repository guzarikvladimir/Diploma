﻿using System;
using System.Collections.Generic;
using System.Linq;
using CP.Platform.Crud.Services;
using CP.Shared.Contract.EmployeeLegalEntity.Models;
using CP.Shared.Contract.EmployeeLegalEntity.Services;
using EmployeeLegalEntityEntity = CP.Repository.Models.EmployeeLegalEntity;

namespace CP.Shared.EmployeeLegalEntity.Services
{
    public class EmployeeLegalEntityRetrievingService : 
        SimpleRetrievingService<EmployeeLegalEntityEntity, EmployeeLegalEntityView>,
        IEmployeeLegalEntityRetrievingService
    {
        public IEnumerable<EmployeeLegalEntityView> Get(Guid employeeId, bool isActive = true)
        {
            return Get().Where(el => el.Employee.Id == employeeId && el.LegalEntity.IsActive);
        }
    }
}