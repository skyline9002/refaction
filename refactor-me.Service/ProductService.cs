using RefactionMe.Entity;
using RefactionMe.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactionMe.Data.Infrastructure;
using RefactionMe.Data.Repositories;
using RefactionMe.Service.Exceptions;

namespace RefactionMe.Service
{
    public class ProductService : BusinessServiceBase<Product>, IProducService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductOptionRepository _productOptionRepository;

        public ProductService(IProductRepository productRepository,
                              IProductOptionRepository productOptionRepository,
                              IUnitOfWork unitOfWork) 
            : base(unitOfWork, productRepository)
        {
            this._productRepository = productRepository;
            this._productOptionRepository = productOptionRepository;
        }

        public void Create(Product product)
        {
            this._productRepository.Add(product);
            this.UnitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            if (!IsExist(id))
            {
                throw new EntityNotFoundException();
            }

            try
            {
                this._productRepository.Delete(item => item.Id == id);
                this._productOptionRepository.Delete(item => item.ProductId == id); //also need to delete related product options.
                this.UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return _productRepository.GetMany(a => a.Name == name);
        }

        public void Update(Guid id, Product product)
        {
            if (!IsExist(id))
            {
                throw new EntityNotFoundException();
            }

            try
            {
                this._productRepository.Update(product);
                this.UnitOfWork.Commit();

            }catch(Exception e)
            {
                throw e;
            }

        }
    }
}
