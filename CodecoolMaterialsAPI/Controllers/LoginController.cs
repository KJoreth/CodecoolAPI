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
        public async Task<ActionResult> GetTokenAsync(string login, string password)
        {
            var hashedLogin = Hasher.ComputeSha256Hash(login);
            var hashedPassword = Hasher.ComputeSha256Hash(password);
            var token = await _userServices.LoginAsync(hashedLogin, hashedPassword);
            return Ok(token);
        }
    }
}
