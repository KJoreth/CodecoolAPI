namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IAdminServices
    {
        Task<UserSimpleDTO> CreateNewAsync(string login, string password);
    }
}