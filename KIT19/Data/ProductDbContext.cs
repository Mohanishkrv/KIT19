using KIT19.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KIT19.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products {  get; set; } 
    }
}
