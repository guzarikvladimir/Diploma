using System;
using CP.Repository.Models;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Employee.Models;

namespace CP.Shared.Contract.CompensationPromotion.Models
{
    public class CompensationPromotionView
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public CurrencyView Currency { get; set; }

        public EmployeeView Employee { get; set; }

        public CompensationPromotionType PromotionType { get; set; }
    }
}