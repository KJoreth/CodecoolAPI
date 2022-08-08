using CodecoolMaterialsAPI.Services.Interfaces;

namespace CodecoolMaterialsAPI.Services
{
    public class MaterialServices : IMaterialServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaterialServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MaterialSimpleDTO>> GetAllAsync()
        {
            List<Material> materials = await _unitOfWork.MaterialRepository.GetAllAsync();
            return _mapper.Map<List<MaterialSimpleDTO>>(materials);
        }

        public async Task<MaterialDetailedDTO> GetSingleByIdAsync(int id)
        {
            Material material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            return _mapper.Map<MaterialDetailedDTO>(material);
        }

    }
}
