
namespace CodecoolMaterialsAPI.Data.DAL
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

    }
}
