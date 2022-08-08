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
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddDb(this IServiceCollection service, string connectionString)
            => service.AddDbContext<APIContext>(options => options.UseSqlServer(connectionString));

        public static void AddMiddlewares(this IServiceCollection service)
        {
            service.AddScoped<ErrorHandlingMiddleware>();
            service.AddScoped<LoggingMiddleware>();
        }

        public static void AddServices(this IServiceCollection service)
        {
            service.AddScoped<IMaterialServices, MaterialServices>();
            service.AddScoped<IAuthorServices, AuthorServices>();
            service.AddScoped<ITypeServices, TypeServices>();
        }

    }
}
