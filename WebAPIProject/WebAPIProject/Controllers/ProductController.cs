using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductService _server = new ProductService();
        public IEnumerable<Product> Get()
        {
            return _server.GetAll().Where(s=>s.Id==1);
        }
        [Route("api/product/{id}")]
        public Product Get(int id)
        {
            Product item = _server.Get(id);
            if (item == null)
            {
                 throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        [Route("api/product")]
        [HttpPost]
        public HttpResponseMessage Post(Product item)
        {
            item = _server.Add(item);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        //public HttpResponseMessage Get(string i,string k)
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
        //    response.Content = new StringContent("hello", Encoding.Unicode);
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };
        //    return response;
        //} 
    }
}
