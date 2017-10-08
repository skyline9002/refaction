using RefactionMe.Data.Infrastructure;
using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Repositories
{
    public class ProductOptionRepository : RepositoryBase<ProductOption>, IProductOptionRepository
    {
        public ProductOptionRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }

}
