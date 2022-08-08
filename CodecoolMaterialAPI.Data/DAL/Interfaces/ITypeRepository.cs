namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface ITypeRepository :IRepository<Entities.MaterialType>
    {
        APIContext APIContext { get; }

        Task<Entities.MaterialType> GetSingleWithAllFieldsByIdAsync(int id);
    }
}