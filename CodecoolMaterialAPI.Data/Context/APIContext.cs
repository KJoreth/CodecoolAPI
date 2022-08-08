namespace CodecoolMaterialsAPI.Data.Context
{
    public class APIContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
