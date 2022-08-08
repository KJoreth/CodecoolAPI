namespace CodecoolMaterialsAPI.Data.Seeder.EntitiesSeeders.Seeders
{
    public static class TypesSeeder
    {
        public static void SeedTypes(this ModelBuilder builder)
        {
            List<Entities.Type> types = new List<Entities.Type>();
            string[] fileLines = File.ReadAllLines("../CodecoolMaterialAPI.Data/Seeder/EntitiesSeeders/Data/Types.txt");
            foreach (string line in fileLines.Skip(1))
            {
                var item = GetItemFromLine(line);
                types.Add(item);
            }

            builder.Entity<Entities.Type>().HasData(types);
        }

        private static Entities.Type GetItemFromLine(string line)
        {
            string[] item = line.Split('|');
            int id = Convert.ToInt32(item[0]);
            string name = item[1];
            string definition = item[2];
            return new Entities.Type() { Id = id, Name = name, Definition = definition };
        }
    }
}
