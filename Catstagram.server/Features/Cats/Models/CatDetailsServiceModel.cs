using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.server.Features.Cats.Models
{
    public class CatDetailsServiceModel : CatListingServiceModel
    {
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
