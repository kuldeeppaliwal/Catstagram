namespace Catstagram.server.Features.Cats
{
    using Catstagram.server.Features.Cats.Models;
    using Catstagram.server.Infrastructure;
    using Catstagram.server.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using static Infrastructure.WebConstants;


    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatService catService;

        public CatsController(ICatService catService)
        {
            this.catService = catService;
        }
        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
           return await this.catService.ByUser(this.User.GetID());
        }
        
        [HttpGet]
        [Route("Details/"+Id)]
        public async Task<CatDetailsServiceModel> Details(int id)        
            => await this.catService.Details(id);
          
       
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
        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.GetID();

            var updated = await this.catService.Update(model.Id, model.Description, userId);
            if (!updated)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.User.GetID();
            var deleted = await this.catService.Delete(id, userId);
            if (!deleted)
            {
                return this.BadRequest();
            }
            return Ok();
        }
    }
}
