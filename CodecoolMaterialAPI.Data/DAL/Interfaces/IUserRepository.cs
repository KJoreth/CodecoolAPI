namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        APIContext APIContext { get; }

        Task<bool> AnyByLoginAsync(string hashedLogin);
        Task<User> GetUserByCredentialsAsync(string hashedLogin, string hashedPassword);
    }
}
