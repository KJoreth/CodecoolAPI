namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(APIContext context) : base(context) { }

        public APIContext APIContext => _context as APIContext;

        public async Task<Author> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Author with id: {id} was not found");

            return await APIContext.Authors
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> AnyByIdAsync(int id)
            => await APIContext.Authors
            .Where(x => x.Id == id)
            .AnyAsync();

    }
}
