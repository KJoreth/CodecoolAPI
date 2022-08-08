namespace CodecoolMaterialsAPI.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class ReviewsSeeder
    {
        public static void SeedRevies(this ModelBuilder builder)
        {
            List<EntitiesTypes> reviews = new List<EntitiesTypes>();
            string[] fileLines = File.ReadAllLines("../CodecoolMaterialAPI.Data/Seeder/EntitiesSeeders/Data/Reviews.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                reviews.Add(item);
            }

            builder.Entity<EntitiesTypes>().HasData(reviews);
        }

        private static EntitiesTypes GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            int materialId = Convert.ToInt32(item[1]);
            string text = item[2];
            int points = Convert.ToInt32(item[3]);
            return new EntitiesTypes() { Id = id, MaterialId = materialId, Text = text, Points = points };
        }
    }
}
