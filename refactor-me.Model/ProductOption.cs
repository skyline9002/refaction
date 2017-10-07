﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Entity
{
    public class ProductOption : Entity.Abstract.Entity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public  string Description { get; set; }
    }
}
