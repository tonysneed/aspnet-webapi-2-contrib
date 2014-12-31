using System.Net.Http.Formatting;
using AspnetWebApi2Helpers.Serialization.Tests.Common.Entities;
using WebApiContrib.Formatting;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Protobuf.Tests
{
    public class MediaTypeFormatterCollectionExtensionsTests
    {
        [Fact]
        public void Formatters_ProtobufPreserveReferences_should_configure_ProtoBufFormatter()
        {
            // Arrange
            var category = new Category { Name = "Beverages" };
            var product = new Product { Name = "Chai", Category = category };
            category.Products.Add(product);
            var formatters = new MediaTypeFormatterCollection();

            // Act
            formatters.ProtobufPreserveReferences(typeof(Category).Assembly);

            // Assert
            var clonedProduct = product.Clone(ProtoBufFormatter.Model);
            Assert.Equal(product.Category.Name, clonedProduct.Category.Name);
        }
    }
}
