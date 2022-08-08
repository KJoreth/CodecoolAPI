using Microsoft.AspNetCore.Http;


namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;
        public MaterialsController(IMaterialServices materialServices)
        {
            _materialServices = materialServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialSimpleDTO>>> GetAllAsync()
            => await _materialServices.GetAllAsync();
    }
}
