using Doccure.MarketService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doccure.MarketService.Context
{
    public class MarketContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-SPG6ILB4\\SQLEXPRESS;initial catalog=DoccureMarketDb;integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }
    }
}
