using CP.Shared.Contract.LegalEntity.Models;
using CP.Shared.Contract.LegalEntity.Services;
using CP.Shared.Core.Services;
using LegalEntityEntity = CP.Repository.Models.LegalEntity;

namespace CP.Shared.LegalEntity.Services
{
    public class LegalEntityModifyingService : 
        SimpleModifyingService<LegalEntityEntity, LegalEntityModel>,
        ILegalEntityModifyingService
    {
    }
}