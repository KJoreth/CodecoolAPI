﻿namespace CodecoolMaterialsAPI.DTOs.TypeDTOs
{
    public class TypeDetailedDTO
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public List<MaterialSimpleDTO> Materials { get; set; }
    }
}
