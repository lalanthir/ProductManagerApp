using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductApp.API.BusinessLogic;
using ProductApp.Domain;

namespace ProductApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLogic _logic;

        public ProductsController(IProductLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _logic.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _logic.GetProductByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

       
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var result= await _logic.SaveProduct(product);
            if (result != null)
                return result;
            else return NotFound();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _logic.DeleteProduct(id);
            return NoContent();
        }
    }
}
