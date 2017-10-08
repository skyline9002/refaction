using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Data.Infrastructure
{
    public interface IDbFactory
    {
        ProductContext GetDbContext();
    }
}
