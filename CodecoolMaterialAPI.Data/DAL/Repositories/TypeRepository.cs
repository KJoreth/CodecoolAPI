namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class TypeRepository : BaseRepository<MaterialType>, ITypeRepository
    {
        public TypeRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;

        public async Task<MaterialType> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Type with id: {id} was not found");

            return await APIContext.Types
                .Where(x => x.Id == id)
                .Include(x => x.Materials)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AnyByIdAsync(int id)
            => await APIContext.Types
            .Where(x => x.Id == id)
            .AnyAsync();
    }
}
