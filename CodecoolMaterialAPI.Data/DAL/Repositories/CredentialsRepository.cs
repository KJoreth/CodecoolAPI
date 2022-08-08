namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class CredentialsRepository : BaseRepository<Credentials>, ICredentialsRepository
    {
        public CredentialsRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

    }
}
