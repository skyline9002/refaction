﻿using refactor_me.Data.Configuration;
using refactor_me.Data.Core;
using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            :base(DbHelpers.ConnectionString)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductOptionConfiguration());
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}