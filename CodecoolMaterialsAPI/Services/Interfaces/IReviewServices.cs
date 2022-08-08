namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IReviewServices
    {
        Task<ReviewDetailedDTO> CreateNewAsync(ReviewCreateDTO model);
        Task<List<ReviewSimpleDTO>> GetAllAsync();
        Task<ReviewDetailedDTO> GetSingleByIdAsync(int id);
    }
}