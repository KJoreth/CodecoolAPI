namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;
    }
}
