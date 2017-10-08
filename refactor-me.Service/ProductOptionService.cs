using RefactionMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactionMe.Entity;
using RefactionMe.Data.Repositories;
using RefactionMe.Data.Infrastructure;
using RefactionMe.Service.Exceptions;

namespace RefactionMe.Service
{
    public class ProductOptionService : BusinessServiceBase<ProductOption>, IProductOptionService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductOptionRepository _productOptionRepository;

        #region DI
        public ProductOptionService(IProductOptionRepository productOptionRepository,
                                    IProductRepository productRepsotiry,
                                    IUnitOfWork unitOfWork)
          : base(unitOfWork, productOptionRepository)

        {
            this._productOptionRepository = productOptionRepository;
            this._productRepository = productRepsotiry;
        } 
        #endregion

        public void CreateOption(Guid productId, ProductOption option)
        {
            if(_productRepository.GetById(productId) == null)
            {   //product does not exists.
                throw new EntityNotFoundException();
            }

            try
            {
                this._productOptionRepository.Add(option);
                this.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void DeleteOption(Guid id)
        {
            if (!IsExist(id))
            {
                throw new EntityNotFoundException();
            }

            try
            {
                this._productOptionRepository.Delete(a => a.Id == id);
                this.UnitOfWork.Commit();

            }catch(Exception e)
            {
                throw e;
            }
        }

        public ProductOption GetOption(Guid productId, Guid optionId)
        {
            return this._productOptionRepository.Get(a => a.ProductId == productId && a.Id == optionId);
        }

        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            return this._productOptionRepository.GetMany(a => a.ProductId == productId);
        }

        public void UpdateOption(Guid id, ProductOption option)
        {
            if (!IsExist(id))
            {
                throw new EntityNotFoundException();
            }

            try
            {
                this._productOptionRepository.Update(option);
                this.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
