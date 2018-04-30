using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CP.Shared.Contract.Currency.Models;
using CP.Shared.Contract.Currency.Services;
using Ninject;

namespace CP.Common.Currency.Controllers
{
    public class CurrencyController : ApiController
    {
        [Inject]
        ICurrencyService CurrencyService { get; set; }

        public IEnumerable<CurrencyView> Get()
        {
            return CurrencyService.GetOrdered();
        }
    }
}