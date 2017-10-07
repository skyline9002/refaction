using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Service.Interface
{
    public interface IProducService
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> SearchByName(string name);
        Product GetProduct(Guid id);
        void Create(Product product);
        void Update(Guid id, Product product);
        void Delete(Guid id);
    }
}
