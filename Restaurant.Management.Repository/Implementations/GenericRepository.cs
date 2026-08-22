using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Repository.Implementations
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RestaurantDbContext _restaurantDbContext;
        public GenericRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
