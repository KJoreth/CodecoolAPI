namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        ITypeRepository MaterialTypeRepository { get; }
        IReviewRepository ReviewRepository { get; }

        Task<int> CompleteUnitAsync();
    }
}