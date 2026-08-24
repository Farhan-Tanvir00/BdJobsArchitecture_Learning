using Microsoft.EntityFrameworkCore;
using Restaurant.Management.AggregateRoot;


namespace Restaurant.Management.Repository.Persistance
{
    internal class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<RestaurantAggregateRoot> Restaurants { get; set; }
        public DbSet<DishAggregateRoot> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantAggregateRoot>(rd =>
            {
                rd.OwnsOne(rd => rd.Address);
                rd.HasMany(rd => rd.Dishes).WithOne(d => d.RestaurantDetails).HasForeignKey(d => d.RestaurantDetailsId);
            });
        }
    }
}
