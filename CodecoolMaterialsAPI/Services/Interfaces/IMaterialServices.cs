namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IMaterialServices
    {
        Task<List<MaterialSimpleDTO>> GetAllAsync();
        Task<MaterialDetailedDTO> GetSingleByIdAsync(int id);
    }
}