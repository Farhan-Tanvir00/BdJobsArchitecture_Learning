using Restaurant.Order.AggregateRoot;
using Restaurant.Order.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.Repository.Implementations
{
    public class OrderRepository
    {
        private readonly RestaurantOrderDbContext _context;
        public OrderRepository(RestaurantOrderDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewOrder(OrderAggregateRoot aggregateRoot)
        {
            _context.Orders.Add(aggregateRoot);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task GetOrderByIdAsync()
    }
}
