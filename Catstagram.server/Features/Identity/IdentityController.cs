namespace Catstagram.server.Features.Identity
{
    using Catstagram.server.Data;
    using Catstagram.server.Model.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        public readonly AppSettings appSettings;

        public IdentityController(UserManager<User> userManager, IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = string.Empty,
                UserName = model.UserName
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.identityService.GenerateJwtToken(
                user.Id, 
                user.UserName, 
                this.appSettings.Secret);

            return new LoginResponseModel
            {
                Token = token
            };
        }
    }
}
