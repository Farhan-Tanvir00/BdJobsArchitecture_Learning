using Microsoft.EntityFrameworkCore;
using Restaurant.Management.AggregateRoot.Entities;


namespace Restaurant.Management.Repository.Persistance
{
    internal class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }

        public DbSet<RestaurantDetails> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantDetails>(rd =>
            {
                rd.OwnsOne(rd => rd.Address);
                rd.HasMany(rd => rd.Dishes).WithOne(d => d.RestaurantDetails).HasForeignKey(d => d.RestaurantDetailsId);
            });
        }
    }
}
