namespace Catstagram.server.Controllers
{
    using Catstagram.server.Data;
    using Catstagram.server.Infrastructure;
    using Catstagram.server.Model;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext data;

        public CatsController(CatstagramDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetID();
            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };
            this.data.Add(cat);
            await this.data.SaveChangesAsync();
            return Created(nameof(this.Create), cat.Id);
        }
    }
}
