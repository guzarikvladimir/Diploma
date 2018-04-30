using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace CP.Platform.Identity.Helpers
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            ClaimsIdentity ci = identity as ClaimsIdentity;
            Claim id = ci?.FindFirst(ClaimTypes.NameIdentifier);
            if (id != null)
            {
                return Guid.Parse((string)Convert.ChangeType(id.Value, typeof(string), CultureInfo.InvariantCulture));
            }

            return Guid.Empty;
        }
    }
}