using Restaurant.Management.AggregateRoot.Entities;


namespace Restaurant.Management.Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<RestaurantDetails> RestaurantRepository { get; }
        IGenericRepository<Dish> DishRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
