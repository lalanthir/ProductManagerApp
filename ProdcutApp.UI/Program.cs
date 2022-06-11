using ProductApp.Data;
using ProductApp.Domain;
using System;
using System.Linq;

namespace ProdcutApp.UI
{
    class Program
    {
        private static ProductContext productContext = new ProductContext();
        static void Main(string[] args)
        {
            productContext.Database.EnsureCreated();
            GetProdcuts();
            AddProdcut();
            GetProdcuts();
            Console.Write("Press any key");
            Console.ReadKey();

        }

        private static void GetProdcuts()
        {
            var prods = productContext.Products.ToList();
            Console.WriteLine($"No of prodcust {prods.Count}");
            foreach(var p in prods)
            {
                Console.WriteLine(p.Name);
            }
        }
        private static void AddProdcut()

        {
            var product = new Product {
            Name="Prod 2",
            Price = 55,
            Type="Books",
            Active=true};
            productContext.Products.Add(product);
            productContext.SaveChanges();
        }
    }
}
