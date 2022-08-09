using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public LoginController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> GetTokenAsync(string login, [FromBody] string password)
        {
            var token = await _userServices.LoginAsync(login, password);
            return Ok(token);
        }
    }
}
