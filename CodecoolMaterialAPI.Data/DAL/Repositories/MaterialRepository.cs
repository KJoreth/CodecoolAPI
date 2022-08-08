
namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;

        public async Task<Material> GetSingleWithAllFieldsByIdAsync(int id)
        {
            if (!await AnyByIdAsync(id))
                throw new ResourceNotFoundException($"Material with id: {id} was not found");

            return await APIContext.Materials
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Type)
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> AnyByIdAsync(int id)
            => await APIContext.Materials
            .Where(x => x.Id == id)
            .AnyAsync();


    }
}
