using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CodeProject.BusinessEntities;
using WebAPI_CodeProject.BusinessServices;

namespace WebAPI_CodeProject.Controllers
{
    public class ProductController : ApiController
    {

        private readonly IProductServices productServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public ProductController(IProductServices p)
        {
            this.productServices = p;
        }


       
        #endregion

        // GET api/product
        public HttpResponseMessage Get()
        {
            var products = productServices.GetAllProducts();
            if (products != null)
            {
                var productEntities = products as List<ProductEntity> ?? products.ToList();
                if (productEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, productEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Products not found");
            //return Request.CreateResponse(HttpStatusCode.OK, "Yes");
        }

        // GET api/product/5
        public HttpResponseMessage Get(int id)
        {
            var product = productServices.GetProductById(id);
            if (product != null)
                return Request.CreateResponse(HttpStatusCode.OK, product);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No product found for this id");
        }

        // POST api/product
        public int Post([FromBody] ProductEntity productEntity)
        {
            return productServices.CreateProduct(productEntity);
        }

        // PUT api/product/5
        public bool Put(int id, [FromBody]ProductEntity productEntity)
        {
            if (id > 0)
            {
                return productServices.UpdateProduct(id, productEntity);
            }
            return false;
        }

        // DELETE api/product/5
        public bool Delete(int id)
        {
            if (id > 0)
                return productServices.DeleteProduct(id);
            return false;
        }
    }
}
