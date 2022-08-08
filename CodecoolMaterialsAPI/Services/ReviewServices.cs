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

        public async Task<ReviewDetailedDTO> CreateNewAsync(ReviewCreateUpdateDTO model)
        {
            if (!await _unitOfWork.MaterialRepository.AnyByIdAsync(model.MaterialId))
                throw new ResourceNotFoundException($"Material with id: {model.MaterialId} doesn't exist");
            Review review = _mapper.Map<Review>(model);
            await _unitOfWork.ReviewRepository.AddAsync(review);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<ReviewDetailedDTO>(review);
        }

        public async Task UpdateAsync(int id, ReviewCreateUpdateDTO model)
        {
            if (!await _unitOfWork.ReviewRepository.AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Review with id: {id} doesn't exist");
            if(!await _unitOfWork.MaterialRepository.AnyByIdAsync(model.MaterialId))
                throw new ResourceNotFoundException($"Material with id: {model.MaterialId} doesn't exist");
            Review review = await _unitOfWork.ReviewRepository.GetSingleByIdAsync(id);
            review.MaterialId = model.MaterialId;
            review.Text = model.Text;
            review.Points = model.Points;
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _unitOfWork.ReviewRepository.AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Review with id: {id} doesn't exist");
            Review review = await _unitOfWork.ReviewRepository.GetSingleByIdAsync(id);
            await _unitOfWork.ReviewRepository.RemoveAsync(review);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
