using Microsoft.EntityFrameworkCore;
using Restaurant.Order.AggregateRoot;
using Restaurant.Order.AggregateRoot.Entity;
using Restaurant.Order.DTO.DTO;
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

        public async Task<OrderAggregateRoot?> GetOrderByIdAsync(int id)
        {
            var result =  await _context.Orders.Include(x => x.OrderLineItems).FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
