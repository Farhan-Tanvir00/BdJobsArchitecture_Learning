using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Repository.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _restaurantDbContext;
        public IGenericRepository<RestaurantDetails> RestaurantRepository { get; }

        public IGenericRepository<Dish> DishRepository { get; }

        public UnitOfWork(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;

            RestaurantRepository = new GenericRepository<RestaurantDetails>(restaurantDbContext);
            DishRepository = new GenericRepository<Dish>(restaurantDbContext);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _restaurantDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("An error occurred while saving changes to the database.", ex);
            }
            return true;
        }

        public void Dispose()
        {
            _restaurantDbContext.Dispose();
        }
    }
}
