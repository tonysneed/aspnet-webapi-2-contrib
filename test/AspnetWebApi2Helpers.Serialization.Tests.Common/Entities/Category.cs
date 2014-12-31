using System.Collections.Generic;

namespace AspnetWebApi2Helpers.Serialization.Tests.Common.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
