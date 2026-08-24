using Microsoft.EntityFrameworkCore;
using Restaurant.Management.DTO.Entities;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Repository.Persistance;
using System.Linq.Expressions;


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
            _restaurantDbContext.Set<T>().Add(entity);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _restaurantDbContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return _restaurantDbContext.Set<T>().AsQueryable();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _restaurantDbContext.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _restaurantDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _restaurantDbContext.Set<T>().Attach(entity);
            _restaurantDbContext.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> expression)
        {
            return _restaurantDbContext.Set<T>().Where(expression);
        }
    }
}
