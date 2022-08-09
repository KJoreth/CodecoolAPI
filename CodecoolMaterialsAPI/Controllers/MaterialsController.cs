namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialServices _materialServices;
        public MaterialsController(IMaterialServices materialServices)
           => _materialServices = materialServices;

        /// <summary>
        /// Returns all Materials in a simplified form
        /// </summary>
        /// <returns>List of Materials</returns>
        /// <response code="200">If Materials were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<MaterialSimpleDTO>>> GetAllAsync()
            => Ok(await _materialServices.GetAllAsync());

        /// <summary>
        /// Returns single Material in a detailed form
        /// </summary>
        /// <returns>Material</returns>
        /// <remarks>
        /// Sample request:
        ///     
        ///     Get
        ///     {
        ///         "id": "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Material was returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpGet("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<MaterialDetailedDTO>> GetSingleByIdAsync(int id)
            => Ok(await _materialServices.GetSingleByIdAsync(id));


        /// <summary>
        /// Returns list of materials with specyfic type
        /// </summary>
        /// <returns>List od materials</returns>
        /// <remarks>
        /// Sample request:
        ///     
        ///     Get
        ///     {
        ///         "typeId": "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Materials were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If type was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpGet("typeFilter/{typeId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MaterialDetailedDTO>> GetListByTypeAsync(int typeId)
            => Ok(await _materialServices.GetAllByTypeAsync(typeId));

        /// <summary>
        /// Creates new Material
        /// </summary>
        /// <returns>Created material</returns>
        /// <remarks>
        /// Sample request:
        ///     
        ///     Post
        ///     {
        ///         "title" : "c# for beginners"
        ///         "location" : "library"
        ///         "publishDate" : "2022-08-09"
        ///         "authorId" : "1"
        ///         "typeId" : "1"
        ///     }
        /// </remarks>
        /// <response code="201">If Material was created</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Author or Type was not found</response>
        /// <response code="409">If Material by this Titile already exists</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<MaterialCreatedDTO>> CreateNewAsync(MaterialCreateUpdateDTO model)
        {
            MaterialCreatedDTO material = await _materialServices.CreateNewAsync(model);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{material.Id}", material);
        }

        /// <summary>
        /// Updates Material
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PUT
        ///     {
        ///         "title" : "c# for beginners"
        ///         "location" : "library"
        ///         "publishDate" : "2022-08-09"
        ///         "authorId" : "1"
        ///         "typeId" : "1"
        ///     }
        /// </remarks>
        /// <response code="204">If Material was updated</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Author, Type or Material was not found</response>
        /// <response code="409">If Material by this Titile already exists</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpPut("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateAsync(int id, MaterialCreateUpdateDTO model)
        {
            await _materialServices.UpdateAsync(id, model);
            return NoContent();
        }

        /// <summary>
        /// Deltes Material
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     
        ///     Delete
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="202">If Material was created</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Material was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _materialServices.DeleteAsync(id);
            return NoContent();
        }




    }
}
