using CashRegister.DAL.EF;
using CashRegister.DAL.Entities;
using CashRegister.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private CashRegisterContext db;

        public CategoryRepository(CashRegisterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }
        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return db.Categories.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
}

}


