using Microsoft.EntityFrameworkCore;
using Restaurant.Receipt.AggregateRoot;
using Restaurant.Receipt.AggregateRoot.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.Repository.Persistance
{
    public class ReceiptDbContext : DbContext
    {
        public ReceiptDbContext(DbContextOptions<ReceiptDbContext> options) : base(options)
        {

        }

        public DbSet<RestaurantReceiptAggregateRoot> Receipt { get; set; }
        public DbSet<ReceiptLineItem> ReceiptLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantReceiptAggregateRoot>(ar =>
            {
                ar.HasMany(ar => ar.OrderLineItems).WithOne().HasForeignKey(ar => ar.ReceiptId);
            });

        }
    }
}
