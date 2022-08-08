namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IUserServices
    {
        Task<string> LoginAsync(string hashedLogin, string hashedPassword);
    }
}