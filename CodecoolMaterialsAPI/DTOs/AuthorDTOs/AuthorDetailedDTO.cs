﻿namespace CodecoolMaterialsAPI.DTOs.AuthorDTOs
{
    public class AuthorDetailedDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaterialCounter { get; set; }
        public List<MaterialSimpleDTO> Materials { get; set; }
    }
}