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
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<MaterialSimpleDTO>>> GetAllAsync()
            => Ok(await _materialServices.GetAllAsync());

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<MaterialDetailedDTO>> GetSingleByIdAsync(int id)
            => Ok(await _materialServices.GetSingleByIdAsync(id));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MaterialCreatedDTO>> CreateNewAsync(MaterialCreateUpdateDTO model)
        {
            MaterialCreatedDTO material = await _materialServices.CreateNewAsync(model);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{material.Id}", material);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAsync(int id, MaterialCreateUpdateDTO model)
        {
            await _materialServices.UpdateAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _materialServices.DeleteAsync(id);
            return NoContent();
        }




    }
}
