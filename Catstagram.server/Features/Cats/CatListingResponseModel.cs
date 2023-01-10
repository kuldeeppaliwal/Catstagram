using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.server.Features.Cats
{
    public class CatListingResponseModel
    {
        public int Id { get; set; }      
        public string ImageUrl { get; set; }
    }
}
