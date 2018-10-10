using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_CodeProject;
using WebAPI_CodeProject.BusinessServices;
using WebAPI_CodeProject.Generic_Repository;
using NUnit.Framework;
using Moq;

namespace NUnitTest
{
    class ProductServicesTest
    {
        private IProductServices _productService;
        private IUnitOfWork _unitOfWork;
        private List<Product> _products;
        private GenericRepository<Product> _productRepository;
        private WebApiDbEntities _dbEntities;


        [OneTimeSetUp]
        public void Setup()
        {
            _products = SetUpProducts();
        }



        private static List<Product> SetUpProducts()
        {
            var prodId = new int();
            var products = TestHelper.GetAllProducts();
            foreach (Product prod in products)
                prod.ProductId = ++prodId;
            return products;


        }

        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
            _products = null;
        }

        [SetUp]
        public void ReInitializeTest()
        {
            _dbEntities = new Mock<WebApiDbEntities>().Object;
            _productRepository = SetUpProductRepository();
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.SetupGet(s => s.ProductRepository).Returns(_productRepository);
            _unitOfWork = unitOfWork.Object;
            _productService = new ProductServices();
        }

        [TearDown]
        public void DisposeTest()
        {
            _productService = null;
            _unitOfWork = null;
            _productRepository = null;
            if (_dbEntities != null)
                _dbEntities.Dispose();
        }


        private GenericRepository<Product> SetUpProductRepository()
        {

            // Initialise repository
            var mockRepo = new Mock<GenericRepository<Product>>(MockBehavior.Default, _dbEntities);

            // Setup mocking behavior
            mockRepo.Setup(p => p.Get()).Returns(_products);

            mockRepo.Setup(p => p.GetById(It.IsAny<int>()))
            .Returns(new Func<int, Product>(
            id => _products.Find(p => p.ProductId.Equals(id))));

            mockRepo.Setup(p => p.Insert((It.IsAny<Product>())))
            .Callback(new Action<Product>(newProduct =>
            {
                dynamic maxProductID = _products.Last().ProductId;
                dynamic nextProductID = maxProductID + 1;
                newProduct.ProductId = nextProductID;
                _products.Add(newProduct);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Product>()))
            .Callback(new Action<Product>(prod =>
            {
                var oldProduct = _products.Find(a => a.ProductId == prod.ProductId);
                oldProduct = prod;
            }));

            mockRepo.Setup(p => p.Delete(It.IsAny<Product>()))
            .Callback(new Action<Product>(prod =>
            {
                var productToRemove =
    _products.Find(a => a.ProductId == prod.ProductId);

                if (productToRemove != null)
                    _products.Remove(productToRemove);
            }));

            // Return mock implementation object
            return mockRepo.Object;
        }

    }
}
