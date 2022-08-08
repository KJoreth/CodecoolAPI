
namespace CodecoolMaterialsAPI.Data.Context
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<EntitiesTypes> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.SeedDB();
    }

}
