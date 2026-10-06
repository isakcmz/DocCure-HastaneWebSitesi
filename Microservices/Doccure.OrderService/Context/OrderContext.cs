using Doccure.OrderService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.OrderService.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
    }
}
