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

        [HttpPost]
        
        public async Task<ActionResult<UserSimpleDTO>> CreateNewAsync(string login, string password)
        {
            var admin = await _adminServices.CreateNewAsync(login, password);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{admin.Id}",admin);
        }

    }
}
