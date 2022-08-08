namespace CodecoolMaterialsAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        IMaterialTypeRepository MaterialTypeRepository { get; }
        IReviewRepository ReviewRepository { get; }

        Task<int> CompleteUnitAsync();
    }
}