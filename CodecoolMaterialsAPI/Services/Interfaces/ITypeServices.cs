namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface ITypeServices
    {
        Task<List<TypeSimpleDTO>> GetAllAsync();
        Task<TypeDetailedDTO> GetSingleByIdAsync(int id);
    }
}