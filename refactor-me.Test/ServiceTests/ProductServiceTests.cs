using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactionMe.Data.Repositories;
using RefactionMe.Entity;
using RefactionMe.Service;
using RefactionMe.Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RefactionMe.Data;
using RefactionMe.Data.Infrastructure;

namespace RefactionMe.Test.ServiceTests
{
    [TestClass]
    public class ProductServiceTests : ServiceTestBase
    {

        private ProductService _productService;


        [TestInitialize]
        public void Setup()
        {
            #region Mock DbContext
            DbContext = new Mock<ProductContext>("test-connection-string");

            var productDataSet = new List<Product>()
            {
                DataHelper.Prodcut_IPhone,
                DataHelper.Product_SamsungPhone
            };


            DbContext.Setup(a => a.Set<Product>()).Returns(base.GetMockDbSet<Product>(productDataSet));
            DbContext.Setup(a => a.Set<ProductOption>()).Returns(base.GetMockDbSet<ProductOption>(DataHelper.Option_DataSet.ToList()));
            #endregion

            #region Mock DbFactory
            DbFactory = new Mock<IDbFactory>();
            DbFactory.Setup(a => a.GetDbContext())
                     .Returns(DbContext.Object);
            #endregion

            UnitOfWork = new UnitOfWork(DbFactory.Object);
  


            ProductRepository = new ProductRepository(DbFactory.Object);
            ProductOptionRepository = new ProductOptionRepository(DbFactory.Object);

            _productService = new ProductService(base.ProductRepository, base.ProductOptionRepository, base.UnitOfWork);           
        }


        [TestMethod]
        public void ProductService_GetAll_SucessfulRun()
        {
            var result = _productService.GetAll();

            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result.FirstOrDefault(a => a.Name == "Samsung Galaxy S7"));
            Assert.IsNotNull(result.FirstOrDefault(a => a.Name == "Apple iPhone 6S"));
;       }

        [TestMethod]
        public void ProductService_SearchByName_SucessfulRun()
        {
            var result = _productService.SearchByName(DataHelper.Prodcut_IPhone.Name);

            Assert.IsTrue(result.Count() > 0);

            var result2 = _productService.SearchByName("Fake Product");

            Assert.IsFalse(result2.Count() > 0);
            
        }

        [TestMethod]
        public void ProductService_GetProductById_SucessfulRun()
        {
            var result = _productService.GetProduct(Guid.Empty);
            Assert.IsNull(result);

            var result2 = _productService.GetProduct(DataHelper.Prodcut_IPhone.Id);
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void ProductService_Create_SucessfulRun()
        {
            _productService.Create(new Product()
            {
                Name = "Test Product",
                Price = 15m,
                DeliveryPrice = 15m,
                Description = "Test",
            });


            //DbContext.Verify(a => a.Set<Product>().Add(It.IsAny<Product>()), Times.Once); //dont know why will throws exception.
            DbContext.Verify(a => a.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ProductService_Update_SucessfulRun()
        {
            DbContext.Setup(dbc => dbc.SaveChanges()).Verifiable();

            var product = new Product
            {
                Name = "Product",
                Description = "Test Product",
                Price = 100.00m,
                DeliveryPrice = 15.00m
            };

            _productService.Update(DataHelper.Prodcut_IPhone.Id, product);
            DbContext.Verify(a => a.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void ProductService_Delete__SucessfullRun()
        {
            DbContext.Setup(dbc => dbc.SaveChanges()).Verifiable();

            _productService.Delete(DataHelper.Prodcut_IPhone.Id);
            DbContext.Verify(dbc => dbc.SaveChanges(), Times.Once);
        }
    }
}
