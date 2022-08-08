namespace CodecoolMaterialsAPI.Data.DAL
{
    public class MaterialTypeRepository : BaseRepository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;
    }
}
