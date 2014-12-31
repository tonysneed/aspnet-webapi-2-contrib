using AspnetWebApi2Helpers.Serialization.Tests.Common.Entities;
using WebApiContrib.Formatting;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Protobuf.Tests
{
    public class ProtoBufFormatterExtensionsTests
    {
        [Fact]
        public void ProtoBufFormatter_ProtobufPreserveReferences_should_configure_ProtoBufFormatter()
        {
            // Arrange
            var category = new Category {Name = "Beverages"};
            var product = new Product {Name = "Chai", Category = category};
            category.Products.Add(product);
            var formatter = new ProtoBufFormatter();

            // Act
            formatter.ProtobufPreserveReferences(typeof(Category).Assembly);

            // Assert
            var clonedProduct = product.Clone(ProtoBufFormatter.Model);
            Assert.Equal(product.Category.Name, clonedProduct.Category.Name);
        }
    }
}
