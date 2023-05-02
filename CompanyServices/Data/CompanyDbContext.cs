using Microsoft.EntityFrameworkCore;
using CompanyServices.Models;

namespace CompanyServices.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
