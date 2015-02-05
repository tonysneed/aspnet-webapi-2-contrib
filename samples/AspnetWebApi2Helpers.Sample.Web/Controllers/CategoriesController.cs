using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using AspnetWebApi2Helpers.Sample.Data;
using AspnetWebApi2Helpers.Sample.Entities;

namespace AspnetWebApi2Helpers.Sample.Web.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET api/categories
        [ResponseType(typeof(IEnumerable<Category>))]
        public IHttpActionResult Get()
        {
            var categories = MockDatabase.Categories
                .OrderBy(e => e.CategoryName)
                .ToList();
            return Ok(categories);
        }
    }
}
