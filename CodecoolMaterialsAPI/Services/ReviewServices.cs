namespace CodecoolMaterialsAPI.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReviewSimpleDTO>> GetAllAsync()
        {
            List<Review> reviews = await _unitOfWork.ReviewRepository.GetAllAsync();
            return _mapper.Map<List<ReviewSimpleDTO>>(reviews);
        }

        public async Task<ReviewDetailedDTO> GetSingleByIdAsync(int id)
        {
            Review review = await _unitOfWork.ReviewRepository.GetSingleByIdAsync(id);
            return _mapper.Map<ReviewDetailedDTO>(review);
        }
    }
}
