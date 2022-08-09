using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }


        /// <summary>
        /// Creates new admin
        /// </summary>
        /// <returns>Created User</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post
        ///     {
        ///         "login" : "123"
        ///         "password" : "123"
        ///     }
        /// </remarks>
        /// <response code="201">If Admin was created</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="405">If not allowed</response>
        /// <response code="409">If Login is already taken</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<UserSimpleDTO>> CreateNewAsync(UserAuthorizationDTO model)
        {
            var admin = await _adminServices.CreateNewAsync(model.Login, model.Password);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{admin.Id}",admin);
        }

    }
}
