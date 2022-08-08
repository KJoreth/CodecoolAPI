namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        APIContext APIContext { get; }

        Task<Material> GetSingleWithAllFieldsByIdAsync(int id);
    }
}