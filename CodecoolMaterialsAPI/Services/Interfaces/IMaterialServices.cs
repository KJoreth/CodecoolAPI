﻿namespace CodecoolMaterialsAPI.Services.Interfaces
{
    public interface IMaterialServices
    {
        Task<MaterialCreatedDTO> CreateNewAsync(MaterialCreateUpdateDTO model);
        Task DeleteAsync(int id);
        Task<List<MaterialSimpleDTO>> GetAllAsync();
        Task<MaterialDetailedDTO> GetSingleByIdAsync(int id);
        Task UpdateAsync(int id, MaterialCreateUpdateDTO model);
    }
}