using System;
using System.Collections.Generic;
using System.Linq;
namespace ProductStore.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetByID(int id);
        void Add(Category product);
        IQueryable<Category> SearchWithPaging(SearchModel search);
    }

    public class SearchModel
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string keywords { get; set; }

    }
}
