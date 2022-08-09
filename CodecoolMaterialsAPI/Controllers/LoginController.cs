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


        /// <summary>
        /// Returns JWT
        /// </summary>
        /// <returns>JWT</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get
        ///     {
        ///         "login" : "123"
        ///         "password" : "123"
        ///     }
        /// </remarks>
        /// <response code="200">If JWT was returned</response>
        /// <response code="404">If Credentials are incorect</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> GetTokenAsync(UserAuthorizationDTO model)
        {
            var token = await _userServices.LoginAsync(model.Login, model.Password);
            return Ok(token);
        }
    }
}
