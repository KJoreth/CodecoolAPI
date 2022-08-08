namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        APIContext APIContext { get; }

        Task<bool> AnyByIdAsync(int id);
        Task<Review> GetSingleByIdAsync(int id);
    }
}