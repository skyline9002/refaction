using RefactionMe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Service.Interface
{
    public interface IProductOptionService
    {
        IEnumerable<ProductOption> GetOptions(Guid productId);
        ProductOption GetOption(Guid productId, Guid optionId);
        void CreateOption(Guid productId, ProductOption option);
        void UpdateOption(Guid id, ProductOption option);
        void DeleteOption(Guid id);
        
    }
}
