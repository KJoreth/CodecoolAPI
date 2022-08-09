using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

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
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<ICredentialsRepository, CredentialsRepository>();
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
            service.AddScoped<IUserServices, UserServices>();
            service.AddScoped<IAdminServices, AdminServices>();
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

        public static void AddSwaggerGenWithJWTSupport(this IServiceCollection service) 
        {

            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CodecoolMaterialAPI",
                    Description = "An ASP.NET Core Web API for managing Codecool materials",
                    
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                       new OpenApiSecurityScheme
                       {
                           Reference = new OpenApiReference
                           {
                               Type = ReferenceType.SecurityScheme,
                               Id = "Bearer",
                           },
                       },
                       new string[] {}
                    }
                 });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

    }
}
