namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;

        public async Task<Review> GetSingleByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Review with id: {id} was not found");

            return await APIContext.Reviews
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> AnyByIdAsync(int id)
            => await APIContext.Materials
            .Where(x => x.Id == id)
            .AnyAsync();
    }
}
