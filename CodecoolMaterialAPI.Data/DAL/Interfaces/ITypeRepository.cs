namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface ITypeRepository :IRepository<Entities.Type>
    {
        APIContext APIContext { get; }
    }
}