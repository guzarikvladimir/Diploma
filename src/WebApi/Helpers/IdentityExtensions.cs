using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace WebApi.Helpers
{
    public static class IdentityExtensions
    {
        public static T GetUserId<T>(this IIdentity identity)
            where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            ClaimsIdentity ci = identity as ClaimsIdentity;
            Claim id = ci?.FindFirst(ClaimTypes.NameIdentifier);
            if (id != null)
            {
                return (T)Convert.ChangeType(id.Value, typeof(T), CultureInfo.InvariantCulture);
            }

            return default(T);
        }

        public static string GetUserRole(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            ClaimsIdentity ci = identity as ClaimsIdentity;
            Claim id = ci?.FindFirst(ClaimsIdentity.DefaultRoleClaimType);

            return id?.Value ?? string.Empty;
        }
    }
}