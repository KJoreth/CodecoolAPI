namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        APIContext APIContext { get; }
    }
}