using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.Shared.Interfaces.Filter;
using System.Linq.Expressions;

namespace Restaurant.Management.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<bool> ExistsAsync(int id);
        IQueryable<T> Search(Expression<Func<T, bool>> expression);
    }
}
