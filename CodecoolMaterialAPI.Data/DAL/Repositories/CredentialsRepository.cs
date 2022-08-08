namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    internal class CredentialsRepository : BaseRepository<Credentials>, ICredentialsRepository
    {
        public CredentialsRepository(DbContext context) : base(context) { }

    }
}
