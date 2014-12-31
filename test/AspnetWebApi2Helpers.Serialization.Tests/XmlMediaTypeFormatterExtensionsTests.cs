using System.IO;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using AspnetWebApi2Helpers.Serialization.Tests.Entities;
using Xunit;

namespace AspnetWebApi2Helpers.Serialization.Tests
{
    public class XmlMediaTypeFormatterExtensionsTests
    {
        [Fact]
        public void InputFormatters_PreserveReferences_should_configure_JsonInputFormatter()
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
            var clonedProduct = Clone(product, serializer);
            Assert.Equal(product.Category.Name, clonedProduct.Category.Name);
        }

        public static T Clone<T>(T obj, DataContractSerializer serializer)
        {
            T copy;
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                copy = (T)serializer.ReadObject(stream);
            }
            return copy;
        }
    }
}
