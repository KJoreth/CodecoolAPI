namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        ITypeRepository TypeRepository { get; }
        IReviewRepository ReviewRepository { get; }
        IUserRepository UserRepository { get; }
        ICredentialsRepository CredentialsRepository { get; }

        Task<int> CompleteUnitAsync();
    }
}