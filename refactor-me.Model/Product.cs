using RefactionMe.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Entity
{
    public class Product : Entity.Abstract.Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DeliveryPrice { get; set; } 
        
    }
}
