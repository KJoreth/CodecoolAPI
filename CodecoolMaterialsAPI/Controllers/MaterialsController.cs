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
            => Ok(await _materialServices.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDetailedDTO>> GetSingleByIdAsync(int id)
            => Ok(await _materialServices.GetSingleByIdAsync(id));

    }
}
