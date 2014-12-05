using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductService _server = new ProductService();
        public IEnumerable<Product> GetAllProducts()
        {
            return _server.GetAll();
        }
        public IHttpActionResult GetProduct(int id)
        {
            Product item = _server.Get(id);
            if (item == null)
            {
                 throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(item);
        }
    }
}
