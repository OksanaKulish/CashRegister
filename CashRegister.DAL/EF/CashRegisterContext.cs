using CashRegister.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DAL.EF
{
    public class CashRegisterContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CashRegisterContext()
            :base("DefaultConnection")
        {
            Database.SetInitializer<CashRegisterContext>(new StoreDbInitializer());
        }

        public CashRegisterContext(string connectionString)
            :base(connectionString)
        { }
    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<CashRegisterContext>
    {
        protected override void Seed(CashRegisterContext db)
        {
            GetCategories().ForEach(c => db.Categories.Add(c));
            GetProducts().ForEach(p => db.Products.Add(p));

            db.SaveChanges();
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                   Id = 1,
                   Name = "Retail"
                },
                new Category
                {
                    Id = 2,
                    Name = "Promotion"
                },
                new Category
                {
                    Id = 3,
                    Name = "Wholesale"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Tangerines",
                    Price = 80,
                    CategoryID = 2
                    
               },
                new Product
                {
                    Id = 2,
                    Name = "Tangerines",
                    Price = 30,
                    CategoryID = 2
               },
                new Product
                {
                   Id = 3,
                    Name = "Honey",
                    Price = 220,
                    CategoryID = 2
                },
                new Product
                {
                   Id = 4,
                    Name = "Honey",
                    Price = 100,
                    CategoryID = 1
                },
                new Product
                {
                   Id = 5,
                    Name = "Cables",
                    Price = 85,
                    CategoryID = 3
                },
                new Product
                {
                   Id = 3,
                    Name = "Cables",
                    Price = 10,
                    CategoryID = 1
                },
            };

            return products;
        }
    }
}
