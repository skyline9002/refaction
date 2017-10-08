using RefactionMe.Data.Infrastructure;
using RefactionMe.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactionMe.Service
{
    public abstract class BusinessServiceBase<T> 
        where T : class, IEntity 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        protected IUnitOfWork UnitOfWork => _unitOfWork;
       

        public BusinessServiceBase(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public bool IsExist(Guid Id)
        {
            return this._repository.GetById(Id) != null;
        }


    }
}
