using Microsoft.EntityFrameworkCore;
using ProductApp.Domain;

namespace ProductApp.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext()
        {

        }
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=ProductsAppDB");
            }
        
            }

        public virtual DbSet<Product> Products { get; set; }
    }
}
