namespace CodecoolMaterialsAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddDAL(this IServiceCollection service)
        {
            service.AddScoped<IAuthorRepository, AuthorRepository>();
            service.AddScoped<IMaterialRepository, MaterialRepository>();
            service.AddScoped<ITypeRepository, TypeRepository>();
            service.AddScoped<IReviewRepository, ReviewRepository>();
        }

        public static void AddDb(this IServiceCollection service, string connectionString)
            => service.AddDbContext<APIContext>(options => options.UseSqlServer(connectionString));

    }
}
