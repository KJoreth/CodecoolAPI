namespace CodecoolMaterialsAPI.DTOs.TypeDTOs
{
    public record TypeDetailedDTO
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<MaterialSimpleDTO> Materials { get; set; }
    }
}
