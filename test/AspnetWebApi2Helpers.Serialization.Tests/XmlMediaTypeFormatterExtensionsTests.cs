using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using AspnetWebApi2Helpers.Serialization.Tests.Common;
using AspnetWebApi2Helpers.Serialization.Tests.Common.Entities;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Tests
{
    public class XmlMediaTypeFormatterExtensionsTests
    {
        [Fact]
        public void XmlFormatter_XmlPreserveReferences_should_configure_XmlFormatter()
        {
            // Arrange
            var category = new Category {Name = "Beverages"};
            var product = new Product {Name = "Chai", Category = category};
            category.Products.Add(product);
            var formatter = new XmlMediaTypeFormatter();

            // Act
            formatter.XmlPreserveReferences(typeof(Category), typeof(Product));
            
            // Assert
            var serializer = formatter.InvokeGetSerializer(typeof (Product),
                null, null) as DataContractSerializer;
            var clonedProduct = product.Clone(serializer);
            Assert.Equal(product.Category.Name, clonedProduct.Category.Name);
        }
    }
}
