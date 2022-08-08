namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

        public async Task<User> GetUserByCredentialsAsync(string hashedLogin, string hashedPassword)
            => await APIContext.Users
                .Where(x => x.Credentials.Login == hashedLogin && x.Credentials.Password == hashedPassword)
                .FirstOrDefaultAsync();
    }
}
