using RefactionMe.Data.Configuration;
using RefactionMe.Data.Infrastructure;
using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            :base(DbHelpers.ConnectionString)
        {

        }

        public ProductContext(string conn)
            :base(conn)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductOptionConfiguration());
        }
    }
}
