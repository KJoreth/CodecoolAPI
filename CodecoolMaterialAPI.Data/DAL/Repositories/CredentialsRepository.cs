namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class CredentialsRepository : BaseRepository<Credentials>, ICredentialsRepository
    {
        public CredentialsRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

        public async Task<bool> AnyByCredentialsAsync(string hashedLogin, string hashedPassword)
            => await APIContext.Credentials
            .Where(x => x.Login == hashedLogin && x.Password == hashedPassword)
            .AnyAsync();

    }
}
