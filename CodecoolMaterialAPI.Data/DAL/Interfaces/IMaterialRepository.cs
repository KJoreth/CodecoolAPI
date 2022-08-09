namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        APIContext APIContext { get; }

        Task<bool> AnyByIdAsync(int id);
        Task<bool> AnyByTtileAsync(string title);
        Task<List<Material>> GetAllByTypeIdAsync(int typeId);
        Task<Material> GetSingleAsNoTrackingByIdAsync(int id);
        Task<Material> GetSingleWithAllFieldsByIdAsync(int id);
    }
}