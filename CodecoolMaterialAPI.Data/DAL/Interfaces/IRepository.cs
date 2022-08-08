﻿namespace CodecoolMaterialsAPI.Data.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
    }
}
