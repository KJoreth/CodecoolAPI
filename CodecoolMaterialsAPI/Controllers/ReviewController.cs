﻿using Microsoft.AspNetCore.Http;
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
    }
}
