using InventoryServices.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
