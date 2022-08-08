namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task<List<AuthorSimpleDTO>> GetAllAsync();
        Task<AuthorDetailedDTO> GetSingleByIdAsync(int id);
    }
}