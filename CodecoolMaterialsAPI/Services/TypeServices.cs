namespace CodecoolMaterialsAPI.Services
{
    public class TypeServices : ITypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TypeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TypeSimpleDTO>> GetAllAsync()
        {
            List<MaterialType> types = await _unitOfWork.TypeRepository.GetAllAsync();
            return _mapper.Map<List<TypeSimpleDTO>>(types);
        }

        public async Task<TypeDetailedDTO> GetSingleByIdAsync(int id)
        {
            MaterialType type = await _unitOfWork.TypeRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<TypeDetailedDTO>(type);
        }

    }
}
