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

        public async Task<ActionResult<List<TypeSimpleDTO>>> GetAllAsync()
        {
            List<Data.Entities.Type> types = await _unitOfWork.TypeRepository.GetAllAsync();
            return _mapper.Map<List<TypeSimpleDTO>>(types);
        }
    }
}
