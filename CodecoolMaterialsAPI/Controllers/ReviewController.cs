using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<ReviewSimpleDTO>>> GetAllAsync()
            => await _reviewServices.GetAllAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDetailedDTO>> GetSingleByIdAsync(int id)
            => await _reviewServices.GetSingleByIdAsync(id);
        [HttpPost]
        public async Task<ActionResult<ReviewDetailedDTO>> CreateNewAsync(ReviewCreateUpdateDTO model)
        {
            ReviewDetailedDTO review = await _reviewServices.CreateNewAsync(model);
            return Created($"{Request.Scheme}://{Request.Host}{Request.Path}/{review.Id}", review);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ReviewCreateUpdateDTO model)
        {
            await _reviewServices.UpdateAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _reviewServices.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
