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

        public async Task<ReviewDetailedDTO> CreateNewAsync(ReviewCreateDTO model)
        {
            if (!await _unitOfWork.MaterialRepository.AnyByIdAsync(model.MaterialId))
                throw new ResourceNotFoundException($"Material with id: {model.MaterialId} doesn't exist");
            Material material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(model.MaterialId);
            Review review = new() { Points = model.Points, Text = model.Text, MaterialId = model.MaterialId};
            await _unitOfWork.ReviewRepository.AddAsync(review);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<ReviewDetailedDTO>(review);
        }
    }
}
