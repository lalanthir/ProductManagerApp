using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.API.BusinessLogic
{
    public class ProductLogic
    {
        private readonly ProductContext _context;
        public ProductLogic(ProductContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return  _context.Products.ToList();
        }

        public Product GetProductById(int Id)
        {
            return  _context.Products.Find(Id); 
        }

        public int SaveProduct(Product product)
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
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
              throw;
            }
            return product.Id;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
