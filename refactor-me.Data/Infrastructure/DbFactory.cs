using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ProductContext _dbContext;

        public ProductContext GetDbContext()
        {
            return _dbContext ?? (_dbContext = new ProductContext());
        }

        protected override void DisposeCore()
        {
            if(this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
    }
}
