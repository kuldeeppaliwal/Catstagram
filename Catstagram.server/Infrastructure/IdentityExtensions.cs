using System.Linq;
using System.Security.Claims;

namespace Catstagram.server.Infrastructure
{
    public static class IdentityExtensions
    {
        public static string GetID(this ClaimsPrincipal user)
            => user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }
}
