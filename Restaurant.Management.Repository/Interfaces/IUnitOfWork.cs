using Restaurant.Management.AggregateRoot;


namespace Restaurant.Management.Repository.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<RestaurantAggregateRoot> RestaurantRepository { get; }
        IGenericRepository<DishAggregateRoot> DishRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
