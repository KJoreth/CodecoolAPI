using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeServices _typeServices;
        public TypesController(ITypeServices typeServices)
        {
            _typeServices = typeServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<TypeSimpleDTO>>> GetAllAsync()
            => await _typeServices.GetAllAsync();

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<TypeDetailedDTO>> GetSingleByIdAsync(int id)
            => await _typeServices.GetSingleByIdAsync(id);

        
    }
}
