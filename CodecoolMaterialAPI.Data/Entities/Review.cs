namespace CodecoolMaterialsAPI.Data.Entities
{
    public class EntitiesTypes
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string Text { get; set; }
        public int Points { get; set; }
    }
}
