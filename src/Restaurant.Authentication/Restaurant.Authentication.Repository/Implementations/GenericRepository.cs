using Restaurant.Authentication.DTO.Entity;
using Restaurant.Authentication.Repository.Interfaces;
using Restaurant.Authentication.Repository.Persistance;

namespace Restaurant.Authentication.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RestaurantAuthenticationDbContext _context;

        public GenericRepository(RestaurantAuthenticationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(int id)
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

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
