using Moq;
using Ninject;
using Ninject.MockingKernel.Moq;
using RefactionMe.Data;
using RefactionMe.Data.Infrastructure;
using RefactionMe.Data.Repositories;
using RefactionMe.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RefactionMe.Test.ServiceTests
{
    public abstract class ServiceTestBase
    {

        public MoqMockingKernel Kernel { get; private set; }

        protected Mock<ProductContext> DbContext { get; set; }
        protected Mock<IDbFactory> DbFactory { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }

        protected IProductRepository ProductRepository { get; set; }
        protected IProductOptionRepository ProductOptionRepository { get; set; }

        protected DbSet<T> GetMockDbSet<T>(List<T> list) 
            where T :class
        {
            var sourceList = list.AsQueryable();

            var result = new Mock<DbSet<T>>();
            result.As<IQueryable<T>>().Setup(m => m.Provider).Returns(sourceList.Provider);
            result.As<IQueryable<T>>().Setup(m => m.Expression).Returns(sourceList.Expression);
            result.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(sourceList.ElementType);
            result.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(sourceList.GetEnumerator());
            result.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => list.Add(s));
            result.Setup(d => d.Add(It.IsAny<T>())).Verifiable();


            return result.Object;
        }


        protected ServiceTestBase()
        {
            Kernel = new MoqMockingKernel(new NinjectSettings
            {
                // Allow use of private constructors for domain objects in ORM
                InjectNonPublic = true
            });
        }
    }
}
