namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IReviewServices
    {
        Task<List<ReviewSimpleDTO>> GetAllAsync();
        Task<ReviewDetailedDTO> GetSingleByIdAsync(int id);
    }
}