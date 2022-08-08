namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IReviewServices
    {
        Task<ReviewDetailedDTO> CreateNewAsync(ReviewCreateUpdateDTO model);
        Task DeleteAsync(int id);
        Task<List<ReviewSimpleDTO>> GetAllAsync();
        Task<ReviewDetailedDTO> GetSingleByIdAsync(int id);
        Task UpdateAsync(int id, ReviewCreateUpdateDTO model);
    }
}