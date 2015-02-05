using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AspnetWebApi2Helpers.Sample.Data;
using AspnetWebApi2Helpers.Sample.Entities;

namespace AspnetWebApi2Helpers.Sample.Web.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        [ResponseType(typeof(IEnumerable<Product>))]
        public IHttpActionResult Get()
        {
            var products = MockDatabase.Products
                .OrderBy(p => p.ProductName)
                .ToList();
            return Ok(products);
        }
    }
}
