using Restaurant.Management.AggregateRoot.Entities;

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
        //IQueryable<T> Search(IFilter<T> filter);
    }
}
