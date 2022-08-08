
namespace CodecoolMaterialsAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APIContext _context;
        public UnitOfWork(APIContext context, IAuthorRepository authorRepository, IMaterialRepository materialRepository,
            ITypeRepository materialTypeRepository, IReviewRepository reviewRepository)
        {
            _context = context;
            AuthorRepository = authorRepository;
            MaterialRepository = materialRepository;
            TypeRepository = materialTypeRepository;
            ReviewRepository = reviewRepository;
        }

        public IAuthorRepository AuthorRepository { get; private set; }
        public IMaterialRepository MaterialRepository { get; private set; }
        public ITypeRepository TypeRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }

        public async Task<int> CompleteUnitAsync()
            => await _context.SaveChangesAsync();

    }
}
