using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProductStore.Models
{
    public class CategoryRepository : IDisposable, ProductStore.Models.ICategoryRepository
    {
        private MyContext db = new MyContext();

        public IEnumerable<Category> GetAll()
        {
            return db.Category;
        }
        public Category GetByID(int id)
        {
            return db.Category.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Category product)
        {
            db.Category.Add(product);
            db.SaveChanges();
        }

        
        
        public IQueryable<Category> SearchWithPaging(SearchModel search)
        {
          var result =  db.Category.OrderBy(x => x.Id).Where(x => x.Name.Contains(search.keywords)).Skip((search.pageNumber-1)*search.pageSize).Take(search.pageSize);
          return result;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}