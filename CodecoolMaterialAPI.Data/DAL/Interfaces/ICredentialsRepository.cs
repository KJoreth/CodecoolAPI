namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface ICredentialsRepository : IRepository<Credentials>
    {
        APIContext APIContext { get; }
    }
}
