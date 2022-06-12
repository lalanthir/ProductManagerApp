using ProductApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.API.BusinessLogic
{
    public interface IProductLogic
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByID(int id);
        Task<Product> SaveProduct(Product product);
        Task DeleteProduct(int id);
    }
}
