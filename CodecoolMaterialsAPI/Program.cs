var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDAL();
builder.Services.AddDb(connectionString);
builder.Services.AddMiddlewares();
builder.Services.AddServices();
builder.Services.AddJsonPatch();


var audience = builder.Configuration["Jwt:Audience"];
var issuer = builder.Configuration["Jwt:Issuer"] ;
var key = (builder.Configuration["Jwt:Key"]);
builder.Services.AddJWTBearer(audience, issuer, key);

builder.Services.AddSwaggerGenWithJWTSupport();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
