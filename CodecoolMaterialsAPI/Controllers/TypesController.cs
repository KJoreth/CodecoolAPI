namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeServices _typeServices;
        public TypesController(ITypeServices typeServices)
            => _typeServices = typeServices;


        /// <summary>
        /// Returns all types in a simplified form
        /// </summary>
        /// <returns>List of types</returns>
        /// <response code="200">If Types were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<TypeSimpleDTO>>> GetAllAsync()
            => await _typeServices.GetAllAsync();


        /// <summary>
        /// Returns a Type in a detailed form
        /// </summary>
        /// <returns>Type</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Types were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Type was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<TypeDetailedDTO>> GetSingleByIdAsync(int id)
            => await _typeServices.GetSingleByIdAsync(id);

        
    }
}
