using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI_CodeProject.BusinessEntities;
using WebAPI_CodeProject.Generic_Repository;

namespace WebAPI_CodeProject.BusinessServices
{
    public class ProductServices:IProductServices
    {
        private IUnitOfWork unitOfWork;

        public ProductServices()
        {
            this.unitOfWork = new UnitOfWork();
        }


        public BusinessEntities.ProductEntity GetProductById(int productId)
        {
            var product = unitOfWork.ProductRepository.GetById(productId);
            if (product != null)
            {
                
                var productModel = Mapper.Map<Product, ProductEntity>(product);
                return productModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the products.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        {
            var products = unitOfWork.ProductRepository.Get().ToList();
            if (products.Any())
            {
                var config = new MapperConfiguration(cfg => {

                    cfg.CreateMap<Product, ProductEntity>();

                });
                IMapper mapper = config.CreateMapper();

                var productsModel = mapper.Map<List<Product>, List<ProductEntity>>(products);
                return productsModel;
            }
            return null;
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        {
          
                var product = new Product
                {
                    ProductName = productEntity.ProductName
                };
                unitOfWork.ProductRepository.Insert(product);
                unitOfWork.Save();
                return product.ProductId;

        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productEntity"></param>
        /// <returns></returns>
        public bool UpdateProduct(int productId, BusinessEntities.ProductEntity productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                
                    var product = unitOfWork.ProductRepository.GetById(productId);
                    if (product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        unitOfWork.ProductRepository.Update(product);
                        unitOfWork.Save();
                        
                        success = true;
                    }
                
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productId)
        {
            var success = false;
            if (productId > 0)
            {
                
                    var product = unitOfWork.ProductRepository.GetById(productId);
                    if (product != null)
                    {

                        unitOfWork.ProductRepository.Delete(product);
                        unitOfWork.Save();
                        
                        success = true;
                    }
                
            }
            return success;
        }
    }
}