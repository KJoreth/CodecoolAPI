namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

    }
}
