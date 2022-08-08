using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorSimpleDTO>>> GetAllAsync()
            => await _authorServices.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDetailedDTO>> GetSingleByIdAsync(int id)
            => await _authorServices.GetSingleByIdAsync(id);
    }
}
