namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;
    }
}
