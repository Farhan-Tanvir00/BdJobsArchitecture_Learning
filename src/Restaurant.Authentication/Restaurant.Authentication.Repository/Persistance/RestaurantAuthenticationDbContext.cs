using Microsoft.EntityFrameworkCore;
using Restaurant.Authentication.AggregateRoot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Repository.Persistance
{
    public class RestaurantAuthenticationDbContext : DbContext
    {
        public RestaurantAuthenticationDbContext(DbContextOptions<RestaurantAuthenticationDbContext> options) : base(options)
        {

        }

        public DbSet<UserAggregateRoot> Users { get; set; }
        public DbSet<RoleAggregateRoot> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAggregateRoot>(user =>
            {
                user.HasMany(u => u.Roles).WithMany(r => r.Users).UsingEntity(j => j.ToTable("UserRoles"));
            });
        }
    }
}
