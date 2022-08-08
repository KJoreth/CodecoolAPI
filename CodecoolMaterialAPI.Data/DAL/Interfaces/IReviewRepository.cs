namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        APIContext APIContext { get; }
    }
}