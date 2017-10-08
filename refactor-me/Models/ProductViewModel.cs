using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactionMe.Api.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }

    }
}