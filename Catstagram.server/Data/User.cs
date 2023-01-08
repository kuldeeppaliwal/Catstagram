using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Catstagram.server.Data
{
    public class User : IdentityUser
    {
        public IEnumerable<Cat> Cats { get; } = new HashSet<Cat>();

    }
}
