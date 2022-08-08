namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class MaterialTypeRepository : BaseRepository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;
    }
}
