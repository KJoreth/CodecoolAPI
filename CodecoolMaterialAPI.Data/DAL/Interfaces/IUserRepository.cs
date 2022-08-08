namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        APIContext APIContext { get; }
    }
}
