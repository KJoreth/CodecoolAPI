namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface ITypeServices
    {
        Task<ActionResult<List<TypeSimpleDTO>>> GetAllAsync();
    }
}