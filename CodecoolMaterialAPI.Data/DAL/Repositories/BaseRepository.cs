namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        public readonly DbContext _context;
        public BaseRepository(DbContext context)
         => _context = context;

        public async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public async Task<List<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetSignleByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task RemoveAsync(T entity)
            => await Task.Run(() => _context.Set<T>().Remove(entity));
    }
}
