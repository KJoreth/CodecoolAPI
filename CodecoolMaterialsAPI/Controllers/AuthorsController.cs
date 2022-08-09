namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
            => _authorServices = authorServices;



        /// <summary>
        /// Returns all Authors in a simplified form
        /// </summary>
        /// <returns>List of Authors</returns>
        /// <response code="200">If Authors were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<AuthorSimpleDTO>>> GetAllAsync()
            => await _authorServices.GetAllAsync();


        /// <summary>
        /// Returns an Author in a detailed form
        /// </summary>
        /// <returns>Author</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Author was returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <responce code="404">If Author was not found</responce>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<AuthorDetailedDTO>> GetSingleByIdAsync(int id)
            => await _authorServices.GetSingleByIdAsync(id);


        /// <summary>
        /// List of Author's Materials which score is above 5.0
        /// </summary>
        /// <returns>List of Materials</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Materials were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <responce code="404">If Author was not found</responce>
        /// <response code="500">If somethind went wrong</response>
        [HttpGet("{id}/Verified")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<MaterialSimpleDTO>>> GetAllVerifiedMaterialsFromAuthor(int id)
            => Ok(await _authorServices.GetAllVerifiedMaterialsFromAuthor(id));
    }
}
