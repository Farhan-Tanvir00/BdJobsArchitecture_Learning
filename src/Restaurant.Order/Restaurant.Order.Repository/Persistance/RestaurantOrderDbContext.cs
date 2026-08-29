using Microsoft.EntityFrameworkCore;
using Restaurant.Order.AggregateRoot;
using Restaurant.Order.AggregateRoot.Entity;


namespace Restaurant.Order.Repository.Persistance
{
    public class RestaurantOrderDbContext : DbContext
    {
        public RestaurantOrderDbContext(DbContextOptions<RestaurantOrderDbContext> options): base(options)
        {
            
        }

        public DbSet<OrderAggregateRoot> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderAggregateRoot>(ar =>
            {
                ar.HasMany(ar => ar.OrderLineItems).WithOne().HasForeignKey(ar => ar.OrderId);
            });

        }
    }
}
