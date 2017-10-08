using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Test.Helper
{
    public static class DataHelper
    {
        public static IEnumerable<Product> Product_DataSet
        {
            get
            {
                return new List<Product>()
                {
                      Product_SamsungPhone,
                      Prodcut_IPhone
                };
            }
        } 
      
        public static IEnumerable<ProductOption> Option_DataSet
        {
            get
            {
                return new List<ProductOption>()
                {
                     Option_Black_IPhone,
                     Option_Black_Sumsung,
                     Option_Gold_IPhone,
                     Option_White_IPhone,
                     Option_White_Sumsung
                };
            }
        } 
        
            
      
          

            
      

        public static Product Product_SamsungPhone = new Product()
        {
            Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"),
            Name = "Samsung Galaxy S7",
            Description = "Newest mobile product from Samsung.",
            Price = 1024.99m,
            DeliveryPrice = 16.99m
        };

        public static Product Prodcut_IPhone = new Product()
        {
            Id = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3"),
            Name = "Apple iPhone 6S",
            Description = "Newest mobile product from Apple.",
            Price = 1299.99m,
            DeliveryPrice = 15.99m
        };

        public static ProductOption Option_White_Sumsung = new ProductOption()
        {
             Description = "White Samsung Galaxy S7",
             Id = Guid.Parse("0643CCF0-AB00-4862-B3C5-40E2731ABCC9"),
             Name = "White",
             ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3")
        };

        public static ProductOption Option_Black_Sumsung = new ProductOption()
        {
            Description = "Black Samsung Galaxy S7",
            Id = Guid.Parse("A21D5777-A655-4020-B431-624BB331E9A2"),
            Name = "Black",
            ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3")
        };

        public static ProductOption Option_Gold_IPhone = new ProductOption()
        {
            Description = "Gold Apple iPhone 6S",
            Id = Guid.Parse("5C2996AB-54AD-4999-92D2-89245682D534"),
            Name = "Rose Gold",
            ProductId = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3")
        };

        public static ProductOption Option_White_IPhone = new ProductOption()
        {
            Description = "White Apple iPhone 6S",
            Id = Guid.Parse("9AE6F477-A010-4EC9-B6A8-92A85D6C5F03"),
            Name = "White",
            ProductId = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3")
        };

        public static ProductOption Option_Black_IPhone = new ProductOption()
        {
            Description = "Black Apple iPhone 6S",
            Id = Guid.Parse("4E2BC5F2-699A-4C42-802E-CE4B4D2AC0EF"),
            Name = "Black",
            ProductId = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3")
        };



    }
}
