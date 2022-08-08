namespace CodecoolMaterialsAPI.Data.DAL
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;
    }
}
