using System.Collections.Generic;
using System.Web.Http;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using Ninject;

namespace CP.Common.Currency.Controllers
{
    public class CurrencyController : ApiController
    {
        [Inject]
        ICurrencyRetrievingService CurrencyRetrievingService { get; set; }

        public IEnumerable<CurrencyView> Get()
        {
            return CurrencyRetrievingService.GetOrdered();
        }
    }
}