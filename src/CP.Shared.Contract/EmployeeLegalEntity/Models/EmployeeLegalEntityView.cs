﻿using System;
using CP.Platform.Crud.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.LegalEntity.Models;

namespace CP.Shared.Contract.EmployeeLegalEntity.Models
{
    public class EmployeeLegalEntityView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public EmployeeView Employee { get; set; }

        public LegalEntityView LegalEntity { get; set; }

        public bool IsPrimary { get; set; }
    }
}