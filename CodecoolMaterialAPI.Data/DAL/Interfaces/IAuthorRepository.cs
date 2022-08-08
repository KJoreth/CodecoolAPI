namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        APIContext APIContext { get; }

        Task<bool> AnyByIdAsync(int id);
        Task<Author> GetSingleWithAllFieldsByIdAsync(int id);
    }
}