namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface ICredentialsRepository : IRepository<Credentials>
    {
        APIContext APIContext { get; }

        Task<bool> AnyByCredentialsAsync(string hashedLogin, string hashedPassword);
    }
}
