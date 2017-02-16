using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=ProductsContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}