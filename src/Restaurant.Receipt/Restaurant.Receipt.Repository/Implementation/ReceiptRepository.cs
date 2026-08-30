using Restaurant.Receipt.AggregateRoot;
using Restaurant.Receipt.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Restaurant.Receipt.Repository.Implementation
{
    public class ReceiptRepository
    {
        private readonly ReceiptDbContext _context;
        public ReceiptRepository(ReceiptDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewReceipt(RestaurantReceiptAggregateRoot aggregateRoot)
        {
            _context.Receipt.Add(aggregateRoot);
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<OrderAggregateRoot?> GetOrderByIdAsync(int id)
        //{
        //    var result = await _context.Orders.Include(x => x.OrderLineItems).FirstOrDefaultAsync(x => x.Id == id);
        //    return result;
        //}
    }
}
