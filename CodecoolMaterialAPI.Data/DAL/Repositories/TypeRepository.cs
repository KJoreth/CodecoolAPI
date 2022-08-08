namespace CodecoolMaterialsAPI.Data.DAL.Repositories
{
    public class TypeRepository : BaseRepository<Entities.Type>, ITypeRepository
    {
        public TypeRepository(APIContext context) : base(context) { }
        public APIContext APIContext => _context as APIContext;
    }
}
