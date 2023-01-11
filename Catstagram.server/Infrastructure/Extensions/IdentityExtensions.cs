using System.Linq;
using System.Security.Claims;

namespace Catstagram.server.Infrastructure.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetID(this ClaimsPrincipal user)
            => user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
