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
        public async Task<ActionResult<List<TypeSimpleDTO>>> GetAllAsync()
            => await _typeServices.GetAllAsync();
    }
}
