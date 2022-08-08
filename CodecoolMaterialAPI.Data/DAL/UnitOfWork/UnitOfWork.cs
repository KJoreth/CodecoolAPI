
namespace CodecoolMaterialsAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIContext _context;
        public UnitOfWork(APIContext context, IAuthorRepository authorRepository, IMaterialRepository materialRepository,
            IMaterialTypeRepository materialTypeRepository, IReviewRepository reviewRepository)
        {
            _context = context;
            AuthorRepository = authorRepository;
            MaterialRepository = materialRepository;
            MaterialTypeRepository = materialTypeRepository;
            ReviewRepository = reviewRepository;
        }

        public IAuthorRepository AuthorRepository { get; private set; }
        public IMaterialRepository MaterialRepository { get; private set; }
        public IMaterialTypeRepository MaterialTypeRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();

    }
}
