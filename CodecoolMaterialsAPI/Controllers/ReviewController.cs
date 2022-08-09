namespace CodecoolMaterialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        /// <summary>
        /// Returns all Revies in a simplified form
        /// </summary>
        /// <returns>List of Revies</returns>
        /// <response code="200">If Revies were returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<List<ReviewSimpleDTO>>> GetAllAsync()
            => await _reviewServices.GetAllAsync();

        /// <summary>
        /// Returns Review in a detailed form
        /// </summary>
        /// <returns>Review</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="200">If Review was returned</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Review was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReviewDetailedDTO>> GetSingleByIdAsync(int id)
            => await _reviewServices.GetSingleByIdAsync(id);

        /// <summary>
        /// Creates Review
        /// </summary>
        /// <returns>Created Review</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post
        ///     {
        ///         "points" : "10"
        ///         "text" : "Amazing"
        ///         "materialId" : "1"
        ///     }
        /// </remarks>
        /// <response code="201">If Review was created</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Material was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<ReviewDetailedDTO>> CreateNewAsync(ReviewCreateUpdateDTO model)
        {
            ReviewDetailedDTO review = await _reviewServices.CreateNewAsync(model);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{review.Id}", review);
        }

        /// <summary>
        /// Updates Review
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Put
        ///     {
        ///         "points" : "10"
        ///         "text" : "Amazing"
        ///         "materialId" : "1"
        ///     }
        /// </remarks>
        /// <response code="204">If Review was updaterd</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Material or Review was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult> UpdateAsync(int id, ReviewCreateUpdateDTO model)
        {
            await _reviewServices.UpdateAsync(id, model);
            return NoContent();
        }


        /// <summary>
        /// Deltes Review
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     Delete
        ///     {
        ///         "id" : "1"
        ///     }
        /// </remarks>
        /// <response code="202">If Review was deleted</response>
        /// <response code="401">If Unauthorized</response>
        /// <response code="403">If not allowed</response>
        /// <response code="404">If Review was not found</response>
        /// <response code="500">If somethind went wrong</response>
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reviewServices.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
