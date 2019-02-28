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
            IList<Category> categories = new List<Category>
            {
                new Category() { Name = "Retail" },
                new Category() { Name = "Promotion" }
            };
            Product product1 = new Product { Name = "Tangerines", Price = 1 };
            Product product2 = new Product { Name = "Honey", Price = 1 };
            Product product3 = new Product { Name = "Cables", Price = 1 };

            db.SaveChanges();
        }
    }
}
