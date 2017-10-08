using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ProductContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public ProductContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _dbFactory.GetDbContext());
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
