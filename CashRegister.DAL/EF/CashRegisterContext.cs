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
            
        }
    }
}
