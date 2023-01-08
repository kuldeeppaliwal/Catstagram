namespace Catstagram.server.Features.Cats
{
    using Catstagram.server.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetID();
            var id = await this.catService.Create(
                model.ImageUrl, 
                model.Description, 
                userId);
            return Created(nameof(this.Create), id);
        }
    }
}
