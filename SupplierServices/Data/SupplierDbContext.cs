using Microsoft.EntityFrameworkCore;
using SupplierServices.Models;

namespace SupplierServices.Data
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
    }
}
