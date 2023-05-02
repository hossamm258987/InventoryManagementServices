using Microsoft.EntityFrameworkCore;
using TypeServices.Models;

namespace TypeServices.Data
{
    public class TypeDbContext : DbContext
    {
        public TypeDbContext(DbContextOptions<TypeDbContext> options):base(options) 
        { 
        }

        public DbSet<ProType> ProTypes { get; set; }
    }
}
