using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using CP.Shared.Core.Services;

namespace CP.Shared.LegalEntity.Services
{
    public class LegalEntityRetrievingService : 
        SimpleRetrievingService<Repository.Models.LegalEntity, LegalEntityView>,
        ILegalEntityRetrievingService
    {
    }
}