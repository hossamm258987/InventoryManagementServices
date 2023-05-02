using Microsoft.EntityFrameworkCore;
using StockServices.Models;

namespace StockServices.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
    }
}
