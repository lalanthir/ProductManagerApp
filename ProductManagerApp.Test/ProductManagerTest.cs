using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Domain;
using ProductApp.API.BusinessLogic;
using System.Linq;

namespace ProductManagerApp.Test
{
    [TestClass]
    public class ProductManagerTest
    {
        IProductLogic _logic;
        [TestMethod]
        public void TestAddProduct()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AddProductDB");
            using (var context = new ProductContext())
            {
                _logic = new ProductLogic(context);
                var product = new Product()
                {
                    Name = "Test Product",
                    Type = "Books",
                    Active = true,
                    Price = 25.5M
                };
                _logic.SaveProduct(product);
                Assert.AreEqual(EntityState.Added, context.Entry(product).State);
            }
        }

       [TestMethod]
        public void TestGetProducts()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("GetProductDB");
            using (var context = new ProductContext())
            {
                _logic = new ProductLogic(context);
                var product = new Product()
                {
                    Name = "Test Product",
                    Type = "Books",
                    Active = true,
                    Price = 25.5M
                };
               context.Add(product);
                var result = _logic.GetProducts().Result;
                Assert.IsTrue(result.ToList().Count > 0);
            }
        }

        [TestMethod]
        public void TestGetProductById()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("GetProductByIdDB");
            var idUnderTest = 1;
            using (var context = new ProductContext())
            {
                _logic = new ProductLogic(context);
                var product = new Product()
                {
                    Id = idUnderTest,
                    Name = "Test Product",
                    Type = "Books",
                    Active = true,
                    Price = 25.5M
                };
                context.Add(product);
                var result = _logic.GetProductByID(idUnderTest).Result;
                Assert.IsTrue(result.Id== idUnderTest);
            }
        }
    }

}
