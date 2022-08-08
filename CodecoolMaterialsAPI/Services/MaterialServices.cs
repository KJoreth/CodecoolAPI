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

        public async Task<MaterialCreatedDTO> CreateNewAsync(MaterialCreateUpdateDTO model)
        {
            if (!await _unitOfWork.AuthorRepository.AnyByIdAsync(model.AuthorId))
                throw new ResourceNotFoundException($"Author id: {model.AuthorId} doesn't exist");
            if (!await _unitOfWork.TypeRepository.AnyByIdAsync(model.TypeId))
                throw new ResourceNotFoundException($"Type id: {model.TypeId} doesn't exist");
            Material material = _mapper.Map<Material>(model);
            await _unitOfWork.MaterialRepository.AddAsync(material);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<MaterialCreatedDTO>(material);
        }

        public async Task UpdateAsync(int id, MaterialCreateUpdateDTO model)
        {
            if (!await _unitOfWork.AuthorRepository.AnyByIdAsync(model.AuthorId))
                throw new ResourceNotFoundException($"Author id: {model.AuthorId} doesn't exist");
            if (!await _unitOfWork.TypeRepository.AnyByIdAsync(model.TypeId))
                throw new ResourceNotFoundException($"Type id: {model.TypeId} doesn't exist");
            if (!await _unitOfWork.MaterialRepository.AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Material id: {id} doesn't exist");
            Material material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            _mapper.Map(model, material);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (!await _unitOfWork.MaterialRepository.AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Material id: {id} doesn't exist");
            Material material = await _unitOfWork.MaterialRepository.GetSingleWithAllFieldsByIdAsync(id);
            await _unitOfWork.MaterialRepository.RemoveAsync(material);
            await _unitOfWork.CompleteUnitAsync();
        }

    }
}
