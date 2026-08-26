using Restaurant.Authentication.DTO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<bool> ExistsAsync(int id);
    }
}
