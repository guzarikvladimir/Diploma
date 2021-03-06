﻿using System;
using CP.Platform.Crud.Models;
using CP.Repository.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Employee.Models;
using CP.Shared.Contract.LegalEntity.Models;

namespace CP.Shared.Contract.CompensationPromotion.Models
{
    public class CompensationPromotionView : IEntityView<Guid>
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public CurrencyView Currency { get; set; }

        public EmployeeView Employee { get; set; }

        public LegalEntityView LegalEntity { get; set; }

        public CompensationPromotionType PromotionType { get; set; }

        public CompensationPromotionStatus PromotionStatus { get; set; }

        public DateTime ApplyDate { get; set; }

        public EmployeeView CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Comment { get; set; }
    }
}