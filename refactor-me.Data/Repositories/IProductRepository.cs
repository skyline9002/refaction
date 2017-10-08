using RefactionMe.Data.Infrastructure;
using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //customized database operations go here.
    }
}
