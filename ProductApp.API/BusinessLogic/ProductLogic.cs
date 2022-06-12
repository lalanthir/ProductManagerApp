using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApp.API.BusinessLogic
{
    public class ProductLogic:IProductLogic
    {
        private readonly ProductContext _context;
        public ProductLogic(ProductContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await  _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByID(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> SaveProduct(Product product)
        {
            int id = product.Id;
            if (id > 0)
            {
                _context.Entry(product).State = EntityState.Modified;
            }
            else
            {
                _context.Products.Add(product);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return product;
        
    }

        public async Task DeleteProduct(int id)
        {
            var product =await _context.Products.FindAsync(id);           
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
