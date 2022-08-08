namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IAuthorServices
    {
        Task<List<AuthorSimpleDTO>> GetAllAsync();
        Task<List<MaterialSimpleDTO>> GetAllVerifiedMaterialsFromAuthor(int id);
        Task<AuthorDetailedDTO> GetSingleByIdAsync(int id);
    }
}