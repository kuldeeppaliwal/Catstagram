using Catstagram.server.Features.Cats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.server.Features.Cats
{
    public interface ICatService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
        public Task<IEnumerable<CatListingServiceModel>> ByUser(string userId);
        public Task<CatDetailsServiceModel> Details(int id);
    }
}
