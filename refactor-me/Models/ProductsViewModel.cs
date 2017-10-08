using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RefactionMe.Api.Models
{
    public class ProductsViewModel
    {
        public ProductViewModel[] Items { get; set; }
    }
}