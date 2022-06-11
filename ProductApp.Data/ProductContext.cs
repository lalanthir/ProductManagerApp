using Microsoft.EntityFrameworkCore;
using ProductApp.Domain;

namespace ProductApp.Data
{
    public class ProductContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }      
    }
}
