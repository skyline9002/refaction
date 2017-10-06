using refactor_me.Data.Core;
using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Repositories
{

    public interface IProductOptionRepository
    {
        //interface for customized Db operations.
    }

    public class ProductOptionRepository : RepositoryBase<Product>, IProductOptionRepository
    {
        public ProductOptionRepository(IDbFactory dbFactory) 
            : base(dbFactory)
        {

        }
    }

   
    
}
