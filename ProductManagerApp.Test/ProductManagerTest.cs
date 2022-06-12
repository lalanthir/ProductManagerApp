using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Domain;

namespace ProductManagerApp.Test
{
    [TestClass]
    public class ProductManagerTest
    {
        [TestMethod]
        public void TestAddProduct()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AddProductDB");
            using (var context = new ProductContext())
            {
                var product = new Product()
                {
                    Name = "Test Product",
                    Type = "Books",
                    Active = true,
                    Price = 25.5M
                };
                context.Products.Add(product);
                Assert.AreEqual(EntityState.Added, context.Entry(product).State);
            }
        }
    }
}
