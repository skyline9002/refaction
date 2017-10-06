using refactor_me.Data.Core;
using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Repositories
{
    public interface IProductRepository
    {
        //interface for customized extension.
    }


    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }

}
