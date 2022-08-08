

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
            service.AddScoped<IReviewServices, ReviewServices>();
        }

        public static void AddJsonPatch(this IServiceCollection service)
        {
            service.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                s.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public static void AddJWTBearer(this IServiceCollection service, string JWTAudience, string JWTIssuer, string JWTKey)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = JWTAudience,
                    ValidIssuer = JWTIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
