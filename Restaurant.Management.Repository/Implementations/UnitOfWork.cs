using Restaurant.Management.AggregateRoot;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Repository.Persistance;


namespace Restaurant.Management.Repository.Implementations
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDbContext _restaurantDbContext;
        public IGenericRepository<RestaurantAggregateRoot> RestaurantRepository { get; }

        public IGenericRepository<DishAggregateRoot> DishRepository { get; }

        public UnitOfWork(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;

            RestaurantRepository = new GenericRepository<RestaurantAggregateRoot>(restaurantDbContext);
            DishRepository = new GenericRepository<DishAggregateRoot>(restaurantDbContext);
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
