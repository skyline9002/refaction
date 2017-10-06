﻿using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Defined the product model constraints.
        /// </summary>
        public ProductConfiguration()
        {
            this.ToTable("Product");
            this.HasKey(a => a.Id);
            this.Property(a => a.Name).HasMaxLength(100).IsRequired();
            this.Property(a => a.Description).HasMaxLength(500);
        }
    }
}
