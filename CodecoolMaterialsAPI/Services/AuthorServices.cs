namespace CodecoolMaterialsAPI.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AuthorSimpleDTO>> GetAllAsync()
        {
            List<Author> authors = await _unitOfWork.AuthorRepository.GetAllAsync();
            return _mapper.Map<List<AuthorSimpleDTO>>(authors);
        }

        public async Task<AuthorDetailedDTO> GetSingleByIdAsync(int id)
        {
            Author author = await _unitOfWork.AuthorRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<AuthorDetailedDTO>(author);
        }

        public async Task<List<MaterialSimpleDTO>> GetAllVerifiedMaterialsFromAuthor(int id)
        {
            if (!await _unitOfWork.AuthorRepository.AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author id: {id} doesn't exist");
            Author author =await _unitOfWork.AuthorRepository.GetSingleWithAllFieldsAndReviewsByIdAsync(id);
            List<Material> verifiedMaterials = new List<Material>();
            foreach(var material in author.Materials)
                if(material.AverageScore > 5)
                    verifiedMaterials.Add(material);

            return _mapper.Map<List<MaterialSimpleDTO>>(verifiedMaterials);
        }
    }
}
