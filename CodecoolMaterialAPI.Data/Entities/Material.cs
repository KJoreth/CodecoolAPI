namespace CodecoolMaterialsAPI.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        
        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }
        public List<Review> Reviews { get; set; }

    }
}
