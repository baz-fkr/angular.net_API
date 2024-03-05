﻿using WebAtrio.UserManagement.Models.Entities;

namespace WebAtrio.UserManagement.Infrastructure
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}
