namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IReviewServices
    {
        Task<List<ReviewSimpleDTO>> GetAllAsync();
    }
}